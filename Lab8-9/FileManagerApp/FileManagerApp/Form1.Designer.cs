namespace FileManagerApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectFolder = new Button();
            treeViewDirectory = new TreeView();
            txtFileName = new TextBox();
            btnSearchFile = new Button();
            lstSearchResults = new ListBox();
            btnRename = new Button();
            btnDelete = new Button();
            btnOpen = new Button();
            txtNewName = new TextBox();
            btnCopy = new Button();
            SuspendLayout();
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new Point(34, 12);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(147, 24);
            btnSelectFolder.TabIndex = 0;
            btnSelectFolder.Text = "Select starting folder";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // treeViewDirectory
            // 
            treeViewDirectory.Location = new Point(34, 41);
            treeViewDirectory.Name = "treeViewDirectory";
            treeViewDirectory.Size = new Size(550, 265);
            treeViewDirectory.TabIndex = 1;
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(187, 13);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(316, 23);
            txtFileName.TabIndex = 2;
            txtFileName.Text = "Type your search for a file here...";
            // 
            // btnSearchFile
            // 
            btnSearchFile.Location = new Point(509, 13);
            btnSearchFile.Name = "btnSearchFile";
            btnSearchFile.Size = new Size(75, 23);
            btnSearchFile.TabIndex = 3;
            btnSearchFile.Text = "Go search";
            btnSearchFile.UseVisualStyleBackColor = true;
            btnSearchFile.Click += btnSearchFile_Click;
            // 
            // lstSearchResults
            // 
            lstSearchResults.FormattingEnabled = true;
            lstSearchResults.ItemHeight = 15;
            lstSearchResults.Location = new Point(34, 312);
            lstSearchResults.Name = "lstSearchResults";
            lstSearchResults.Size = new Size(550, 124);
            lstSearchResults.TabIndex = 4;
            // 
            // btnRename
            // 
            btnRename.Location = new Point(590, 42);
            btnRename.Name = "btnRename";
            btnRename.Size = new Size(135, 23);
            btnRename.TabIndex = 7;
            btnRename.Text = "Rename selected file";
            btnRename.UseVisualStyleBackColor = true;
            btnRename.Click += btnRename_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(731, 13);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete selected file";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(590, 13);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(135, 23);
            btnOpen.TabIndex = 11;
            btnOpen.Text = "Open selected file";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpenFile_Click;
            // 
            // txtNewName
            // 
            txtNewName.Location = new Point(590, 71);
            txtNewName.Name = "txtNewName";
            txtNewName.Size = new Size(276, 23);
            txtNewName.TabIndex = 12;
            txtNewName.Text = "Type new name here...";
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(731, 42);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(135, 23);
            btnCopy.TabIndex = 13;
            btnCopy.Text = "Make copy of file";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 450);
            Controls.Add(btnCopy);
            Controls.Add(txtNewName);
            Controls.Add(btnOpen);
            Controls.Add(btnDelete);
            Controls.Add(btnRename);
            Controls.Add(lstSearchResults);
            Controls.Add(btnSearchFile);
            Controls.Add(txtFileName);
            Controls.Add(treeViewDirectory);
            Controls.Add(btnSelectFolder);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectFolder;
        private TreeView treeViewDirectory;
        private TextBox txtFileName;
        private Button btnSearchFile;
        private ListBox lstSearchResults;
        private Button btnRename;
        private Button btnDelete;
        private Button btnOpen;
        private TextBox txtNewName;
        private Button btnCopy;
    }
}
