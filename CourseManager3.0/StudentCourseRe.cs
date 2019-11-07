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
    public partial class StudentCourseRe : Form
    {
        public StudentCourseRe()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");

        private void Student_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                con.Open();
                String query = "select S.FirstName,S.LastName,C.CourseName,C.Nakaz from Students S,Cources C, CourceRegistration cr  WHERE cr.StudentID = S.StudentID and cr.CourceID = C.CourceID and S.StudentID=" + int.Parse(textBox1.Text);
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    SDA.Fill(dt);
                if (dt.Rows.Count > 0)//if theres a student prints else prints error.
                    dataGridView1.DataSource = dt;
                else
                    MessageBox.Show("No match,Try again.");
                con.Close();
            }
            else
                MessageBox.Show("No input,Please enter ID number.");//message is texbox is empty.
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudentToCourse ss = new AddStudentToCourse();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
    }
