using DBMSPROJECT;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace COLLEGEPORTAL
{
    public partial class Admin : Form
    {
        private dbmsProjectDataContext db;

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();
            LoadStudentData();
            HideControls();
        }

        private void LoadStudentData()
        {
            db=new dbmsProjectDataContext();
            student s1=new student();

            var join1 = from a in db.attends
                        join s in db.students on a.Student_ID equals s.student_Reg
                        select new
                        {
                            a.Student_ID,
                            a.Student_Name,
                            s.student_Fees,
                            s.student_Payment,
                            s.student_HB   ,
                   
                            a.A,
                            a.P
                        };
            dataGridView1.DataSource = join1.ToList();

        }

        private void LoadTeacherData()
        {
            var teachers = from t in db.teachers
                           select new
                           {
                               t.Teacher_Reg,
                               t.Teacher_name,
                               t.Teacher_subjects,
                               t.Teacher_Fees,
                               t.Class_Teacher
                           };
            dataGridView1.DataSource = teachers.ToList();
        }

        private void HideControls()
        {
            button1.Visible = false;
            button6.Visible = false;   
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            dataGridView1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            //button6.Visible = false;
            //button7.Visible = false;    
        }

        private void ShowDeleteControls()
        {
            dataGridView1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;

        }

        private void ShowUpdateControls()
        {
            var c = from s in db.students select s;

            dataGridView1.Visible = true;
            dataGridView1.DataSource = c.ToList();
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void ShowAttendanceControls()
        {
            var studentAttendance = from s in db.students
                                    join a in db.attends on s.student_Reg equals a.Student_ID
                                    select new
                                    {
                                        s.student_Reg,
                                        s.student_name,
                                        a.A,
                                        a.P
                                    };
            dataGridView1.DataSource = studentAttendance.ToList();

            dataGridView1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
          //  button6.Visible = true;
            //button7.Visible = true;
        }

        private void ShowUpdateTeacherControls()
        {
            LoadTeacherData();
            dataGridView1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;
        }

        private void deleteStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = from s in db.students select s;

            //dataGridView1.Visible = true;
            dataGridView1.DataSource = c.ToList();
            ShowDeleteControls();
        }

        private void updateStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;  
            label4.Visible = true;
            label1.Text = "Name:";
            label2.Text = "StudentPayment:";
            label3.Text = "Fees:";
            label4.Text = "HB:";
            ShowUpdateControls();
        }

        private void updateAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ShowAttendanceControls();
            Attend a =new Attend();
            a.ShowDialog    ();
                       }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int regToDelete = Convert.ToInt32(textBox1.Text);

                var studentToDelete = db.students.SingleOrDefault(st => st.student_Reg == regToDelete);
                var studentToDelete1 = db.Subject_Computers.SingleOrDefault(st => st.id == regToDelete);
                var studentToDelete2 = db.Subject_Englishes.SingleOrDefault(st => st.id == regToDelete);
                var studentToDelete3 = db.Subject_Maths.SingleOrDefault(st => st.id == regToDelete);
                var studentToDelete4 = db.Subject_Phies.SingleOrDefault(st => st.id == regToDelete);
                var studentToDelete5 = db.Subject_Pks.SingleOrDefault(st => st.id == regToDelete);
                var studentToDelete6 = db.Subject_Urdus.SingleOrDefault(st => st.id == regToDelete);
                var studentToDelete0 = db.attends.SingleOrDefault(st => st.Student_ID == regToDelete);

                if (studentToDelete != null)
                {
                    db.students.DeleteOnSubmit(studentToDelete);
                }
                if (studentToDelete1 != null)
                {
                    db.Subject_Computers.DeleteOnSubmit(studentToDelete1);
                }
                if (studentToDelete2 != null)
                {
                    db.Subject_Englishes.DeleteOnSubmit(studentToDelete2);
                }
                if (studentToDelete3 != null)
                {
                    db.Subject_Maths.DeleteOnSubmit(studentToDelete3);
                }
                if (studentToDelete4 != null)
                {
                    db.Subject_Phies.DeleteOnSubmit(studentToDelete4);
                }
                if (studentToDelete5 != null)
                {
                    db.Subject_Pks.DeleteOnSubmit(studentToDelete5);
                }
                if (studentToDelete6 != null)
                {
                    db.Subject_Urdus.DeleteOnSubmit(studentToDelete6);
                }
                if (studentToDelete0 != null)
                {
                    db.attends.DeleteOnSubmit(studentToDelete0);
                }

                if (studentToDelete != null || studentToDelete1 != null || studentToDelete2 != null || studentToDelete3 != null ||
                    studentToDelete4 != null || studentToDelete5 != null || studentToDelete6 != null || studentToDelete0 != null)
                {
                    db.SubmitChanges();
                    MessageBox.Show("Student and related records deleted successfully.");
                    LoadStudentData();
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid registration number.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (!int.TryParse(textBox1.Text, out int regToUpdate))
                {
                    MessageBox.Show("Please enter a valid registration number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (!int.TryParse(textBox2.Text, out int fees))
                {
                    MessageBox.Show("Please enter a valid fee amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                dbmsProjectDataContext db = new dbmsProjectDataContext();

                
                var studentToUpdate = db.students.SingleOrDefault(st => st.student_Reg == regToUpdate);

                if (studentToUpdate != null)
                {
                   
                    studentToUpdate.student_name = textBox5.Text;
                    studentToUpdate.student_Payment = textBox4.Text;
                    studentToUpdate.student_Fees = Convert.ToInt32(textBox2.Text);
                    studentToUpdate.student_HB = textBox3.Text;

                
                    db.SubmitChanges();

                    MessageBox.Show("Student updated successfully.");
                    LoadStudentData(); 
                }
                else
                {
                    MessageBox.Show("Student not found.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var roll = Convert.ToInt32(textBox1.Text);
                var ab = db.attends.SingleOrDefault(attend => attend.Student_ID == roll);

                if (ab != null)
                {
                    ab.A = Convert.ToInt32(textBox2.Text);
                    ab.P = Convert.ToInt32(textBox3.Text);

                    db.SubmitChanges();
                    MessageBox.Show("Attendance updated successfully.");

                    var show = from s1 in db.attends select s1;
                    dataGridView1.DataSource = show.ToList();
                }
                else
                {
                    MessageBox.Show("Student not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void addStudentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ADD a = new ADD();
            a.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            textBox1.Visible = false;
            button1.Visible = false;
            LoadStudentData();
        }

        private void addTeachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Teacher a = new Add_Teacher();
            a.ShowDialog();
        }

        private void removeTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadTeacherData();
            ShowDeleteControls();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var regToDelete = Convert.ToInt32(textBox1.Text);
                var teacherToDelete = db.teachers.SingleOrDefault(teacher => teacher.Teacher_Reg == regToDelete);

                if (teacherToDelete != null)
                {
                    db.teachers.DeleteOnSubmit(teacherToDelete);
                    db.SubmitChanges();
                    MessageBox.Show("Teacher deleted successfully.");
                    LoadTeacherData();
                }
                else
                {
                    MessageBox.Show("Teacher not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void updateTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label1.Text = "Teacher Reg:";
            label2.Text = "Class Teacher:";
            label3.Text = "Subject:";
            label4.Text = "Fees:";
            ShowUpdateTeacherControls();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var regToUpdate = Convert.ToInt32(textBox1.Text);
                var teacherToUpdate = db.teachers.SingleOrDefault(teacher => teacher.Teacher_Reg == regToUpdate);

                if (teacherToUpdate != null)
                {
                    teacherToUpdate.Teacher_name = textBox2.Text;
                    teacherToUpdate.Teacher_subjects = textBox3.Text;
                    teacherToUpdate.Teacher_Fees = Convert.ToInt32(textBox4.Text);
                    teacherToUpdate.Class_Teacher = textBox5.Text;

                    db.SubmitChanges();
                    MessageBox.Show("Teacher updated successfully.");
                    LoadTeacherData();
                }
                else
                {
                    MessageBox.Show("Teacher not found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int pr = Convert.ToInt32(textBox3.Text);
            db = new dbmsProjectDataContext();
            var ab = db.attends.FirstOrDefault(attend => attend.Student_ID == pr);
            if (ab != null)
            {
                ab.A += 1;


                db.SubmitChanges();

                var show = from s1 in db.attends where s1.Student_ID == pr select s1;
                dataGridView1.DataSource = show.ToList();
            }
            else
            {
                MessageBox.Show("Student Not Found");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int pr = Convert.ToInt32(textBox3.Text);
            db=new dbmsProjectDataContext();

            var ab = db.attends.FirstOrDefault(attend => attend.Student_ID== pr);
            if (ab != null)
            {
                //  int newP = Convert.ToInt32(textBox1.Text); // Example textBox for new P value
                //int newA = Convert.ToInt32(textBox2.Text); // Example textBox for new A value

                //ab.P = newP;
                //ab.A = newA;

                db.SubmitChanges();

                var show = from s1 in db.attends select s1;
                dataGridView1.DataSource = show.ToList();
            }
            else
            {
                MessageBox.Show("Student Not Found");
            }
        }

        private void updateMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mark m = new Mark();
            //dataGridView1.Visible = false;
            //textBox1.Visible = true;
            //textBox4.Visible = true;
            //button1 .Visible = false;
            //button2.Visible = false;
            //button3.Visible = true;
            //button4.Visible = false;
            //button5.Visible = false;
            //button6.Visible = false;
            //int rol = Convert.ToInt16(textBox1.Text);
            //string sub=textBox4.Text;
            //int ub = Convert.ToInt32(textBox3.Text);
            //var c = from ck in db.students
            //      where ck.student_Reg == rol
            /*    select ck;
        if (c != null)
        {

            dataGridView1.DataSource = c.ToList();
        }
            */
            MessageBox.Show("You Can't update Students Marks");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void policyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adminSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admins a=new
                Admins();
            a.ShowDialog();
        }

        private void contectUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContUs contUs = new ContUs();
            contUs.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
             var ch=MessageBox.Show("Do you want to exit the program", "Exit", MessageBoxButtons.YesNo);
            if (ch==DialogResult.Yes)
            {
                Close();
            }
        }

        private void adminSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Admins a=new Admins();
            a.ShowDialog();
        }
    }
}
