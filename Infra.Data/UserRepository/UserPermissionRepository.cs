
using Infra.Data.Contract;
using Infra.School.Data.AdoCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.UserRepository
{
    public class UserPermissionRepository : BaseConnectClass,IUserPermissionRepository
    {
        public bool CheckPermession(string userName, string ActionName, string ControllerName)
        {
            //using (var entity= new SchoolErp())
            //{


            //    var result = entity.Proc_CheckPermisssion(userName, ActionName, ControllerName);
            //    if (result != null)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }

        public void GetMenuList(string userName)
        {
            //using (var entity = new SchoolErp())
            //{


            //   // var result = entity.Proc_GetAssingNavList(userName).ToList();
               
            //};
        }
    }
}
