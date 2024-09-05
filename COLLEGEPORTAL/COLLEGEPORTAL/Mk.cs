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
    public partial class Mk : Form
    {
        private readonly int reg;

        public Mk(int reg)
        {
            InitializeComponent();
            this.reg = reg;
//s            MessageBox.Show(""+reg);
            db = new dbmsProjectDataContext();
        }

        private dbmsProjectDataContext db;

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void Mk_Load(object sender, EventArgs e)
        {
            db = new dbmsProjectDataContext();

            Subject_Computer subject = db.Subject_Computers.FirstOrDefault(s => s.id == reg);
            if (subject != null)
            {
                label18.Text = subject.Cmp_Marks.ToString();
                label19.Text = subject.First_Term_marks.ToString();
                label20.Text = subject.Second_Term_marks.ToString();
                label21.Text = subject.Final_Term_marks.ToString();
            }
            else
            {
              //  MessageBox.Show("Computer subject marks not found.");
            }

            Subject_Phy sp = db.Subject_Phies.FirstOrDefault(p => p.id == reg);
            if (sp != null)
            {
                label25.Text = sp.Marks.ToString();
                label24.Text = sp.First_Term_marks.ToString();
                label23.Text = sp.Second_Term_marks.ToString();
                label22.Text = sp.Final_Term_marks.ToString();
            }
            else
            {
                //MessageBox.Show("Physics subject marks not found.");
            }

            Subject_Urdu u = db.Subject_Urdus.FirstOrDefault(p => p.id == reg);
            if (u != null)
            {
                label29.Text = u.Marks.ToString();
                label28.Text = u.First_Term_marks.ToString();
                label27.Text = u.Second_Term_marks.ToString();
                label26.Text = u.Final_Term_marks.ToString();
            }
            else
            {
                //MessageBox.Show("Urdu subject marks not found.");
            }

            Subject_English se = db.Subject_Englishes.FirstOrDefault(p => p.id == reg);
            if (se != null)
            {
                label33.Text = se.Marks.ToString();
                label32.Text = se.First_Term_marks.ToString();
                label31.Text = se.Second_Term_marks.ToString();
                label30.Text = se.Final_Term_marks.ToString();
            }
            else
            {
                //MessageBox.Show("English subject marks not found.");
            }

            Subject_Math m = db.Subject_Maths.FirstOrDefault(p => p.id == reg);
            if (m != null)
            {
                label37.Text = m.Marks.ToString();
                label36.Text = m.First_Term_marks.ToString();
                label35.Text = m.Second_Term_marks.ToString();
                label34.Text = m.Final_Term_marks.ToString();
            }
            else
            {
                //MessageBox.Show("Maths subject marks not found.");
            }

            Subject_Pk pk = db.Subject_Pks.FirstOrDefault(p => p.id == reg);
            if (pk != null)
            {
                label41.Text = pk.Marks.ToString();
                label40.Text = pk.First_Term_marks.ToString();
                label39.Text = pk.Second_Term_marks.ToString();
                label38.Text = pk.Final_Term_marks.ToString();
            }
            else
            {
                //MessageBox.Show("Pakistan Studies subject marks not found.");
            }
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
