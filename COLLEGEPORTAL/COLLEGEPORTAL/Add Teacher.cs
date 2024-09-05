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
    public partial class Add_Teacher : Form
    {
        public Add_Teacher()
        {
            InitializeComponent();
        }
        dbmsProjectDataContext db;
        private void button1_Click(object sender, EventArgs e)
        {


            db = new dbmsProjectDataContext();


            teacher tc = new teacher();

            try {
                tc.Teacher_Reg = Convert.ToInt32(textBox1.Text);
                tc.Teacher_name = textBox2.Text;
                tc.Teacher_subjects = textBox3.Text;
                tc.Teacher_Fees = Convert.ToInt32(textBox4.Text);
                tc.Class_Teacher = radioButton1.Checked ? "yes" : "no";


                db.teachers.InsertOnSubmit(tc);

                db.SubmitChanges();

                MessageBox.Show("Teacher added successfully!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                radioButton1.Checked = false;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }

        private void Add_Teacher_Load(object sender, EventArgs e)
        {

        }
    }
    
}
