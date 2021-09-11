using Application.Service.Contract;
using Infra.Data.Contract;
using Infra.Data.Factory;
using Infra.Data.SurveyRepository;
using PMAY.Dto.SurveyForDto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.SurveyService
{
    public class SurveysService : ISurveyService
    {
        private readonly ISurveyReposirory surveyRepository;

        public SurveysService()
        {
            surveyRepository = FactoryDataLayer<SurveysRepository>.Create();
        }
        public List<BeneficiaryListforDto> GetBeneficiaryList()
        {
            DataTable dt = surveyRepository.GetBeneficiaryList();
            List<BeneficiaryListforDto> listforDtos = new List<BeneficiaryListforDto>();
            listforDtos = (from DataRow dr in dt.Rows
                   select new BeneficiaryListforDto()
                   {
                       id = Convert.ToInt32(dr["id"]),
                       Name = dr["Name"].ToString(),
                       BeneficiaryCode = dr["BeneficiaryCode"].ToString(),
                       AdharNo=dr["AadharId"].ToString(),
                       CreationDate=dr["CreationDate"].ToString(),
                       WardName =dr["Wardname"].ToString()
                       
                   }).ToList();
            return listforDtos;
        }

        public DataTable BeneficiaryDetail(int Id)
        {
            return surveyRepository.BeneficiaryDetail(Id);
        }

    }
}
