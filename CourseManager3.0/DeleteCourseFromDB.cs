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
    public partial class DeleteCourseFromDB : Form
    {
        public DeleteCourseFromDB()
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
        int checkIfExist(string a)//Function to check if cource exist.
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT * FROM Cources WHERE ([CourceID] = '" + a + "')", con);
            if (check_User_Name.ExecuteScalar() != null)
            {
                con.Close();
                return 0;
            }
            con.Close();
            return 1;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (CheckEmptyInsert() == 1)//check that no space is NULL
            {
                if (checkIfExist(textBox2.Text) == 0)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
                    con.Open();
                    String query = "delete FROM Grades WHERE([CourceID] = '" + textBox2.Text + "') ";
                    String query2 = "delete FROM CourceRegistration WHERE([CourceID] = '" + textBox2.Text + "') ";
                    String query3 = "delete FROM Cources WHERE([CourceID] = '" + textBox2.Text + "') ";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SqlDataAdapter SDA2 = new SqlDataAdapter(query2, con);
                    SqlDataAdapter SDA3 = new SqlDataAdapter(query3, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    SDA2.SelectCommand.ExecuteNonQuery();
                    SDA3.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully deleted");
                    con.Close();
                }
                else
                    MessageBox.Show("Wrong input,CourceID doesn't exist.");
            }
            else
                MessageBox.Show("No input,Please enter input correctly.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
