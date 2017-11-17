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
    public partial class Dia : UserControl
    {
        BackgroundWorker licao;

        public Dia()
        {
            InitializeComponent();

            lblDiaa.Font = new Font(Vars.ff[1], 35F, FontStyle.Bold);
            lblDiaa.Tag = lblDiaa.Height / lblDiaa.Font.Size;
            btnAdicionar.Tag = btnAdicionar.Height / btnAdicionar.Font.Size;
            btnVoltar.Tag = btnVoltar.Height / btnVoltar.Font.Size;
        }

        private void lblDiaa_Click(object sender, EventArgs e)
        {

        }
        private BackgroundWorker CreateBackgroundWorker()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += licao_DoWork;
            return bw;
        }
        private void licao_DoWork(object sender, DoWorkEventArgs e)
        {
            licao.WorkerSupportsCancellation = true; Invoke(new Action(() =>
            {
                flowLayoutPanel1.Controls.Clear();
            }));
            Bunifu.Framework.UI.BunifuSeparator sep1 = new Bunifu.Framework.UI.BunifuSeparator();
            sep1.Width = flowLayoutPanel1.Width - 30;
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                MySqlCommand checarLicoes = new MySqlCommand("SELECT * FROM licoes INNER JOIN profdisc ON licoes.disc = cod_disc INNER JOIN disc ON discid_disc = cod_discs WHERE mesentrega = @Mes AND diaentrega = @Dia AND sala = @Sala AND avaliado > 0;", CONEXAO);
                try
                {

                    CONEXAO.Open();
                    checarLicoes.Parameters.AddWithValue("@Mes", Vars.mesSelec);
                    checarLicoes.Parameters.AddWithValue("@Dia", Vars.diaSelec);
                    checarLicoes.Parameters.AddWithValue("@Sala", Properties.Settings.Default.codSala);

                    

                    int cod = Convert.ToInt32(checarLicoes.ExecuteScalar());

                    if (cod > 0)
                    {
                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel1.Controls.Add(sep1);
                        }));
                    }

                    MySqlDataReader lerLicoes = checarLicoes.ExecuteReader();


                    while (lerLicoes.Read())
                    {
                        string textolicao = lerLicoes["licao"].ToString();
                        if (textolicao.Substring(textolicao.Length - 1, 1) != "." && textolicao.Substring(textolicao.Length - 1, 1) != "!" && textolicao.Substring(textolicao.Length - 1, 1) != "?" && textolicao.Substring(textolicao.Length - 1, 1) != "\r\n")
                            textolicao += ".";

                        TableLayoutPanel painel = new TableLayoutPanel();
                        painel.AutoSize = true;



                        licaoTit licaoTit = new licaoTit(lerLicoes["nome_disc"].ToString(), flowLayoutPanel1.Width - 31);
                        licaoTit.Height = 35;
                        FontStyle estilo = FontStyle.Regular;
                        if (licaoTit.Font.Bold)
                            estilo = FontStyle.Bold;
                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                            licaoTit.Font = new System.Drawing.Font(licaoTit.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(licaoTit.Font.Size) * 1.5), estilo);
                        painel.Controls.Add(licaoTit);



                        licaoTxt licaoTxt = new licaoTxt(textolicao, flowLayoutPanel1.Width - 31);
                        estilo = FontStyle.Regular;
                        if (licaoTxt.Font.Bold)
                            estilo = FontStyle.Bold;
                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                            licaoTxt.Font = new System.Drawing.Font(licaoTxt.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(licaoTxt.Font.Size) * 1.5), estilo);
                        painel.Controls.Add(licaoTxt);

                        if (lerLicoes["link_anexo"].ToString() != "")
                        {
                            string link = lerLicoes["link_anexo"].ToString();
                            pic picc = new DiarioDeClasse.pic(link, flowLayoutPanel1.Width - 31); //PictureBox pb = new PictureBox();
                            picc.ImageLocation = link;
                            Image img = picc.Image;
                            picc.Image = img;
                            painel.Controls.Add(picc);
                        }


                        AddPor licaoAddPor = new AddPor(lerLicoes["adicionadopor"].ToString(), lerLicoes["cod"].ToString());
                        if (licaoAddPor.Font.Bold)
                            estilo = FontStyle.Bold;
                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                            licaoAddPor.Font = new System.Drawing.Font(licaoAddPor.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(licaoAddPor.Font.Size) * 1.5), estilo);
                        painel.Controls.Add(licaoAddPor);


                        AddEm licaoAddEm = new AddEm(lerLicoes["adicionadoem"].ToString());
                        if (licaoAddEm.Font.Bold)
                            estilo = FontStyle.Bold;
                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                            licaoAddEm.Font = new System.Drawing.Font(licaoAddEm.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(licaoAddEm.Font.Size) * 1.5), estilo);
                        painel.Controls.Add(licaoAddEm);

                        if (Properties.Settings.Default.permInt == 1 || Properties.Settings.Default.permInt == 2 || Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                        {
                            Bunifu.Framework.UI.BunifuTileButton btnExcluir = new Bunifu.Framework.UI.BunifuTileButton();
                            btnExcluir.BackColor = Color.Transparent;
                            btnExcluir.color = Color.Transparent;
                            btnExcluir.colorActive = System.Drawing.Color.DodgerBlue;
                            btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
                            btnExcluir.Image = Properties.Resources.icons8_Trash_Can_64px;
                            btnExcluir.ImagePosition = 0;
                            btnExcluir.ImageZoom = 100;
                            btnExcluir.LabelPosition = 0;
                            btnExcluir.LabelText = "";
                            btnExcluir.Location = new System.Drawing.Point(349, 254);
                            btnExcluir.Margin = new System.Windows.Forms.Padding(6);
                            btnExcluir.Size = new System.Drawing.Size(40, 40);
                            btnExcluir.TabIndex = 0;
                            btnExcluir.Tag = lerLicoes["cod"].ToString();
                            btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
                            btnExcluir.Anchor = AnchorStyles.Right;
                            painel.Controls.Add(btnExcluir);
                        }

                        Bunifu.Framework.UI.BunifuSeparator sep = new Bunifu.Framework.UI.BunifuSeparator();
                        sep.Width = flowLayoutPanel1.Width - 30;

                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel1.Controls.Add(painel);
                            flowLayoutPanel1.Controls.Add(sep);
                        }));

                    }
                    lerLicoes.Close();
                }
                catch (Exception erro)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    if (erro.ToString().ToLower().Contains("system.invalidoperationexception"))
                    {

                    }
                    else
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
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/dia/licao.php?sala=" + Properties.Settings.Default.codSala + "&dia=" + Vars.diaSelec + "&mes=" + Vars.mesSelec).Trim();
                string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                if (resultado != "0")
                {
                    Invoke(new Action(() =>
                    {
                        flowLayoutPanel1.Controls.Add(sep1);
                    }));
                }
                foreach (string teste in reps)
                {
                    string[] codes = teste.Split(new string[] { "@#@" }, StringSplitOptions.RemoveEmptyEntries);
                    if (codes.Length > 3)
                    {
                        string discLicao = codes[0];
                        string codLicao = codes[1];
                        string txtLicao = codes[2];
                        string anexoLicao = "";
                        string addPorLicao = "";
                        string addEmLicao = "";
                        if (codes[3].Contains("imgur"))
                        {
                            anexoLicao = codes[3];
                            addPorLicao = codes[4];
                            addEmLicao = codes[5];
                        }
                        else
                        {
                            addPorLicao = codes[3];
                            addEmLicao = codes[4];
                        }

                        string textolicao = txtLicao;
                        if (textolicao.Substring(textolicao.Length - 1, 1) != "." && textolicao.Substring(textolicao.Length - 1, 1) != "!" && textolicao.Substring(textolicao.Length - 1, 1) != "?" && textolicao.Substring(textolicao.Length - 1, 1) != "\r\n")
                            textolicao += ".";

                        TableLayoutPanel painel = new TableLayoutPanel();
                        painel.AutoSize = true;

                        licaoTit licaoTit = new licaoTit(discLicao, flowLayoutPanel1.Width - 31);
                        licaoTit.Height = 35;
                        FontStyle estilo = FontStyle.Regular;
                        if (licaoTit.Font.Bold)
                            estilo = FontStyle.Bold;
                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                            licaoTit.Font = new System.Drawing.Font(licaoTit.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(licaoTit.Font.Size) * 1.5), estilo);
                        painel.Controls.Add(licaoTit);

                        DateTime dateValue = new DateTime(2017, Convert.ToInt32(Vars.mesSelec), Int32.Parse(Vars.diaSelec));

                        licaoTxt licaoTxt = new licaoTxt(textolicao, flowLayoutPanel1.Width - 31);
                        estilo = FontStyle.Regular;
                        if (licaoTxt.Font.Bold)
                            estilo = FontStyle.Bold;
                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                            licaoTxt.Font = new System.Drawing.Font(licaoTxt.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(licaoTxt.Font.Size) * 1.5), estilo);
                        painel.Controls.Add(licaoTxt);

                        if (anexoLicao != "")
                        {
                            Invoke(new Action(() =>
                            {
                                string link = anexoLicao;
                                pic picc = new DiarioDeClasse.pic(link, flowLayoutPanel1.Width - 31); //PictureBox pb = new PictureBox();
                                picc.ImageLocation = link;
                                Image img = picc.Image;
                                picc.Image = img;
                                painel.Controls.Add(picc);
                            }));
                        }

                        AddPor licaoAddPor = new AddPor(addPorLicao, codLicao);
                        if (licaoAddPor.Font.Bold)
                            estilo = FontStyle.Bold;
                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                            licaoAddPor.Font = new System.Drawing.Font(licaoAddPor.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(licaoAddPor.Font.Size) * 1.5), estilo);
                        painel.Controls.Add(licaoAddPor);


                        AddEm licaoAddEm = new AddEm(addEmLicao);
                        if (licaoAddEm.Font.Bold)
                            estilo = FontStyle.Bold;
                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                            licaoAddEm.Font = new System.Drawing.Font(licaoAddEm.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(licaoAddEm.Font.Size) * 1.5), estilo);
                        painel.Controls.Add(licaoAddEm);

                        if (Properties.Settings.Default.permInt == 1 || Properties.Settings.Default.permInt == 2 || Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                        {
                            Bunifu.Framework.UI.BunifuTileButton btnExcluir = new Bunifu.Framework.UI.BunifuTileButton();
                            btnExcluir.BackColor = Color.Transparent;
                            btnExcluir.color = Color.Transparent;
                            btnExcluir.colorActive = System.Drawing.Color.DodgerBlue;
                            btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
                            btnExcluir.Image = Properties.Resources.icons8_Trash_Can_64px;
                            btnExcluir.ImagePosition = 0;
                            btnExcluir.ImageZoom = 100;
                            btnExcluir.LabelPosition = 0;
                            btnExcluir.LabelText = "";
                            btnExcluir.Location = new System.Drawing.Point(349, 254);
                            btnExcluir.Margin = new System.Windows.Forms.Padding(6);
                            btnExcluir.Size = new System.Drawing.Size(40, 40);
                            btnExcluir.TabIndex = 0;
                            btnExcluir.Tag = codes[1];
                            btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
                            btnExcluir.Anchor = AnchorStyles.Right;
                            painel.Controls.Add(btnExcluir);
                        }

                        Bunifu.Framework.UI.BunifuSeparator sep = new Bunifu.Framework.UI.BunifuSeparator();
                        sep.Width = flowLayoutPanel1.Width - 30;

                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel1.Controls.Add(painel);
                            flowLayoutPanel1.Controls.Add(sep);
                        }));
                    }
                }
            }
        }
        

        public void btnExcluir_Click(object sender, EventArgs e)
        {
            Bunifu.Framework.UI.BunifuTileButton fon = sender as Bunifu.Framework.UI.BunifuTileButton;
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                MySqlCommand apagar = new MySqlCommand("UPDATE licoes SET avaliado = -1 WHERE cod = @Cod", CONEXAO);
                apagar.Parameters.AddWithValue("@Cod", fon.Tag.ToString());
                try
                {
                    CONEXAO.Open();
                    apagar.ExecuteNonQuery();
                }
                catch (Exception erro)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                }
                finally
                {
                    CONEXAO.Close();
                    iniciarBw();
                }
            }
            else
            {
                WebClient kjNegar = new WebClient();
                kjNegar.Encoding = System.Text.Encoding.UTF8;
                string resultadoNegar = kjNegar.DownloadString("http://" + Vars.cfgPhp + "/dia/btnExcluir.php?cod=" + fon.Tag.ToString()).Trim();
                if (resultadoNegar == "1")
                    iniciarBw();
            }
        }
        
        public void iniciarBw()
        {
            if (licao != null)
            {
                licao.CancelAsync();
            }
            licao = CreateBackgroundWorker();
            licao.RunWorkerAsync();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Vars.teste.Controls.Clear();
            Vars.af.addTarefa = new AddTarefa();
            Vars.teste.Controls.Add(Vars.af.addTarefa);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Vars.af.calendario.iniciarBw();
            Vars.teste.Controls.Clear();
            Vars.teste.Controls.Add(Vars.af.calendario);
        }

        private void Dia_Load(object sender, EventArgs e)
        {
            lblDiaa.Text = "Dia " + Vars.diaSelec + " de " + Vars.mesSelec2;
            iniciarBw();
            foreach (Control aa in this.Controls)
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

        private void btnVoltar_Resize(object sender, EventArgs e)
        {
            Vars.resize((Control)sender);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            Vars.resize(lblDiaa);
        }
    }
}
