using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMAY.Dto.SurveyForDto
{
    public class BeneficiaryListforDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string BeneficiaryCode { get; set; }
        public string AdharNo { get; set; }
        public string CreationDate { get; set; }
        public string WardName { get; set; } //extra

    }
}
