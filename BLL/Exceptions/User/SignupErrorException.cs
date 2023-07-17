using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions.User
{
    public class SignupErrorException : Exception
    {
        public SignupErrorException(string? message) : base(ModifyMessage(message))
        { }

        private static string ModifyMessage(string message)
        {
            string respCode = "";
            switch (message)
            {
                case "DuplicateUserName":
                    respCode = "USERNAME_TAKEN";
                    break;
                case "DuplicateEmail":
                    respCode = "EMAIL_ADDRESS_TAKEN";
                    break;
                case "PasswordTooShort":
                    respCode = "PASSWORD_TOO_SHORT";
                    break;
                case "InvalidEmail":
                    respCode = "INVALID_EMAIL_ADDRESS";
                    break;
                case "InvalidUserName":
                    respCode = "INVALID_USERNAME";
                    break;
                default:
                    respCode = message;
                    break;

            }
            return respCode;
        }
    }
}
