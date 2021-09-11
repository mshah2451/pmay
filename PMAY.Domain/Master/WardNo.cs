using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMAY.Domain.Master
{
    public class WardNo
    {
        public int id { get; set; }
        public string wardId { get; set; }
        public string Wardname { get; set; }
        public string Address { get; set; }
        public DateTime createOn { get; set; }
    }
}
