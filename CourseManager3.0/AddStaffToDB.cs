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
    public partial class AddStaffToDB : Form
    {
        public AddStaffToDB()
        {
            InitializeComponent();
        }
        int checkIfExist(string a)//function to check if already registred to that course
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
        int CheckEmptyInsert()//function to check in all is NOT null.
        {
            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (textBox2 != null && !string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    if (textBox5 != null && !string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        if (textBox4 != null && !string.IsNullOrWhiteSpace(textBox4.Text))
                        {
                            if (textBox3 != null && !string.IsNullOrWhiteSpace(textBox3.Text))
                            {
                                if (textBox6 != null && !string.IsNullOrWhiteSpace(textBox6.Text))
                                {
                                    return 1;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }
        int GetStaffKey()//function that return staff key(TeacherID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            string stm = "SELECT COUNT(TeacherID) FROM Teachers WHERE TeacherID>=2000 and TeacherID<3000";
            SqlCommand cmd = new SqlCommand(stm, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar()) + 2000;
            con.Close();
            return count;
        }
        int GetStaffKeyID()//function to get staff KeyID from Login DB .
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            string stm = "SELECT COUNT(KeyID) FROM Login WHERE KeyID>=200 and KeyID<300";
            SqlCommand cmd = new SqlCommand(stm, con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar()) + 200;
            con.Close();
            return count;
        }
        private void Student_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            
            int StaffKey = GetStaffKey();
            
            if (CheckEmptyInsert() == 1)//check that no space is NULL
            {
                if (checkIfExist(textBox1.Text) == 1)//check if value already exist in CourceRegistration function.
                {
                    String query = "INSERT INTO Teachers(FirstName,LastName,Email,Phone,TeacherID) VALUES('" + textBox5.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox6.Text + "'," + StaffKey + ")";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Insert succsesfull to staff db");

                    int KeyID = GetStaffKeyID();
                    String query2 = "INSERT INTO Login(Username,Password,KeyID,TeacherID) VALUES('" + textBox1.Text + "','" + textBox2.Text + "'," + KeyID + "," + StaffKey + ")";
                    SqlDataAdapter SDA2 = new SqlDataAdapter(query2, con);
                    SDA2.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Insert succsesfull to login db");
                }
                else
                    MessageBox.Show("Error,Failed registration because Username already exist.");
            }
            else
                MessageBox.Show("No input,Please enter input correctly.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
