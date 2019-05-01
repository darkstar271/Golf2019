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
        DataTable GolfTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        public int AddTwoNumbers(int Num1, int Num2)
        {
            int answer = Num1 + Num2;
            return answer;

        }






        public void datatablecolumns()
        {
            // clear the old data
            GolfTable.Clear();
            //add in the column titles to the datatable
            try
            {
                GolfTable.Columns.Add("ID");
                GolfTable.Columns.Add("Title");
                GolfTable.Columns.Add("Firstname");
                GolfTable.Columns.Add("Surname");
                GolfTable.Columns.Add("Gender");
                GolfTable.Columns.Add("DOB");
                GolfTable.Columns.Add("Street");
                GolfTable.Columns.Add("Suburb");
                GolfTable.Columns.Add("City");
                GolfTable.Columns.Add("Available week days");
                GolfTable.Columns.Add("Handicap");

            }
            catch
            {

            }
        }
        public void loadDatabase()
        {
            //load datatable columns
            datatablecolumns();
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


                    //add in each row to the datatable
                    GolfTable.Rows.Add(
                        reader["ID"],
                        reader["Title"],
                        reader["Firstname"],
                        reader["Surname"],
                        reader["Gender"],
                        reader["DOB"],
                        reader["Street"],
                        reader["Suburb"],
                        reader["City"],
                        reader["Available week days"],
                        reader["Handicap"]);



                }
                reader.Close();
                DGVgolf.DataSource = GolfTable;
                connection.Close();
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            //LvGolf.Items.Clear();
            loadDatabase();
            //using (SqlConnection connection = new SqlConnection
            //    (connectionString))
            ////using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection
            //{
            //    string QueryString = "SELECT * FROM Golf ORDER by ID";

            //    //read in the data with a data reader open the data connection
            //    connection.Open();
            //    SqlCommand Command = new SqlCommand(QueryString, connection);

            //    SqlDataReader reader = Command.ExecuteReader();
            //    //  connection.Open();
            //    while (reader.Read())
            //    {//add each row to the listbox 
            //        ListViewItem item = new ListViewItem(new[] {
            //            reader["ID"].ToString(),
            //            reader["Title"].ToString(),
            //            reader["Firstname"].ToString(),
            //            reader["Surname"].ToString(),
            //            reader["Gender"].ToString(),
            //            reader["DOB"].ToString(),
            //            reader["Street"].ToString(),
            //            reader["Suburb"].ToString(),
            //            reader["City"].ToString(),
            //            reader["Available week days"].ToString(),
            //            reader["Handicap"].ToString()
            //        });
            //        LvGolf.Items.Add(item);

            //    }
            //    reader.Close();
            //    connection.Close();
            //}


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
            loadDatabase();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //this updates existing data in the database where the ID of the data equals the ID in the text box

            string updatestatement = "UPDATE Golf set Title=@Title, Firstname=@Firstname, Surname=@Surname, Gender=@Gender, DOB=@DOB, Street=@Street, Suburb=@suburb, City=@City, [Available week days]=@Available, Handicap=@Handicap where ID = @ID ";
            SqlConnection Con = new SqlConnection();
            string connectionString = @"Data Source=CYGNUS271\SQLEXPRESS;Initial Catalog=Golf;Integrated Security=True;";
            Con.ConnectionString = connectionString;

            SqlCommand update = new SqlCommand(updatestatement, Con);

            update.Parameters.AddWithValue("@ID", txtID.Text);
            update.Parameters.AddWithValue("@Title", txtTitle.Text);
            update.Parameters.AddWithValue("@Firstname", txtFirstname.Text);
            update.Parameters.AddWithValue("@Surname", txtSurname.Text);
            update.Parameters.AddWithValue("@Street", txtStreet.Text);
            update.Parameters.AddWithValue("@Suburb", txtSuburb.Text);
            update.Parameters.AddWithValue("@City", txtCity.Text);
            update.Parameters.AddWithValue("@Gender", txtGender.Text);
            update.Parameters.AddWithValue("@DOB", txtDOB.Text);
            update.Parameters.AddWithValue("@Handicap", txtHandicap.Text);
            update.Parameters.AddWithValue("@Available", txtAvailable.Text);

            Con.Open();
            //its NONQuery as data is only going up
            update.ExecuteNonQuery();
            Con.Close();
            loadDatabase();


        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection();
            string connectionString = @"Data Source=CYGNUS271\SQLEXPRESS;Initial Catalog=Golf;Integrated Security=True;";
            Con.ConnectionString = connectionString;

            string DeleteCommand = "Delete Golf where ID =@ID";

            SqlCommand DeleteData = new SqlCommand(DeleteCommand, Con);
            DeleteData.Parameters.AddWithValue("@ID", txtID.Text);

            Con.Open();
            DeleteData.ExecuteNonQuery();
            Con.Close();
            loadDatabase();

        }

        private void DGVgolf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //show the data in the DGV in the text boxes
                string newvalue = DGVgolf.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //show the output on the header
                this.Text = "Row : " + e.RowIndex.ToString() + newvalue;
                //pass data to the text boxes
                txtID.Text = DGVgolf.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTitle.Text = DGVgolf.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtFirstname.Text = DGVgolf.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSurname.Text = DGVgolf.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtGender.Text = DGVgolf.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDOB.Text = DGVgolf.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtStreet.Text = DGVgolf.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSuburb.Text = DGVgolf.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtCity.Text = DGVgolf.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtAvailable.Text = DGVgolf.Rows[e.RowIndex].Cells[9].Value.ToString();
                txtHandicap.Text = DGVgolf.Rows[e.RowIndex].Cells[10].Value.ToString();


            }
            catch
            {

            }
        }
    }
}
