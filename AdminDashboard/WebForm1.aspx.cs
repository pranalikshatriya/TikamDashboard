using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminDashboard
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                try
                {
                    string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=Pranali123; Database=tikam; ";
                    NpgsqlConnection connection = new NpgsqlConnection(connstring);
                    connection.Open();

                    NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM biddingstatus", connection);
                    NpgsqlDataReader reader = command.ExecuteReader();
                    for (int i = 0; reader.Read(); i++)
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = "Slot "+reader[0].ToString();
                        newItem.Selected = (bool)reader[1];
                        CheckBoxList1.Items.Add(newItem);


                    }

                    connection.Close();


                }
                catch (Exception msg) { throw msg; }

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string connstring = "Server=localhost; Port=5432; User Id=postgres; Password=Pranali123; Database=tikam; ";
                NpgsqlConnection connection = new NpgsqlConnection(connstring);
                connection.Open();
                foreach (ListItem lists in CheckBoxList1.Items)
                {
                    
                    NpgsqlCommand command = new NpgsqlCommand("Update biddingstatus SET biddingclosed=" + lists.Selected+" WHERE slot ="+ Int32.Parse(lists.Text.Substring(5)),connection);
                    command.ExecuteNonQuery();
                    
                }

                connection.Close();

            }
            catch (Exception msg) { throw msg; }
        }
    }
}