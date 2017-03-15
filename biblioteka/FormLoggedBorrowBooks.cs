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
    public partial class FormLoggedBorrowBooks : FormPrimary
    {
        SqlConnection connection;
        string connectionString;

        public FormLoggedBorrowBooks()
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
            labelUser.Text = User.AlreadyUserName;
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
            // Selected book Id integer value.
            int selectedBookId = Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value);

            // Query that create table row that create relation between book id and user id(many-to-many relation).
            string query = "INSERT INTO UserBooks VALUES ('"+ FormLoggedBooks.AlreadyUserId + "','"+ selectedBookId +"')";
            User.DoQueryStatic(query);

            // Decrease qunatity value by 1.
            DecreaseQuantityValue();
            // Update DataGridView.
            PopulateBooks();  
        }

        private void PopulateBooks()
        {
            DataTable bookTable = Book.ReturnBooksTable();
            bookDataGridView.DataSource = bookTable;
        }

        // Method used to decrease quantity value in table Book by 1.
        private void DecreaseQuantityValue()
        {
            // Selected book Id integer value.
            int selectedBookId = Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value);

            // Set query, that is used to decrease quantity value by 1.
            string query = "UPDATE Book SET quantity = quantity - 1 where Id = '"+ selectedBookId + "'";
            Book.DoQueryStatic(query);
        }

        
    }
}
