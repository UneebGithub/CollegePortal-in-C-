using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLLEGEPORTAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Teacher");
            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Admin");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        dbmsProjectDataContext db;
        private void button1_Click(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();
            var user = textBox1.Text;
            var pass = textBox2.Text;

            if (comboBox1.SelectedIndex == 0) // Teacher
            {
                var teacher1 = (from t in db.teachers
                                where t.Teacher_name == user
                                select t).FirstOrDefault();

                if (teacher1 != null)
                {
                    Teacher tc = new Teacher(teacher1.Teacher_name, teacher1.Teacher_Reg, teacher1.Teacher_subjects);
                    tc.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or not authorized.");
                }
            }
            else if (comboBox1.SelectedIndex == 1) // Student
            {
                var student1 = (from t1 in db.students
                                where t1.student_name ==user && t1.student_Reg.ToString()==pass
                                select t1).FirstOrDefault();
                //MessageBox.Show(" " + student1);
                if (student1 != null)
                {
                    Std tc = new Std(student1.student_name, student1.student_Reg,student1.student_Payment);
                    tc.Show();
                    //this.Close();
                    //  tc.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else if (comboBox1.SelectedIndex == 2) // Admin
            {
                var adminUser = (from l in db.loginn_Admins
                                 where l.user_namee == user && l.user_pass == pass
                                 select l).FirstOrDefault();

                if (adminUser != null)
                {
                    Admin a = new Admin();
                    a.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            else
            {
                MessageBox.Show("Please select a user type.");
            }

            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
