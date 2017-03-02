using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblioteka
{
    class User
    {
        public static string AlreadyUserName;

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string City { get; private set; }
        public string Email { get; private set; }

        public User(string userName, string password)
        {
            SetUserName(userName);
            SetPassword(password);
        }

        public User(string userName, string password, string firstName, string lastName, string city, string email)
        {
            SetUserName(userName);
            SetPassword(password);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetCity(city);
            SetEmail(email);
            Activate();
        }


        private void SetUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new Exception("UserName can not be empty.");
            }
            if (UserName == userName)
            {
                return;
            }
            UserName = userName;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
        }

        private void SetFirstName(string firstName)
        {
            throw new NotImplementedException();
        }

        private void SetLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        private void SetCity(string city)
        {
            throw new NotImplementedException();
        }

        private void SetEmail(string email)
        {
            throw new NotImplementedException();
        }

        private void Activate()
        {
            throw new NotImplementedException();
        }


        public bool LoginUser()
        {
            SqlConnection connection;
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;

            string query = "SELECT * FROM UserTable where Username = @user and Password = @pass";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                // get string from textBox1 and textBox2
                command.Parameters.AddWithValue("@user", UserName);
                command.Parameters.AddWithValue("@pass", Password);

                // create new DataTable instance
                DataTable recipeTable = new DataTable();
                adapter.Fill(recipeTable);

                int count = recipeTable.Rows.Count;
                if (count == 1)
                {
                    AlreadyUserName = UserName;
                    MessageBox.Show(AlreadyUserName);
                    MessageBox.Show("Login Successful!");
                    return true;
                }
                else
                {
                    MessageBox.Show("Login failed! Invalid User Name or password.");
                    return false;
                }

            }
        }


    }  
}
