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
    class Book : IDataBase
    {
        public string Title { get; private set; }
        public string AuthorFirstName { get; private set; }
        public string AuthorLastName { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public string Category { get; private set; }
        public int Quantity { get; private set; }


        public bool IsConnected { get; private set; }



        public void PopulateUserBooks()
        {

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

        public void SaveChanges(SqlDataAdapter dataAdapter)
        {
            DataTable userTable = new DataTable();
            dataAdapter.Fill(userTable);

            // Update database.
            dataAdapter.Update(userTable);
        }


    }
}
