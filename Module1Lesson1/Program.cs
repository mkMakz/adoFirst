using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Odbc;

namespace Module1Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            //Console.WriteLine(connectionString);


            //SqlConnection con = new SqlConnection(connectionString);

            //try
            //{
            //    con.Open();
            //    Console.WriteLine("Connection opened");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //    Console.WriteLine("Connection closed");
            //}

    
              List<AccessTab> accessTabs = new List<AccessTab>();

            SqlConnection conn;
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select top 10 * from AccessTab";

                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    AccessTab accessTab = new AccessTab();
                    accessTab.intTabId = Int32.Parse(rdr[0].ToString());
                    accessTab.strTabName = rdr[1].ToString();
                    accessTab.strDescription = rdr[2].ToString();

                    accessTabs.Add(accessTab);
                }

            }//con.Close()

            foreach (var item in accessTabs)
            {
                Console.WriteLine(item);
            }
         
            #region
            //string connectionString1 = ConfigurationManager
            //   .ConnectionStrings["DefaultConnectionAccess"]
            //   .ConnectionString;

            //OleDbConnection con;
            //using (con = new OleDbConnection(connectionString1))
            //{
            //    con.Open();
            //    Console.WriteLine("Connection opened");
            //    Console.WriteLine(con.State);

            //    Console.WriteLine("Connection properties");
            //    Console.WriteLine($"\t connection string {con.ConnectionString}");

            //    Console.WriteLine($"\t data base {con.Database}");

            //    Console.WriteLine($"\t Server {con.DataSource}");

            //    Console.WriteLine($"\t server version {con.ServerVersion}");



            //}//con.Close()
            //Console.WriteLine(con.State);

            //Console.WriteLine();

            //string connectionString2 = ConfigurationManager
            //  .ConnectionStrings["DefaultConnection2"]
            //  .ConnectionString;

            //OleDbConnection conne;
            //using (conne = new OleDbConnection(connectionString2))
            //{
            //    conne.Open();
            //    Console.WriteLine("Connection opened");
            //    Console.WriteLine(conne.State);

            //    Console.WriteLine("Connection properties");
            //    Console.WriteLine($"\t connection string {conne.ConnectionString}");

            //    Console.WriteLine($"\t data base {conne.Database}");

            //    Console.WriteLine($"\t Server {conne.DataSource}");

            //    Console.WriteLine($"\t server version {conne.ServerVersion}");



            //}//con.Close()
            //Console.WriteLine(conne.State);

            //Console.WriteLine();

            //string connectionString3 = ConfigurationManager
            //  .ConnectionStrings["DefaultConnection3"]
            //  .ConnectionString;

            //OdbcConnection connect;
            //using (connect = new OdbcConnection(connectionString3))
            //{
            //    connect.Open();
            //    Console.WriteLine("Connection opened");
            //    Console.WriteLine(connect.State);

            //    Console.WriteLine("Connection properties");
            //    Console.WriteLine($"\t connection string {connect.ConnectionString}");

            //    Console.WriteLine($"\t data base {connect.Database}");

            //    Console.WriteLine($"\t Server {connect.DataSource}");

            //    Console.WriteLine($"\t server version {connect.ServerVersion}");



            //}//con.Close()
            //Console.WriteLine(connect.State);
            #endregion
        }
    }
     public class AccessTab
    {
        public int intTabId { get; set; }
        public string strTabName { get; set; }
        public string strDescription { get; set; }
        public override string ToString()
        {
            string str = string.Format("{0}. {1} ({2})", intTabId, strTabName, strDescription);
            return str;
        }
    }
}

