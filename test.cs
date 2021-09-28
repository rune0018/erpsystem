using System.Data.SqlClient;
using System.IO;

namespace ERPsystem
{
    class test
    {
        /// <summary>
        /// test the server with the string connection string
        /// </summary>
        /// <param name="connect"></param>
        /// <returns></returns>
        public static bool sqlConnection(string connect = "Server=localhost;Database=ERPSystem;Trusted_Connection=True;MultipleActiveResultSets=true")
        {

            SqlConnection connection = new SqlConnection(File.ReadAllText("../../../connectionString.txt"));
            
            try
            {
                connection.Open();
            }
            catch
            {
                return false;
            }
            connection.Close();
            return true;
        }
    }
}
