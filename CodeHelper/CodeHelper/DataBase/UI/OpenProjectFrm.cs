using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;
using CodeHelper.Xml;

namespace CodeHelper.DataBaseHelper
{
    public partial class OpenProjectFrm : Form
    {
        public OpenProjectFrm()
        {
            InitializeComponent();
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtProjectFile.Text = dlg.FileName.Trim();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtProjectFile.Text))
            {
                if (!string.IsNullOrEmpty(DBGlobalService.ProjectFile))
                {
                    DBGlobalService.Save();
                }
                DBGlobalService.ProjectFile = this.txtProjectFile.Text.Trim();
                
                //ProjectDoc doc = new ProjectDoc();
                var doc = new Document();
                doc.Load(DBGlobalService.ProjectFile);
                DBGlobalService.CurrentProject = new ProjectType(doc);                
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
