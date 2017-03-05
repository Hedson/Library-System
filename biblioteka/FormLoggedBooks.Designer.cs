namespace biblioteka
{
    partial class FormLoggedBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonGoToLibrary = new System.Windows.Forms.Button();
            this.listOfUserBooks = new System.Windows.Forms.ListBox();
            this.selectedBookInformationButton = new System.Windows.Forms.Button();
            this.returnABookButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.database1DataSet = new biblioteka.Database1DataSet();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookTableAdapter = new biblioteka.Database1DataSetTableAdapters.BookTableAdapter();
            this.tableAdapterManager = new biblioteka.Database1DataSetTableAdapters.TableAdapterManager();
            this.bookDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGoToLibrary
            // 
            this.buttonGoToLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonGoToLibrary.Location = new System.Drawing.Point(622, 41);
            this.buttonGoToLibrary.Name = "buttonGoToLibrary";
            this.buttonGoToLibrary.Size = new System.Drawing.Size(149, 66);
            this.buttonGoToLibrary.TabIndex = 11;
            this.buttonGoToLibrary.Text = "Borrow a book";
            this.buttonGoToLibrary.UseVisualStyleBackColor = true;
            this.buttonGoToLibrary.Click += new System.EventHandler(this.buttonGoToLibrary_Click);
            // 
            // listOfUserBooks
            // 
            this.listOfUserBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listOfUserBooks.FormattingEnabled = true;
            this.listOfUserBooks.ItemHeight = 20;
            this.listOfUserBooks.Location = new System.Drawing.Point(809, 187);
            this.listOfUserBooks.Name = "listOfUserBooks";
            this.listOfUserBooks.Size = new System.Drawing.Size(175, 364);
            this.listOfUserBooks.TabIndex = 12;
            // 
            // selectedBookInformationButton
            // 
            this.selectedBookInformationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.selectedBookInformationButton.Location = new System.Drawing.Point(284, 83);
            this.selectedBookInformationButton.Name = "selectedBookInformationButton";
            this.selectedBookInformationButton.Size = new System.Drawing.Size(174, 69);
            this.selectedBookInformationButton.TabIndex = 13;
            this.selectedBookInformationButton.Text = "Selected book informations\r\n";
            this.selectedBookInformationButton.UseVisualStyleBackColor = true;
            // 
            // returnABookButton
            // 
            this.returnABookButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.returnABookButton.Location = new System.Drawing.Point(43, 83);
            this.returnABookButton.Name = "returnABookButton";
            this.returnABookButton.Size = new System.Drawing.Size(174, 69);
            this.returnABookButton.TabIndex = 14;
            this.returnABookButton.Text = "Return a book";
            this.returnABookButton.UseVisualStyleBackColor = true;
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.logoutButton.Location = new System.Drawing.Point(818, 41);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(133, 66);
            this.logoutButton.TabIndex = 15;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataMember = "Book";
            this.bookBindingSource.DataSource = this.database1DataSet;
            // 
            // bookTableAdapter
            // 
            this.bookTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BookTableAdapter = this.bookTableAdapter;
            this.tableAdapterManager.UpdateOrder = biblioteka.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UserBooksTableAdapter = null;
            this.tableAdapterManager.UserTableAdapter = null;
            this.tableAdapterManager.UserTableTableAdapter = null;
            // 
            // bookDataGridView
            // 
            this.bookDataGridView.AllowUserToAddRows = false;
            this.bookDataGridView.AllowUserToDeleteRows = false;
            this.bookDataGridView.AllowUserToOrderColumns = true;
            this.bookDataGridView.AutoGenerateColumns = false;
            this.bookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.bookDataGridView.DataSource = this.bookBindingSource;
            this.bookDataGridView.Location = new System.Drawing.Point(27, 167);
            this.bookDataGridView.Name = "bookDataGridView";
            this.bookDataGridView.Size = new System.Drawing.Size(744, 384);
            this.bookDataGridView.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "title";
            this.dataGridViewTextBoxColumn2.HeaderText = "title";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "authorFirstName";
            this.dataGridViewTextBoxColumn3.HeaderText = "authorFirstName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "authorLastName";
            this.dataGridViewTextBoxColumn4.HeaderText = "authorLastName";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "year";
            this.dataGridViewTextBoxColumn5.HeaderText = "year";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "quantity";
            this.dataGridViewTextBoxColumn6.HeaderText = "quantity";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "category";
            this.dataGridViewTextBoxColumn7.HeaderText = "category";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // FormLoggedBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 579);
            this.Controls.Add(this.bookDataGridView);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.returnABookButton);
            this.Controls.Add(this.selectedBookInformationButton);
            this.Controls.Add(this.listOfUserBooks);
            this.Controls.Add(this.buttonGoToLibrary);
            this.Name = "FormLoggedBooks";
            this.Text = "FormLoggedBooks";
            this.Load += new System.EventHandler(this.FormLoggedBooks_Load);
            this.Controls.SetChildIndex(this.buttonGoToLibrary, 0);
            this.Controls.SetChildIndex(this.listOfUserBooks, 0);
            this.Controls.SetChildIndex(this.selectedBookInformationButton, 0);
            this.Controls.SetChildIndex(this.returnABookButton, 0);
            this.Controls.SetChildIndex(this.logoutButton, 0);
            this.Controls.SetChildIndex(this.bookDataGridView, 0);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGoToLibrary;
        private System.Windows.Forms.ListBox listOfUserBooks;
        private System.Windows.Forms.Button selectedBookInformationButton;
        private System.Windows.Forms.Button returnABookButton;
        private System.Windows.Forms.Button logoutButton;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource bookBindingSource;
        private Database1DataSetTableAdapters.BookTableAdapter bookTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView bookDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}