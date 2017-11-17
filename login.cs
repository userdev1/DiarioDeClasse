using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace DiarioDeClasse
{
    public partial class login : UserControl
    {

        BackgroundWorker licao;
        BackgroundWorker iniciar;
        carregando carregando;

        public void conectar()
        {
            Vars.ip = "172.20.10.11";

            if (cbHost.Text == "Localhost")
                Vars.Cfg = "Server=localhost; Database=colanchieta; Userid=root; Pwd=vertrigo";
            if (cbHost.Text == "Servidor Local")
                Vars.Cfg = "Server=" + Vars.ip + "; Database=colanchieta; Userid=aaa; Pwd=aa";
            if (cbHost.Text == "Servidor")
                Vars.Cfg = "Server=colanchieta.mysql.uhserver.com; Database=colanchieta; Userid=userdev; Pwd=@devuser1224";
        }

        public login()
        {
            InitializeComponent();
            Vars.transpPB(pictureBox1);

            foreach (Control aa in tableLayoutPanel1.Controls)
            {
                foreach (Control aaa in aa.Controls)
                {
                    if (aaa is Label || aaa is Bunifu.Framework.UI.BunifuMaterialTextbox)
                        aaa.Tag = aaa.Height / aaa.Font.Size;
                    /*if (aaaa is Bunifu.Framework.UI.BunifuFlatButton)
                        aaaa.Tag = ((Bunifu.Framework.UI.BunifuFlatButton)aaaa).Height / Convert.ToInt32(((Bunifu.Framework.UI.BunifuFlatButton)aaaa).TextFont.Size);*/
                    if (aaa is Bunifu.Framework.UI.BunifuFlatButton)
                        aaa.Tag = aaa.Height / ((Bunifu.Framework.UI.BunifuFlatButton)aaa).TextFont.Size;
                    if (aaa is Panel || aaa is TableLayoutPanel)
                        foreach (Control aaaa in aaa.Controls)
                        {
                            if (aaaa is Label || aaaa is Bunifu.Framework.UI.BunifuMaterialTextbox)
                                aaaa.Tag = aaaa.Height / aaaa.Font.Size;
                            /*if (aaaa is Bunifu.Framework.UI.BunifuFlatButton)
                                aaaa.Tag = ((Bunifu.Framework.UI.BunifuFlatButton)aaaa).Height / Convert.ToInt32(((Bunifu.Framework.UI.BunifuFlatButton)aaaa).TextFont.Size);*/
                            if (aaaa is Bunifu.Framework.UI.BunifuFlatButton)
                                aaaa.Tag = aaaa.Height / ((Bunifu.Framework.UI.BunifuFlatButton)aaaa).TextFont.Size;
                        }
                }
            }
        }

        private void cbHost_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Properties.Settings.Default.servidor = cbHost.SelectedIndex;
            Properties.Settings.Default.Save();
            switch (Properties.Settings.Default.servidor)
            {
                /*case 1:
                    Vars.cfgPhp = "169.254.90.198";
                    Vars.af.bunifuCheckbox1.Checked = false;
                    break;*/
                default:
                    Vars.cfgPhp = "bruno-rodrigues2infoc.000webhostapp.com/php";
                    break;
            }

            txtUser.Enabled = true;
            txtPass.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            cbHost.Enabled = false;
            btnDesc.Enabled = true;
            conectar();
        }

        private void btnDesc_Click_1(object sender, EventArgs e)
        {
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            cbHost.Enabled = true;
            btnDesc.Enabled = false;
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            var teste = (Panel)this.Parent;
            var af = (Form1)teste.Parent;
            teste.Controls.Clear();
            af.registrar = new Registrar() { Dock = DockStyle.Fill };
            teste.Controls.Add(af.registrar);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (txtPass.Text != "" || txtUser.Text != "")
                {
                    if (!Properties.Settings.Default.phpLocal)
                    {
                        string login = "SELECT * FROM login INNER JOIN info_salas ON login.sala_login = cod_sala WHERE usuario_login = @Usuario AND senha_login = @Senha";
                        MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                        MySqlCommand checarLogin = new MySqlCommand(login, CONEXAO);
                        checarLogin.Parameters.AddWithValue("@Usuario", txtUser.Text);
                        checarLogin.Parameters.AddWithValue("@Senha", txtPass.Text);
                        try
                        {//////
                            CONEXAO.Open();
                            int cod = Convert.ToInt32(checarLogin.ExecuteScalar());

                            if (cod > 0)
                            {
                                Vars.af.carregando.Show();
                                MySqlDataReader logar = checarLogin.ExecuteReader();

                                while (logar.Read())
                                {
                                    Properties.Settings.Default.senha = txtPass.Text;
                                    Properties.Settings.Default.cod = logar["cod_login"].ToString();
                                    Properties.Settings.Default.nome = logar["nome_login"].ToString();
                                    Properties.Settings.Default.usuario = logar["usuario_login"].ToString();
                                    Properties.Settings.Default.codSala = Convert.ToInt32(logar["sala_login"]);
                                    Properties.Settings.Default.sala = logar["nome_sala"].ToString();
                                    Properties.Settings.Default.permInt = Convert.ToInt32(logar["perm_login"]);
                                    Vars.checarPermissao();
                                    Properties.Settings.Default.Save();

                                    /*if (logar["aval_login"].ToString() == "")
                                    {
                                        af.timer1.Enabled = true;
                                    }*/

                                }
                                logar.Close();
                                txtUser.Text = "";
                                txtPass.Text = "";
                                Vars.logado = true;

                                Vars.af.sideBar.BackColor = Vars.corFundoSide;
                                Vars.af.btnInicio.Normalcolor = Vars.corFundoSide;
                                Vars.af.btnHorario.Normalcolor = Vars.corFundoSide;
                                Vars.af.btnCalendario.Normalcolor = Vars.corFundoSide;
                                Vars.af.btnTurmas.Normalcolor = Vars.corFundoSide;
                                Vars.af.btnCfg.Normalcolor = Vars.corFundoSide;
                                Vars.af.panel1.Enabled = true;
                                if (Properties.Settings.Default.permInt == 2)
                                {
                                    Vars.af.btnHorario.Enabled = false;
                                    Vars.af.btnHorario.Cursor = Cursors.Default;
                                }
                                else
                                {
                                    Vars.af.btnHorario.Enabled = true;
                                    Vars.af.btnHorario.Cursor = Cursors.Hand;
                                }

                                if (Properties.Settings.Default.permInt < 1)
                                {
                                    Vars.af.btnCfg.Enabled = false;
                                    Vars.af.btnCfg.Cursor = Cursors.Default;
                                }
                                else
                                {
                                    Vars.af.btnCfg.Enabled = true;
                                    Vars.af.btnCfg.Cursor = Cursors.Hand;
                                }
                                this.Hide();
                                Vars.teste = (Panel)this.Parent;
                                Vars.af = (Form1)Vars.teste.Parent;
                                Vars.af.bunifuFlatButton1_Click(Vars.af.btnInicio, null);
                            }
                            else
                            {
                                MessageBox.Show("Dados incorretos!");
                            }
                        }
                        catch (Exception erro)
                        {
                            if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                            if (!erro.ToString().Contains("Null"))
                                MessageBox.Show("Houve um erro no MySql:\r\n" + erro.ToString());
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
                        string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/login.php?user=" + txtUser.Text + "&senha=" + txtPass.Text).Trim();
                        char[] delimiters = new char[] { ',' };
                        string[] codes = resultado.Split(delimiters, StringSplitOptions.None);
                        int i = 0;
                        Properties.Settings.Default.senha = txtPass.Text;
                        Properties.Settings.Default.cod = codes[0];
                        Properties.Settings.Default.nome = codes[1];
                        Properties.Settings.Default.usuario = codes[2];
                        Properties.Settings.Default.codSala = Convert.ToInt32(codes[3]);
                        Properties.Settings.Default.sala = codes[4];
                        Properties.Settings.Default.permInt = Convert.ToInt32(codes[6]);
                        Vars.checarPermissao();
                        Properties.Settings.Default.Save();
                        txtUser.Text = "";
                        txtPass.Text = "";
                        Vars.logado = true;

                        Vars.af.sideBar.BackColor = Vars.corFundoSide;
                        Vars.af.btnInicio.Normalcolor = Vars.corFundoSide;
                        Vars.af.btnHorario.Normalcolor = Vars.corFundoSide;
                        Vars.af.btnCalendario.Normalcolor = Vars.corFundoSide;
                        Vars.af.btnTurmas.Normalcolor = Vars.corFundoSide;
                        Vars.af.btnCfg.Normalcolor = Vars.corFundoSide;
                        Vars.af.panel1.Enabled = true;
                        if (Properties.Settings.Default.permInt == 2)
                        {
                            Vars.af.btnHorario.Enabled = false;
                            Vars.af.btnHorario.Cursor = Cursors.Default;
                        }
                        else
                        {
                            Vars.af.btnHorario.Enabled = true;
                            Vars.af.btnHorario.Cursor = Cursors.Hand;
                        }

                        if (Properties.Settings.Default.permInt < 1)
                        {
                            Vars.af.btnCfg.Enabled = false;
                            Vars.af.btnCfg.Cursor = Cursors.Default;
                        }
                        else
                        {
                            Vars.af.btnCfg.Enabled = true;
                            Vars.af.btnCfg.Cursor = Cursors.Hand;
                        }
                        Vars.af.bunifuFlatButton1_Click(Vars.af.btnInicio, null);
                    }
                }
                else
                {

                    MessageBox.Show("Preencha todos os dados!");
                }
                
            }));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://user404.000webhostapp.com");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblVersao_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if (Vars.HitTest((PictureBox)sender, e.X, e.Y))
                System.Diagnostics.Process.Start("http://user404.000webhostapp.com/UserDev/userdev.html");
         }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.ToString() == "13")
                button1_Click_1(button1, null);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (swt.Value)
            {
                Properties.Settings.Default.lembrarsenha = 1;
            }
            else
            {
                Properties.Settings.Default.lembrarsenha = 0;
            }
            Properties.Settings.Default.Save();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public void iniciarBw()
        {
            if (licao != null)
            {
                licao.CancelAsync();
            }
            licao = CreateBackgroundWorkerLicao();
            licao.RunWorkerAsync();
        }

        public void iniciarBw2()
        {
            if (iniciar != null)
            {
                iniciar.CancelAsync();
            }
            iniciar = CreateBackgroundWorkerIniciar();
            iniciar.RunWorkerAsync();
        }

        private BackgroundWorker CreateBackgroundWorkerLicao()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += licao_DoWork;
            return bw;
        }

        private BackgroundWorker CreateBackgroundWorkerIniciar()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += iniciar_DoWork;
            return bw;
        }

        private void iniciar_DoWork(object sender, DoWorkEventArgs e)
        {
            Vars.af.addTarefa = new AddTarefa() { Dock = DockStyle.Fill };
            //af.calendario = new Calendario();
            //af.info = new info();
            Vars.af.selecMes = new selecMes() { Dock = DockStyle.Fill };
            Vars.af.turmas = new turmas() { Dock = DockStyle.Fill };
        }

        private void licao_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                this.lblTit.ForeColor = Vars.corTit;
                //this.label2.ForeColor = Vars.corTxt;
                //this.label3.ForeColor = Vars.corTxt;
                this.label4.ForeColor = Vars.corTxt;
                this.btnDesc.BackColor = Vars.corfunbtn;
                this.btnDesc.ForeColor = Vars.corBtn;
                this.cbHost.BackColor = Vars.corfunbtn;
                this.button2.BackColor = Vars.corfunbtn;
                this.button2.ForeColor = Vars.corBtn;
                this.button1.BackColor = Vars.corfunbtn;
                this.button1.ForeColor = Vars.corBtn;
                this.lblVersao.ForeColor = Vars.corTxt;
                this.BackColor = Vars.corFundo;

                //Properties.Settings.Default.ip = new WebClient().DownloadString(@"http://icanhazip.com").Trim();
                string versao = "";
                Invoke(new Action(() =>
                {
                    cbHost.SelectedIndex = Properties.Settings.Default.servidor;
                }));
                if (Properties.Settings.Default.phpLocal)
                {
                    WebClient kj = new WebClient();
                    kj.Headers.Add(HttpRequestHeader.Cookie, "__test=42581cd9659c51eea9f4ee998509e2d3; expires=Thu, 31-Dec-37 23:55:55 GMT; path=/");
                    versao = kj.DownloadString("http://" + Vars.cfgPhp + "/versao.php").Trim();
                }
                else
                {
                    MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                    MySqlCommand checarLogin = new MySqlCommand("SELECT * FROM info_diario", CONEXAO);
                    checarLogin.Parameters.AddWithValue("@Usuario", txtUser.Text);
                    checarLogin.Parameters.AddWithValue("@Senha", txtPass.Text);
                    try
                    {
                        CONEXAO.Open();
                        MySqlDataReader logar = checarLogin.ExecuteReader();
                        while (logar.Read())
                        {
                            versao = logar["versao"].ToString();
                        }
                        logar.Close();
                    }
                    finally
                    {
                        CONEXAO.Close();
                    }
                }
                if (Vars.ver == versao)
                {
                    Invoke(new Action(() =>
                    {
                        lblVersao.Text = "Versão atual:\r\n" + versao;
                        txtUser.Enabled = true;
                        txtPass.Enabled = true;
                        button1.Enabled = true;
                        button2.Enabled = true;
                        cbHost.Enabled = false;
                        btnDesc.Enabled = true;
                        lblVersao.Show();
                    }));
                }
                else
                {
                    try
                    {
                        Process.Start(@"AtualizarDiario.exe");
                    }
                    finally
                    {
                        Environment.Exit(1);
                    }

                }
                Invoke(new Action(() =>
                {
                    this.iniciarBw2();
                    /*System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Region = new Region(path);*/
                }));
                if (Properties.Settings.Default.lembrarsenha == 1)
                {
                    Invoke(new Action(() =>
                    {
                        txtUser.Text = Properties.Settings.Default.usuario;
                        txtPass.Text = Properties.Settings.Default.senha;
                        this.button1_Click_1(null, null);
                    }));
                }
            }
            catch (Exception ee)
            {
                if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                MessageBox.Show(ee.ToString());
            }
            finally
            {

                if (!IsHandleCreated)
                    this.CreateControl();
                Invoke(new Action(() =>
                {
                    carregando.Visible = false;
                    this.Visible = true;
                    panel3.Width = panel3.Width - 1;
                    panel3.Width = panel3.Width + 1;




                }));
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        { 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            carregando = Vars.af.carregando;
            carregando.Visible = true;
            this.Visible = false;



            txtUser.Font = new System.Drawing.Font(txtUser.Font.FontFamily, Convert.ToInt32(txtUser.Font.Size + 1));
            txtUser.Font = new System.Drawing.Font(txtUser.Font.FontFamily, Convert.ToInt32(txtUser.Font.Size - 1));
            txtPass.Font = new System.Drawing.Font(txtPass.Font.FontFamily, Convert.ToInt32(txtPass.Font.Size + 1));
            txtPass.Font = new System.Drawing.Font(txtPass.Font.FontFamily, Convert.ToInt32(txtPass.Font.Size - 1));

            lblTit.Font = new Font(Vars.ff[2], lblTit.Font.Size, FontStyle.Bold);
            this.iniciarBw();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        public bool HitTest(PictureBox control, int x, int y)
        {
            var result = false;
            if (control.Image == null)
                return result;
            var method = typeof(PictureBox).GetMethod("ImageRectangleFromSizeMode",
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var r = (Rectangle)method.Invoke(control, new object[] { control.SizeMode });
            using (var bm = new Bitmap(r.Width, r.Height))
            {
                using (var g = Graphics.FromImage(bm))
                    g.DrawImage(control.Image, 0, 0, r.Width, r.Height);
                if (r.Contains(x, y) && bm.GetPixel(x - r.X, y - r.Y).A != 0)
                    result = true;
            }
            return result;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void resize(object sender, EventArgs e)
        {
            Vars.resize((Control)sender);
        }

        private void lblTit_Resize(object grr, EventArgs e)
        {
            Vars.resize(lblTit);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel8_Resize(object sender, EventArgs e)
        {
            Vars.resize(lblVersao);
        }

        private void panel7_Resize(object sender, EventArgs e)
        {
            Vars.resize(label5);
        }

        private void panel10_Resize(object sender, EventArgs e)
        {
            Vars.resize(label5);
        }

        private void panel4_Resize(object sender, EventArgs e)
        {
            Vars.resize(txtPass);

        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            Vars.resize(txtUser);
        }

        private void tableLayoutPanel3_Resize(object sender, EventArgs e)
        {
            Vars.resize(label4);
        }

        private void txtPass_OnValueChanged(object sender, EventArgs e)
        {
            if (txtPass.Text == "a")
            {
                txtPass.Font = new Font(txtPass.Font.FontFamily, 0.01F);
            }
        }

        private void txtPass_OnValueChanged_1(object sender, EventArgs e)
        {
            txtPass.isPassword = true;
        }



        
    }
}
