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
namespace CourseManager3._0
{
    public partial class AddStudentToDB : Form
    {
       
        public AddStudentToDB()
        {
            InitializeComponent();
        }
        int checkIfExist(string a)//function to check if username already exist. 
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Login WHERE ([UserName] = '" + a + "')", con);
            if (check_User_Name.ExecuteScalar() != null)
            {
                con.Close();
                return 0;
            }
            con.Close();
            return 1;
        }
        int CheckEmptyInsert()//Function to check if textbox is empty..
        {
            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (textBox2 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (textBox5 != null && !string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        if (textBox4 != null && !string.IsNullOrWhiteSpace(textBox4.Text))
                        {
                            return 1;
                        }
                    }
                }
            }
            return 0;
        }
        int GetStudentKey()//Function that return StudentID from Students DB.
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            string stm = "SELECT COUNT(StudentID) FROM Students";
            SqlCommand cmd = new SqlCommand(stm, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar())+1003;
            con.Close();
            return count;
        }
        int GetStudentKeyID()//Function to get student KeyID from Login DB .
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            string stm = "SELECT COUNT(KeyID) FROM Login WHERE KeyID>=100 and KeyID<200";
            SqlCommand cmd = new SqlCommand(stm, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar()) + 100;
            con.Close();
            return count;
        }
        private void Student_Click(object sender, EventArgs e)
        {
          
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            int StudentKey = GetStudentKey();
            if (checkedListBox1.CheckedItems.Count > 1 || checkedListBox1.CheckedItems.Count==0)//check if listbox check is 1 .
            {
                MessageBox.Show("Error,You must choose only one department.");
                this.Close();
            }
            
            if (CheckEmptyInsert() == 1)//Call check empty Function.
            {
                if (checkIfExist(textBox1.Text) == 1)//check if username  already exist in  Login db.
                {
                    String query = "INSERT INTO Students(FirstName,LastName,Department,StudentID) VALUES('" + textBox5.Text + "','" + textBox4.Text + "','" + checkedListBox1.Text + "'," + StudentKey + ")";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Insert succsesfull to students db");

                    int KeyID = GetStudentKeyID();
                    String query2 = "INSERT INTO Login(Username,Password,KeyID,StudentID) VALUES('" + textBox5.Text + "','" + textBox4.Text + "'," + KeyID + "," + StudentKey + ")";
                    SqlDataAdapter SDA2 = new SqlDataAdapter(query2, con);
                    SDA2.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Insert succsesfull #2");
                }
                else
                    MessageBox.Show("Error,Failed registration because Username already exist.");
            }
            else
                MessageBox.Show("No input,Please enter input correctly.");


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddStudentToDB_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}