using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeHelper.Core.UI
{
    public delegate void FindTextChange(string text);

    public partial class FindFrm : Form
    {
        public event FindTextChange OnFindTextChange;

        public FindFrm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tbText.Text))
            {
                return;
            }

            if (OnFindTextChange != null)
                OnFindTextChange(this.tbText.Text.Trim());
        }
    }
}
