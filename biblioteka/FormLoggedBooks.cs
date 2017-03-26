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
        public static int AlreadyUserId;

        SqlConnection connection;
        string connectionString;

        User userLogged = new User(User.AlreadyUserName);

        public FormLoggedBooks()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void FormLoggedBooks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.database1DataSet.Book);
            SetUserId();
            PopulateUserBooks();
            CheckAdmin();
            labelUser.Text = User.AlreadyUserName;
        }

        // Method that set global static variable AlreadyUserId from database based on AlreadyUserName that was setted before.
        private void SetUserId()
        {
            string query = "SELECT u.Id FROM UserTable u " +
                "WHERE u.UserName = '" + User.AlreadyUserName + "'";
            //using (connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query, connection))
            //using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            //{
            //    command.Parameters.AddWithValue("@UserName", User.AlreadyUserName);

            //    DataTable userTable = new DataTable();
            //    adapter.Fill(userTable);

            //    AlreadyUserId = int.Parse(userTable.Rows[0][0].ToString());
            //}
            try
                {
                    DataTable userTable = User.DoQueryReturnTable(query);
                    AlreadyUserId = int.Parse(userTable.Rows[0][0].ToString());
                }
            catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }

        // Method that populate Books borrowed by user to DataGridView from database.
        private void PopulateUserBooks()
        {
           // listOfUserBooks.MultiColumn = true;
            string query = "SELECT * FROM Book a " +
                "INNER JOIN UserBooks b ON a.Id = b.BookId " +
                "WHERE b.UserId = '"+ FormLoggedBooks.AlreadyUserId +"'";
            DataTable bookTable = Book.DoQueryReturnTable(query);
            bookDataGridView.DataSource = bookTable;
        }



        private void buttonGoToLibrary_Click(object sender, EventArgs e)
        {
            FormLoggedBorrowBooks formLogged = new FormLoggedBorrowBooks();
            formLogged.Show();
            this.Hide();
        }

        private void bookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bookBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.goToSignInForm();
        }


        private void returnABookButton_Click(object sender, EventArgs e)
        {

            string query = "DELETE TOP (1) FROM UserBooks WHERE UserId='" + FormLoggedBooks.AlreadyUserId + "' AND BookId='" + Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value) + "'";

            //using (connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query, connection))
            //{
            //    connection.Open();
            //    command.Parameters.AddWithValue("@UserId", FormLoggedBooks.AlreadyUserId);
            //    // Value at first column of selected DataGridvView row(Selected book Id).
            //    command.Parameters.AddWithValue("@BookId", Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value));


            //    command.ExecuteScalar();
            //}
            Book.DoQueryStatic(query);

            // Second query to decrease quantity value by 1.
            query = "UPDATE Book SET quantity = quantity + 1 where Id = '" + Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value) + "'";

            //using (connection = new SqlConnection(connectionString))
            //using (SqlCommand command = new SqlCommand(query, connection))
            //{
            //    connection.Open();
            //    command.Parameters.AddWithValue("@BookId", Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value));


            //    command.ExecuteScalar();
            //}
            Book.DoQueryStatic(query);
            PopulateUserBooks();
        }

        private void buttonAdminPanel_Click(object sender, EventArgs e)
        {

            if (userLogged.IsAdmin(AlreadyUserId))
            {
                FormUserEditor formAdminEditor = new FormUserEditor();
                formAdminEditor.Show();
                this.Hide();
            }
        }

    

        private void booksEditorButton_Click(object sender, EventArgs e)
        {
            if (userLogged.IsAdmin(AlreadyUserId))
            {
                FormBookEditor formAdminEditor = new FormBookEditor();
                formAdminEditor.Show();
                this.Hide();
            }
        }

        private void CheckAdmin()
        {
            if (userLogged.IsAdmin(AlreadyUserId))
            {
                userEditorButton.Enabled = true;
                userEditorButton.Visible = true;

                booksEditorButton.Enabled = true;
                booksEditorButton.Visible = true;

                administratorLabel.Visible = true;
            }
        }
    }
}
