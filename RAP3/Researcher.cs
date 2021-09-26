using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP3
{




    class Researcher
    {
        private Dictionary<EmploymentLevel, String> EmploymentLevelToJobTitle = new Dictionary<EmploymentLevel, String>
            {
                { EmploymentLevel.Postdoc, "Postdoc"},
                { EmploymentLevel.Lecturer, "Lecturer"},
                { EmploymentLevel.SeniorLecturer, "Senior Lecturer" },
                { EmploymentLevel.AssociateProfesor, "Associate Profesor"},
                { EmploymentLevel.Profesor, "Profesor" },
                { EmploymentLevel.Student, "Student" }
            };
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Title { get; set; }

        public String FormalName { get; set;}

        private EmploymentLevel _level { get; set; }  
        public EmploymentLevel Level  
        {
            get
            {
                return _level;
            } 
            set 
            {
                JobTitle = EmploymentLevelToJobTitle[value];
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
