using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileManagerApp
{
    public partial class Form1 : Form
    {
        private string selectedFolderPath = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFolderPath = folderDialog.SelectedPath;
                    treeViewDirectory.Nodes.Clear();
                    TreeNode rootNode = new TreeNode(new DirectoryInfo(selectedFolderPath).Name) { Tag = selectedFolderPath };
                    treeViewDirectory.Nodes.Add(rootNode);
                    LoadDirectory(selectedFolderPath, rootNode);
                }
            }
        }

        private void LoadDirectory(string path, TreeNode node)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    TreeNode subNode = new TreeNode(Path.GetFileName(dir)) { Tag = dir };
                    node.Nodes.Add(subNode);
                    LoadDirectory(dir, subNode);
                }

                foreach (var file in Directory.GetFiles(path))
                {
                    node.Nodes.Add(new TreeNode(Path.GetFileName(file)) { Tag = file });
                }
            }
            catch (UnauthorizedAccessException)
            {
                node.Nodes.Add(new TreeNode("[Access denied to this document/folder]"));
            }
        }

        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            if (ValidateSearchInput())
            {
                lstSearchResults.Items.Clear();
                SearchFile(selectedFolderPath, txtFileName.Text);
            }
        }

        private bool ValidateSearchInput()
        {
            if (string.IsNullOrWhiteSpace(txtFileName.Text))
            {
                MessageBox.Show("Please enter a file name to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                MessageBox.Show("Please select a folder first.", "No Folder Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void SearchFile(string directory, string fileName)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory, "*" + fileName + "*", SearchOption.AllDirectories))
                {
                    lstSearchResults.Items.Add(file);
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            PerformFileAction(filePath => Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true }), "Error opening file");
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (lstSearchResults.SelectedItem != null && !string.IsNullOrWhiteSpace(txtNewName.Text))
            {
                string oldFilePath = lstSearchResults.SelectedItem.ToString();
                string newFilePath = Path.Combine(Path.GetDirectoryName(oldFilePath), txtNewName.Text + Path.GetExtension(oldFilePath));
                PerformFileAction(filePath => File.Move(filePath, newFilePath), "Error renaming file");
                lstSearchResults.Items[lstSearchResults.SelectedIndex] = newFilePath;
            }
            else
            {
                MessageBox.Show("Please select a file and enter a new name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            PerformFileAction(filePath =>
            {
                string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath) + " - copy" + Path.GetExtension(filePath));
                File.Copy(filePath, newFilePath);
                lstSearchResults.Items.Add(newFilePath);
            }, "Error copying file");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PerformFileAction(filePath =>
            {
                File.Delete(filePath);
                lstSearchResults.Items.Remove(lstSearchResults.SelectedItem);
            }, "Error deleting file");
        }

        private void PerformFileAction(Action<string> fileAction, string errorMessage)
        {
            if (lstSearchResults.SelectedItem != null)
            {
                string filePath = lstSearchResults.SelectedItem.ToString();
                try
                {
                    if (File.Exists(filePath))
                    {
                        fileAction(filePath);
                        MessageBox.Show("Operation successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{errorMessage}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
