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
    public partial class MainLogin : Form
    {
        public MainLogin()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            SqlCommand com = new SqlCommand("SELECT * FROM Login WHERE Username=@user and Password=@pw ", con);
            con.Open();
            com.Parameters.AddWithValue("@user", textBox1.Text);
            com.Parameters.AddWithValue("@pw", textBox2.Text);
            
            SqlDataReader DR = com.ExecuteReader();
            if (DR.HasRows == true)
            {
                MessageBox.Show("Login succeeded.");
                while (DR.Read())
                {
                   // in the SQL table, Role collum : 1=admin, 2=staff, 3=student.
                    if (DR["KeyID"].ToString()[0]=='3')
                    {
                        AdminLogin ss = new AdminLogin();
                        ss.Show();
                    }
                    
       
                    if (DR["KeyID"].ToString()[0] == '2')
                    {
                        
                        StaffLogin ss = new StaffLogin();
                        ss.Show();
                    }

                  
                    if (DR["KeyID"].ToString()[0] == '1')
                    {
                        StudentLogin ss = new StudentLogin();
                        ss.Show();
                    }

                }

            }
            else
            {
                MessageBox.Show("Fail");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
