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


        private void PopulateUsers()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM UserTable", connection))
            {
                //Da
                DataTable loginTable = new DataTable();
                adapter.Fill(loginTable);

                listBox1.DisplayMember = "UserName";
                listBox1.ValueMember = "id";
                listBox1.DataSource = loginTable;
            }
        }


        //btn_Submit Click event - take user nad pass, connect to database and login
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //string query = "SELECT * FROM UserTable where Username = @user and Password = @pass";
            //using (connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query, connection))
            //using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            //{
            //    // get string from textBox1 and textBox2
            //    command.Parameters.AddWithValue("@user", textBoxLogin.Text);
            //    command.Parameters.AddWithValue("@pass", textBoxPassword.Text);

            //    // create new DataTable instance
            //    DataTable recipeTable = new DataTable();
            //    adapter.Fill(recipeTable);

            //    int count = recipeTable.Rows.Count;
            //    if (count == 1)
            //    {
            //        AlreadyUserName = textBoxLogin.Text;
            //        MessageBox.Show(AlreadyUserName);
            //        MessageBox.Show("Login Successful!");
            //        this.Hide();
            //        FormLoggedBooks bio = new FormLoggedBooks();
            //        bio.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Login failed!");
            //    }

            //}

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
            PopulateUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration registrationWindow = new Registration();
            registrationWindow.Show();
            this.Hide();
        }

    }
}
