
using PMAY.Dto.SurveyForDto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Contract
{
    public interface ISurveyService
    {
        List<BeneficiaryListforDto> GetBeneficiaryList();

        DataTable BeneficiaryDetail(int ID);
    }
}
