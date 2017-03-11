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
    class User : IDataBase
    {
        public static string AlreadyUserName;

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string City { get; private set; }
        public string Email { get; private set; }


        public bool IsConnected { get; private set; }
        public delegate void LoginUserBody();

        public User(string userName)
        {
            SetUserName(userName);
        }
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
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("First name can not be empty.");
            }
            if (Password == firstName)
            {
                return;
            }
            FirstName = firstName;
        }

        private void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("Last name can not be empty.");
            }
            if (Password == lastName)
            {
                return;
            }
            LastName = lastName;
        }

        private void SetCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new Exception("City can not be empty.");
            }
            if (Password == city)
            {
                return;
            }
            City = city;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can not be empty.");
            }
            if (Password == email)
            {
                return;
            }
            Email = email;
        }

        private void Activate()
        {
            throw new NotImplementedException();
        }


        public void LoginUser()
        {
            SqlConnection connection;
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;

            //string query = "SELECT * FROM UserTable where Username = @user and Password = @pass";

            string query = "SELECT * FROM UserTable where Username = '" + UserName + "'and Password ='" + Password + "'";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                // command.Parameters.AddWithValue("@user", UserName);
                // command.Parameters.AddWithValue("@pass", Password);

                // create new DataTable instance
                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                int count = userTable.Rows.Count;
                if (count == 1)
                {
                    AlreadyUserName = UserName;
                    MessageBox.Show(AlreadyUserName);
                    MessageBox.Show("Login Successful!");
                }
                else
                {
                    MessageBox.Show("Login failed! Invalid User Name or password.");
                }

            }


        }

        // Method added new user to UserTable database table.
        public void RegisterUser()
        {
            string query = "INSERT INTO UserTable VALUES ('" + UserName +"' ,'" + Password + "','" + FirstName + "','" + LastName + "','" + City + "','" + Email + "','"+0+"')";
            DoQuery(query);
        }


        // Method check if user is admin (Do edycji -- nie powtarzać kodu niepotrzebnie)
        public bool IsAdmin(int alreadyUserId)
        {
            SqlConnection connection;
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;

            string query = "SELECT IsAdmin From UserTable where Username = '" + UserName + "'and Id ='" + alreadyUserId + "'";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                // create new DataTable instance
                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                bool field = userTable.Rows[0].Field<bool>(0);

                if (field == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }




        // Method used to Cennect to DB for functionalities like add, edit, delete elements from database.
        public void DoQuery(string query)
        {
            SqlConnection connection;
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                SaveChanges(dataAdapter);
            }
        }

        public void SaveChanges(SqlDataAdapter dataAdapter)
        {
            DataTable userTable = new DataTable();
            dataAdapter.Fill(userTable);

            // Update database.
            dataAdapter.Update(userTable);        
        }

        
    }
}
