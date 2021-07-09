using DocumentFormat.OpenXml.ExtendedProperties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADO
{
    class Program
    {




        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Store"].ConnectionString;
            using SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            var dataSet = new DataSet();
            var ItemsAdapter = new SqlDataAdapter();

            ItemsAdapter.SelectCommand = new SqlCommand("SELECT * FROM Cars",connection);
            ItemsAdapter.Fill(dataSet, "Cars");
            Console.WriteLine(dataSet.Tables["Cars"].Rows.Add(new object[] {3,"Toyota","Land Cruser",2018,false}));




            //ItemsAdapter.Update(dataSet,"Cars");
            string add = null;
            add = "insert into Cars (Id,Vendor,Model,Year,IsNew) values(5,'BMW','x6',2021,true)";
            
            ItemsAdapter.InsertCommand = new SqlCommand(add ,connection);

            ItemsAdapter.Fill(dataSet);





            //Console.WriteLine(dataSet.Tables.Count);
            
            for (int i = 0; i < dataSet.Tables["Cars"].Rows.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables["Cars"].Rows[i].ItemArray.Length; j++)
                { 
            Console.Write(dataSet.Tables["Cars"].Rows[i].ItemArray[j]);
                    Console.Write("  ");
                }
                Console.WriteLine();
            }


        }
    }
}
