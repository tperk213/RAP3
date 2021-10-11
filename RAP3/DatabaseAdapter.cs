using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace RAP3
{
    abstract class DatabaseAdapter
    {
        private static string server = "alacritas.cis.utas.edu.au";
        private static string db = "kit206";
        private static string user = "kit206";
        private static string password = "kit206";
        public static MySqlConnection conn;

        public static Dictionary<char, EmploymentLevel> CharToEmploymentLevel = new Dictionary<char, EmploymentLevel>
            {
                { 'A', EmploymentLevel.Postdoc },
                { 'B', EmploymentLevel.Lecturer },
                { 'C', EmploymentLevel.SeniorLecturer },
                { 'D', EmploymentLevel.AssociateProfesor },
                { 'E', EmploymentLevel.Profesor },
            };

        public static void GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0}; Data Source={1}; User Id ={2}; Password={3}",
                    db, server, user, password);
                conn = new MySqlConnection(connectionString);
            }
        }
        

        public static MySqlDataReader RunCommand(String command)
        {
            GetConnection();
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldnt open connection to database {0}", e);
            }
            MySqlCommand cmd = new MySqlCommand(command, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }
        public static List<Researcher> LoadResearchers()
        {
            Console.WriteLine("Loading Researchers ....");
            string cmd = "select `id`, `given_name`, `family_name`, `email`, `title`, `level` from researcher;";
            MySqlDataReader rdr = RunCommand(cmd);

            var researcherList = new List<Researcher>();
            Researcher res;

            while (rdr.Read())
            {
                res = new Researcher();
                res.Id = rdr.GetInt32("id");
                res.FirstName = rdr.GetString("given_name");
                res.LastName = rdr.GetString("family_name");
                res.Email = rdr.GetString("email");
                res.Title = rdr.GetString("title");
                res.setFormalName();

                EmploymentLevel level;
                if (rdr.IsDBNull(rdr.GetOrdinal("level")))
                {
                    level = EmploymentLevel.Student;
                }
                else
                {
                    level = CharToEmploymentLevel[rdr.GetChar("level")];
                }
                res.Level = level;

                researcherList.Add(res);
            }

            conn.Close();
            return researcherList;
        }


        //Fetch full researcher details
        //
        public static Researcher FetchFullResearcherDetails(Researcher researcher) {

            string cmd = String.Format("select * from researcher where `id` = {0};", researcher.Id);
            MySqlDataReader rdr = RunCommand(cmd);

            if (rdr.Read())
            {
                researcher.FirstName = rdr.GetString("given_name");
                researcher.LastName = rdr.GetString("family_name");
                researcher.Title = rdr.GetString("title");
                researcher.Campus = rdr.GetString("campus");
                researcher.Email = rdr.GetString("email");
                researcher.CommencedCurrentPosition = rdr.GetString("current_start");
                researcher.CommencedInstitution = rdr.GetString("utas_start");
                researcher.PhotoUrl = rdr.GetString("photo");
                researcher.Unit = rdr.GetString("unit");
                researcher.getTenure();

                //Checks if the degree is null
                if (rdr.IsDBNull(rdr.GetOrdinal("degree")))
                {
                    researcher.Degree = "NA";
                }
                else
                {
                    researcher.Degree = rdr.GetString("degree");
                }
            }
            rdr.Close();

            researcher.Publications = DatabaseAdapter.LoadPublications(researcher);
            researcher.Positions = DatabaseAdapter.GetPositionHistory(researcher);

            return researcher;
        }

        public static ObservableCollection<Publication> LoadPublications(Researcher r)
        {
            ObservableCollection<Publication> publications = new ObservableCollection<Publication>();
            Publication p = new Publication();
            string cmd = String.Format("select `title`, `doi`, `year` from `publication` where `doi` in (select `doi` from `researcher_publication` where `researcher_id` = {0});", r.Id);
            MySqlDataReader rdr = RunCommand(cmd);
            while (rdr.Read())
            {
                p.Doi = rdr.GetString("doi");
                p.Title = rdr.GetString("title");
                p.PublicationYear = rdr.GetString("year");
                publications.Add(p);
            }
            conn.Close();

            //get publication count
            string query = String.Format("select count(*) as numofpub from `publication` where `doi` in (select `doi` from `researcher_publication` where `researcher_id` = {0}); ", r.Id);
            MySqlDataReader reader = RunCommand(query);

            while (reader.Read())
            {
                p.NumberOfPublication = reader.GetInt32("numofpub");
                publications.Add(p);
            }
            conn.Close();
          
            //Get number of publication within last 3 years
            string query1 = String.Format("select count(`year`) as threeyearpub from `publication` where(year(`year`) <= year(now()) - 3 and `doi` in (select `doi` from `researcher_publication` where `researcher_id` = {0}));", r.Id);
            MySqlDataReader reader1 = RunCommand(query1);

            while (reader1.Read())
            {
                int threeyearCount = reader1.GetInt32("threeyearpub");

                string avg = (threeyearCount/3).ToString("0.0");

                p.ThreeYearAvg = avg;

                publications.Add(p);
            }

            conn.Close();

            return publications;

        }

        //get position details
        public static ObservableCollection<Position> GetPositionHistory(Researcher r)
        {
            ObservableCollection<Position> position = new ObservableCollection<Position>();
            string cmd = String.Format("select `start`,`end`, `level` from position where `id` = {0};", r.Id);
            MySqlDataReader rdr = RunCommand(cmd);
            while (rdr.Read())
            {
                Position p = new Position();
                p.start = rdr.GetString("start");

                //Checks if end date exits
                if (rdr.IsDBNull(rdr.GetOrdinal("end")))
                {
                    p.end = "Current";
                }
                else
                {
                    p.end = rdr.GetString("end");
                }

                //get employment level and map with employment enum
                EmploymentLevel level;
                if (rdr.IsDBNull(rdr.GetOrdinal("level")))
                {
                    level = EmploymentLevel.Student;
                }
                else
                {
                    level = CharToEmploymentLevel[rdr.GetChar("level")];
                }

                p.Level = level;

                position.Add(p);
            }

            conn.Close();
            return position;

        }


    }
}
