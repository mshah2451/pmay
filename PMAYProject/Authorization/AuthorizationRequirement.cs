


using Application.Service.Contract;
using Application.Service.FactoryApplicationService;
using Application.Service.UsersService;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace School.Api.Authorization
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        private  IUserPermissionService _userPermissionService;
        public CustomAuthorize(params string[] roles)
        {
            this.allowedroles = roles;
           
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //Create permission string based on the requested controller name and action name in the format 'controllername-action'
            string requiredPermission = String.Format("{0}-{1}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName);
            _userPermissionService = ApplicatonServiceFactory<UserPermissionService>.Create();
           // if (!base.IsAuthorized(filterContext)) return false;
            var actionName = filterContext.ActionDescriptor.ActionName;
            var ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var isAuthorized = true;
  
            // Do some work here to determine if the user has the
            // correct permissions to be authorized anywhere this
            // attribute is used. Assume the username is how
            // you'd link back to a custom user permission scheme.
            var username = filterContext.RequestContext.HttpContext.User.Identity.Name;
            isAuthorized = _userPermissionService.IsUserAllow(username, actionName, ControllerName);
            if (!isAuthorized)
            {
                //User doesn't have the required permission and is not a SysAdmin, return our custom “401 Unauthorized” access error
                //Since we are setting filterContext.Result to contain an ActionResult page, the controller's action will not be run.
                //The custom “401 Unauthorized” access error will be returned to the browser in response to the initial request.
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Index" }, { "controller", "Unauthorised" } });
            }

          
            //Create an instance of our custom user authorization object passing requesting user's 'Windows Username' into constructor
            //  RBACUser requestingUser = new RBACUser(filterContext.RequestContext.HttpContext.User.Identity.Name);
            //Check if the requesting user has the permission to run the controller's action
            
        }

      
     
    }
}
   

