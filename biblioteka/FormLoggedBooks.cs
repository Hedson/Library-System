using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblioteka
{
    public partial class FormLoggedBooks : FormPrimary
    {
        SqlConnection connection;
        string connectionString;

        public static int AlreadyUserId;

        public FormLoggedBooks()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void FormLoggedBooks_Load(object sender, EventArgs e)
        {
            SetUserId();
            PopulateUserBooks();
        }

        // Method that set global static variable AlreadyUserId from database based on AlreadyUserName that was setted before.
        private void SetUserId()
        {
            string query = "SELECT u.Id FROM UserTable u " +
                "WHERE u.UserName = @UserName";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@UserName", User.AlreadyUserName);

                DataTable userTable = new DataTable();
                adapter.Fill(userTable);

                AlreadyUserId = int.Parse(userTable.Rows[0][0].ToString());
            }
        }

        // Method that populate Books borrowed by user to list from database.
        private void PopulateUserBooks()
        {
            string query = "SELECT a.title FROM Book a " +
                "INNER JOIN UserBooks b ON a.Id = b.BookId " +
                "WHERE b.UserId = @UserId";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@UserId", FormLoggedBooks.AlreadyUserId);

                DataTable ingredientTable = new DataTable();
                adapter.Fill(ingredientTable);

                listOfUserBooks.DisplayMember = "title";
                listOfUserBooks.ValueMember = "Id";
                listOfUserBooks.DataSource = ingredientTable;
            }
        }



        private void buttonGoToLibrary_Click(object sender, EventArgs e)
        {
            FormLogged formLogged = new FormLogged();
            formLogged.Show();
            this.Hide();
        }

        
    }
}
