using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using WMPLib;
using System.Media;

namespace DiarioDeClasse
{
    public partial class principal : UserControl
    {
        public principal()
        {
            InitializeComponent();
            lblAvisoTit.ForeColor = Vars.corTit;
            lblLicaoTit.ForeColor = Vars.corTit;
            lblVerifTit.ForeColor = Vars.corTit;
            lblAvisoTit.Font = new System.Drawing.Font(Vars.ff[0], lblAvisoTit.Font.Size, FontStyle.Bold);
            lblLicaoTit.Font = new System.Drawing.Font(Vars.ff[0], lblLicaoTit.Font.Size, FontStyle.Bold);
            lblVerifTit.Font = new System.Drawing.Font(Vars.ff[0], lblVerifTit.Font.Size, FontStyle.Bold);
        }

        public BackgroundWorker licao, aviso, rep;

        MySqlConnection CONEXAOaaa = new MySqlConnection(Vars.Cfg);

        carregando carregando;

        private void principal_Load(object sender, EventArgs e)
        {
            /*carregando = Vars.af.carregando;
            carregando.Visible = true;
            this.Visible = false;*/
            iniciarBw();
            Vars.af.iniciarBw();
            this.Visible = false;
            this.Visible = true;
        }

        public void iniciarBw()
        {
            //flowLayoutPanel1.Controls.Clear();
            //flowLayoutPanel2.Controls.Clear();
            if (licao != null)
            {
                licao.CancelAsync();
            }
            licao = CreateBackgroundWorkerLicao();
            licao.RunWorkerAsync();
            if (aviso != null)
            {
                aviso.CancelAsync();
            }
            aviso = CreateBackgroundWorkerAviso();
            aviso.RunWorkerAsync();
            if (Properties.Settings.Default.permInt == 1)
            {
                if (rep != null)
                {
                    rep.CancelAsync();
                }
                rep = CreateBackgroundWorkerRep();
                rep.RunWorkerAsync();
            }
        }

        public BackgroundWorker CreateBackgroundWorkerLicao()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += licao_DoWork;
            return bw;
        }

        public BackgroundWorker CreateBackgroundWorkerAviso()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += aviso_DoWork;
            return bw;
        }

        public BackgroundWorker CreateBackgroundWorkerRep()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += rep_DoWork;
            return bw;
        }

        private void rep_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {
                panelVerif.Controls.Clear();
            }));
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAObw = new MySqlConnection(Vars.Cfg);
                MySqlCommand checarTarefas = new MySqlCommand("SELECT * FROM licoes INNER JOIN profdisc ON licoes.disc = cod_disc INNER JOIN info_salas ON sala = cod_sala INNER JOIN disc ON discid_disc = cod_discs WHERE avaliado = 0 AND avaliado != -1 AND nome_sala = @Sala", CONEXAObw);
                checarTarefas.Parameters.AddWithValue("@Sala", Properties.Settings.Default.sala);
                try
                {
                    CONEXAObw.Open();
                    MySqlDataReader lerTarefas = checarTarefas.ExecuteReader();
                    while (lerTarefas.Read())
                    {
                        Bunifu.Framework.UI.BunifuSeparator sep = new Bunifu.Framework.UI.BunifuSeparator();

                        if (!Vars.af.aRep2.Contains(lerTarefas["cod"].ToString()))
                            Vars.af.aRep2.Add(lerTarefas["cod"].ToString());

                        string licao = lerTarefas["licao"].ToString();
                        if (licao.Substring(licao.Length - 1, 1) != "." && licao.Substring(licao.Length - 1, 1) != "!" && licao.Substring(licao.Length - 1, 1) != "?" && licao.Substring(licao.Length - 1, 1) != "\r\n")
                            licao += ".";

                        TableLayoutPanel painel = new TableLayoutPanel();
                        painel.AutoSize = true;

                        licaoTit licaoTit = new licaoTit(lerTarefas["nome_disc"].ToString(), panelVerif.Width - 31);
                        painel.Controls.Add(licaoTit);

                        licaoTxt licaoTxt = new licaoTxt(licao, panelVerif.Width - 31);
                        painel.Controls.Add(licaoTxt);

                        if (lerTarefas["link_anexo"].ToString() != "")
                        {
                            Invoke(new Action(() =>
                            {
                                string link = lerTarefas["link_anexo"].ToString();
                                pic pic = new DiarioDeClasse.pic(link, panelVerif.Width - 31); //PictureBox pb = new PictureBox();
                                pic.ImageLocation = link;
                                Image img = pic.Image;
                                pic.Image = img;
                                painel.Controls.Add(pic);
                            }));
                        }

                        AddPor licaoAddPor = new AddPor(lerTarefas["adicionadopor"].ToString(), lerTarefas["cod"].ToString());
                        painel.Controls.Add(licaoAddPor);


                        AddEm licaoAddEm = new AddEm(lerTarefas["adicionadoem"].ToString());
                        painel.Controls.Add(licaoAddEm);

                        Panel grr = new Panel();
                        grr.Height = 40;
                        grr.Width = 42;
                        grr.Dock = DockStyle.Fill;

                        Bunifu.Framework.UI.BunifuTileButton btnAceitar = new Bunifu.Framework.UI.BunifuTileButton();
                        btnAceitar.BackColor = Color.Transparent;
                        btnAceitar.color = Color.Transparent;
                        btnAceitar.colorActive = System.Drawing.Color.DodgerBlue;
                        btnAceitar.Cursor = System.Windows.Forms.Cursors.Hand;
                        btnAceitar.Image = Properties.Resources.icons8_Ok_64px;
                        btnAceitar.ImagePosition = 0;
                        btnAceitar.ImageZoom = 100;
                        btnAceitar.LabelPosition = 0;
                        btnAceitar.LabelText = "";
                        btnAceitar.Size = new System.Drawing.Size(28, 28);
                        btnAceitar.TabIndex = 0;
                        btnAceitar.Tag = lerTarefas["cod"].ToString();
                        btnAceitar.Click += (s, eee) =>
                        {
                            Bunifu.Framework.UI.BunifuTileButton aa = s as Bunifu.Framework.UI.BunifuTileButton;
                            MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                            MySqlCommand aceitar = new MySqlCommand("UPDATE licoes SET avaliado = 1 WHERE cod = @Cod;", CONEXAO);
                            aceitar.Parameters.AddWithValue("@Cod", aa.Tag.ToString());
                            CONEXAO.Open();
                            aceitar.ExecuteNonQuery();
                            CONEXAO.Close();
                            Invoke(new Action(() =>
                            {
                                panelVerif.Controls.Remove(painel);
                                panelVerif.Controls.Remove(sep);
                            }));
                        };
                        btnAceitar.Anchor = AnchorStyles.Left;
                        grr.Controls.Add(btnAceitar);
                        Bunifu.Framework.UI.BunifuTileButton btnNegar = new Bunifu.Framework.UI.BunifuTileButton();
                        btnNegar.BackColor = Color.Transparent;
                        btnNegar.color = Color.Transparent;
                        btnNegar.colorActive = System.Drawing.Color.DodgerBlue;
                        btnNegar.Cursor = System.Windows.Forms.Cursors.Hand;
                        btnNegar.Image = Properties.Resources.icons8_Cancel_64px;
                        btnNegar.ImagePosition = 0;
                        btnNegar.ImageZoom = 100;
                        btnNegar.LabelPosition = 0;
                        btnNegar.LabelText = "";
                        btnNegar.Size = new System.Drawing.Size(28, 28);
                        btnNegar.TabIndex = 0;
                        btnNegar.Tag = lerTarefas["cod"].ToString();
                        btnNegar.Click += (s, eee) =>
                        {
                            Bunifu.Framework.UI.BunifuTileButton aa = s as Bunifu.Framework.UI.BunifuTileButton;
                            MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                            MySqlCommand negar = new MySqlCommand("UPDATE licoes SET avaliado = -1 WHERE cod = @Cod;", CONEXAO);
                            negar.Parameters.AddWithValue("@Cod", aa.Tag.ToString());
                            CONEXAO.Open();
                            negar.ExecuteNonQuery();
                            CONEXAO.Close();
                            Invoke(new Action(() =>
                            {
                                panelVerif.Controls.Remove(painel);
                                panelVerif.Controls.Remove(sep);
                            }));
                        };
                        btnNegar.Anchor = AnchorStyles.Right;
                        grr.Controls.Add(btnNegar);
                        painel.Controls.Add(grr);


                        sep.Width = panelVerif.Width - 30;
                        Invoke(new Action(() =>
                        {
                            panelVerif.Controls.Add(painel);
                            panelVerif.Controls.Add(sep);
                        }));
                    }
                    lerTarefas.Close();
                    CONEXAObw.Close();
                }
                catch (Exception erro)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/principal/rep.php?sala=" + Properties.Settings.Default.sala).Trim();
                string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
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

                        Bunifu.Framework.UI.BunifuSeparator sep = new Bunifu.Framework.UI.BunifuSeparator();
                        string licao = txtLicao;
                        if (licao.Substring(licao.Length - 1, 1) != "." && licao.Substring(licao.Length - 1, 1) != "!" && licao.Substring(licao.Length - 1, 1) != "?" && licao.Substring(licao.Length - 1, 1) != "\r\n")
                            licao += ".";

                        TableLayoutPanel painel = new TableLayoutPanel();
                        painel.AutoSize = true;

                        licaoTit licaoTit = new licaoTit(discLicao, panelVerif.Width - 31);
                        painel.Controls.Add(licaoTit);

                        licaoTxt licaoTxt = new licaoTxt(licao, panelVerif.Width - 31);
                        painel.Controls.Add(licaoTxt);

                        if (anexoLicao != "")
                        {
                            Invoke(new Action(() =>
                            {
                                string link = anexoLicao;
                                pic pic = new DiarioDeClasse.pic(link, panelVerif.Width - 31); //PictureBox pb = new PictureBox();
                                pic.ImageLocation = link;
                                Image img = pic.Image;
                                pic.Image = img;
                                painel.Controls.Add(pic);
                            }));
                        }

                        AddPor licaoAddPor = new AddPor(addPorLicao, codLicao);
                        painel.Controls.Add(licaoAddPor);


                        AddEm licaoAddEm = new AddEm(addEmLicao);
                        painel.Controls.Add(licaoAddEm);

                        Panel grr = new Panel();
                        grr.Height = 40;
                        grr.Width = 42;
                        grr.Dock = DockStyle.Fill;

                        Bunifu.Framework.UI.BunifuTileButton btnAceitar = new Bunifu.Framework.UI.BunifuTileButton();
                        btnAceitar.BackColor = Color.Transparent;
                        btnAceitar.color = Color.Transparent;
                        btnAceitar.colorActive = System.Drawing.Color.DodgerBlue;
                        btnAceitar.Cursor = System.Windows.Forms.Cursors.Hand;
                        btnAceitar.Image = Properties.Resources.icons8_Ok_64px;
                        btnAceitar.ImagePosition = 0;
                        btnAceitar.ImageZoom = 100;
                        btnAceitar.LabelPosition = 0;
                        btnAceitar.LabelText = "";
                        btnAceitar.Size = new System.Drawing.Size(28, 28);
                        btnAceitar.TabIndex = 0;
                        btnAceitar.Tag = codLicao;
                        btnAceitar.Click += (s, eee) =>
                        {
                            Bunifu.Framework.UI.BunifuTileButton aa = s as Bunifu.Framework.UI.BunifuTileButton;
                            WebClient kjAceitar = new WebClient();
                            kjAceitar.Encoding = System.Text.Encoding.UTF8;
                            string resultadoAceitar = kjAceitar.DownloadString("http://" + Vars.cfgPhp + "/principal/aceitarLicao.php?cod=" + aa.Tag.ToString()).Trim();
                            if (resultadoAceitar == "1")
                                Invoke(new Action(() =>
                                {
                                    panelVerif.Controls.Remove(painel);
                                    panelVerif.Controls.Remove(sep);
                                }));
                        };
                        btnAceitar.Anchor = AnchorStyles.Left;
                        grr.Controls.Add(btnAceitar);
                        Bunifu.Framework.UI.BunifuTileButton btnNegar = new Bunifu.Framework.UI.BunifuTileButton();
                        btnNegar.BackColor = Color.Transparent;
                        btnNegar.color = Color.Transparent;
                        btnNegar.colorActive = System.Drawing.Color.DodgerBlue;
                        btnNegar.Cursor = System.Windows.Forms.Cursors.Hand;
                        btnNegar.Image = Properties.Resources.icons8_Cancel_64px;
                        btnNegar.ImagePosition = 0;
                        btnNegar.ImageZoom = 100;
                        btnNegar.LabelPosition = 0;
                        btnNegar.LabelText = "";
                        btnNegar.Size = new System.Drawing.Size(28, 28);
                        btnNegar.TabIndex = 0;
                        btnNegar.Tag = codLicao;
                        btnNegar.Click += (s, eee) =>
                        {
                            Bunifu.Framework.UI.BunifuTileButton aa = s as Bunifu.Framework.UI.BunifuTileButton;
                            WebClient kjNegar = new WebClient();
                            kjNegar.Encoding = System.Text.Encoding.UTF8;
                            string resultadoNegar = kjNegar.DownloadString("http://" + Vars.cfgPhp + "/principal/negarLicao.php?cod=" + aa.Tag.ToString()).Trim();
                            if (resultadoNegar == "1")
                                Invoke(new Action(() =>
                                {
                                    panelVerif.Controls.Remove(painel);
                                    panelVerif.Controls.Remove(sep);
                                }));
                        };
                        btnNegar.Anchor = AnchorStyles.Right;
                        grr.Controls.Add(btnNegar);
                        painel.Controls.Add(grr);
                        sep.Width = panelVerif.Width - 30;
                        Invoke(new Action(() =>
                        {
                            panelVerif.Controls.Add(painel);
                            panelVerif.Controls.Add(sep);
                        }));
                    }
                }
            }
            Vars.trabRep = false;
        }


        public void licaoSemana(string dia, string mes)
        {
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAObw = new MySqlConnection(Vars.Cfg);
                MySqlCommand checarLicoes = new MySqlCommand("SELECT * FROM licoes INNER JOIN profdisc ON licoes.disc = cod_disc INNER JOIN disc ON discid_disc = cod_discs WHERE mesentrega = @Mes AND diaentrega = @Dia AND avaliado > 0 AND sala = '" + Properties.Settings.Default.codSala + "';", CONEXAObw);
                try
                {
                    checarLicoes.Parameters.AddWithValue("@Mes", mes);
                    checarLicoes.Parameters.AddWithValue("@Dia", dia);

                    CONEXAObw.Open();
                    MySqlDataReader lerLicoes = checarLicoes.ExecuteReader();

                    while (lerLicoes.Read())
                    {
                        if (!Vars.af.aLicao2.Contains(lerLicoes["cod"].ToString()))
                            Vars.af.aLicao2.Add(lerLicoes["cod"].ToString());

                        string licao = lerLicoes["licao"].ToString();
                        if (licao.Substring(licao.Length - 1, 1) != "." && licao.Substring(licao.Length - 1, 1) != "!" && licao.Substring(licao.Length - 1, 1) != "?" && licao.Substring(licao.Length - 1, 1) != "\r\n")
                            licao += ".";

                        TableLayoutPanel painel = new TableLayoutPanel();
                        painel.AutoSize = true;
                        painel.Dock = DockStyle.Fill;

                        licaoTit licaoTit = new licaoTit(lerLicoes["nome_disc"].ToString(), flowLayoutPanel1.Width - 31);
                        painel.Controls.Add(licaoTit);

                        DateTime dateValue = new DateTime(2017, Convert.ToInt32(lerLicoes["mesentrega"].ToString()), Int32.Parse(lerLicoes["diaentrega"].ToString()));
                        licaoTit licaoTit2 = new licaoTit("Para a próxima " + checarDia(dateValue.ToString("ddd")) + "!", flowLayoutPanel1.Width - 31);
                        painel.Controls.Add(licaoTit2);

                        licaoTxt licaoTxt = new licaoTxt(licao, flowLayoutPanel1.Width - 31);
                        painel.Controls.Add(licaoTxt);

                        if (lerLicoes["link_anexo"].ToString() != "")
                        {
                            Invoke(new Action(() =>
                            {
                                string link = lerLicoes["link_anexo"].ToString();
                                pic pic = new DiarioDeClasse.pic(link, flowLayoutPanel1.Width - 31); //PictureBox pb = new PictureBox();
                                pic.ImageLocation = link;
                                Image img = pic.Image;
                                pic.Image = img;
                                painel.Controls.Add(pic);
                            }));
                        }

                        AddPor licaoAddPor = new AddPor(lerLicoes["adicionadopor"].ToString(), lerLicoes["cod"].ToString());
                        painel.Controls.Add(licaoAddPor);


                        AddEm licaoAddEm = new AddEm(lerLicoes["adicionadoem"].ToString());
                        painel.Controls.Add(licaoAddEm);

                        Bunifu.Framework.UI.BunifuSeparator sep = new Bunifu.Framework.UI.BunifuSeparator();
                        sep.Width = flowLayoutPanel1.Width - 30;

                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel1.Controls.Add(painel);
                            flowLayoutPanel1.Controls.Add(sep);
                        }));
                    }
                    lerLicoes.Close();
                    CONEXAObw.Close();
                }
                catch (Exception erro)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/principal/licao.php?sala=" + Properties.Settings.Default.codSala + "&dia=" + dia + "&mes=" + mes).Trim();
                string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
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

                        if (!Vars.af.aLicao2.Contains(codLicao))
                            Vars.af.aLicao2.Add(codLicao);

                        string licao = txtLicao;
                        if (licao.Substring(licao.Length - 1, 1) != "." && licao.Substring(licao.Length - 1, 1) != "!" && licao.Substring(licao.Length - 1, 1) != "?" && licao.Substring(licao.Length - 1, 1) != "\r\n")
                            licao += ".";

                        TableLayoutPanel painel = new TableLayoutPanel();
                        painel.AutoSize = true;

                        licaoTit licaoTit = new licaoTit(discLicao, flowLayoutPanel1.Width - 31);
                        painel.Controls.Add(licaoTit);
                        DateTime dateValue = new DateTime(2017, Convert.ToInt32(mes), Int32.Parse(dia));
                        licaoTit licaoTit2 = new licaoTit("Para a próxima " + checarDia(dateValue.ToString("ddd")) + "!", flowLayoutPanel1.Width - 31);
                        painel.Controls.Add(licaoTit2);

                        licaoTxt licaoTxt = new licaoTxt(licao, flowLayoutPanel1.Width - 31);
                        painel.Controls.Add(licaoTxt);

                        if (anexoLicao != "")
                        {
                            Invoke(new Action(() =>
                            {
                                string link = anexoLicao;
                                pic pic = new DiarioDeClasse.pic(link, flowLayoutPanel1.Width - 31); //PictureBox pb = new PictureBox();
                                pic.ImageLocation = link;
                                Image img = pic.Image;
                                pic.Image = img;
                                painel.Controls.Add(pic);
                            }));
                        }

                        AddPor licaoAddPor = new AddPor(addPorLicao, codLicao);
                        painel.Controls.Add(licaoAddPor);


                        AddEm licaoAddEm = new AddEm(addEmLicao);
                        painel.Controls.Add(licaoAddEm);

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

        private void licao_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {
                flowLayoutPanel1.Controls.Clear();
            }));
            DateTime dateValue = new DateTime(2017, Convert.ToInt32(DateTime.Now.Month.ToString("00")), Int32.Parse(DateTime.Now.Day.ToString("00")));
            if (checarDia(dateValue.ToString("ddd")) == "Sabado")
            {
                var tomorrow = dateValue.AddDays(2);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
            }
            if (checarDia(dateValue.ToString("ddd")) == "Domingo")
            {
                var tomorrow = dateValue.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
            }
            if (checarDia(dateValue.ToString("ddd")) == "Segunda")
            {
                var tomorrow = dateValue;
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
            }
            if (checarDia(dateValue.ToString("ddd")) == "Terca")
            {
                var tomorrow = dateValue;
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
            }
            if (checarDia(dateValue.ToString("ddd")) == "Quarta")
            {
                var tomorrow = dateValue;
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
            }
            if (checarDia(dateValue.ToString("ddd")) == "Quinta")
            {
                var tomorrow = dateValue;
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
                tomorrow = tomorrow.AddDays(1);
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
            }
            if (checarDia(dateValue.ToString("ddd")) == "Sexta")
            {
                var tomorrow = dateValue;
                licaoSemana(tomorrow.Day.ToString(), tomorrow.Month.ToString());
            }
            //Vars.trabLicao = false;
        }

        public string checarDia(string aa)
        {
            if (aa != "sab" && Vars.diaNome != "aa")
            {
                switch (aa)
                {
                    case "seg":
                        return "Segunda";
                    case "ter":
                        return "Terca";
                    case "qua":
                        return "Quarta";
                    case "qui":
                        return "Quinta";
                    case "sex":
                        return "Sexta";
                    case "sáb":
                        return "Sabado";
                    case "dom":
                        return "Domingo";
                    default:
                        return "";
                }
            }
            else
                return "nain";
        }



        private void aviso_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {
                flowLayoutPanel2.Controls.Clear();
            }));
            if (!Properties.Settings.Default.phpLocal)
            {
                try
                {
                    MySqlConnection CONEXAObw = new MySqlConnection(Vars.Cfg);
                    MySqlCommand checarAvisos = new MySqlCommand("SELECT * FROM avisos WHERE excluido_avisos = 0 AND sala_aviso = '" + Properties.Settings.Default.codSala + "' OR sala_aviso = 0 ORDER BY adicionadoem_aviso DESC;", CONEXAObw);
                    CONEXAObw.Open();
                    MySqlDataReader lerAvisos = checarAvisos.ExecuteReader();
                    while (lerAvisos.Read())
                    {
                        if (!Vars.af.aAviso2.Contains(lerAvisos["cod_aviso"].ToString()))
                            Vars.af.aAviso2.Add(lerAvisos["cod_aviso"].ToString());

                        string aviso = lerAvisos["texto_aviso"].ToString();
                        if (aviso.Substring(aviso.Length - 1, 1) != "." && aviso.Substring(aviso.Length - 1, 1) != "!" && aviso.Substring(aviso.Length - 1, 1) != "?" && aviso.Substring(aviso.Length - 1, 1) != "\r\n")
                            aviso += ".";
                        avisoTxt avisoTxt = new avisoTxt(aviso);
                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel2.Controls.Add(avisoTxt);
                        }));
                        AddPor licaoAddPor = new AddPor(lerAvisos["adicionadopor_aviso"].ToString(), lerAvisos["cod_aviso"].ToString());
                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel2.Controls.Add(licaoAddPor);
                        }));
                        AddEm licaoAddEm = new AddEm(lerAvisos["adicionadoem_aviso"].ToString());
                        Bunifu.Framework.UI.BunifuSeparator sep = new Bunifu.Framework.UI.BunifuSeparator();
                        sep.Width = flowLayoutPanel2.Width - 30;
                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel2.Controls.Add(licaoAddEm);
                            flowLayoutPanel2.Controls.Add(sep);
                        }));
                    }
                    lerAvisos.Close();
                    CONEXAObw.Close();
                }
                catch (Exception ee)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/principal/avisos.php?sala=" + Properties.Settings.Default.codSala).Trim();
                string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string teste in reps)
                {
                    string[] codes = teste.Split(new string[] { "@#@" }, StringSplitOptions.RemoveEmptyEntries);
                    if (codes.Length > 3)
                    {
                        string txtAviso = codes[2];
                        string addPorAviso = codes[0];
                        string addEmAviso = codes[1];
                        string codAviso = codes[3];

                        if (!Vars.af.aAviso2.Contains(codAviso))
                            Vars.af.aAviso2.Add(codAviso);

                        string aviso = txtAviso;
                        if (aviso.Substring(aviso.Length - 1, 1) != "." && aviso.Substring(aviso.Length - 1, 1) != "!" && aviso.Substring(aviso.Length - 1, 1) != "?" && aviso.Substring(aviso.Length - 1, 1) != "\r\n")
                            aviso += ".";
                        avisoTxt avisoTxt = new avisoTxt(aviso);
                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel2.Controls.Add(avisoTxt);
                        }));
                        AddPor licaoAddPor = new AddPor(addPorAviso, codAviso);
                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel2.Controls.Add(licaoAddPor);
                        }));
                        AddEm licaoAddEm = new AddEm(addEmAviso);
                        Bunifu.Framework.UI.BunifuSeparator sep = new Bunifu.Framework.UI.BunifuSeparator();
                        sep.Width = flowLayoutPanel2.Width - 30;
                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel2.Controls.Add(licaoAddEm);
                            flowLayoutPanel2.Controls.Add(sep);
                        }));
                    }
                }
            }
            Vars.trabAviso = false;
            /*Invoke(new Action(() =>
            {
                carregando.Visible = false;
                this.Visible = true;
            }));*/
        }

        private void principal_VisibleChanged(object sender, EventArgs e)
        {
            Vars.af.lblNome.Text = Properties.Settings.Default.nome;
            Vars.af.lblSala.Text = Properties.Settings.Default.sala;
            Vars.af.lblId.Text = "ID: " + Properties.Settings.Default.cod;
            if (Properties.Settings.Default.permInt == 1 || Properties.Settings.Default.permInt == 3)
            {
                tableLayoutPanel2.RowCount = 3;
                tableLayoutPanel2.RowStyles[0].Height = 50;
                panelVerif.Show();
                lblVerifTit.Show();
                bunifuSeparator2.Show();
            }
            else
            {
                tableLayoutPanel2.RowCount = 1;
                tableLayoutPanel2.RowStyles[0].Height = 1000;
                tableLayoutPanel2.RowStyles[1].Height = 0;
                tableLayoutPanel2.RowStyles[2].Height = 0;
                panelVerif.Hide();
                lblVerifTit.Hide();
                bunifuSeparator2.Hide();
            }
        }

        private void lblVerifTit_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void principal_SizeChanged(object sender, EventArgs e)
        {
        }

        private void lblAvisoTit_Resize(object sender, EventArgs e)
        {

        }



    }

    class avisoTxt : Label
    {
        public avisoTxt(string texto)
        {
            this.Font = new System.Drawing.Font(Vars.ff[0], 13F, FontStyle.Bold);
            this.ForeColor = Vars.corTxt;
            this.AutoSize = true;
            this.Text = texto;
        }
    }

    class licaoTit : Label
    {
        public licaoTit(string texto, int width)
        {
            this.Font = new Font(Vars.ff[0], 13F, FontStyle.Bold);
            this.ForeColor = Vars.corTit;
            this.Width = width;
            this.Anchor = AnchorStyles.None;
            this.Text = texto;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
    }

    class licaoTxt : Label
    {
        public licaoTxt(string texto, int width)
        {
            this.Font = new System.Drawing.Font("Courier New", 11F);
            this.ForeColor = Vars.corTxt;
            this.AutoSize = true;
            this.MaximumSize = new System.Drawing.Size(width - 25, 999999);
            this.Anchor = AnchorStyles.None;
            this.Text = texto;
        }
    }

    class AddPor : Label
    {
        public AddPor(string texto, string cod)
        {
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = Vars.corTxt;
            this.AutoSize = true;
            this.Anchor = AnchorStyles.None;
            this.Text = "(Adicionado por " + texto;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tag = cod;
        }
    }

    class AddEm : Label
    {
        public AddEm(string texto)
        {
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = Vars.corTxt;
            this.AutoSize = true;
            this.Anchor = AnchorStyles.None;
            this.Text = "em " + texto + ")\r\n";
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
    }

    class pic : PictureBox
    {
        public pic(string link, int width)
        {
            this.Size = new System.Drawing.Size(width, (width * 9) / 16);
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Image = Properties.Resources.loading;
            this.Anchor = AnchorStyles.None;
            this.Tag = link;
            this.Cursor = Cursors.Hand;
            this.Click += new System.EventHandler(go);
        }
        public void go(object sender, EventArgs e)
        {
            frmImagem abrirfrmImagem;
            PictureBox fon = sender as PictureBox;
            if (fon.Image != fon.InitialImage)
                abrirfrmImagem = new frmImagem(fon.Image);
            else
                abrirfrmImagem = new frmImagem(fon.Tag.ToString());
            abrirfrmImagem.ShowDialog();
        }
    }



}
