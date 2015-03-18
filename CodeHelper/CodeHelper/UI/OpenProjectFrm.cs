using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.Core.Services;
using System.IO;

namespace CodeHelper.UI
{
    public partial class OpenProjectFrm : Form
    {
        public OpenProjectFrm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtProjectFile.Text = dlg.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtProjectFile.Text))
            {
                if (!string.IsNullOrEmpty(GlobalService.CurrentPrj_Name))
                {
                    GlobalService.Save();
                }
                GlobalService.CurrentPrj_Name = Path.GetFileName(this.txtProjectFile.Text.Trim());
                GlobalService.CurrentPrj_Dir = this.txtProjectFile.Text;
                
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
