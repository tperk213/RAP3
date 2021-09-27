﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int Id { get; set; }
        private String _firstName { get; set; }
        public String FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                FullName = value + " " + LastName;
            }
        }
        private String _lastName;
        public String LastName 
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                FullName = FirstName + " " + value;
            }
        }

        public String FullName { get; set; }
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

        public String CommencedPosition { get; set; }
        public Double Tenure { get; set; }
        public int NumberOfPublications { get; set; }
        
        public String SchoolUnit { get; set; }

        public ObservableCollection<Publication> Publications { get; set; }

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
