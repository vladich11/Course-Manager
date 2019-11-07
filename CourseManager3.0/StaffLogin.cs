using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseManager3._0
{
    public partial class StaffLogin : Form
    {
        public StaffLogin()
        {
            InitializeComponent();
        }

        private void StaffLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Student_Click(object sender, EventArgs e)
        {
            ManageDBStudent ss = new ManageDBStudent();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageDBCourse ss = new ManageDBCourse();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentCourseRe ss = new StudentCourseRe();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintStudentGrades ss = new PrintStudentGrades();
            ss.Show();
        }
    }
}
