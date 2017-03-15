using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace biblioteka
{
    public partial class FormSignIn : FormPrimary
    {
        // Public static string to share this string to other forms.
        public static string AlreadyUserName;

        SqlConnection connection;
        string connectionString;


        public FormSignIn()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }


        //btn_Submit Click event - take user nad pass, connect to database and login
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void Login()
        {
            string userName = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            try
            {
                User user = new User(userName, password);
                user.LoginUser();

                this.Hide();
                FormLoggedBooks bio = new FormLoggedBooks();
                bio.Show();

            }
            catch (Exception exception)
            {
                //Full exception information:
                //MessageBox.Show($"An error: {exception}");  
                
                // Display only exception Message:  
                MessageBox.Show(exception.Message);
            }
        }


        private void buttonAsGuest_Click(object sender, EventArgs e)
        {
            FormGuest guestWindow = new FormGuest();
            guestWindow.Show();
            this.Hide(); 
        }


        private void bookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bookBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormSignIn_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.database1DataSet.Book);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration registrationWindow = new Registration();
            registrationWindow.Show();
            this.Hide();
        }

    }
}
