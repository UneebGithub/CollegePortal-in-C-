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
    public partial class Std : Form
    {
        private readonly string name;
        private readonly int reg;
        private readonly int sub;
        private string student_name;
        private int student_Reg;
        private int? student_Fees;
        private string student_payment;
        public Std(string name, int reg, string student_payment)
        {
            InitializeComponent();
            this.name = name;
            this.reg = reg;
            dbmsProjectDataContext db = new dbmsProjectDataContext();
            this.student_payment = student_payment;
        }

        private void Students_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            progressBar3.Visible = false;
            progressBar4.Visible = false;
            progressBar5.Visible = false;
            progressBar6.Visible = false;
            dataGridView1.Visible = false;

            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

            label1.Text = $"Name: {name}";
            label4.Text = $"Reg: {reg}";
            label6.Text = $"Payment: {student_payment}";
        }

        private void display_result()
        {
            progressBar1.Visible = true;
            progressBar2.Visible = true;
            progressBar3.Visible = true;
            progressBar4.Visible = true;
            progressBar5.Visible = true;
            progressBar6.Visible = true;
            dataGridView1.Visible = false;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;

            using (var db = new dbmsProjectDataContext())
            {
                var subjectMarks = db.Subject_Computers.FirstOrDefault(s => s.id == reg);
                var subjectMarks1 = db.Subject_Englishes.FirstOrDefault(s => s.id == reg);
                var subjectMarks2 = db.Subject_Maths.FirstOrDefault(s => s.id == reg);
                var subjectMarks3 = db.Subject_Phies.FirstOrDefault(s => s.id == reg);
                var subjectMarks4 = db.Subject_Pks.FirstOrDefault(s => s.id == reg);
                var subjectMarks5 = db.Subject_Urdus.FirstOrDefault(s => s.id == reg);

                if (subjectMarks != null)
                {
                    if (int.TryParse(subjectMarks.Result, out int result))
                    {
                        progressBar1.Value = result;
                    }
                }
                else
                {
                    //MessageBox.Show("Marks not found for Computer subject.");
                }

                if (subjectMarks1 != null)
                {
                    if (int.TryParse(subjectMarks1.Result, out int result1))
                    {
                        progressBar2.Value = result1;
                    }
                }
                else
                {
                    //MessageBox.Show("Marks not found for English subject.");
                }

                if (subjectMarks2 != null)
                {
                    if (int.TryParse(subjectMarks2.Result, out int result2))
                    {
                        progressBar3.Value = result2;
                    }
                }
                else
                {
                    //MessageBox.Show("Marks not found for Maths subject.");
                }

                if (subjectMarks3 != null)
                {
                    if (int.TryParse(subjectMarks3.Result, out int result3))
                    {
                        progressBar4.Value = result3;
                    }
                }
                else
                {
                   // MessageBox.Show("Marks not found for Physics subject.");
                }

                if (subjectMarks4 != null)
                {
                    if (int.TryParse(subjectMarks4.Result, out int result4))
                    {
                        progressBar5.Value = result4;
                    }
                }
                else
                {
                 //   MessageBox.Show("Marks not found for Pakistan Studies subject.");
                }

                if (subjectMarks5 != null)
                {
                    if (int.TryParse(subjectMarks5.Result, out int result5))
                    {
                        progressBar6.Value = result5;
                    }
                }
                else
                {
                    //MessageBox.Show("Marks not found for Urdu subject.");
                }
            }
        }

        private void checkMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void quizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mk marks = new Mk(reg);
            marks.ShowDialog();
        }

        private void resultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            display_result();
        }

        private void attendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            attendd();
        }
        dbmsProjectDataContext db;
        private void attendd()
        {
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            progressBar3.Visible = false;
            progressBar4.Visible = false;
            progressBar5.Visible = false;
            progressBar6.Visible = false;
           // dataGridView1.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            db =new dbmsProjectDataContext();
            dataGridView1.Visible = true;
            var sh = from a in db.attends
                                 join s in db.students on a.Student_ID equals s.student_Reg
                                 where a.Student_ID == reg
                                 select new
                                 {
                                     RollNumber= s.student_Reg,
                                     StudentName = s.student_name,
                                     a.A,
                                     a.P
                                     
                                 };

            if (sh.Any())
            {
                dataGridView1.DataSource = sh.ToList();
            }
        }
    }
}
