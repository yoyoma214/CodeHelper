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
    public partial class CreatePorjectFrm : Form
    {
        public CreatePorjectFrm()
        {
            InitializeComponent();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtSaveDir.Text) &&
                !string.IsNullOrEmpty(this.txtProjectName.Text))
            {
                string selectDir = this.txtSaveDir.Text.Trim();
                string projectName = this.txtProjectName.Text.Trim();
                
                string path = System.IO.Path.Combine(selectDir, this.txtProjectName.Text.Trim());
                System.IO.Directory.CreateDirectory(path);
                
                DBGlobalService.ProjectFile = System.IO.Path.Combine(path, projectName+".xml");
                
                //doc.SetSchemaLocation(GlobalService.ConfigXsd);
                if (!System.IO.File.Exists(DBGlobalService.ProjectFile))
                {
                    var stream = System.IO.File.Create(DBGlobalService.ProjectFile);
                    stream.Close();
                }
                var doc = new Document();
                DBGlobalService.CurrentProjectDoc = doc;
                //doc.Load(GlobalService.ProjectFile);
                var prj = doc.CreateNode<ProjectType>();
                doc.Root = prj;
                DBGlobalService.CurrentProject = prj;
                DBGlobalService.CurrentProject.Name = projectName ;  
              
                doc.Save(DBGlobalService.ProjectFile);        
        
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
