using Application.Service.Contract;
using Infra.Data.Contract;
using Infra.Data.Factory;
using Infra.Data.Master;
using PMAY.Domain.Master;
using PMAY.Dto.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Masters
{
    public class MastersService : IMastersService
    {
        private readonly IMasterRepository masterRepository;

        public MastersService()
        {
            masterRepository = FactoryDataLayer<MasterRepository>.Create();
        }
        public List<WardNoforDto> WardNo()
        {
            DataTable dt = masterRepository.WardMaster();
            List<WardNoforDto> lst = new List<WardNoforDto>();
            lst = (from DataRow dr in dt.Rows
                   select new WardNoforDto()
                   {
                       id = Convert.ToInt32(dr["id"]),
                       wardId=dr["wardId"].ToString(),
                       Wardname=dr["Wardname"].ToString()
             }).ToList();
            return lst;
        }
    }
}
