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
    public partial class ManageDBCourse : Form
    {
        public ManageDBCourse()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");

        private void ManageDBCourse_Load(object sender, EventArgs e)
        {

        }

        private void Student_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM Cources";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCourseToDB ss = new AddCourseToDB();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCourseFromDB ss = new DeleteCourseFromDB();
            ss.Show();
        }
    }
}
