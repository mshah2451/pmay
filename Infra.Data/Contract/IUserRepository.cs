
using PMAY.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Contract
{
    public interface IUserRepository
    {
       Guid InsertUser(UserRegistertion user);
        UserRegistertion GetUser(string UserName);

        void ChangePassword(UserRegistertion user);

        void ChangeRole(UserRegistertion user);
        void UpdateLoginlast(string userId);
        string PasswordRecoveryToken(string userId,string callfrom);

        string IsValidToken(string token,string userId);
        UserRegistertion GetStudentByAdmissionId(string id);
        bool UpdatePassword(string Userid, byte[] PasswordHas, byte[] PasswordSlat);
    }
}
