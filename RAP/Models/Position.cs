using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAPFinal.Models
{
    class Position
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
        public string start { get; set; }
        public string end { get; set; }

        public string position { get; set; }

        private EmploymentLevel _level { get; set; }
        public EmploymentLevel Level
        {
            get
            {
                return _level;
            }
            set
            {
                position = EmploymentLevelToJobTitle[value];
                _level = value;
            }
        }

    }
}
