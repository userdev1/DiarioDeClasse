using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiarioDeClasse
{
    public partial class carregando : UserControl
    {
        public carregando()
        {
            InitializeComponent();
            bunifuCircleProgressbar1.ProgressColor = Vars.corFundoSide;
            label1.ForeColor = Vars.corTit;
            this.Dock = DockStyle.Fill;
            label1.Tag = label1.Height / label1.Font.Size;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!IsHandleCreated)
                this.CreateControl();
            Invoke(new Action(() =>
            {
                if (label1.Text == "Carregando" || label1.Text == "Carregando." || label1.Text == "Carregando..")
                    label1.Text += ".";
                else
                    label1.Text = "Carregando";
            }));
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            Vars.resize(label1);
        }

    }
}
