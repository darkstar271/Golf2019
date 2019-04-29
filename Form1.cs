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
// page 254 Golf
namespace Golf2019
{


    //https://www.w3schools.com/sql/sql_view.asp
    //https://www.w3schools.com/sql/sql_stored_procedures.asp

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
            using (SqlConnection connection = new SqlConnection
                (connectionString))
            //using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection
            {
                string QueryString = "SELECT * FROM Golf ORDER by ID";

                //read in the data with a data reader open the data connection
                connection.Open();
                SqlCommand Command = new SqlCommand(QueryString, connection);

                SqlDataReader reader = Command.ExecuteReader();
                //  connection.Open();
                while (reader.Read())
                {//add each row to the listbox 
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

        private void BtnCount_Click(object sender, EventArgs e)
        {


            //string connectionString = @"Data Source=CYGNUS271\SQLEXPRESS;Initial Catalog=Golf;Integrated Security=True;";
            // a simple Scalar query just returning one value.
            string queryString = "SELECT COUNT(ID) FROM Golf";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand Command = new SqlCommand(queryString, connection);
                connection.Open();
                btnCount.Text = Command.ExecuteScalar().ToString();
                connection.Close();
            }






        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // this puts the parameters into the code so that the data in the text boxes is added to the database
            string NewEntry = "INSERT INTO Golf (Title, Firstname, Surname, Gender, DOB, Street, Suburb, City, [Available week days], Handicap) VALUES ( @Title, @Firstname, @Surname, @Gender, @DOB, @Street, @Suburb, @City, @Available, @Handicap)";
            SqlConnection Con = new SqlConnection();
            string connectionString = @"Data Source=CYGNUS271\SQLEXPRESS;Initial Catalog=Golf;Integrated Security=True;";
            Con.ConnectionString = connectionString;
            using (SqlCommand newdata = new SqlCommand(NewEntry, Con))
            {
                newdata.Parameters.AddWithValue("@Title", txtTitle.Text).Value = "Mr";
                newdata.Parameters.AddWithValue("@Firstname", txtFirstname.Text).Value = "James";
                newdata.Parameters.AddWithValue("@Surname", txtSurname.Text).Value = "Bond";
                newdata.Parameters.AddWithValue("@Street", txtStreet.Text).Value = "123 Bond Street";
                newdata.Parameters.AddWithValue("@Suburb", txtSuburb.Text).Value = "Merivale";
                newdata.Parameters.AddWithValue("@City", txtCity.Text).Value = "Christchurch";
                newdata.Parameters.AddWithValue("@Gender", txtGender.Text).Value = "M";
                newdata.Parameters.AddWithValue("@DOB", txtDOB.Text).Value = "1/2/1935";
                newdata.Parameters.AddWithValue("@Handicap", txtHandicap.Text).Value = "2";
                newdata.Parameters.AddWithValue("@Available", txtAvailable.Text).Value = "";
                Con.Open(); //open a connection to the database
                            //its a NONQuery as it doesn't return any data its only going up to the server

                newdata.ExecuteNonQuery();
                //Run the Query
                //a happy message box

            }
            //Run the LoadDatabase method we made earler to see the new data.
            // loadDatabase();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
