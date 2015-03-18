using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.Repository;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.Forms
{
    class FormNode : BaseNode
    {
        private FormView formView;

        public FormView FormView
        {
            get
            {
                return formView;
            }
            set
            {
                this.Text = this.Name = value.Name;
                this.formView = value;

                this.formView.OnName_ProperyChanged += new CodeHelper.Xml.ProperyChanged<string>(service_Name_ProperyChanged);
            }
        }

        void service_Name_ProperyChanged(string oldValue, string newVal)
        {
            this.Text = this.Name = newVal;
        }

        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
                if (this.formView != null)
                {
                    this.formView.Name = value;
                }
            }
        }

        protected override void OnDelete(object sender, EventArgs args)
        {
            base.OnDelete(sender, args);

            this.FormView.RemoveSelf();
        }

        protected override void OnEdit(object sender, EventArgs args)
        {
            //base.OnEdit(sender, args);

            var frm = new FormViewFrm(this.formView);

            frm.ShowDialog();

            //frm.Text
        }
    }
}
