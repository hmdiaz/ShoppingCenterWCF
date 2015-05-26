using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCenterWCFServiceLibrary
{
    [ServiceContract]
    public interface IServiceUser
    {
        [OperationContract]
        CommonResult SignUp(string email, string password);

        [OperationContract]
        CommonResult ActiveAccount(string email, string confirmationCode);

        [OperationContract]
        CommonResult ChangePassword(int userId, string password);

        [OperationContract]
        CommonResult ChangeUserName(int userId, string userName);

        [OperationContract]
        CommonResult ChangeEmail(int userId, string email);

        [OperationContract]
        SignInResult SignIn(string email, string password);

        [OperationContract]
        CommonResult ReSendConfirmationEmail(int userId);
    }
}
