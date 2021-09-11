
using PMAY.Domain.Master;
using PMAY.Dto.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Contract
{
   public interface IMastersService
    {
        //  Task<BaseMastersList> GetAllMasters();

        List<WardNoforDto> WardNo();
    }
}
