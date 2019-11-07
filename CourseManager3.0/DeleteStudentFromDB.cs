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
    public partial class DeleteStudentFromDB : Form
    {
        public DeleteStudentFromDB()
        {
            InitializeComponent();
        }
        int CheckEmptyInsert()//Function to check if textbox is empty.
        {
            if (textBox2 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                return 1;
            }
            return 0;
        }
        int checkIfExist(string a)//Function to check if  Staff  exist.
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Students WHERE ([StudentID] = '" + a + "')", con);
            if (check_User_Name.ExecuteScalar() != null)
            {
                con.Close();
                return 0;
            }
            con.Close();
            return 1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (CheckEmptyInsert() == 1)//check that no space is NULL
            {
                if (checkIfExist(textBox2.Text) == 0)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
                    con.Open();
                    String query1 = "delete FROM Login WHERE([StudentID] = '" + textBox2.Text + "') ";
                    String query2 = "delete FROM CourceRegistration WHERE([StudentID] = '" + textBox2.Text + "') ";
                    String query3 = "delete FROM Grades WHERE([StudentID] = '" + textBox2.Text + "') ";
                    String query4 = "delete FROM Students WHERE([StudentID] = '" + textBox2.Text + "') ";
                    SqlDataAdapter SDA1 = new SqlDataAdapter(query1, con);
                    SqlDataAdapter SDA2 = new SqlDataAdapter(query2, con);
                    SqlDataAdapter SDA3 = new SqlDataAdapter(query3, con);
                    SqlDataAdapter SDA4 = new SqlDataAdapter(query4, con);
                    SDA1.SelectCommand.ExecuteNonQuery();
                    SDA2.SelectCommand.ExecuteNonQuery();
                    SDA3.SelectCommand.ExecuteNonQuery();
                    SDA4.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully deleted");
                    con.Close();
                }
                else
                    MessageBox.Show("Wrong input,StudentID doesn't exist.");
            }
            else
                MessageBox.Show("No input,Please enter input correctly.");
        }
    }
}
