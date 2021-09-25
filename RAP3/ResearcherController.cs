using System;
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
            string cmd = "select `given_name`, `family_name`, `email`, `title`, `level` from researcher;";
            MySqlDataReader rdr = db.RunCommand(cmd);

            masterResearcherList = new List<Researcher>();
            Researcher res;

            while (rdr.Read())
            {
                string first_name = rdr.GetString("given_name");
                string last_name = rdr.GetString("family_name");
                string email = rdr.GetString("email");
                string title = rdr.GetString("title");
                Char level;
                if (rdr.IsDBNull(rdr.GetOrdinal("level")))
                {
                    level = 'n';
                }
                else
                {
                    level = rdr.GetChar("level");
                }
                res = new Researcher();
                res.FirstName = first_name;
                res.LastName = last_name;
                res.Email = email;
                res.Title = title;
                res.Level = Char.ToString(level);
                res.setFormalName();

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

        public void FilterByLevel()
        {
            // Filter the reasearchers by the level indicated in the dropdown box should be an event handler
        }

    }
}
