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
    public partial class AddStudentToCourse_S_A_ : Form
    {
        public AddStudentToCourse_S_A_()
        {
            InitializeComponent();
        }
        int checkIfExist(string a, string b)//function to check if already registred to that course
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM CourceRegistration WHERE ([StudentID] = '" + a + "'and [CourceID] = '" + b + "')", con);
            if (check_User_Name.ExecuteScalar() != null)
            {
                con.Close();
                return 0;
            }
            con.Close();
            return 1;
        }
        int CheckEmptyInsert()//Function to check if textbox is empty.
        {
            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (textBox2 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (textBox3 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        private void Student_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            String query = "INSERT INTO CourceRegistration(StudentID,CourceID) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SqlCommand check_StudentID_CourseID = new SqlCommand("SELECT * FROM Students,Cources WHERE ([StudentID] = '" + textBox1.Text + "'and [CourceID] = '" + textBox2.Text + "') ", con);
            if (CheckEmptyInsert() == 1)//check that no space is NULL
            {
                SqlCommand check_Password = new SqlCommand("SELECT * FROM Login WHERE ([Password] = '" + textBox3.Text + "') ", con);
                if (check_Password.ExecuteScalar() != null)
                {
                    if (check_StudentID_CourseID.ExecuteScalar() != null)
                    {
                        if (checkIfExist(textBox1.Text, textBox2.Text) == 1)
                        {
                            SDA.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("Successfully registration");
                        }
                        else
                            MessageBox.Show("Error,Failed registration because student already exist.");
                    }
                }
                else
                    MessageBox.Show("Wrong Password");
            }
            else
                MessageBox.Show("Error,no input");
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            String query = "delete FROM CourceRegistration WHERE([StudentID] = '" + textBox1.Text + "'and [CourceID] = '" + textBox2.Text + "') ";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            if (CheckEmptyInsert() == 1)//check that no space is NULL
            {
                SqlCommand check_Password = new SqlCommand("SELECT * FROM Login WHERE ([Password] = '" + textBox3.Text + "') ", con);
                if (check_Password.ExecuteScalar() != null)
                {
                    if (checkIfExist(textBox1.Text, textBox2.Text) == 0)//last change here 
                    {
                        SDA.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Successfully deleted");
                    }
                    else
                        MessageBox.Show("Error,Failed to delete because student or course do not exist.");
                }
                else
                    MessageBox.Show("Wrong password");

            }
            else
                MessageBox.Show("Error,No input ");
            con.Close();
        }
    }
}
