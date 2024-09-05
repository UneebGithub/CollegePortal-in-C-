using System;
using System.Linq;
using System.Windows.Forms;

namespace COLLEGEPORTAL
{
    public partial class ADD : Form
    {
        public ADD()
        {
            InitializeComponent();
        }

        dbmsProjectDataContext db;

        private void button1_Click(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();

           
            int checkedCount = 0;
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    checkedCount++;
                }
            }

            
            if (checkedCount > 7)
            {
                MessageBox.Show("You can only check up to 7 checkboxes.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int reg = Convert.ToInt32(textBox2.Text);
                string name = textBox1.Text;
                string sub1 = textBox3.Text;
                int fees = Convert.ToInt32(textBox4.Text);
                string HB = textBox5.Text;

                
                student st = new student
                {
                    student_Reg = reg,
                    student_Fees = fees,
                    student_HB = HB,
                    student_Payment = sub1,
                    student_name = name
                };

                
                db.students.InsertOnSubmit(st);

                
                attend attendance = new attend
                {
                    Student_ID = reg, 
                    Student_Name = name,
                    P = 0,
                    A = 0
                };

                
                db.attends.InsertOnSubmit(attendance);

                
                db.SubmitChanges();

                MessageBox.Show("Insert Successfully");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for registration, subject, and fees.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ADD_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
