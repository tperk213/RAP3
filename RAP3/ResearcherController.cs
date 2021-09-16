using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace RAP3
{
    class ResearcherController
    {
        public List<Researcher> researchers;
        DatabaseHandler db;

        public ResearcherController()
        {
            researchers = new List<Researcher>();
            db = new DatabaseHandler();
        }

        public void LoadResearchers()
        {
            Console.WriteLine("Loading Researchers ....");
            string cmd = "select `given_name`, `family_name` from researcher;";
            MySqlDataReader rdr = db.RunCommand(cmd);

            researchers = new List<Researcher>();
            Researcher res;

            while (rdr.Read())
            {
                string first_name = rdr.GetString("given_name");
                string last_name = rdr.GetString("family_name");

                res = new Researcher();
                res.Name = first_name + last_name;

                researchers.Add(res);
            }
        }

        public void PrintResearchers()
        {
            foreach (var res in researchers)
            {
                res.print();
            }
        }

        public List<string> GetAllNames()
        {
            List<string> names = new List<string>();
            foreach( var res in researchers)
            {
                names.Add(res.Name);
            }
            return names;
        }

    }
}
