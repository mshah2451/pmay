
using Application.Service.Contract;
using Infra.Data.Contract;
using Infra.Data.Factory;
using Infra.Data.UserRepository;
using System.Threading.Tasks;

namespace Application.Service.UsersService
{
    public class UserPermissionService : IUserPermissionService
    {

        private readonly IUserPermissionRepository _userPermssionRepository;
        public UserPermissionService()
        {
            _userPermssionRepository = FactoryDataLayer<UserPermissionRepository>.Create();

        }
        public bool IsUserAllow(string UserId, string ActionName, string Controller)
        {
           return _userPermssionRepository.CheckPermession(UserId, ActionName, Controller);
        }
    }
}
