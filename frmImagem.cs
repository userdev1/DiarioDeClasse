using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiarioDeClasse
{
    public partial class frmImagem : Form
    {
        public frmImagem(Image grr)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            pictureBox1.Image = grr;
        }
        public frmImagem(string grr)
        {
            InitializeComponent();
            pictureBox1.LoadAsync(grr);
        }
        private void frmImagem_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
