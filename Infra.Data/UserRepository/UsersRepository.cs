
using Infra.Data.Contract;
using Infra.School.Data.AdoCore;
using PMAY.Domain.Users;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.UserRepository
{
    public class UsersRepository : BaseConnectClass,IUserRepository
    {
        public void ChangePassword(UserRegistertion user)
        {
            throw new NotImplementedException();
        }

        public void ChangeRole(UserRegistertion user)
        {
            throw new NotImplementedException();
        }

        public UserRegistertion GetStudentByAdmissionId(string id)
        {
            throw new NotImplementedException();
        }

        public UserRegistertion GetUser(string id)
        {
            DataTable dt = new DataTable();
            Open();
            objCommand.CommandText = "select * from [dbo].[Users] where userId='" + id + "' or EmailId='" + id + "'";
            objCommand.CommandType = CommandType.Text;
            SqlDataReader sqlDataReader = objCommand.ExecuteReader();
            //using (SqlDataReader sqlDataReader = objCommand.ExecuteReader())
            //{

                dt.Load(sqlDataReader);
                Close();
            //   // return dt;
            //}
            if (dt.Rows.Count >= 1)
            {
                UserRegistertion userRegistertion = new UserRegistertion();
                userRegistertion.PasswordSalt = (byte[])(dt.Rows[0]["PasswordSalt"]);
                userRegistertion.PasswordHash = (byte[])(dt.Rows[0]["PasswordHash"]);
                userRegistertion.userId = dt.Rows[0]["userId"].ToString();
                //userRegistertion.numberOfFiledLogin = (int?)dt.Rows[0]["numberOfFiledLogin"];
                userRegistertion.isActive = dt.Rows[0]["isActive"]!=null?(bool)dt.Rows[0]["isActive"]:false;
                userRegistertion.EmailId = dt.Rows[0]["EmailId"].ToString();
                userRegistertion.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                userRegistertion.UniqueId = (Guid)dt.Rows[0]["UniqueId"];
                return userRegistertion;
                //userRegistertion.roleId = entity.UserRoles.Where(x => x.UniqueId == user.UniqueId).FirstOrDefault().roleId
            }

            
            return null;
            }
           
               
        
        public Guid InsertUser(UserRegistertion user)
        {

            user.UniqueId = Guid.NewGuid();
            Open();
            objCommand.CommandText = "Proc_UserRegistration";
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@userId", user.userId);
            objCommand.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            objCommand.Parameters.AddWithValue("@PasswordSalt", user.PasswordSalt);
            objCommand.Parameters.AddWithValue("@EmailId", user.EmailId);
            objCommand.Parameters.AddWithValue("@PhoneNo", user.PhoneNo);
            objCommand.Parameters.AddWithValue("@UniqueId", user.UniqueId);
            SqlDataReader sqlDataReader = objCommand.ExecuteReader();
              DataTable dt = new DataTable();
                dt.Load(sqlDataReader);
                Close();

            return user.UniqueId;
        }

        public string IsValidToken(string token, string userId)
        {
            throw new NotImplementedException();
        }

        public string PasswordRecoveryToken(string userId, string callfrom)
        {
            throw new NotImplementedException();
        }

        public void UpdateLoginlast(string userId)
        {
            Open();
            objCommand.CommandText = "update [dbo].[Users] set lastLogin=getDate() where userId='" + userId + "'";
            objCommand.CommandType = CommandType.Text;
            SqlDataReader sqlDataReader = objCommand.ExecuteReader();
            
            Close();
        }

        public bool UpdatePassword(string Userid, byte[] PasswordHas, byte[] PasswordSlat)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// USer Detail
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public async Task<TeacherDetails> GetUserDetail(string userId)
        //{
        //    using (var context = new SchoolErp())
        //    {
        //        var results = await context.Where(x => x.Email == userId || x.Phone == userId).FirstOrDefaultAsync();
        //        if (results != null)
        //        {
        //            var result = new TeacherDetails()
        //            {
        //                FirstName = results.firstName,
        //                Lastname = results.Lastname,
        //                Address1 = results.Address1,
        //                Address2 = results.Address2,
        //                Dob = results.Dob,
        //                Doj = results.Doj,
        //                Email = results.Email,
        //                MidName = results.midName,
        //                EnrollmentCode = results.enrollmentCode,
        //                Phone = results.Phone

        //            };
        //            return result;
        //        }

        //        return null;
        //    }
        //}
    }
}
