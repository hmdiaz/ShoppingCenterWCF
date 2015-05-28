using ShoppingCenterBOL.Entities;
using ShoppingCenterDAL;
using ShoppingCenterWCFServiceLibrary.DTO;
using ShoppingCenterWCFServiceLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCenterWCFServiceLibrary
{
    public class ServiceUser : IServiceUser
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CommonResult SignUp(string email, string password)
        {
            //Validate Email Address
            if (email.Count(e => e == '@') != 1)
            {
                return new CommonResult() { Success = false, ErrorMessage = "Email格式不正确" };
            }

            //Check if email address is in database
            try
            {
                var userCount = unitOfWork.UserRepository.Get(e => e.Email == email).Count();
                if (userCount > 0)
                {
                    return new CommonResult() { Success = false, ErrorMessage = "Email地址已经存在" };
                }
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            //Get Confirmation Code
            Guid confirmationCode = CodeUtility.GetConfirmationCode();

            //Tranform Password to MD5
            string passwordMD5 = CodeUtility.GetMd5(password);

            //Generate New User Info
            var newUser = new User()
            {
                Email = email,
                Password = passwordMD5,
                ConfirmationCode = confirmationCode,
                UserName = email,
                ErrorTimes = 0,
                LastErrorDateTime = null,
                RegisteredDate = DateTime.Now,
                IsConfirmed = false,
                UserType = "U",
                UserInfo = new UserInfo()
            };

            //Send Confirmation Email
            try
            {
                sendConfirmationEmail(email, confirmationCode);
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            //Insert To Database
            try
            {
                unitOfWork.UserRepository.Insert(newUser);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            //Success
            return new CommonResult { Success = true };
        }

        public CommonResult ActiveAccount(string email, string confirmationCode)
        {
            User user;

            //Get User By Email Address 
            try
            {
                user = unitOfWork.UserRepository.Get(e => e.Email == email).Single();
            }
            catch
            {
                return new CommonResult() { Success = false, ErrorMessage = "Email Address Does Not Exist" };
            }

            //If The User Is Active
            if (user.IsConfirmed)
            {
                return new CommonResult() { Success = false, ErrorMessage = user.Email + "is active." };
            }

            //Check Confirmation Code Match
            if (user.ConfirmationCode.ToString() != confirmationCode)
            {
                return new CommonResult() { Success = false, ErrorMessage = "Validation failed." };
            }

            //Match
            //Active Account
            user.IsConfirmed = true;

            //Update User To Database
            try
            {
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            //Success
            return new CommonResult() { Success = true };
        }

        public CommonResult ChangePassword(int userId, string password)
        {
            User user;

            try
            {
                user = unitOfWork.UserRepository.GetById(userId);
                user.Password = CodeUtility.GetMd5(password);

                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            return new CommonResult() { Success = true };
        }

        public CommonResult ChangeUserName(int userId, string userName)
        {

            User user;

            try
            {
                user = unitOfWork.UserRepository.GetById(userId);
                user.UserName = userName;

                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            return new CommonResult() { Success = true };
        }

        public CommonResult ChangeEmail(int userId, string email)
        {
            User user;

            //Validate Email Address
            if (email.Count(e => e == '@') != 1)
            {
                return new CommonResult() { Success = false, ErrorMessage = "Email格式不正确" };
            }

            //Get User
            try
            {
                user = unitOfWork.UserRepository.GetById(userId);

                var confirmationCode = CodeUtility.GetConfirmationCode();

                user.Email = email;
                user.ConfirmationCode = confirmationCode;
                user.IsConfirmed = false;

                //Update Database
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();

                sendConfirmationEmail(email, confirmationCode);
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            //Success
            return new CommonResult() { Success = true };
        }

        public SignInResult SignIn(string email, string password)
        {
            User user;

            //Get User By Email Address 
            try
            {
                user = unitOfWork.UserRepository.Get(e => e.Email == email, null, "UserInfo").Single();
            }
            catch
            {
                return new SignInResult() { Success = false, ErrorMessage = "用户名不存在" };
            }

            //错误次数大于等于5次
            if (user.ErrorTimes >= 5)
            {
                var totalMidutes = (user.LastErrorDateTime.Value - DateTime.Now).TotalMinutes;

                //是否处于冻结期？(错误次数*15分钟)
                if (totalMidutes < user.ErrorTimes * 15.0)
                {
                    return new SignInResult() { Success = false, ErrorMessage = "错误次数太多，请" + Math.Ceiling(totalMidutes) + "分钟后再试" };
                }
            }

            //Check Password Match
            SignInResult result;

            if (user.Password != CodeUtility.GetMd5(password))
            {
                //密码错误

                //密码错误次数增加
                user.ErrorTimes = user.ErrorTimes + 1;

                //记录当前时间为最后一次错误时间
                user.LastErrorDateTime = DateTime.Now;

                //返回密码错误
                result = new SignInResult() { Success = false, ErrorMessage = "Wrong Password" };
            }
            else
            {
                //Success
                //清除密码错误记录
                user.ErrorTimes = 0;
                user.LastErrorDateTime = null;

                //返回DTOUser
                result = new SignInResult() { Success = true, User = new DTOUser(user) };
            }

            //保存用户信息
            try
            {
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new SignInResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            //返回结果
            return result;
        }

        public CommonResult ReSendConfirmationEmail(int userId)
        {
            User user;

            try
            {
                user = unitOfWork.UserRepository.GetById(userId);
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            //Is Active
            if (user.IsConfirmed)
            {
                return new CommonResult() { Success = false, ErrorMessage = user.Email + "is active." };
            }

            //Send Confirmation Email
            try
            {
                sendConfirmationEmail(user.Email, user.ConfirmationCode);
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = CodeUtility.GetErrorMessage(ee) };
            }

            //Success
            return new CommonResult() { Success = true };
        }

        private void sendConfirmationEmail(string email, Guid confirmationCode)
        {
            try
            {
                MailMessage Mail = new MailMessage();

                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"], Int32.Parse(ConfigurationManager.AppSettings["Port"]));

                Mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailAddress"], ConfigurationManager.AppSettings["DisplayName"]);

                Mail.Subject = "Email Address Confirmation";

                Mail.Body = "Congratulations!" + Environment.NewLine + "The following code is your confirmation code :" + Environment.NewLine + confirmationCode.ToString();

                Mail.To.Add(email);

                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["EmailAddress"], ConfigurationManager.AppSettings["Code"]);

                SmtpServer.Send(Mail);
            }
            catch
            {
                throw;
            }
        }
    }
}
