using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteka
{
    // This model will be used to validate Add, delete and update book methods for admin.
    class Book : IDataBase
    {
        public static int SelectedBookId;

        public string Title { get; private set; }
        public string AuthorFirstName { get; private set; }
        public string AuthorLastName { get; private set; }
        public int ReleaseDate { get; private set; }
        public string Category { get; private set; }
        public int Quantity { get; private set; }


        public bool IsConnected { get; private set; }

        public Book(string title, string authorFirstName, string authorLastName, string releaseDate, string category, string quantity)
        {
            SetTitle(title);
            SetAuthorFirstName(authorFirstName);
            SetAuthorLastName(authorLastName);
            SetReleaseDate(releaseDate);
            SetCategory(category);
            SetQuantity(quantity);
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception("Title can not be empty.");
            }
            if (Title == title)
            {
                return;
            }
            Title = title;
        }

        private void SetAuthorFirstName(string authorFirstName)
        {
            if (string.IsNullOrWhiteSpace(authorFirstName))
            {
                throw new Exception("Author first name field can not be empty.");
            }
            if (AuthorFirstName == authorFirstName)
            {
                return;
            }
            AuthorFirstName = authorFirstName;
        }

        private void SetAuthorLastName(string authorLastName)
        {
            if (string.IsNullOrWhiteSpace(authorLastName))
            {
                throw new Exception("Author last name field can not be empty.");
            }
            if (AuthorLastName == authorLastName)
            {
                return;
            }
            AuthorLastName = authorLastName;
        }

        private void SetReleaseDate(string releaseDate)
        {
            if (string.IsNullOrWhiteSpace(releaseDate))
            {
                throw new Exception("Publication date can not be empty.");
            }

            int releaseDateValue = 0;

            if (Int32.TryParse(releaseDate, out releaseDateValue))
            {

            }
            else
            {
                throw new Exception("Invalid type. Insert numeric value with ranke 1-2100.");
            }

            if (releaseDateValue > 2100 || releaseDateValue < 1)
            {
                throw new Exception("Publication date is out of range. You can selece 1 - 2100 year.");
            }
            if (ReleaseDate == releaseDateValue)
            {
                return;
            }
            ReleaseDate = releaseDateValue;
        }

        private void SetCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                throw new Exception("Category can not be empty.");
            }
            if (Category == category)
            {
                return;
            }
            Category = category;
        }

        private void SetQuantity(string quantity)
        {
            if (string.IsNullOrWhiteSpace(quantity))
            {
                throw new Exception("Quantity can not be empty.");
            }

            int quantityValue = 0;

            if (Int32.TryParse(quantity, out quantityValue))
            {

            }
            else
            {
                throw new Exception("Invalid type. Insert numeric value with range 0-10000.");
            }

            if (quantityValue > 10000 || quantityValue < 0)
            {
                throw new Exception("Quantity is out of range. You can select 0 - 10000 range.");
            }
            if (Quantity == quantityValue)
            {
                return;
            }
            Quantity = quantityValue;
        }

        public void AddBook()
        {
            string query = "INSERT INTO Book VALUES ('" + Title + "' ,'" + AuthorFirstName + "','" + AuthorLastName + 
                "','" + ReleaseDate + "','" + Category + "','" + Quantity + "')";
            DoQuery(query);
        }

        public void UpdateBook()
        {
             string query = "UPDATE Book SET title = '" + Title + "' ,authorFirstName = '" + AuthorFirstName + "',authorLastName = '" + AuthorLastName +
                    "',year = '" + ReleaseDate + "',category = '" + Category + "',quantity = '" + Quantity + "'WHERE Id = '" + SelectedBookId + "'";
              DoQuery(query);
        }
        public static void DeleteBook()
        {
            //First delete from UserBooks table all relationships many to many between UserTable and Book.
            string query = "DELETE FROM UserBooks WHERE BookId = '" + SelectedBookId + "'";
            DoQueryStatic(query);
            // Now delete column from Book table.
            string queryDelete = "DELETE from Book WHERE Id = '" + SelectedBookId + "'";
            DoQueryStatic(queryDelete);
        }


        // Return actual Book table - used to refresh displayed data.
        public static DataTable ReturnBooksTable()
        {
            string query = "SELECT * FROM Book";

            DataTable dataTable = DoQueryReturnTable(query);
            return dataTable;
        }


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

        public void SaveChanges(SqlDataAdapter dataAdapter)
        {
            DataTable userTable = new DataTable();
            dataAdapter.Fill(userTable);

            // Update database.
            dataAdapter.Update(userTable);
        }


    }
}
