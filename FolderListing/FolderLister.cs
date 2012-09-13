using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FolderReader;

namespace FolderListing
{
    public partial class FolderLister : Form
    {
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
            if (DialogResult.OK== browser.ShowDialog())
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
            var folderReader = new Reader(textBoxFolderPath.Text);
            var files = folderReader.ReadFiles();
            var writer = new Writer(textBoxSaveAs.Text, files);
            writer.Write();
            MessageBox.Show("Report complete", "Complete", MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
        }
    }
}
