using Application.Service.Contract;
using Application.Service.FactoryApplicationService;
using Application.Service.UsersService;
using PMAY.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMAYProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController()
        {
            _userService = ApplicatonServiceFactory<UserRegistrationService>.Create();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UserLoginDto userLogin)
        {
            if (ModelState.IsValid)
            {
                var userdetails = _userService.Login(userLogin);

                if(userdetails==null)
                {
                    ModelState.AddModelError(string.Empty,"Login Details is Invalid");
                    return View("Index");
                    try
                    {
                       
                        // string token = _userService.createToken(user.UserId, userFromRepo.RoleId.ToString());
                        //return the token
                        HttpCookie userIdCookie = new HttpCookie("token");
                        userIdCookie.Value = userdetails.UserId;
                        Response.Cookies.Add(userIdCookie);
                        HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
          1,
          userdetails.UserId,
          DateTime.Now,
          DateTime.Now.AddMinutes(15),
          false, //pass here true, if you want to implement remember me functionality
          userdetails.UserId);

                        string encTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                        Response.Cookies.Add(faCookie);
                        Session.Add("userId", userdetails.UserId);
                    }
                    catch (Exception ex)
                    {
                        var exs = ex;
                    }
                }
            }
            return RedirectToAction("index", "Surveyor");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");

        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegistrationReq(UserRegistrationDto userRegistration)
        {
            if (ModelState.IsValid)
            {
                if (!_userService.UserExists(userRegistration.UserId))
                {
                    _userService.UserRegistration(userRegistration);//return Unique Id
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "UserId already exist");
                    return View("UserRegistration");
                }
            }
            return View("UserRegistration");
        }

        public JsonResult ForgotPassword(string Username)
        {
            if (!string.IsNullOrEmpty(Username))
            {
                if (_userService.UserExists(Username))
                {
                    var userFromRepo =  _userService.PasswordRecoveryTokenGenerateApp(Username);
                    if (!string.IsNullOrEmpty(userFromRepo))
                    {
                        return Json(new { d=userFromRepo,  JsonRequestBehavior.AllowGet });
                    }
                    //   var userFromRepo = await _userService.PasswordRecoveryTokenGenerate(Username);
                    //  return Ok<bool>(userFromRepo);
                }
            }
            //return the token
            
            return Json(new { d="user dose not exist", JsonRequestBehavior.AllowGet });
        }
    }
}