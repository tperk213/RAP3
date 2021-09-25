using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP3
{
    enum JobLevel
    {
        A,
        B,
        C,
        D,
        E
    }



    class Researcher
    {
        public Dictionary<String, String> JobToJobTitle = new Dictionary<string, string>
            {
                { "A", "Postdoc" },
                { "B", "Lecturer" },
                { "C", "Senior Lecturer" },
                { "D", "Associate Profesor" },
                { "E", "Profesor" },
                { "n", "Student"}
            };
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Title { get; set; }

        public String FormalName { get; set;}

        private string _level; 
        public string Level  
        {
            get
            {
                return _level;
            } 
            set 
            {
                JobTitle = JobToJobTitle[value];
                _level = value;
            }
        }
        public String JobTitle { get; set; }
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
            return LastName + ", " + FirstName + " (" + Title + ")";
        }

        public void setFormalName()
        {
            FormalName = LastName + ", " + FirstName + " (" + Title + ")";
        }


    }
}
