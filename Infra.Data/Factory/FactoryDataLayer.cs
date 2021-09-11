

using Infra.Data.Contract;
using Infra.Data.Master;
using Infra.Data.SurveyRepository;
using Infra.Data.UserRepository;
using System.Data;
using Unity;

namespace Infra.Data.Factory
{
    public static class FactoryDataLayer<AnyType>
    {
        private static IUnityContainer ObjectsofOurProjects = null;

        public static AnyType Create()
        {
            //Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();

                ObjectsofOurProjects.RegisterType<IUserRepository,
                    UsersRepository>();
                ObjectsofOurProjects.RegisterType<IUserPermissionRepository,
                   UserPermissionRepository>();
                ObjectsofOurProjects.RegisterType<IMasterRepository, MasterRepository>();
                ObjectsofOurProjects.RegisterType<ISurveyReposirory, SurveysRepository>();

            }
            //  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>();
        }
    }
 }
