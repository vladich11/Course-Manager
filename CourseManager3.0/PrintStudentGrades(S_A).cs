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
    public partial class PrintStudentGrades_S_A_ : Form
    {
        public PrintStudentGrades_S_A_()
        {
            InitializeComponent();
        }

        private void Student_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
            con.Open();
            if (textBox1 != null && textBox2 != null && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand check_Password = new SqlCommand("SELECT * FROM Login WHERE ([Password] = '" + textBox1.Text + "') ", con);
                if (check_Password.ExecuteScalar() != null)
                {

                    String query = "select C.CourseName,G.Grade from Grades G,Cources C  WHERE  G.CourceID = C.CourceID and G.StudentID=" + int.Parse(textBox2.Text);
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
                    MessageBox.Show("Wrong password");
            }
            else
                MessageBox.Show("No input,Please enter ID number.");//message is texbox is empty.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
