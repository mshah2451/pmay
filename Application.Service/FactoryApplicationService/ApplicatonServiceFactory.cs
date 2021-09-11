
using Application.Service.Contract;
using Application.Service.Masters;
using Application.Service.SurveyService;
using Application.Service.UsersService;
using Unity;

namespace Application.Service.FactoryApplicationService
{
   public static class  ApplicatonServiceFactory<AnyType>
    {
        private static IUnityContainer ObjectsofOurProjects = null;
     
        public static AnyType Create()
        {
            //Lazy loading. Eager loading
          
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();

                ObjectsofOurProjects.RegisterType<IUserService,
                    UserRegistrationService>();
                ObjectsofOurProjects.RegisterType<IUserPermissionService,
                  UserPermissionService>();
                ObjectsofOurProjects.RegisterType<IMastersService, MastersService>();
                ObjectsofOurProjects.RegisterType<ISurveyService, SurveysService>();
            }
            //  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>();
        }
    }
}
