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
    public partial class TableStatusSettingFrm : Form
    {

        private TableStatusType _settings = null;

        public TableStatusSettingFrm(TableStatusType setting)
        {
            InitializeComponent();

            _settings = setting;

            this.textEditorControl.Text = _settings.Settings == null ? "" : _settings.Settings.Trim();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            DBGlobalService.FireClearError();
            var conn = ConnectionManager.Get(DBGlobalService.ConnectionString);
            conn.Parse_TableStatus(_settings.Settings);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.Settings = this.textEditorControl.Text.Trim();

            DBGlobalService.Save();

            DBGlobalService.FireClearError();
            var conn = ConnectionManager.Get(DBGlobalService.ConnectionString);
            
            conn.Parse_TableStatus(_settings.Settings);

            ConnectionManager.Update(conn);
        }
    }
}
