using System;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Sql_connect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");
            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                QueryEmployee(conn);
            }
            catch (Exception e) 
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            Console.Read();
        }

        private static void QueryEmployee(MySqlConnection conn)
        {
            string order, store, book, ordered_copies;
            string sql = "Select order_number, customer_store_id, book_id, ordered_copies from ordering_stores";

            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sql;

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        order = reader["order_number"].ToString();
                        store = reader["customer_store_id"].ToString();
                        book = reader["book_id"].ToString();
                        ordered_copies = reader["ordered_copies"].ToString();
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Order:" + order + " Store:" + store + " Book:" + book + " Ordered copies:" + ordered_copies);
                        Console.WriteLine("-------------------------------------------");
                    }
                }
            }
        }
    }
}
