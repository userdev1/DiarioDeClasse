using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DiarioDeClasse
{
    public partial class Registrar : UserControl
    {
        List<string> aa;
        public Registrar()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int solicPerm = 0;
            if (rbRep.Checked == true)
                solicPerm = 1;
            if (rbProf.Checked == true)
                solicPerm = 2;

            int contasNoIp = 0;


            if (txtUsuario.Text != "" && txtNome.Text != "" && txtSenha.Text != "" && cbSala.selectedValue != "Sua sala:" &&
                txtEmail.Text != "" && txtEmail.Text.Contains("@") && txtSenha.Text == txtSenha2.Text)
            {
                MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                try
                {
                    MySqlCommand registrar = new MySqlCommand("INSERT INTO login VALUES (null, @Nome, @Usuario, @Senha, @Sala, @Cadastro, 0, @SolicPerm, @IP, null, @Email)", CONEXAO);
                    MySqlCommand checarSalas = new MySqlCommand("SELECT * FROM info_salas", CONEXAO);

                    try
                    {
                        CONEXAO.Open();

                        MySqlDataReader lerSalas = checarSalas.ExecuteReader();

                        while (lerSalas.Read())
                        {
                            if (cbSala.selectedValue == lerSalas["nome_sala"].ToString())
                                registrar.Parameters.AddWithValue("@Sala", lerSalas["cod_sala"]);

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

                    CONEXAO.Open();
                    registrar.Parameters.AddWithValue("@Nome", txtNome.Text);
                    registrar.Parameters.AddWithValue("@Usuario", txtUsuario.Text);
                    registrar.Parameters.AddWithValue("@Senha", txtSenha.Text);
                    Vars.atualizarData();
                    registrar.Parameters.AddWithValue("@Cadastro", Vars.ano + "-" + Vars.mes + "-" + Vars.dia + " " + Vars.hora + ":" + Vars.minuto + ":" + Vars.segundo);
                    registrar.Parameters.AddWithValue("@SolicPerm", solicPerm.ToString());
                    registrar.Parameters.AddWithValue("@IP", Properties.Settings.Default.ip);
                    registrar.Parameters.AddWithValue("@Email", txtEmail.Text);
                    registrar.ExecuteNonQuery();
                    CONEXAO.Close();
                    MessageBox.Show("Registrado!");
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
                MessageBox.Show("Existem campos vazios!");
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Vars.teste.Controls.Clear();
            Vars.teste.Controls.Add(Vars.af.login1);
        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            foreach (Control aaa in tableLayoutPanel2.Controls)
            {
                if (aaa is Bunifu.Framework.UI.BunifuMaterialTextbox)
                {
                    aaa.Tag = aaa.Height / aaa.Font.Size;
                }
            }
            foreach (Control aaa in tableLayoutPanel3.Controls)
            {
                if (aaa is Bunifu.Framework.UI.BunifuMaterialTextbox)
                {
                    aaa.Tag = aaa.Height / aaa.Font.Size;
                }
            }

            btnVoltar.Tag = btnVoltar.Height / btnVoltar.Font.Size;
            bunifuThinButton21.Tag = bunifuThinButton21.Height / bunifuThinButton21.Font.Size;
            cbSala.Tag = cbSala.Height / cbSala.Font.Size;

            aa = new List<string>();
            cbSala.Clear();
            cbSala.AddItem("Sua sala:");
            cbSala.selectedIndex = 0;
            MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
            MySqlCommand checarSalas = new MySqlCommand("SELECT * FROM info_salas ORDER BY fund_medio ASC, nome_sala ASC", CONEXAO);
            try
            {
                CONEXAO.Open();

                MySqlDataReader lerSalas = checarSalas.ExecuteReader();

                while (lerSalas.Read())
                {
                    if (!aa.Contains(lerSalas["nome_sala"].ToString()))
                        aa.Add(lerSalas["nome_sala"].ToString());
                }
                lerSalas.Close();
                CONEXAO.Close();
                aa.Sort(StringComparer.CurrentCulture);
                foreach (string aaa in aa)
                {
                    if (aaa != "")
                    cbSala.AddItem(aaa);
                }
            }
            catch (Exception erro)
            {
                if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
            }
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            
            ((Bunifu.Framework.UI.BunifuMaterialTextbox)sender).isPassword = true;
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control a in tableLayoutPanel1.Controls)
            {
                MessageBox.Show(a.Name);
                if (a is TableLayoutPanel)
                    foreach (Control aa in a.Controls)
                    {
                        MessageBox.Show(aa.Name);
                        if (!(aa is Panel))
                            Vars.resize(aa);
                    }
                if (a is Bunifu.Framework.UI.BunifuThinButton2)
                    Vars.resize(a);
            }
        }
    }
}
