
using PMAY.Domain.Users;
using PMAY.Dto.Users;
using System;
using System.Threading.Tasks;

namespace Application.Service.Contract
{
   public interface IUserService
    {
        Guid UserRegistration(UserRegistrationDto user);
        bool UserExists(string username);
        UserRegistertion AdmissionIdExists(string username);
    UserLoginResponseForDto Login(UserLoginDto user);
       bool PasswordRecoveryTokenGenerate(string userId);
       UserDto GetUserDetail(string userId);
      string IsValidToken(string token,string userId);
       bool UpdatePassword(UserPasswordResetForDto userPasswordResetForDto);
       string PasswordRecoveryTokenGenerateApp(string userId);
        //string createToken(string username, string roleId);
    }
}
