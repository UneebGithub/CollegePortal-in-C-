using System;
using System.Windows.Forms;

namespace COLLEGEPORTAL
{
    public partial class Admins : Form
    {
        private dbmsProjectDataContext db;

        public Admins()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            
            using (db = new dbmsProjectDataContext())
            {
                try
                {
                    string check_user = textBox1.Text;
                    string check_password = textBox2.Text;

                    
                    loginn_Admin lg = new loginn_Admin
                    {
                        user_namee = check_user,
                        user_pass = check_password
                    };

                    
                    db.loginn_Admins.InsertOnSubmit(lg);
                    db.SubmitChanges();

                    MessageBox.Show("Admin credentials added successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                    
                }
            }
        }
    }
}
