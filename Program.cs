using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ADO.NETSqlDataAdapter
{
    class Program
    {
        static void Main()
        {
            try
            {
                string constr = "data source=.; database=Employee; integrated security=SSPI";

                //using 
                using (SqlConnection connection = new SqlConnection(constr))
                {
                    //we create an instance of SqlDataAdapter class using the constructor which takes two parameters i.e. the SqlCommandText and the Connection object
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Employee", connection);

                //    Then we create an instance of DataSet and Datatable object.
                    //using data table to store tables
                    DataTable dt = new DataTable();

                    //call the Fill() method of the DataAdapter class
                    //This method handles the Opening and closing of the database connections automatically for us

                    sda.Fill(dt);
                    Console.WriteLine("data table");

                    // using DataRow to loop through each record and print the data on the console
                    foreach (DataRow r in dt.Rows)
                    {
                        Console.WriteLine(r["name"] + "" + r["email"]);


                    }
                    Console.WriteLine();

                }

            }
            catch(Exception eg)
            {
                Console.WriteLine("not found", eg);
            }
            Console.ReadLine();
            }

    }
   
}
