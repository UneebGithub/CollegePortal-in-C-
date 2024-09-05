using COLLEGEPORTAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DBMSPROJECT
{
    public partial class Attend : Form
    {
        private dbmsProjectDataContext dbms;

        public Attend()
        {
            InitializeComponent();
            dbms = new dbmsProjectDataContext();
        }

        private void Attend_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pr = Convert.ToInt32(textBox3.Text);

            var student = dbms.students.FirstOrDefault(s => s.student_Reg == pr);
            if (student == null)
            {
                MessageBox.Show("Student Not Registered");
                return;
            }

            var attendance = dbms.attends.FirstOrDefault(attend => attend.Student_ID == pr);
            if (attendance != null)
            {
                attendance.P += 1;
                dbms.SubmitChanges();
            }
            else
            {
                var newAttendance = new attend
                {
                    Student_ID = pr,
                    P = 1,
                    A = 0
                };
                dbms.attends.InsertOnSubmit(newAttendance);
                dbms.SubmitChanges();
            }

            var show = from s1 in dbms.students
                       join s2 in dbms.attends on s1.student_Reg equals s2.Student_ID
                       where s1.student_Reg == pr
                       select new
                       {
                           s1.student_Reg,
                           s1.student_name,
                           s2.P,
                           s2.A
                       };

            dataGridView1.DataSource = show.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int pr = Convert.ToInt32(textBox3.Text);

            var student = dbms.students.FirstOrDefault(s => s.student_Reg == pr);
            if (student == null)
            {
                MessageBox.Show("Student Not Registered");
                return;
            }

            var attendance = dbms.attends.FirstOrDefault(attend => attend.Student_ID == pr);
            if (attendance != null)
            {
                attendance.A += 1;
                dbms.SubmitChanges();
            }
            else
            {
                var newAttendance = new attend
                {
                    Student_ID = pr,
                    P = 0,
                    A = 1
                };
                dbms.attends.InsertOnSubmit(newAttendance);
                dbms.SubmitChanges();
            }

            var show = from s1 in dbms.students
                       join s2 in dbms.attends on s1.student_Reg equals s2.Student_ID
                       where s1.student_Reg == pr
                       select new
                       {
                           s1.student_Reg,
                           s1.student_name,
                           s2.P,
                           s2.A
                       };

            dataGridView1.DataSource = show.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pr = Convert.ToInt32(textBox3.Text);

            var student = dbms.students.FirstOrDefault(s => s.student_Reg == pr);
            if (student == null)
            {
                MessageBox.Show("Student Not Registered");
                return;
            }

            var attendance = dbms.attends.FirstOrDefault(attend => attend.Student_ID == pr);
            if (attendance == null)
            {
                var newAttendance = new attend
                {
                    Student_ID = pr,
                    P = 0,
                    A = 0
                };
                dbms.attends.InsertOnSubmit(newAttendance);
                dbms.SubmitChanges();
            }

            var show = from s1 in dbms.students
                       join s2 in dbms.attends on s1.student_Reg equals s2.Student_ID
                       select new
                       {
                           s1.student_Reg,
                           s1.student_name,
                           s2.P,
                           s2.A
                       };

            dataGridView1.DataSource = show.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells["student_Reg"].Value.ToString();
            }
        }
    }
}
