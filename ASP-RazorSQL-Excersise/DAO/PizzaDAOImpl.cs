using ASP_RazorSQL_Excersise.Model;
using ASP_RazorSQL_Excersise.DAO.DBUtil;
using System.Data.SqlClient;
using System.Data;

namespace ASP_RazorSQL_Excersise.DAO
{
    public class PizzaDAOImpl : IPizzaDAO
    {
        public void Insert(Pizza pizza)
        {
            try
            {
                CreateTableIfNotExists();

                // Get Connection to SQLDB
                using SqlConnection? conn = DBHelper.GetConnection();

                // Open the connection
                conn!.Open();

                // Set up sql command string
                string sql = "INSERT INTO PIZZAS (COLD_CUT, CHEESE, TOPPING1, TOPPING2) VALUES (@ColdCut, @Cheese, @Topping1, @Topping2)";

                // Create new SqlCommand
                using SqlCommand command = new SqlCommand(sql, conn);

                // Add model parameters to sql command
                command.Parameters.AddWithValue("@ColdCut", pizza.ColdCut);
                command.Parameters.AddWithValue("@Cheese", pizza.Cheese);
                command.Parameters.AddWithValue("@Topping1", pizza.Topping1);
                command.Parameters.AddWithValue("@Topping2", pizza.Topping2);

                // ExecuteCommand
                command.ExecuteNonQuery();

            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(Pizza pizza)
        {
            try
            {
                // Get Connection to SQLDB
                using SqlConnection? conn = DBHelper.GetConnection();

                // Open the connection
                conn!.Open();

                // Create sql command string
                string sql = "UPDATE PIZZAS SET COLD_CUT=@ColdCut, CHEESE=@Cheese, TOPPING1=@Topping1, TOPPING2=@Topping2 WHERE ID=@Id";

                // Create new SqlCommand with string
                using SqlCommand command = new SqlCommand(sql, conn);

                // Add Model parameters to sqlcommand
                command.Parameters.AddWithValue("@ColdCut", pizza.ColdCut);
                command.Parameters.AddWithValue("@Cheese", pizza.Cheese);
                command.Parameters.AddWithValue("@Topping1", pizza.Topping1);
                command.Parameters.AddWithValue("@Topping2", pizza.Topping2);
                command.Parameters.AddWithValue("@Id", pizza.Id);

                // Execute command
                command.ExecuteNonQuery();
            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            
        }
        public void Delete(Pizza pizza)
        {
            try
            {
                //Get Connection to SQLDB
                using SqlConnection? conn = DBHelper.GetConnection();

                //Open the connection
                conn!.Open();

                //Create sql command string
                string sql = "DELETE FROM PIZZAS WHERE ID=@Id";

                //Create new sql command
                using SqlCommand command = new SqlCommand(sql, conn);

                //Add Model parameters
                command.Parameters.AddWithValue("@Id", pizza.Id);

                //Exequte command
                command.ExecuteNonQuery();

            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Pizza Get(long id)
        {
            Pizza? pizza = null;
            try
            {
                // Get Connection to SQLDB
                using SqlConnection? conn = DBHelper.GetConnection();

                // Open Connection
                conn!.Open();

                // Create String
                string sql = "SELECT * FROM PIZZAS WHERE ID=@Id";

                // Create new SqlCommand with string
                using SqlCommand command = new SqlCommand(sql, conn);

                // Add parameters
                command.Parameters.AddWithValue("@Id", id);

                // Use SqlDataReader to read from sql
                using SqlDataReader reader = command.ExecuteReader();

                // If reader can read initialize new pizza and set it's properties
                if (reader.Read())
                {
                    pizza = new();
                    pizza.Id = reader.GetInt32(0);
                    pizza.ColdCut = reader.GetString(1);
                    pizza.Cheese = reader.GetString(2);
                    pizza.Topping1 = reader.GetString(3);
                    pizza.Topping2 = reader.GetString(4);

                }

                return pizza!;
            }catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Pizza> GetAll()
        {
            List<Pizza> pizzas = new();
            try
            {
                // Get Connection to SQLDB
                using SqlConnection? conn = DBHelper.GetConnection();

                // Open the Connection
                conn!.Open();

                // Create string sql command
                string sql = "SELECT * FROM PIZZAS";

                // Create new SqlCommand with string and connection
                using SqlCommand command = new SqlCommand(sql, conn);

                // Use command to read from DB
                using SqlDataReader reader = command.ExecuteReader();

                // While you can read create new pizza and add it to list
                while (reader.Read())
                {
                    Pizza pizza = new()
                    {
                        Id = reader.GetInt32(0),
                        ColdCut = reader.GetString(1),
                        Cheese = reader.GetString(2),
                        Topping1 = reader.GetString(3),
                        Topping2 = reader.GetString(4)
                    };
                    pizzas.Add(pizza);
                }
                return pizzas;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            
        }

        private void CreateTableIfNotExists()
        {
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();
                conn!.Open();
                
                
                Console.WriteLine("Table Pizzas doesn't exist.");
                string sql = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PIZZAS' AND xtype='U') " +
                        "CREATE TABLE PIZZAS(" +
                        "ID INT IDENTITY," +
                        "COLD_CUT VARCHAR(100) NOT NULL," +
                        "CHEESE VARCHAR(100) NOT NULL," +
                        "TOPPING1 VARCHAR(100) NOT NULL," +
                        "TOPPING2 VARCHAR(100) NOT NULL" +
                        ")";

                using SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                    
                
            } catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        
    }
}
