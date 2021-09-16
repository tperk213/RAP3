using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace RAP3
{
    class DatabaseHandler
    {
        private string server;
        private string database;
        private string uid;
        private string password;
        public MySqlConnection conn;

        public DatabaseHandler()
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

        }

        public MySqlDataReader RunCommand(String command)
        {
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
    }
}
