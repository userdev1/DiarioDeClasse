using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net;

namespace DiarioDeClasse
{
    public partial class turmas : UserControl
    {

        public turmas()
        {
            InitializeComponent();
            label1.Font = new System.Drawing.Font(Vars.ff[1], label1.Font.Size, FontStyle.Bold);
            label1.Tag = label1.Height / label1.Font.Size;
        }
        public void lerSalas()
        {
            zerar();
            int fundMedio = 0;
            if (rbFund1.Checked)
                fundMedio = 1;
            if (rbFund2.Checked)
                fundMedio = 2;
            if (rbMedio.Checked)
                fundMedio = 3;
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                MySqlCommand checarSalas = new MySqlCommand("SELECT * FROM info_salas WHERE fund_medio = @FundMedio ORDER BY nome_sala ASC", CONEXAO);
                checarSalas.Parameters.AddWithValue("@FundMedio", fundMedio);
                try
                {
                    CONEXAO.Open();

                    MySqlDataReader lerSalas = checarSalas.ExecuteReader();

                    while (lerSalas.Read())
                    {
                        addBotao(lerSalas["nome_sala"].ToString(), fundMedio);
                    }
                    lerSalas.Close();
                }
                catch (Exception erro)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                }
                finally
                {
                    CONEXAO.Close();
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/turmas/addBotao.php?fundmedio=" + fundMedio.ToString()).Trim();
                string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string teste in reps)
                {
                    addBotao(teste, fundMedio);
                }
            }
        }
        public void addBotao(string sala, int fundMedio)
        {
            if (fundMedio == 3)
            {
                if (sala[0] == '1')
                {
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText != "" && btn41.ButtonText != "" && btn51.ButtonText == "")
                    {
                        btn51.Enabled = true;
                        btn51.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText != "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn41.Enabled = true;
                        btn41.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn31.Enabled = true;
                        btn31.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText == "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn21.Enabled = true;
                        btn21.ButtonText = sala;
                    }
                    if (btn11.ButtonText == "" && btn21.ButtonText == "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn11.Enabled = true;
                        btn11.ButtonText = sala;
                    }
                }
                if (sala[0] == '2')
                {
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText != "" && btn43.ButtonText != "" && btn53.ButtonText == "")
                    {
                        btn53.Enabled = true;
                        btn53.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText != "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn43.Enabled = true;
                        btn43.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn33.Enabled = true;
                        btn33.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText == "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn23.Enabled = true;
                        btn23.ButtonText = sala;
                    }
                    if (btn13.ButtonText == "" && btn23.ButtonText == "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn13.Enabled = true;
                        btn13.ButtonText = sala;
                    }
                }
                if (sala[0] == '3')
                {
                    if (btn15.ButtonText != "" && btn25.ButtonText != "" && btn35.ButtonText != "" && btn45.ButtonText != "" && btn55.ButtonText == "")
                    {
                        btn55.Enabled = true;
                        btn55.ButtonText = sala;
                    }
                    if (btn15.ButtonText != "" && btn25.ButtonText != "" && btn35.ButtonText != "" && btn45.ButtonText == "" && btn55.ButtonText == "")
                    {
                        btn45.Enabled = true;
                        btn45.ButtonText = sala;
                    }
                    if (btn15.ButtonText != "" && btn25.ButtonText != "" && btn35.ButtonText == "" && btn45.ButtonText == "" && btn55.ButtonText == "")
                    {
                        btn35.Enabled = true;
                        btn35.ButtonText = sala;
                    }
                    if (btn15.ButtonText != "" && btn25.ButtonText == "" && btn35.ButtonText == "" && btn45.ButtonText == "" && btn55.ButtonText == "")
                    {
                        btn25.Enabled = true;
                        btn25.ButtonText = sala;
                    }
                    if (btn15.ButtonText == "" && btn25.ButtonText == "" && btn35.ButtonText == "" && btn45.ButtonText == "" && btn55.ButtonText == "")
                    {
                        btn15.Enabled = true;
                        btn15.ButtonText = sala;
                    }
                }
            }
            if (fundMedio == 1)
            {
                if (sala[0] == '1')
                {
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText != "" && btn41.ButtonText != "" && btn51.ButtonText == "")
                    {
                        btn51.Enabled = true;
                        btn51.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText != "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn41.Enabled = true;
                        btn41.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn31.Enabled = true;
                        btn31.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText == "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn21.Enabled = true;
                        btn21.ButtonText = sala;
                    }
                    if (btn11.ButtonText == "" && btn21.ButtonText == "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn11.Enabled = true;
                        btn11.ButtonText = sala;
                    }
                }
                if (sala[0] == '2')
                {
                    if (btn12.ButtonText != "" && btn22.ButtonText != "" && btn32.ButtonText != "" && btn42.ButtonText != "" && btn52.ButtonText == "")
                    {
                        btn52.Enabled = true;
                        btn52.ButtonText = sala;
                    }
                    if (btn12.ButtonText != "" && btn22.ButtonText != "" && btn32.ButtonText != "" && btn42.ButtonText == "" && btn52.ButtonText == "")
                    {
                        btn42.Enabled = true;
                        btn42.ButtonText = sala;
                    }
                    if (btn12.ButtonText != "" && btn22.ButtonText != "" && btn32.ButtonText == "" && btn42.ButtonText == "" && btn52.ButtonText == "")
                    {
                        btn32.Enabled = true;
                        btn32.ButtonText = sala;
                    }
                    if (btn12.ButtonText != "" && btn22.ButtonText == "" && btn32.ButtonText == "" && btn42.ButtonText == "" && btn52.ButtonText == "")
                    {
                        btn22.Enabled = true;
                        btn22.ButtonText = sala;
                    }
                    if (btn12.ButtonText == "" && btn22.ButtonText == "" && btn32.ButtonText == "" && btn42.ButtonText == "" && btn52.ButtonText == "")
                    {
                        btn12.Enabled = true;
                        btn12.ButtonText = sala;
                    }
                }
                if (sala[0] == '3')
                {
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText != "" && btn43.ButtonText != "" && btn53.ButtonText == "")
                    {
                        btn53.Enabled = true;
                        btn53.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText != "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn43.Enabled = true;
                        btn43.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn33.Enabled = true;
                        btn33.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText == "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn23.Enabled = true;
                        btn23.ButtonText = sala;
                    }
                    if (btn13.ButtonText == "" && btn23.ButtonText == "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn13.Enabled = true;
                        btn13.ButtonText = sala;
                    }
                }
                if (sala[0] == '4')
                {
                    if (btn14.ButtonText != "" && btn24.ButtonText != "" && btn34.ButtonText != "" && btn44.ButtonText != "" && btn54.ButtonText == "")
                    {
                        btn54.Enabled = true;
                        btn54.ButtonText = sala;
                    }
                    if (btn14.ButtonText != "" && btn24.ButtonText != "" && btn34.ButtonText != "" && btn44.ButtonText == "" && btn54.ButtonText == "")
                    {
                        btn44.Enabled = true;
                        btn44.ButtonText = sala;
                    }
                    if (btn14.ButtonText != "" && btn24.ButtonText != "" && btn34.ButtonText == "" && btn44.ButtonText == "" && btn54.ButtonText == "")
                    {
                        btn34.Enabled = true;
                        btn34.ButtonText = sala;
                    }
                    if (btn14.ButtonText != "" && btn24.ButtonText == "" && btn34.ButtonText == "" && btn44.ButtonText == "" && btn54.ButtonText == "")
                    {
                        btn24.Enabled = true;
                        btn24.ButtonText = sala;
                    }
                    if (btn14.ButtonText == "" && btn24.ButtonText == "" && btn34.ButtonText == "" && btn44.ButtonText == "" && btn54.ButtonText == "")
                    {
                        btn14.Enabled = true;
                        btn14.ButtonText = sala;
                    }
                }
                if (sala[0] == '5')
                {
                    if (btn15.ButtonText != "" && btn25.ButtonText != "" && btn35.ButtonText != "" && btn45.ButtonText != "" && btn55.ButtonText == "")
                    {
                        btn55.Enabled = true;
                        btn55.ButtonText = sala;
                    }
                    if (btn15.ButtonText != "" && btn25.ButtonText != "" && btn35.ButtonText != "" && btn45.ButtonText == "" && btn55.ButtonText == "")
                    {
                        btn45.Enabled = true;
                        btn45.ButtonText = sala;
                    }
                    if (btn15.ButtonText != "" && btn25.ButtonText != "" && btn35.ButtonText == "" && btn45.ButtonText == "" && btn55.ButtonText == "")
                    {
                        btn35.Enabled = true;
                        btn35.ButtonText = sala;
                    }
                    if (btn15.ButtonText != "" && btn25.ButtonText == "" && btn35.ButtonText == "" && btn45.ButtonText == "" && btn55.ButtonText == "")
                    {
                        btn25.Enabled = true;
                        btn25.ButtonText = sala;
                    }
                    if (btn15.ButtonText == "" && btn25.ButtonText == "" && btn35.ButtonText == "" && btn45.ButtonText == "" && btn55.ButtonText == "")
                    {
                        btn15.Enabled = true;
                        btn15.ButtonText = sala;
                    }
                }
            }
            if (fundMedio == 2)
            {
                if (sala[0] == '6')
                {
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText != "" && btn41.ButtonText != "" && btn51.ButtonText == "")
                    {
                        btn51.Enabled = true;
                        btn51.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText != "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn41.Enabled = true;
                        btn41.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText != "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn31.Enabled = true;
                        btn31.ButtonText = sala;
                    }
                    if (btn11.ButtonText != "" && btn21.ButtonText == "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn21.Enabled = true;
                        btn21.ButtonText = sala;
                    }
                    if (btn11.ButtonText == "" && btn21.ButtonText == "" && btn31.ButtonText == "" && btn41.ButtonText == "" && btn51.ButtonText == "")
                    {
                        btn11.Enabled = true;
                        btn11.ButtonText = sala;
                    }
                }
                if (sala[0] == '7')
                {
                    if (btn12.ButtonText != "" && btn22.ButtonText != "" && btn32.ButtonText != "" && btn42.ButtonText != "" && btn52.ButtonText == "")
                    {
                        btn52.Enabled = true;
                        btn52.ButtonText = sala;
                    }
                    if (btn12.ButtonText != "" && btn22.ButtonText != "" && btn32.ButtonText != "" && btn42.ButtonText == "" && btn52.ButtonText == "")
                    {
                        btn42.Enabled = true;
                        btn42.ButtonText = sala;
                    }
                    if (btn12.ButtonText != "" && btn22.ButtonText != "" && btn32.ButtonText == "" && btn42.ButtonText == "" && btn52.ButtonText == "")
                    {
                        btn32.Enabled = true;
                        btn32.ButtonText = sala;
                    }
                    if (btn12.ButtonText != "" && btn22.ButtonText == "" && btn32.ButtonText == "" && btn42.ButtonText == "" && btn52.ButtonText == "")
                    {
                        btn22.Enabled = true;
                        btn22.ButtonText = sala;
                    }
                    if (btn12.ButtonText == "" && btn22.ButtonText == "" && btn32.ButtonText == "" && btn42.ButtonText == "" && btn52.ButtonText == "")
                    {
                        btn12.Enabled = true;
                        btn12.ButtonText = sala;
                    }
                }
                if (sala[0] == '8')
                {
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText != "" && btn43.ButtonText != "" && btn53.ButtonText == "")
                    {
                        btn53.Enabled = true;
                        btn53.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText != "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn43.Enabled = true;
                        btn43.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText != "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn33.Enabled = true;
                        btn33.ButtonText = sala;
                    }
                    if (btn13.ButtonText != "" && btn23.ButtonText == "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn23.Enabled = true;
                        btn23.ButtonText = sala;
                    }
                    if (btn13.ButtonText == "" && btn23.ButtonText == "" && btn33.ButtonText == "" && btn43.ButtonText == "" && btn53.ButtonText == "")
                    {
                        btn13.Enabled = true;
                        btn13.ButtonText = sala;
                    }
                }
                if (sala[0] == '9')
                {
                    if (btn14.ButtonText != "" && btn24.ButtonText != "" && btn34.ButtonText != "" && btn44.ButtonText != "" && btn54.ButtonText == "")
                    {
                        btn54.Enabled = true;
                        btn54.ButtonText = sala;
                    }
                    if (btn14.ButtonText != "" && btn24.ButtonText != "" && btn34.ButtonText != "" && btn44.ButtonText == "" && btn54.ButtonText == "")
                    {
                        btn44.Enabled = true;
                        btn44.ButtonText = sala;
                    }
                    if (btn14.ButtonText != "" && btn24.ButtonText != "" && btn34.ButtonText == "" && btn44.ButtonText == "" && btn54.ButtonText == "")
                    {
                        btn34.Enabled = true;
                        btn34.ButtonText = sala;
                    }
                    if (btn14.ButtonText != "" && btn24.ButtonText == "" && btn34.ButtonText == "" && btn44.ButtonText == "" && btn54.ButtonText == "")
                    {
                        btn24.Enabled = true;
                        btn24.ButtonText = sala;
                    }
                    if (btn14.ButtonText == "" && btn24.ButtonText == "" && btn34.ButtonText == "" && btn44.ButtonText == "" && btn54.ButtonText == "")
                    {
                        btn14.Enabled = true;
                        btn14.ButtonText = sala;
                    }
                }
            }
        }
        public void zerar()
        {
            foreach (Control aa in tableLayoutPanel3.Controls)
            {
                if (aa is Bunifu.Framework.UI.BunifuThinButton2)
                {
                    var aaa = (Bunifu.Framework.UI.BunifuThinButton2)aa;
                    aaa.Enabled = aaa.Visible = false;
                    aaa.ButtonText = "";
                }
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuThinButton2 clickedButton = sender as Bunifu.Framework.UI.BunifuThinButton2;
            Vars.teste.Controls.Clear();
            Vars.af.info = new info(clickedButton.ButtonText, false) { Dock = DockStyle.Fill };
            Vars.teste.Controls.Add(Vars.af.info);
        }
        private void turmas_Load(object sender, EventArgs e)
        {
            rbMedio.Checked = true;

            /*foreach (Control aa in tableLayoutPanel3.Controls)
            {
                if (aa is Bunifu.Framework.UI.BunifuThinButton2)
                {
                    var aaa = (Bunifu.Framework.UI.BunifuThinButton2)aa;
                    aaa.Tag = aaa.Height / aaa.Font.Size;
                    MessageBox.Show(aaa.Name + "  " + aaa.Tag.ToString());
                    if (aaa.ButtonText == "" || aaa.ButtonText == "ThinButton")
                        aaa.Visible = false;
                    else
                        aaa.Show();
                    aaa.Refresh();
                }
            }*/
        }
        private void turmas_VisibleChanged(object sender, EventArgs e)
        {
            foreach (Control aa in tableLayoutPanel3.Controls)
            {
                if (aa is Bunifu.Framework.UI.BunifuThinButton2)
                {
                    var aaa = (Bunifu.Framework.UI.BunifuThinButton2)aa;
                    if (aaa.ButtonText == "" || aaa.ButtonText == "ThinButton")
                        aaa.Visible = false;
                    else
                        aaa.Show();
                    aaa.Refresh();
                }
            }
        }
        private void rbMedio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton grr = sender as RadioButton;
            if (grr.Name == "rbFund1")
            {
                if (grr.Checked)
                {
                    rbFund2.Checked = false;
                    rbMedio.Checked = false;
                    lerSalas();
                }
            }
            if (grr.Name == "rbFund2")
            {
                if (grr.Checked)
                {
                    rbFund1.Checked = false;
                    rbMedio.Checked = false;
                    lerSalas();
                }
            }
            if (grr.Name == "rbMedio")
            {
                if (grr.Checked)
                {
                    rbFund1.Checked = false;
                    rbFund2.Checked = false;
                    lerSalas();
                }
            }

            foreach (Control aa in tableLayoutPanel3.Controls)
            {
                if (aa is Bunifu.Framework.UI.BunifuThinButton2)
                {
                    var aaa = (Bunifu.Framework.UI.BunifuThinButton2)aa;
                    aaa.Tag = aaa.Height / aaa.Font.Size;
                    if (aaa.ButtonText == "" || aaa.ButtonText == "ThinButton")
                        aaa.Visible = false;
                    else
                        aaa.Show();
                    aaa.Refresh();
                }
            }
            tableLayoutPanel3_Resize(tableLayoutPanel3, null);
        }

        private void tableLayoutPanel3_Resize(object sender, EventArgs e)
        {
            foreach (Control aa in tableLayoutPanel3.Controls)
            {
                if (aa is Bunifu.Framework.UI.BunifuThinButton2)
                {
                    Vars.resize(aa);
                }
            }
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            Vars.resize(label1);
        }
    }
}
