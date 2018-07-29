using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;

namespace AdminDashboard
{
    public class Datos
    {
        public Datos()
        {

            




        }

        public DataTable getdata()
        {

            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=Pranali123; Database=tikam; ";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();

                // load checkbox data
                string command = "SELECT slot,bid FROM displaydata ORDER BY slot ASC";
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command,connection);
                adapter.Fill(ds,"result");
                dt = ds.Tables[0];
                connection.Close();
                adapter.Dispose();
                connstring = null;
                return dt;
            }
            catch (Exception msg) { throw msg; }
        }
    }
}