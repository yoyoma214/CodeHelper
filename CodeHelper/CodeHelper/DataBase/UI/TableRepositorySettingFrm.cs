using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;
using CodeHelper.Core.DbConfig;

namespace CodeHelper.DataBaseHelper.UI
{
    public partial class TableRepositorySettingFrm : Form
    {

        private TableRepositoryType _tableRepository = null;

        public TableRepositorySettingFrm(TableRepositoryType tableRepository)
        {
            InitializeComponent();
            
            _tableRepository = tableRepository;

            this.textEditorControl.Text = _tableRepository.Settings == null ? "" : _tableRepository.Settings.Trim();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            DBGlobalService.FireClearError();
            var conn = ConnectionManager.Get(DBGlobalService.ConnectionString);
            conn.Parse_TableRepository(_tableRepository.Settings);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _tableRepository.Settings = this.textEditorControl.Text.Trim();

            DBGlobalService.Save();
            DBGlobalService.FireClearError();
            var conn = ConnectionManager.Get(DBGlobalService.ConnectionString);
            conn.Parse_TableRepository(_tableRepository.Settings);

            ConnectionManager.Update(conn);
        }
    }
}
