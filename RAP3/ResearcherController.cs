﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RAP3
{
    class ResearcherController
    {
        private List<Researcher> masterResearcherList;
        private ObservableCollection<Researcher> viewableResearcherList;
        DatabaseHandler db;


        public ResearcherController()
        {
            masterResearcherList = new List<Researcher>();
            viewableResearcherList = new ObservableCollection<Researcher>();
            db = new DatabaseHandler();
        }

        public void LoadResearchers()
        {
            Console.WriteLine("Loading Researchers ....");
            string cmd = "select `given_name`, `family_name`, `email` from researcher;";
            MySqlDataReader rdr = db.RunCommand(cmd);

            masterResearcherList = new List<Researcher>();
            Researcher res;

            while (rdr.Read())
            {
                string first_name = rdr.GetString("given_name");
                string last_name = rdr.GetString("family_name");
                string email = rdr.GetString("email");

                res = new Researcher();
                res.Name = first_name + last_name;
                res.Email = email;

                masterResearcherList.Add(res);
            }

            foreach (var curRes in masterResearcherList)
            {
                viewableResearcherList.Add(curRes);
            }
        }

        public ObservableCollection<Researcher> GetResearchers()
        {
            return viewableResearcherList;
        }

    }
}
