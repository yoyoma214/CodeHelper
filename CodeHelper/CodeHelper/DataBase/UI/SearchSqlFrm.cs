using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;
using CodeHelper.DataBaseHelper;
using ICSharpCode.TextEditor.Document;

namespace CodeHelper.DataBase.UI
{
    public partial class SearchSqlFrm : Form
    {
        //private TableType Table { get; set; }

        public SearchSqlFrm(TableType table)
        {
            InitializeComponent();
            this.textEditorControl1.Document.HighlightingStrategy =
               HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");

        }

        private void btnGenInsertSql_Click(object sender, EventArgs e)
        {
            try
            {
                var helper = new DbHelper(DBGlobalService.Connection);
                var sql = this.textEditorControl1.Text.Trim();
                var ds = helper.ExecuteDataSet(sql);
                var insertSql = "insert into " + ds.Tables[0].TableName;
                insertSql += "(";
                foreach (DataColumn column in ds.Tables[0].Columns)
                {
                    
                    insertSql += column.ColumnName;
                }
                insertSql += ")";

                foreach (var row in ds.Tables[0].Rows)
                {

                }
                helper.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
