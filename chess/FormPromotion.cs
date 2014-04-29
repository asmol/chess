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
    public partial class FormPromotion : Form, IFormPromotion
    {
        public FormPromotion()
        {
            InitializeComponent();
        }

        public event FigureChosenHandler FigureChosen;

        private void FormPromotion_Shown(object sender, EventArgs e)
        {
            RBQueen.Checked = true;
        }

        private void BOK_Click(object sender, EventArgs e)
        {
            var button = GBPromotion.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            FigureChosen(this,new FigureChosenEventArgs((EPawnPromotion)Enum.Parse(typeof(EPawnPromotion),(button as RadioButton).Text)));
            Hide();
        }
    }
}