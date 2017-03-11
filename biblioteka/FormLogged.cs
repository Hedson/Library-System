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
    public partial class FormLogged : FormPrimary
    {
        SqlConnection connection;
        string connectionString;

        public FormLogged()
        {
            InitializeComponent();
            labelUser.Text = FormSignIn.AlreadyUserName;
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void bookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bookBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormLogged_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.database1DataSet.Book);

        }

        private void buttonGoToUserBooks_Click(object sender, EventArgs e)
        {
            FormLoggedBooks formLoggedBooks = new FormLoggedBooks();
            formLoggedBooks.Show();
            this.Hide();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchValue = searchTextBox.Text.ToUpper();

            bookDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            try
            {
                bool valueResult = false;
                foreach (DataGridViewRow row in bookDataGridView.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Value.ToString().ToUpper() != null && row.Cells[i].Value.ToString().ToUpper().Equals(searchValue))
                        {
                            int rowIndex = row.Index;
                            bookDataGridView.Rows[rowIndex].Selected = true;
                            valueResult = true;

                            // Move to selected DaraGridView row.
                            bookDataGridView.CurrentCell = bookDataGridView.Rows[rowIndex].Cells[0];
                            break;
                        }
                    }

                }
                if (!valueResult)
                {
                    MessageBox.Show("Unable to find " + searchTextBox.Text, "Not Found");
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void borrowABookButton_Click(object sender, EventArgs e)
        {           
            string query = "INSERT INTO UserBooks VALUES (@UserId,@BookId)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@UserId", FormLoggedBooks.AlreadyUserId);
                // Value at first column of selected DataGridvView row(Selected book Id).
                command.Parameters.AddWithValue("@BookId", Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value));


                command.ExecuteScalar();
            }

            // Decrease qunatity value by 1.
            DecreaseQuantityValue(); 
            // Update DataGridView.
            PopulateBooks();  
        }

        private void PopulateBooks()
        {
            string query = "SELECT * FROM Book";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable bookTable = new DataTable();
                adapter.Fill(bookTable);

                bookDataGridView.DataSource = bookTable;
            }

        }

        // Method used to decrease quantity value in table Book by 1.
        private void DecreaseQuantityValue()
        {
            // Set query, that is used to decrease quantity value by 1.
            string query = "UPDATE Book SET quantity = quantity - 1 where Id = @BookId";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@BookId", Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value));


                command.ExecuteScalar();
            }
        }

        
    }
}
