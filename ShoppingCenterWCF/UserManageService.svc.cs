using ShoppingCenterBOL;
using ShoppingCenterDAL;
using ShoppingCenterWCF;
using ShoppingCenterWCF.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCenterWCF
{
    public class UserManageService : IUserManageService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public CommonResult SignUp(string email, string password)
        {
            //Validate Email Address
            if (email.Count(e => e == '@') != 1)
            {
                return new CommonResult() { Success = false, ErrorMessage = "Email地址不正确" };
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
                return new CommonResult() { Success = false, ErrorMessage = ee.Message + Environment.NewLine + ee.InnerException.Message };
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
                IsConfirmed = false,
                UserType = "U",
                UserInfo = null
            };

            //Send Confirmation Email
            try
            {
                sendConfirmationEmail(email, confirmationCode);
            }
            catch (Exception ee)
            {
                return new CommonResult { Success = false, ErrorMessage = ee.Message };
            }

            //Insert To Database
            try
            {
                unitOfWork.UserRepository.Insert(newUser);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult { Success = false, ErrorMessage = ee.Message };
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

            //Create User Information
            //TODO: Need Test
            user.UserInfo = new UserInfo()
            {
                UserId = user.UserId,
                UserName = user.Email,
                SignInDateTime = DateTime.Now,
                User = user
            };

            //Update User To Database
            try
            {
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message };
            }

            //Success
            return new CommonResult() { Success = true, ErrorMessage = "" };
        }

        public CommonResult ChangePassword(int userId, string password)
        {
            var user = unitOfWork.UserRepository.GetById(userId);
            user.Password = CodeUtility.GetMd5(password);

            try
            {
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message };
            }

            return new CommonResult() { Success = true };
        }

        public CommonResult ChangeUserName(int userId, string userName)
        {
            var userInfo = unitOfWork.UserInfoRepository.GetById(userId);
            userInfo.UserName = userName;

            try
            {
                unitOfWork.UserInfoRepository.Update(userInfo);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult() { Success = false, ErrorMessage = ee.Message };
            }

            return new CommonResult() { Success = true };
        }

        public CommonResult ChangeEmail(int userId, string email)
        {
            //Validate Email Address
            if (email.Count(e => e == '@') != 1)
            {
                return new CommonResult() { Success = false, ErrorMessage = "Email地址不正确" };
            }

            //Get Confirmation Code
            Guid confirmationCode = CodeUtility.GetConfirmationCode();

            var user = unitOfWork.UserRepository.GetById(userId);

            user.Email = email;
            user.ConfirmationCode = confirmationCode;
            user.IsConfirmed = false;

            //Update Database
            try
            {
                unitOfWork.UserRepository.Update(user);
                unitOfWork.Save();
            }
            catch (Exception ee)
            {
                return new CommonResult { Success = false, ErrorMessage = ee.Message };
            }

            //Send Confirmation Email
            try
            {
                sendConfirmationEmail(email, confirmationCode);
            }
            catch (Exception ee)
            {
                return new CommonResult { Success = false, ErrorMessage = ee.Message };
            }

            //Success
            return new CommonResult() { Success = true, ErrorMessage = "" };
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
                return new SignInResult() { Success = false, ErrorMessage = "Wrong Password" };
            }

            //Check Password Match
            if (user.Password != CodeUtility.GetMd5(password))
            {
                return new SignInResult() { Success = false, ErrorMessage = "Wrong Password" };
            }

            //Success
            return new SignInResult() { Success = true, User = user };

        }

        public CommonResult ReSendConfirmationEmail(int userId)
        {
            var user = unitOfWork.UserRepository.GetById(userId);

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
                return new CommonResult { Success = false, ErrorMessage = ee.Message };
            }

            //Success
            return new CommonResult() { Success = true, ErrorMessage = "" };
        }

        private static void sendConfirmationEmail(string email, Guid confirmationCode)
        {
            try
            {
                MailMessage Mail = new MailMessage();

                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"], Int32.Parse(ConfigurationManager.AppSettings["Port"]));

                Mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailAddress"], ConfigurationManager.AppSettings["DisplayName"]);

                Mail.Subject = "Email Address Confirmation";
                Mail.Body = "Congratulations!" + Environment.NewLine + "The following code is your confirmation code :" + Environment.NewLine + confirmationCode.ToString();

                Mail.To.Add(email);

                SmtpServer.Credentials = new System.Net.NetworkCredential("MyShoppingCenter@163.com", "jedkxfwscpvrwivx");

                SmtpServer.Send(Mail);
            }
            catch
            {
                throw;
            }
        }
    }
}
