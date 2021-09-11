using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMAY.Domain.Survey
{
   public class Beneficiary
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string BeneficiaryCode { get; set; }
        public string AdharNo { get; set; }
        public DateTime CreationDate { get; set; }
        public int WardNo { get; set; }
        public string FatherName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        
        public string Gender { get; set; }
    }
}
