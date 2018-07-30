using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Services;



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

                    // load grid data


                    DataSet ds = new DataSet();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM displaydata ORDER BY slot ASC", connection);
                    da.Fill(ds); 
                    Grid1.DataSource = ds;
                    Grid1.DataBind();


                    // load checkbox data
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
                    connstring = null; 

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
                connstring = null;
            }
            catch (Exception msg) { throw msg; }
        }

        [WebMethod]
        public static ColumnChart getdata() {

            DataTable dt = new Datos().getdata();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    List<SeriesItem> series = new List<SeriesItem>();
                    for (int i = 1; i <= 30; i++)
                    {
                      series.Add(new SeriesItem() { name = "Slot " + i.ToString(), y = 50 });
                        
                    }


                    foreach (DataRow dr in dt.Rows)
                    {

                        
                        foreach (var item in series.FindAll(a => a.name == ("Slot " + dr[0].ToString())))
                        {
                            item.y = Int32.Parse(dr[1].ToString());
                        }

                        
                    }      
                            
                       
                   
                    return new ColumnChart(series);

                }
                else { return null; }

            }
            else { return null;  }

        }    

    }
}