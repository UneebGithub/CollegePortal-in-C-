using System.Linq;
using System.Windows.Forms;
using System;
using DBMSPROJECT;

namespace COLLEGEPORTAL
{
    public partial class Teacher : Form
    {
        static int results = 0;
        private readonly string teacherName;
        private readonly string teacherSubjects;
        private readonly int teacherReg;
        public int q, f, s, fl, a, r;
        public Teacher(string s1, int s4, string s3)
        {
            InitializeComponent();
            teacherName = s1;
            teacherSubjects = s3;
            teacherReg = s4;
            dbmsProjectDataContext db = new dbmsProjectDataContext();
            var tc = db.teachers.FirstOrDefault(teacher => teacher.Teacher_Reg == teacherReg && teacher.Teacher_name == teacherName);

            if (tc?.Class_Teacher == "yes")
            {
                attendanceToolStripMenuItem.Enabled = true;
                attendanceToolStripMenuItem.Visible = true;
            }
            else
            {
                attendanceToolStripMenuItem.Enabled = false;
                attendanceToolStripMenuItem.Visible = false;
            }
            label1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            dataGridView1.Visible = false;
            button1.Visible = false;
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMarksTestUpdates();
        }

        private dbmsProjectDataContext db;

        private void ShowMarksTestUpdates()
        {
            label1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button2.Visible = false;
            dataGridView1.Visible = true;
            button1.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            switch (teacherSubjects)
            {
                case "CS":
                    // label1.Text = "Enter Computer Marks:";
                    break;
                case "Maths":
                    //label1.Text = "Enter Maths Marks:";
                    break;
                case "Science":
                    //label1.Text = "Enter Science Marks:";
                    break;
                case "English":
                    //label1.Text = "Enter English Marks:";
                    break;
                default:
                    label1.Visible = false;
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();
            try
            {
                int roll = Convert.ToInt32(textBox1.Text);
                int mrk = Convert.ToInt32(textBox2.Text);


                var studentMark = db.students.FirstOrDefault(m => m.student_Reg== roll);
                if (studentMark != null)
                {

                    var student = db.students.FirstOrDefault(s => s.student_Reg == roll);
                    string studentName = student?.student_name;
                    //1-for CS
                    if (teacherSubjects == "CS")
                    {
                        var stdMark1 = db.Subject_Computers.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Cmp_Marks = mrk;
                            stdMark1.Student_Name = studentName;
                            q += mrk;
                        }
                        else
                        {
                            var newm = new Subject_Computer
                            {
                                id = roll,
                                Cmp_Marks = mrk

                            };
                            q += mrk;
                            db.Subject_Computers.InsertOnSubmit(newm);
                        }
                    }
                    //2-for Maths
                    else if (teacherSubjects == "Math")
                    {
                        var stdMark1 = db.Subject_Maths.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Math
                            {
                                id = roll,
                                Marks = mrk
                            };
                            db.Subject_Maths.InsertOnSubmit(newMa);
                        }
                    }

                    //3-for english
                    else if (teacherSubjects == "English")
                    {
                        var stdMark1 = db.Subject_Englishes.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_English
                            {
                                id = roll,
                                Marks = mrk
                            };
                            db.Subject_Englishes.InsertOnSubmit(newMa);
                        }
                    }
                    //4-for urdu 
                    else if (teacherSubjects == "Urdu")
                    {
                        var stdMark1 = db.Subject_Urdus.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Urdu
                            {
                                id = roll,
                                Marks = mrk
                            };
                            db.Subject_Urdus.InsertOnSubmit(newMa);
                        }
                    }
                    //5-for PK
                    else if (teacherSubjects == "PakStd")
                    {
                        var stdMark1 = db.Subject_Pks.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Pk
                            {
                                id = roll,
                                Marks = mrk
                            };
                            db.Subject_Pks.InsertOnSubmit(newMa);
                        }
                    }
                    //6-for phy
                    else if (teacherSubjects == "Phy")
                    {
                        var stdMark1 = db.Subject_Phies.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Phy
                            {
                                id = roll,
                                Marks = mrk
                            };
                            db.Subject_Phies.InsertOnSubmit(newMa);
                        }
                    }

                    db.SubmitChanges();


                    var updatedMarks = from m in db.Marks
                                       join s in db.students on m.student_id equals s.student_Reg
                                       where m.student_id == roll
                                       select new
                                       {
                                           Student_Name = s.student_name,
                                           Student_Roll = roll,
                                           Marks = mrk
                                       };

                    dataGridView1.DataSource = updatedMarks.ToList();
                    MessageBox.Show("Marks updated successfully!");
                }
                else
                {
                    MessageBox.Show("Roll number does not exist in the Marks table.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();
            try
            {
                int roll = Convert.ToInt32(textBox1.Text);
                int mrk = Convert.ToInt32(textBox2.Text);


                var studentMark = db.students.FirstOrDefault(m => m.student_Reg== roll);
                if (studentMark != null)
                {

                    var student = db.students.FirstOrDefault(s => s.student_Reg == roll);
                    string studentName = student?.student_name;
                    //1-for CS
                    if (teacherSubjects == "CS")
                    {
                        var stdMark1 = db.Subject_Computers.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.First_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                            f += q;
                        }
                        else
                        {
                            var newm = new Subject_Computer
                            {
                                id = roll,
                                First_Term_marks = mrk
                            };
                            f += q;
                            db.Subject_Computers.InsertOnSubmit(newm);
                        }
                    }
                    //2-for Maths
                    else if (teacherSubjects == "Math")
                    {
                        var stdMark1 = db.Subject_Maths.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.First_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Math
                            {
                                id = roll,
                                First_Term_marks = mrk
                            };
                            db.Subject_Maths.InsertOnSubmit(newMa);
                        }
                    }

                    //3-for english
                    else if (teacherSubjects == "English")
                    {
                        var stdMark1 = db.Subject_Englishes.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.First_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_English
                            {
                                id = roll,
                                First_Term_marks = mrk
                            };
                            db.Subject_Englishes.InsertOnSubmit(newMa);
                        }
                    }
                    //4-for urdu 
                    else if (teacherSubjects == "Urdu")
                    {
                        var stdMark1 = db.Subject_Urdus.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.First_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Urdu
                            {
                                id = roll,
                                First_Term_marks = mrk
                            };
                            db.Subject_Urdus.InsertOnSubmit(newMa);
                        }
                    }
                    //5-for PK
                    else if (teacherSubjects == "PakStd")
                    {
                        var stdMark1 = db.Subject_Pks.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.First_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Pk
                            {
                                id = roll,
                                First_Term_marks = mrk
                            };
                            db.Subject_Pks.InsertOnSubmit(newMa);
                        }
                    }
                    //6-for phy
                    else if (teacherSubjects == "Phy")
                    {
                        var stdMark1 = db.Subject_Phies.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.First_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Phy
                            {
                                id = roll,
                                First_Term_marks = mrk
                            };
                            db.Subject_Phies.InsertOnSubmit(newMa);
                        }
                    }

                    db.SubmitChanges();


                    var updatedMarks = from m in db.Marks
                                       join s in db.students on m.student_id equals s.student_Reg
                                       where m.student_id == roll
                                       select new
                                       {
                                           Student_Name = s.student_name,
                                           Student_Roll = roll,
                                           First_Term_marks = mrk
                                       };

                    dataGridView1.DataSource = updatedMarks.ToList();
                    MessageBox.Show("Marks updated successfully!");
                }
                else
                {
                    MessageBox.Show("Roll number does not exist in the Marks table.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            textBox3.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();
            try
            {
                int roll = Convert.ToInt32(textBox1.Text);
                int mrk = Convert.ToInt32(textBox2.Text);


                var studentMark = db.students.FirstOrDefault(m => m.student_Reg == roll);
                if (studentMark != null)
                {

                    var student = db.students.FirstOrDefault(s => s.student_Reg == roll);
                    string studentName = student?.student_name;
                    //1-for CS
                    if (teacherSubjects == "CS")
                    {
                        var stdMark1 = db.Subject_Computers.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Second_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                            s += f;
                        }
                        else
                        {
                            var newm = new Subject_Computer
                            {
                                id = roll,
                                Second_Term_marks = mrk
                            };
                            s += f;
                            db.Subject_Computers.InsertOnSubmit(newm);
                        }
                    }
                    //2-for Maths
                    else if (teacherSubjects == "Math")
                    {
                        var stdMark1 = db.Subject_Maths.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Second_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Math
                            {
                                id = roll,
                                Second_Term_marks = mrk
                            };
                            db.Subject_Maths.InsertOnSubmit(newMa);
                        }
                    }

                    //3-for english
                    else if (teacherSubjects == "English")
                    {
                        var stdMark1 = db.Subject_Englishes.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Second_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_English
                            {
                                id = roll,
                                Second_Term_marks = mrk
                            };
                            db.Subject_Englishes.InsertOnSubmit(newMa);
                        }
                    }
                    //4-for urdu 
                    else if (teacherSubjects == "Urdu")
                    {
                        var stdMark1 = db.Subject_Urdus.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Second_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Urdu
                            {
                                id = roll,
                                Second_Term_marks = mrk
                            };
                            db.Subject_Urdus.InsertOnSubmit(newMa);
                        }
                    }
                    //5-for PK
                    else if (teacherSubjects == "PakStd")
                    {
                        var stdMark1 = db.Subject_Pks.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Second_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Pk
                            {
                                id = roll,
                                Second_Term_marks = mrk
                            };
                            db.Subject_Pks.InsertOnSubmit(newMa);
                        }
                    }
                    //6-for phy
                    else if (teacherSubjects == "Phy")
                    {
                        var stdMark1 = db.Subject_Phies.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Second_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                        }
                        else
                        {
                            var newMa = new Subject_Phy
                            {
                                id = roll,
                                Second_Term_marks = mrk
                            };
                            db.Subject_Phies.InsertOnSubmit(newMa);
                        }
                    }

                    db.SubmitChanges();


                    var updatedMarks = from m in db.Marks
                                       join s in db.students on m.student_id equals s.student_Reg
                                       where m.student_id == roll
                                       select new
                                       {
                                           Student_Name = s.student_name,
                                           Student_Roll = roll,
                                           First_Term_marks = mrk
                                       };

                    dataGridView1.DataSource = updatedMarks.ToList();
                    MessageBox.Show("Marks updated successfully!");
                }
                else
                {
                    MessageBox.Show("Roll number does not exist in the Marks table.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void firsttermTestUpdates()
        {
            label1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dataGridView1.Visible = true;
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            db = new dbmsProjectDataContext();
            try
            {
                Subject_Computer sc=new Subject_Computer();
                int roll = Convert.ToInt32(textBox1.Text);
                int mrk = Convert.ToInt32(textBox2.Text);
           
                
                var studentMark = db.students.FirstOrDefault(m => m.student_Reg == roll);
                if (studentMark != null)
                {

                    var student = db.students.FirstOrDefault(s => s.student_Reg == roll);
                    string studentName = student?.student_name;
                    //1-for CS
                    if (teacherSubjects == "CS")
                    {
                        var stdMark1 = db.Subject_Computers.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Final_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                            // fl += s;
                            //results = (int)(sc.Final_Term_marks + sc.First_Term_marks + sc.Second_Term_marks + sc.Cmp_Marks);
                            //MessageBox.Show(""+fl);
                            int results = (int)(stdMark1.Final_Term_marks + stdMark1.First_Term_marks + stdMark1.Second_Term_marks + stdMark1.Cmp_Marks);
                            MessageBox.Show("Total Marks: " + results);
                            stdMark1.Result = results.ToString();
                            //stdMark1.Result = fl.ToString();

                        }
                        else
                        {
                            var newm = new Subject_Computer
                            {
                                id = roll,
                                Final_Term_marks = mrk
                            };
                            db.Subject_Computers.InsertOnSubmit(newm);
                        }
                    }
                    //2-for Maths
                    else if (teacherSubjects == "Math")
                    {
                        var stdMark1 = db.Subject_Maths.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Final_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                            int results = (int)(stdMark1.Final_Term_marks + stdMark1.First_Term_marks + stdMark1.Second_Term_marks + stdMark1.Marks);
                            MessageBox.Show("Total Marks: " + results);
                            stdMark1.Result = results.ToString();
                        }
                        else
                        {
                            var newMa = new Subject_Math
                            {
                                id = roll,
                                Final_Term_marks = mrk

                            };
                            db.Subject_Maths.InsertOnSubmit(newMa);
                        }
                    }

                    //3-for english
                    else if (teacherSubjects == "English")
                    {
                        var stdMark1 = db.Subject_Englishes.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Final_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                            int results = (int)(stdMark1.Final_Term_marks + stdMark1.First_Term_marks + stdMark1.Second_Term_marks + stdMark1.Marks);
                            MessageBox.Show("Total Marks: " + results);
                            stdMark1.Result = results.ToString();
                        }
                        else
                        {
                            var newMa = new Subject_English
                            {
                                id = roll,
                                Final_Term_marks = mrk
                            };
                            db.Subject_Englishes.InsertOnSubmit(newMa);
                        }
                    }
                    //4-for urdu 
                    else if (teacherSubjects == "Urdu")
                    {
                        var stdMark1 = db.Subject_Urdus.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Final_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                            int results = (int)(stdMark1.Final_Term_marks + stdMark1.First_Term_marks + stdMark1.Second_Term_marks + stdMark1.Marks);
                            MessageBox.Show("Total Marks: " + results);
                            stdMark1.Result = results.ToString();
                        }
                        else
                        {
                            var newMa = new Subject_Urdu
                            {
                                id = roll,
                                Final_Term_marks = mrk
                            };
                            db.Subject_Urdus.InsertOnSubmit(newMa);
                        }
                    }
                    //5-for PK
                    else if (teacherSubjects == "PakStd")
                    {
                        var stdMark1 = db.Subject_Pks.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Final_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                            int results = (int)(stdMark1.Final_Term_marks + stdMark1.First_Term_marks + stdMark1.Second_Term_marks + stdMark1.Marks);
                            MessageBox.Show("Total Marks: " + results);
                            stdMark1.Result = results.ToString();
                        }
                        else
                        {
                            var newMa = new Subject_Pk
                            {
                                id = roll,
                                Final_Term_marks = mrk
                            };
                            db.Subject_Pks.InsertOnSubmit(newMa);
                        }
                    }
                    //6-for phy
                    else if (teacherSubjects == "Phy")
                    {
                        var stdMark1 = db.Subject_Phies.FirstOrDefault(m => m.id == roll);
                        if (stdMark1 != null)
                        {
                            stdMark1.Final_Term_marks = mrk;
                            stdMark1.Student_Name = studentName;
                            int results = (int)(stdMark1.Final_Term_marks + stdMark1.First_Term_marks + stdMark1.Second_Term_marks + stdMark1.Marks);
                            MessageBox.Show("Total Marks: " + results);
                            stdMark1.Result = results.ToString();
                        }
                        else
                        {
                            var newMa = new Subject_Phy
                            {
                                id = roll,
                                Final_Term_marks = mrk
                            };
                            db.Subject_Phies.InsertOnSubmit(newMa);
                        }
                    }

                    db.SubmitChanges();


                    var updatedMarks = from m in db.Marks
                                       join s in db.students on m.student_id equals s.student_Reg
                                       where m.student_id == roll
                                       select new
                                       {
                                           Student_Name = s.student_name,
                                           Student_Roll = roll,
                                           Final_Term_marks = mrk
                                       };


                    dataGridView1.DataSource = updatedMarks.ToList();

                    MessageBox.Show("Marks updated successfully!");
                }
                else
                {
                    MessageBox.Show("Roll number does not exist in the Marks table.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void serach()
        {
            button4.Visible = false;
            button3.Visible = false;
            label1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dataGridView1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button5.Visible = true;
        }
        private void searchStudnetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serach();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            db=new dbmsProjectDataContext();
            try
            {
                int roll = Convert.ToInt32(textBox1.Text);

                if (db == null)
                {
                    MessageBox.Show("Database context is not initialized.");
                    return;
                }

                if (db.students == null)
                {
                    MessageBox.Show("Students data is not available.");
                    return;
                }

                var student = db.students.FirstOrDefault(s => s.student_Reg == roll);

                if (student != null)
                {
                    var studentData = from s in db.students
                                      where s.student_Reg == roll
                                      select s;

                    dataGridView1.DataSource = studentData.ToList();
                }
                else
                {
                    MessageBox.Show("Student data not found");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid roll number.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void result()
        {
            button4.Visible = false;
            button3.Visible = false;
            label1.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            dataGridView1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            button6.Visible = true;
        }
        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result();
        }

        private void uploadMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();
            try
            {
                int roll = Convert.ToInt32(textBox1.Text);

                if (db == null)
                {
                    MessageBox.Show("Database context is not initialized.");
                    return;
                }

                if (db.students == null)
                {
                    MessageBox.Show("Students data is not available.");
                    return;
                }

                var student = db.students.FirstOrDefault(s => s.student_Reg == roll);

                if (student != null)
                {
                    var teacherSubjects = "CS"; 

                    switch (teacherSubjects)
                    {
                        case "CS":
                            var csData = from s in db.students
                                         join m in db.Subject_Computers on s.student_Reg equals m.id
                                         where s.student_Reg == roll
                                         select new
                                         {
                                             s.student_Reg,
                                             s.student_name,
                                             m.Cmp_Marks,
                                             m.Final_Term_marks,
                                             m.Second_Term_marks,
                                             m.First_Term_marks,
                                             m.Result,
                                         };

                            dataGridView1.DataSource = csData.ToList();
                            break;

                        case "Math":
                            var mathData = from s in db.students
                                           join m in db.Subject_Maths on s.student_Reg equals m.id
                                           where s.student_Reg == roll
                                           select new
                                           {
                                               s.student_Reg,
                                               s.student_name,
                                               m.Marks,
                                               m.Final_Term_marks,
                                               m.Second_Term_marks,
                                               m.First_Term_marks,
                                               m.Result,
                                           };

                            dataGridView1.DataSource = mathData.ToList();
                            break;

                        case "Phy":
                            var scienceData = from s in db.students
                                              join m in db.Subject_Phies on s.student_Reg equals m.id
                                              where s.student_Reg == roll
                                              select new
                                              {
                                                  s.student_Reg,
                                                  s.student_name,
                                                  m.Marks,
                                                  m.Final_Term_marks,
                                                  m.Second_Term_marks,
                                                  m.First_Term_marks,
                                                  m.Result,
                                              };

                            dataGridView1.DataSource = scienceData.ToList();
                            break;

                        

                        default:
                            MessageBox.Show("Subject not recognized.");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Student data not found.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid roll number.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void markToolStripMenuItem_Click(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();
            try
            {
                Attend at=new Attend();
                at.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void stTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firsttermTestUpdates();
            //first term  

        }
        private void sectermTestUpdates()
        {
            button3.Visible = true;
            button4.Visible = false;
            button6.Visible = false;
            button3.Visible = true;
            label1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dataGridView1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
        }
        private void ndTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //2nd tream marks
            sectermTestUpdates();


        }
        private void Final()
        {
            button4.Visible = true;
            button3.Visible = false;
            label1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dataGridView1.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
        }
        private void finalTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Final();
            //3rd 

        }
    }
}
