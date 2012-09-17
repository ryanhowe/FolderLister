using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FolderReaderWriter;

namespace FolderListing
{
    /// <summary>
    /// Form to prompt user for folder to list and where to save listing
    /// </summary>
    public partial class FolderLister : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderLister" /> class.
        /// </summary>
        public FolderLister()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            var browser = new FolderBrowserDialog();
            if (DialogResult.OK == browser.ShowDialog())
            {
                textBoxFolderPath.Text = browser.SelectedPath;
            }
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            var saveAs = new SaveFileDialog();
            saveAs.AddExtension = true;
            saveAs.DefaultExt = ".csv";

            if (DialogResult.OK == saveAs.ShowDialog())
                textBoxSaveAs.Text = saveAs.FileName;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!ValidateSelections())
                return;

            var folderReader = new Reader(textBoxFolderPath.Text);
            var files = folderReader.ReadFiles();
            var writer = new Writer(textBoxSaveAs.Text, files);
            writer.Write();
            MessageBox.Show("Report complete", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private bool ValidateSelections()
        {
            var valid = true;
            if (String.IsNullOrEmpty(textBoxFolderPath.Text.Trim()))
            {
                errorProvider1.SetError(textBoxFolderPath, "Please specify folder to list");
                valid = false;
            }

            else
                errorProvider1.SetError(textBoxFolderPath, "");

            if (String.IsNullOrEmpty(textBoxSaveAs.Text.Trim()))
            {
                errorProvider1.SetError(textBoxSaveAs, "Please specify where to save listing");
                valid = false;
            }

            else
                errorProvider1.SetError(textBoxSaveAs, "");

            return valid;
        }
    }
}
