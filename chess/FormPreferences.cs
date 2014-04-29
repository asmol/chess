using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace chess
{
    public partial class FormPreferences : Form
    {
        public FormPreferences()
        {
            InitializeComponent();

            CBTimeEnabled_CheckedChanged(null,null);
        }

        private void BOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void CBTimeEnabled_CheckedChanged(object sender, EventArgs e)
        {
            MTBTimeWhite.Enabled = CBTimeEnabled.Checked;
            MTBTimeBlack.Enabled = CBTimeEnabled.Checked;
        }
    }
}
