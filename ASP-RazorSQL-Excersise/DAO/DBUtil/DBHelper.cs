using System.Data.SqlClient;

namespace ASP_RazorSQL_Excersise.DAO.DBUtil
{
    public class DBHelper
    {
        private static SqlConnection? conn;

        
        private DBHelper() { }

        public static SqlConnection? GetConnection()
        {
            try
            {
                ConfigurationManager manager = new();
                manager.AddJsonFile("appsettings.json");
                string url = manager.GetConnectionString("DefaultConnection");
                conn = new SqlConnection(url);
                return conn;
            }catch(ArgumentException e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public static void CloseConnection()
        {
            conn!.Close();
        }
    }
}
