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
    public partial class ManageDBStudent : Form
    {
        public ManageDBStudent()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-MOD95DG5;Initial Catalog=EliSchool;Integrated Security=True");
        private void ManageDBStudent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddStudentToDB ss = new AddStudentToDB();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Student_Click(object sender, EventArgs e)
        {
            con.Open();
            String query = "SELECT * FROM Students";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();

            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            DeleteStudentFromDB ss = new DeleteStudentFromDB();
            ss.Show();
        }
    }
    
}
