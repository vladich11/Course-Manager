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
    public partial class StudentLogin : Form
    {
        
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Student_Click(object sender, EventArgs e)
        {
            PrintTeachersDB ss = new PrintTeachersDB();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintCourseDB ss = new PrintCourseDB();
            ss.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StudentCourseRe_S_A_ ss = new StudentCourseRe_S_A_();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintStudentGrades_S_A_ ss = new PrintStudentGrades_S_A_();
            ss.Show();
        }
    }
}
