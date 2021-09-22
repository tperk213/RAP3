using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP3
{
    class Researcher
    {
        public String Name { get; set; }
        public String Title { get; set; }
        public String Campus { get; set; }
        public String Email { get; set; }
        public String PhotoUrl { get; set; }
        public String CommencedInstitution { get; set; }
        public Double Tenure { get; set; }
        public int NumberOfPublications { get; set; }
        public int Average { get; set; }
        public int PerformanceLevel { get; set; }

        public Researcher()
        {

        }

        public override string ToString()
        {
            return Name;
        }

    }
}
