using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace LibraryManagementSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ViewAllIssuedBooks();
            StudentDepart();
            BooksByDepart();
            StudentIdInitializeOnUpdate();
            StudentDepartCombo6();
            StudentIdInitializeOnReturn();
            InitializeDepartmentForBooksRecord();
            IniializeDepartmentForAddBookRecord();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void ViewAllIssuedBooks()
        {
            SqlConnection conn = new SqlConnection("Data Source =.\SQLEXPRESS; Integrated security = SSPI; database = MICS");
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM IssuedBooks", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        public void StudentDepart()
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["dname"].ToString());
            }
            conn.Close();

        }
        public void StudentDepartCombo6()
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox6.Items.Add(dr["dname"].ToString());
            }
            conn.Close();
        }
        public void BooksByDepart()
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["dname"].ToString());
            }
            conn.Close();
        }
        public void DeparttoBookName()
        {
            if (comboBox2.Text == "Computer Science")
            {
                this.comboBox3.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ComputerScience", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();

            }
            else if (comboBox2.Text == "Electric Engineering")
            {
                this.comboBox3.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ElectricEngineering", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox2.Text == "Mass Communication")
            {
                this.comboBox3.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM MassCommunication", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox2.Text == "Mathematical Science")
            {
                this.comboBox3.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM MathematicalScience", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox2.Text == "Islamic Studies")
            {
                this.comboBox3.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM IslamicStudies", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox2.Text == "Commerce")
            {
                this.comboBox3.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Commerce", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox2.Text == "Business Administration")
            {
                this.comboBox3.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BusinessAdministration", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
        }
        public void AddIssuedBooks()
        {
            if (textBox1.Text == "" || comboBox1.Text == "" || comboBox3.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("All Fields are Required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO issuedBooks (s_name,s_dep,issuedBook,issueddate,returningDate,LateFine) VALUES (@s_name,@s_dep,@issuedBook,@issueddate,@returningDate,@LateFine)", conn);
                cmd.Parameters.AddWithValue("@s_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@s_dep", comboBox1.Text);
                cmd.Parameters.AddWithValue("@issuedBook", comboBox3.Text);
                cmd.Parameters.AddWithValue("@issuedDate", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@returningDate", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@LateFine", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Has Been Interted","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBox1.Clear();
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                textBox2.Clear();
                comboBox2.Items.Clear();
                conn.Close();
            }
        }
        public void StudentIdInitializeOnUpdate()
        {
            this.comboBox4.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM IssuedBooks", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox4.Items.Add(dr["s_id"].ToString());
            }
            conn.Close();
        }
        public void StudentIdToAll()
        {
            this.comboBox5.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM IssuedBooks Where s_id = '" + comboBox4.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox4.Text = dr["s_name"].ToString();
                textBox5.Text = dr["s_dep"].ToString();
                comboBox5.Items.Add(dr["issuedBook"].ToString());
                dateTimePicker3.Text = dr["issuedDate"].ToString();
                dateTimePicker4.Text = dr["returningDate"].ToString();
                textBox3.Text = dr["LateFine"].ToString();
            }
            conn.Close();

            if (comboBox4.Text != "")
            {
                comboBox6.Enabled = true;
            }
            else
            {
                comboBox6.Enabled = false;
            }
        }

        public void IssuedBookUpdate()
        {
            if(textBox4.Text == "" || textBox5.Text == "" || comboBox5.Text == "")
            {
                MessageBox.Show("All Fields Required \n\n *Note: Late fees is Optional", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE IssuedBooks SET s_name = @s_name, s_dep = @s_dep, issuedBook = @issuedBook, issuedDate = @issuedDate, returningDate = @returningDate, LateFine = @LateFine Where s_id = '" + comboBox4.Text + "'",conn);
            cmd.Parameters.AddWithValue("@s_name", textBox4.Text);
            cmd.Parameters.AddWithValue("@s_dep", textBox5.Text);
            cmd.Parameters.AddWithValue("@issuedBook", comboBox5.Text);
            cmd.Parameters.AddWithValue("@issuedDate", dateTimePicker4.Text);
            cmd.Parameters.AddWithValue("@returningDate", dateTimePicker3.Text);
            cmd.Parameters.AddWithValue("@LateFine", textBox3.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Has Been Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox4.Clear();
            textBox5.Clear();
            comboBox5.Items.Clear();
            textBox3.Clear();
            comboBox6.Items.Clear();
            comboBox6.Enabled = false;
            conn.Close();
            }
        }

        public void DepartToBooksForUpdateTab()
        {
            
            if (comboBox6.Text == "Computer Science")
            {
                this.comboBox5.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ComputerScience", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();

            }
            else if (comboBox6.Text == "Electric Engineering")
            {
                this.comboBox5.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ElectricEngineering", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox6.Text == "Mass Communication")
            {
                this.comboBox5.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM MassCommunication", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox6.Text == "Mathematical Science")
            {
                this.comboBox5.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM MathematicalScience", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox6.Text == "Islamic Studies")
            {
                this.comboBox5.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM IslamicStudies", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox6.Text == "Commerce")
            {
                this.comboBox5.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Commerce", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
            else if (comboBox6.Text == "Business Administration")
            {
                this.comboBox5.Items.Clear();
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM BusinessAdministration", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["BookName"].ToString());
                }
                conn.Close();
            }
        }

        private void StudentIdInitializeOnReturn()
        {
            this.comboBox7.Items.Clear();
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM IssuedBooks", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox7.Items.Add(dr["s_id"].ToString());
            }
            conn.Close();
        }

        public void StudentIdToAllOnReturn()
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM IssuedBooks Where s_id = '" + comboBox7.Text + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox6.Text = dr["s_name"].ToString();
                textBox7.Text = dr["s_dep"].ToString();
                textBox8.Text = dr["issuedBook"].ToString();
                dateTimePicker5.Text = dr["issuedDate"].ToString();
                dateTimePicker6.Text = dr["returningDate"].ToString();
                textBox9.Text = dr["LateFine"].ToString();
            }
        }

        public void ReturnOnIssuedBook()
        {
            if (comboBox7.Text == "")
            {
                MessageBox.Show("Please Select Student Id", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM IssuedBooks Where s_id = '" + comboBox7.Text + "'", conn);
                cmd.Parameters.AddWithValue("s_id", comboBox7.Text);
                cmd.Parameters.AddWithValue("s_name", textBox6.Text);
                cmd.Parameters.AddWithValue("s_dep", textBox7.Text);
                cmd.Parameters.AddWithValue("issuedBook", textBox8.Text);
                cmd.Parameters.AddWithValue("issuedDate", dateTimePicker5.Text);
                cmd.Parameters.AddWithValue("returningDate", dateTimePicker6.Text);
                cmd.Parameters.AddWithValue("LateFine", textBox9.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Has Been Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox7.Items.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                dateTimePicker5.Refresh();
                dateTimePicker6.Refresh();
                textBox9.Clear();
                conn.Close();
            }
        }

        private void InitializeDepartmentForBooksRecord()
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox8.Items.Add(dr["dname"].ToString());
            }
            conn.Close();
        }

        private void BooksRecordViewAll()
        {
            
            if (comboBox8.Text == "Computer Science")
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ComputerScience", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            else if (comboBox8.Text =="Electric Engineering")
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ElectricEngineering", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            else if (comboBox8.Text == "Mass Communication")
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MassCommunication", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            else if (comboBox8.Text == "Mathematical Science")
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MathematicalScience", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            else if (comboBox8.Text == "Islamic Studies")
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM IslamicStudies", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            else if (comboBox8.Text == "Business Administration")
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM BusinessAdministration", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }
            else if (comboBox8.Text == "Commerce")
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Commerce", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                conn.Close();
            }

        }

        private void IniializeDepartmentForAddBookRecord()
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox9.Items.Add(dr["dname"].ToString());
            }
            conn.Close();
        }

        private void AddBookRecord()
        {
            if ((comboBox9.Text == "Computer Science") && (textBox10.Text != ""))
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ComputerScience (BookName) VALUES (@BookName)", conn);
                cmd.Parameters.AddWithValue("BookName", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has Been Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else if ((comboBox9.Text == "Electric Engineering") && (textBox10.Text != ""))
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO ElectricEngineering (BookName) VALUES (@BookName)", conn);
                cmd.Parameters.AddWithValue("BookName", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has Been Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else if ((comboBox9.Text == "Commerce") && (textBox10.Text != ""))
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Commerce (BookName) VALUES (@BookName)", conn);
                cmd.Parameters.AddWithValue("BookName", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has Been Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else if ((comboBox9.Text == "Islamic Studies") && (textBox10.Text != ""))
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO IslamicStudies (BookName) VALUES (@BookName)", conn);
                cmd.Parameters.AddWithValue("BookName", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has Been Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else if ((comboBox9.Text == "Business Administration") && (textBox10.Text != ""))
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO BusinessAdministration (BookName) VALUES (@BookName)", conn);
                cmd.Parameters.AddWithValue("BookName", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has Been Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else if ((comboBox9.Text == "Mathematical Science") && (textBox10.Text != ""))
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO MathematicalScience (BookName) VALUES (@BookName)", conn);
                cmd.Parameters.AddWithValue("BookName", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has Been Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else if ((comboBox9.Text == "Mass Communication") && (textBox10.Text != ""))
            {
                SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO MassCommunication (BookName) VALUES (@BookName)", conn);
                cmd.Parameters.AddWithValue("BookName", textBox10.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has Been Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            else if (comboBox9.Text == "" && textBox10.Text == "")
            {
                MessageBox.Show("All fields are required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox9.Text == "")
            {
                MessageBox.Show("Department Name is required","Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Book Name is required", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BooksByDepartRefresh()
        {
            SqlConnection conn = new SqlConnection("Data Source = HAIER; Initial Catalog = LibraryManagementSystem; Integrated Security = true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Departments", conn);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox6.Items.Add(dr["dname"].ToString());
            }
            conn.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeparttoBookName();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddIssuedBooks();
            ViewAllIssuedBooks();
            StudentIdInitializeOnUpdate();
            StudentIdInitializeOnReturn();
            StudentDepart();
            BooksByDepart();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentIdToAll();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartToBooksForUpdateTab();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IssuedBookUpdate();
            ViewAllIssuedBooks();
            StudentIdInitializeOnUpdate();
            StudentIdInitializeOnReturn();
            BooksByDepartRefresh();
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            StudentIdToAllOnReturn();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReturnOnIssuedBook();
            ViewAllIssuedBooks();
            StudentIdInitializeOnReturn();
            StudentIdInitializeOnUpdate();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            BooksRecordViewAll();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddBookRecord();
        }
    }
}
