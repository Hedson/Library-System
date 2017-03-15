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
    public partial class FormUserEditor : Form
    {
        public FormUserEditor()
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

        private void FormAdminEditor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.UserTable' table. You can move, or remove it, as needed.
            this.userTableTableAdapter.Fill(this.database1DataSet.UserTable);
            // TODO: This line of code loads data into the 'database1DataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.database1DataSet.Book);

        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            string userName = loginTextBox.Text;
            string password = passwordTextBox.Text;
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string city = cityTextBox.Text;
            string email = emailTextBox.Text;

            try
            {
                User user = new User(userName, password, firstName, lastName, city, email);
                user.RegisterUser();

                DataTable userTable = User.ReturnUserTable();
                userTableDataGridView.DataSource = userTable;

                MessageBox.Show("New user created.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
