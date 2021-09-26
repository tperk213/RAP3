using System;
using System.Collections.Generic;
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
       /* public DatabaseHandler()
        {
            server = "alacritas.cis.utas.edu.au";
            database = "kit206";
            uid = "kit206";
            password = "kit206";

            Console.WriteLine("Connecting to Database ....");
            string connectionString = String.Format("Database={0}; Data Source={1}; User Id ={2}; Password={3}; SSL Mode=0",
                database, server, uid, password);
            try
            {
                conn = new MySqlConnection(connectionString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught {0}", e);
            }
            Console.WriteLine("Database connection established ....");

        }*/

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
            string cmd = "select `given_name`, `family_name`, `email`, `title`, `level` from researcher;";
            MySqlDataReader rdr = RunCommand(cmd);

            var researcherList = new List<Researcher>();
            Researcher res;

            while (rdr.Read())
            {
                res = new Researcher();
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

            return researcherList;
        }
    }
}
