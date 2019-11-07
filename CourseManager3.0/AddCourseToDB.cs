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
    public partial class AddCourseToDB : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
        int CheckEmptyInsert()//Function to check if textbox is empty..
        {
            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (textBox2 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (textBox5 != null && !string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        if (textBox6 != null && !string.IsNullOrWhiteSpace(textBox6.Text))
                        {
                            if (textBox4 != null && !string.IsNullOrWhiteSpace(textBox4.Text))
                            {
                                return 1;
                            }
                        }
                    }
                }
            }
            return 0;
        }
        int GetCourseKey()//Function that return CourceID from Cources DB.
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            string stm = "SELECT COUNT(CourceID) FROM Cources";
            SqlCommand cmd = new SqlCommand(stm, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar()) + 4002;
            con.Close();
            return count;
        }
        int checkIfExist(string a)//function to check if already registred to that course
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Teachers WHERE ([TeacherID] = '" + a + "')", con);
            if (check_User_Name.ExecuteScalar() != null)
            {
                con.Close();
                return 0;
            }
            con.Close();
            return 1;
        }
        public AddCourseToDB()
        {
            InitializeComponent();
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Student_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            int CourseKey = GetCourseKey();
            if (checkedListBox1.CheckedItems.Count > 1 || checkedListBox1.CheckedItems.Count == 0)//check if listbox check is 1 .
            {
                MessageBox.Show("Error,You must choose only one department.");
                this.Close();
            }
            else//if first check is ok
            {
                if (CheckEmptyInsert() == 1)//Call check empty Function.
                {
                    if (checkIfExist(textBox4.Text) == 0)//check if TeacherID exist in Teachers db.
                    {
                        String query = "INSERT INTO Cources(CourseName,Nakaz,Department,Days,Time,TeacherID,CourceID) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + checkedListBox1.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "'," + CourseKey + ")";
                        SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                        SDA.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Insert succsesfull to course db");
                        con.Close();
                    }
                    else
                        MessageBox.Show("Error,Failed registration because no such TeacherID ");

                }
                else
                    MessageBox.Show("No input,Please enter input correctly.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
