using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golf2019
{
    public partial class Form1 : Form
    {
        // Data Source=CYGNUS271\SQLEXPRESS;Initial Catalog=Golf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

        private string connectionString =
           @"Data Source=CYGNUS271\SQLEXPRESS;Initial Catalog=Golf;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            LvGolf.Items.Clear();
            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                string QueryString = "SELECT * FROM Golf ORDER by ID";


                connection.Open();
                SqlCommand Command = new SqlCommand(QueryString, connection);

                SqlDataReader reader = Command.ExecuteReader();
                //  connection.Open();
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(new[] {
                        reader["ID"].ToString(),
                        reader["Title"].ToString(),
                        reader["Firstname"].ToString(),
                        reader["Surname"].ToString(),
                        reader["Gender"].ToString(),
                        reader["DOB"].ToString(),
                        reader["Street"].ToString(),
                        reader["Suburb"].ToString(),
                        reader["City"].ToString(),
                        reader["Available week days"].ToString(),
                        reader["Handicap"].ToString()
                    });
                    LvGolf.Items.Add(item);

                }
                reader.Close();
                connection.Close();
            }


        }
    }
}
