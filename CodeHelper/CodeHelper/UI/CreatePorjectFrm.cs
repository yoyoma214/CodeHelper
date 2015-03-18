using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CodeHelper.Core.Services;

namespace CodeHelper.UI
{
    public partial class CreatePorjectFrm : Form
    {
        public CreatePorjectFrm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSaveDir.Text) &&
               !string.IsNullOrEmpty(this.txtProjectName.Text))
            {
                string selectDir = this.txtSaveDir.Text.Trim();
                string projectName = this.txtProjectName.Text.Trim();

                string path = System.IO.Path.Combine(selectDir, this.txtProjectName.Text.Trim());
                System.IO.Directory.CreateDirectory(path);

                string prjFile = Path.Combine(path, this.txtProjectName.Text.Trim() + ".prj");
                File.Create(prjFile);

                GlobalService.CurrentPrj_Name = this.txtProjectName.Text.Trim();
                GlobalService.CurrentPrj_Dir = path;

                //创建文件夹
                Directory.CreateDirectory(Path.Combine(path, "XmlModel"));
                Directory.CreateDirectory(Path.Combine(path, "DataModel"));
                Directory.CreateDirectory(Path.Combine(path,"DataView"));
                Directory.CreateDirectory(Path.Combine(path, "ViewModel"));
                Directory.CreateDirectory(Path.Combine(path, "WorkFlow"));                

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dlg = new OpenFileDialog();
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtSaveDir.Text = dlg.SelectedPath.Trim();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
