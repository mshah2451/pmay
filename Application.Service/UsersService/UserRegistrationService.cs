
//using MailAndSmsService.Sms;
using Application.Service.Contract;
using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using PMAY.Dto.Users;
using PMAY.Domain.Users;
using Infra.Data.Contract;
using School.Application;
using Infra.Data.UserRepository;
using Infra.Data.Factory;

namespace Application.Service.UsersService
{
   public class UserRegistrationService: BaseService, IUserService
    {
       private readonly IUserRepository _userRepository;
        public UserRegistrationService()
        {
            _userRepository = FactoryDataLayer<UsersRepository>.Create();
        }
        //public void InsertUser(UserRegistrationDto user)
        //{
 
        //   var mapToUser= mapper.Map<UserRegistertion>(user);
        //    _userRepository.InsertUser(mapToUser);
        //}
        public Guid UserRegistration(UserRegistrationDto user)
        {
            

             byte[] passwordHash, passwordSalt;
                CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
            UserRegistertion userToCreate = new UserRegistertion();

            //var userToCreate = mapper.Map<UserRegistertion>(user);
            userToCreate.PasswordHash = passwordHash;
            userToCreate.PasswordSalt = passwordSalt;
            userToCreate.EmailId = user.Email;
            userToCreate.userId = user.UserId;
            userToCreate.PhoneNo = user.PhoneNo;
              
          return  _userRepository.InsertUser(userToCreate);
           
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserLoginResponseForDto Login(UserLoginDto user)
        {
            var userdata = _userRepository.GetUser(user.UserId);
           
            if (userdata == null)
                return null;

            if (!VerifyPasswordHash(user.Password, userdata.PasswordHash, userdata.PasswordSalt))
            {
                return null;
            }
            updateLastLogin(user.UserId);  //update lastloign details
            UserLoginResponseForDto userResponce = new UserLoginResponseForDto();
            userResponce.UserId = user.UserId;
           //var userResponse= mapper.Map<UserLoginResponseForDto>(userdata);
            return userResponce;
        }
        private void updateLastLogin(string id)
        {
           _userRepository.UpdateLoginlast(id);
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }
        public bool UserExists(string username)
        {
            var userdata =  _userRepository.GetUser(username);
            if (userdata!=null)
                return true;

            return false;
        }

        public bool PasswordRecoveryTokenGenerate(string userId)
        {
            string token = _userRepository.PasswordRecoveryToken(userId,"web");
           string issuer = ConfigurationManager.AppSettings["issuer"];
           string url = issuer + "/" + "restpassword?token="+token;
         //if (EmailSendService.SendMail("<h1>Password Recovery</h1>" + "<a href=" + url + "></a>", userId, "Password recovery"))
         //   {
         //       return true;
         //   }
            return false;
        }

        public string IsValidToken(string token,string userId)
        {
            return  _userRepository.IsValidToken(token,userId);
        }

        public bool UpdatePassword(UserPasswordResetForDto userPasswordReset)
        {

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userPasswordReset.Password, out passwordHash, out passwordSalt);
            
            return  _userRepository.UpdatePassword(userPasswordReset.UserId,passwordHash,passwordSalt); 
        }

        public UserDto GetUserDetail(string userId)
        {
            throw new NotImplementedException();
        }

        public  string PasswordRecoveryTokenGenerateApp(string userId)
        {
           var result=  _userRepository.GetUser(userId);
            var otp=  _userRepository.PasswordRecoveryToken(userId,"mobile");
            if(result!=null && otp != null)
            {
                if (!string.IsNullOrEmpty(result.PhoneNo))
                {
                   // await SendSms.SendOtp(result.PhoneNo," Password Reset OTP :"+ otp);
                    return "OTP has been sent on registered mobile number";
                }
                return "mobile number is not registered";

            }
            
            return "Admission Id does not exist";
        }

        public UserRegistertion AdmissionIdExists(string username)
        {
            var userdata =  _userRepository.GetStudentByAdmissionId(username);
            if (userdata != null)
                return userdata;

            return null;
        }
        //public string createToken(string username, string roleId)
        //{
        //    //Set issued at date
        //    DateTime issuedAt = DateTime.UtcNow;
        //    //set the time when it expires
        //    DateTime expires = DateTime.UtcNow.AddDays(7);
        //    string issuer = ConfigurationManager.AppSettings["issuer"];
        //    string audience = ConfigurationManager.AppSettings["audience"];
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    //create a identity and add claims to the user which we want to log in
        //    ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
        //    {
        //        new Claim(ClaimTypes.Name, username,ClaimTypes.Role,roleId),
        //         new Claim(ClaimTypes.Role,roleId),

        //    });

        //    const string sec = ConstantKeys.seckey;
        //    var now = DateTime.UtcNow;
        //    var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
        //    var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


        //    //create the jwt ,
        //    var token =
        //        (JwtSecurityToken)
        //            tokenHandler.CreateJwtSecurityToken(issuer: issuer, audience: audience, subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    return tokenString;
        //}
    }
}
