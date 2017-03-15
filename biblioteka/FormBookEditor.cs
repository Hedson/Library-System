using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biblioteka
{
    public partial class FormBookEditor : Form
    {

        public FormBookEditor()
        {
            InitializeComponent();
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            FormLoggedBooks formLoggedBooks = new FormLoggedBooks();
            formLoggedBooks.Show();
            this.Hide();
        }

        private void bookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bookBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormBookEditor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.database1DataSet.Book);

        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string authorFirstName = authorFirstNameTextBox.Text;
            string authorLastName = authorLastNameTextBox.Text;
            string publicationDate = publicationDateTextBox.Text;
            string category = categoryTextBox.Text;
            string quantity = quantityTextBox.Text;

            try
            {
                Book book = new Book(title, authorFirstName, authorLastName, publicationDate, category, quantity);
                book.AddBook();

                DataTable bookTable = Book.ReturnBooksTable();
                bookDataGridView.DataSource = bookTable;

                MessageBox.Show("Book added to database.");

                

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void updateBookButton_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text;
            string authorFirstName = authorFirstNameTextBox.Text;
            string authorLastName = authorLastNameTextBox.Text;
            string publicationDate = publicationDateTextBox.Text;
            string category = categoryTextBox.Text;
            string quantity = quantityTextBox.Text;

            Book.SelectedBookId = Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value);

            try
            {
                Book book = new Book(title, authorFirstName, authorLastName, publicationDate, category, quantity);
                book.UpdateBook();

                DataTable bookTable = Book.ReturnBooksTable();
                bookDataGridView.DataSource = bookTable;

                MessageBox.Show("Book details updated.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void deleteBookButton_Click(object sender, EventArgs e)
        {

            Book.SelectedBookId = Convert.ToInt32(bookDataGridView.CurrentRow.Cells[0].Value);
            Book.DeleteBook();
            DataTable bookTable = Book.ReturnBooksTable();
            bookDataGridView.DataSource = bookTable;
        }
    }
}
