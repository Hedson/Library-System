﻿using System;
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
        public static int SelectedUserId;

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
            string query = "SELECT * FROM UserTable where Username = '" + UserName + "'and Password ='" + Password + "'";
            DataTable userTable = DoQueryReturnTable(query);
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

        // Method added new user to UserTable database table.
        public void RegisterUser()
        {
            string query = "INSERT INTO UserTable VALUES ('" + UserName +"' ,'" + Password + "','" + Email + "','" + FirstName + "','" + LastName + "','" + City + "','"+0+"')";
            DoQuery(query);
        }


        // Method check if user is admin (Do edycji -- nie powtarzać kodu niepotrzebnie)
        public bool IsAdmin(int alreadyUserId)
        {
            string query = "SELECT IsAdmin From UserTable where Username = '" + UserName + "'and Id ='" + alreadyUserId + "'";

            DataTable userTable = DoQueryReturnTable(query);

            bool field = userTable.Rows[0].Field<bool>(0);

            if (field)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public void UpdateUser()
        {
            string query = "UPDATE UserTable SET UserName = '" + UserName + "' ,Password = '" + Password + "',email = '" + Email +
                   "',FirstName = '" + FirstName + "',LastName = '" + LastName + "',City = '" + City + "',IsAdmin = '" + 0 + "'WHERE Id = '" + SelectedUserId + "'";
            DoQuery(query);
        }

        public static void DeleteUser()
        {
            //First delete from UserBooks table all relationships many to many between Books and User.
            string query = "DELETE FROM UserBooks WHERE UserId = '" + SelectedUserId + "'";
            DoQueryStatic(query);
            // Now delete column from Book table.
            string queryDelete = "DELETE from UserTable WHERE Id = '" + SelectedUserId + "'";
            DoQueryStatic(queryDelete);
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
        public static void DoQueryStatic(string query)
        {
            SqlConnection connection;
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                // Update database.
                dataAdapter.Update(userTable);
            }
        }

        public void SaveChanges(SqlDataAdapter dataAdapter)
        {
            DataTable userTable = new DataTable();
            dataAdapter.Fill(userTable);

            // Update database.
            dataAdapter.Update(userTable);        
        }

        // Return actual Book table - used to refresh displayed data.
        public static DataTable ReturnUserTable()
        {
            string query = "SELECT * FROM UserTable";

            DataTable dataTable = DoQueryReturnTable(query);
            return dataTable;
        }

        public static DataTable DoQueryReturnTable(string query)
        {
            SqlConnection connection;
            string connectionString;
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                // create new DataTable instance
                DataTable userTable = new DataTable();
                dataAdapter.Fill(userTable);

                return userTable;
            }
        }

        
    }
}
