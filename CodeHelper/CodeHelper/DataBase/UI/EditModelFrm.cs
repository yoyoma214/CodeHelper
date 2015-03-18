using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.DataBaseHelper.Items;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper
{
    public partial class EditModelFrm : Form
    {
        DBModelNode model = null;
        ColumnSetNode columns = null;
        public EditModelFrm()
        {
            InitializeComponent();
        }
        public void UpdateModel(DBModelNode model, ColumnSetNode columns)
        {
            this.model = model;
            this.columns = columns;

            var source = from column in this.columns.Children
                         select column.Name;
            this.ColumnName.DataSource = source.ToList();

            //this.ColumnName.ValueMember = "Name";
            //this.ColumnName.DisplayMember = "Name";
            source = from t in DbTypeProvider.SystemTypeMap
                     select t.Key;

            this.SystemType.DataSource = source.ToList();
            //this.SystemType.ValueMember = "value";
            //this.SystemType.DisplayMember = "key";
            foreach (BaseNode n in model.Children)
            {
                if ((n is FieldNode) == false)
                    continue;

                FieldNode f = n as FieldNode;
                this.fieldItems.Add(new FieldItem()
                {
                    ColumnName = f.ColumnName,
                    Description = f.Description,
                    Name = f.Name,
                    NullAble = f.NullAble,
                    SystemType = f.SystemType.Name
                });
            }

            this.dataGridView1.DataSource = this.fieldItems;

        }
        List<FieldItem> fieldItems = new List<FieldItem>();
        public IList<FieldItem> FieldItems
        {
            get
            {
                return this.fieldItems;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //this.fieldItems.Clear();
            this.fieldItems = new List<FieldItem>();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (row.IsNewRow)
                    continue;

                //var columns = from f in this.fieldItems
                //              where f.Name == row.Cells["Name"].Value.ToString()
                //              select f;
                FieldItem item = new FieldItem();
                //var obj = row.Cells[0];
                item.Name = row.Cells["MyName"].Value.ToString();
                item.ColumnName = row.Cells["ColumnName"].Value.ToString();
                item.Description = row.Cells["Description"].Value.ToString();
                item.NullAble = (bool)row.Cells["NullAble"].Value;
                item.SystemType = row.Cells["SystemType"].Value.ToString();
                this.fieldItems.Add(item);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public class FieldItem
        {
            public string Name { get; set; }
            public bool NullAble { get; set; }
            public string SystemType{get;set;}
            public string ColumnName { get; set; }
            public string Description { get; set; }
        }
    }
}
