using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolleeFileSort
{
    public class Enrollee
    {
        public string userId { get; set; }       
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int versionNumber { get; set; }
        public string insuranceCompany { get; set; }
    }
}
