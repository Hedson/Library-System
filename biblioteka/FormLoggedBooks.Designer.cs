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
            this.buttonGoToLibrary = new System.Windows.Forms.Button();
            this.listOfUserBooks = new System.Windows.Forms.ListBox();
            this.buttonBookInformations = new System.Windows.Forms.Button();
            this.buttonReturnABook = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
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
            this.listOfUserBooks.Location = new System.Drawing.Point(47, 143);
            this.listOfUserBooks.Name = "listOfUserBooks";
            this.listOfUserBooks.Size = new System.Drawing.Size(288, 364);
            this.listOfUserBooks.TabIndex = 12;
            // 
            // buttonBookInformations
            // 
            this.buttonBookInformations.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonBookInformations.Location = new System.Drawing.Point(400, 182);
            this.buttonBookInformations.Name = "buttonBookInformations";
            this.buttonBookInformations.Size = new System.Drawing.Size(174, 76);
            this.buttonBookInformations.TabIndex = 13;
            this.buttonBookInformations.Text = "Selected book informations\r\n";
            this.buttonBookInformations.UseVisualStyleBackColor = true;
            // 
            // buttonReturnABook
            // 
            this.buttonReturnABook.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonReturnABook.Location = new System.Drawing.Point(400, 307);
            this.buttonReturnABook.Name = "buttonReturnABook";
            this.buttonReturnABook.Size = new System.Drawing.Size(174, 69);
            this.buttonReturnABook.TabIndex = 14;
            this.buttonReturnABook.Text = "Return a book";
            this.buttonReturnABook.UseVisualStyleBackColor = true;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.buttonLogout.Location = new System.Drawing.Point(818, 41);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(133, 66);
            this.buttonLogout.TabIndex = 15;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            // 
            // FormLoggedBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 579);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonReturnABook);
            this.Controls.Add(this.buttonBookInformations);
            this.Controls.Add(this.listOfUserBooks);
            this.Controls.Add(this.buttonGoToLibrary);
            this.Name = "FormLoggedBooks";
            this.Text = "FormLoggedBooks";
            this.Load += new System.EventHandler(this.FormLoggedBooks_Load);
            this.Controls.SetChildIndex(this.buttonGoToLibrary, 0);
            this.Controls.SetChildIndex(this.listOfUserBooks, 0);
            this.Controls.SetChildIndex(this.buttonBookInformations, 0);
            this.Controls.SetChildIndex(this.buttonReturnABook, 0);
            this.Controls.SetChildIndex(this.buttonLogout, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGoToLibrary;
        private System.Windows.Forms.ListBox listOfUserBooks;
        private System.Windows.Forms.Button buttonBookInformations;
        private System.Windows.Forms.Button buttonReturnABook;
        private System.Windows.Forms.Button buttonLogout;
    }
}