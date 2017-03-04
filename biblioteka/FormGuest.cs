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
    public partial class FormGuest : FormPrimary
    {
        public FormGuest()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            this.goToSignInForm();
        }


        private void bookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bookBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void FormGuest_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Book' table. You can move, or remove it, as needed..
            this.bookTableAdapter.Fill(this.database1DataSet.Book);

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
    }
}
