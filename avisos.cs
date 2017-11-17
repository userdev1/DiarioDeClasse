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
using System.Net;

namespace DiarioDeClasse
{
    public partial class avisos : UserControl
    {

        BackgroundWorker aviso;

        public avisos()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Vars.af.btnCfg.selected = false;
            Vars.af.bunifuFlatButton1_Click(Vars.af.btnInicio, null);
        }

        public BackgroundWorker CreateBackgroundWorkerAviso()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += aviso_DoWork;
            return bw;
        }

        public void iniciarBw()
        {
            flowLayoutPanel1.Controls.Clear();
            if (aviso != null)
            {
                aviso.CancelAsync();
            }
            aviso = CreateBackgroundWorkerAviso();
            aviso.RunWorkerAsync();
        }

        private void aviso_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(new Action(() =>
            {
                flowLayoutPanel1.Controls.Clear();
            }));
            if (!Properties.Settings.Default.phpLocal)
            {
                try
                {

                    MySqlConnection CONEXAObw = new MySqlConnection(Vars.Cfg);
                    MySqlCommand checarAvisos;
                    if (Properties.Settings.Default.permInt == 2)
                        checarAvisos = new MySqlCommand("SELECT * FROM avisos INNER JOIN info_salas ON cod_sala = sala_aviso WHERE excluido_avisos = 0 AND adicionadopor_aviso LIKE '%" + Properties.Settings.Default.nome + "%';", CONEXAObw);
                    else
                        checarAvisos = new MySqlCommand("SELECT * FROM avisos WHERE excluido_avisos = 0 AND sala_aviso = '" + Properties.Settings.Default.codSala + "';", CONEXAObw);
                    CONEXAObw.Open();
                    Bunifu.Framework.UI.BunifuSeparator sep1 = new Bunifu.Framework.UI.BunifuSeparator();
                    sep1.Width = flowLayoutPanel1.Width - 30;
                    int cod = Convert.ToInt32(checarAvisos.ExecuteScalar());

                    if (cod > 0)
                    {
                        Invoke(new Action(() =>
                        {
                            flowLayoutPanel1.Controls.Add(sep1);
                        }));
                    }
                    MySqlDataReader lerAvisos = checarAvisos.ExecuteReader();
                    while (lerAvisos.Read())
                    {
                        string aviso = lerAvisos["texto_aviso"].ToString();
                        if (aviso.Substring(aviso.Length - 1, 1) != "." && aviso.Substring(aviso.Length - 1, 1) != "!" && aviso.Substring(aviso.Length - 1, 1) != "?" && aviso.Substring(aviso.Length - 1, 1) != "\r\n")
                            aviso += ".";
                        /*
                        Label avisoSub = new Label();
                        avisoSub.Font = new System.Drawing.Font("Trajan Pro", 13F, FontStyle.Bold);
                        avisoSub.ForeColor = Vars.corTit;
                        avisoSub.Size = new System.Drawing.Size(flowLayoutPanel2.Width - 30, 30);
                        avisoSub.Text = "Lição de " + lerAvisos["nome_disc"].ToString() + ":";
                        avisoSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        flowLayoutPanel2.Controls.Add(avisoSub);*/

                        TableLayoutPanel painel = new TableLayoutPanel();
                        painel.AutoSize = true;


                        if (Properties.Settings.Default.permInt == 2)
                        {
                            licaoTit avisoTit = new licaoTit(lerAvisos["nome_sala"].ToString(), flowLayoutPanel1.Width - 31);
                            painel.Controls.Add(avisoTit);
                        }

                        avisoTxt avisoTxt = new avisoTxt(aviso);
                        avisoTxt.MaximumSize = new System.Drawing.Size(flowLayoutPanel1.Width - 25, 999999);
                        painel.Controls.Add(avisoTxt);
                        /*
                        if (lerAvisos["link_anexo"].ToString() != "")
                        {
                            string link = lerAvisos["link_anexo"].ToString();
                            PictureBox pic = new PictureBox();
                            pic.Size = new System.Drawing.Size(321, 170);
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Load(link);
                            pic.Tag = link;
                            pic.Cursor = Cursors.Hand;
                            pic.Click += new System.EventHandler(go);
                            flowLayoutPanel2.Controls.Add(pic);
                        }
                        */

                        AddPor avisoAddPor = new AddPor(lerAvisos["adicionadopor_aviso"].ToString(), lerAvisos["cod_aviso"].ToString());
                        avisoAddPor.AutoSize = false;
                        avisoAddPor.Width = flowLayoutPanel1.Width - 31;
                        painel.Controls.Add(avisoAddPor);


                        AddEm avisoAddEm = new AddEm(lerAvisos["adicionadoem_aviso"].ToString());
                        painel.Controls.Add(avisoAddEm);

                        if (lerAvisos["adicionadopor_aviso"].ToString() != "Equipe")
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
                            btnExcluir.Tag = lerAvisos["cod_aviso"].ToString();
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
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/avisos/avisos.php?sala=" + Properties.Settings.Default.codSala + "&perm=" + Properties.Settings.Default.permInt + 
                    "&nome=" + Properties.Settings.Default.nome).Trim();
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

                        string aviso = txtAviso;
                        if (aviso.Substring(aviso.Length - 1, 1) != "." && aviso.Substring(aviso.Length - 1, 1) != "!" && aviso.Substring(aviso.Length - 1, 1) != "?" && aviso.Substring(aviso.Length - 1, 1) != "\r\n")
                            aviso += ".";

                        TableLayoutPanel painel = new TableLayoutPanel();
                        painel.AutoSize = true;


                        if (Properties.Settings.Default.permInt == 2)
                        {
                            licaoTit avisoTit = new licaoTit(codes[4], flowLayoutPanel1.Width - 31);
                            painel.Controls.Add(avisoTit);
                        }

                        avisoTxt avisoTxt = new avisoTxt(aviso);
                        avisoTxt.MaximumSize = new System.Drawing.Size(flowLayoutPanel1.Width - 31, 999999);
                        painel.Controls.Add(avisoTxt);
                        /*
                        if (lerAvisos["link_anexo"].ToString() != "")
                        {
                            string link = lerAvisos["link_anexo"].ToString();
                            PictureBox pic = new PictureBox();
                            pic.Size = new System.Drawing.Size(321, 170);
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Load(link);
                            pic.Tag = link;
                            pic.Cursor = Cursors.Hand;
                            pic.Click += new System.EventHandler(go);
                            flowLayoutPanel2.Controls.Add(pic);
                        }
                        */

                        AddPor avisoAddPor = new AddPor(addPorAviso, codAviso);
                        avisoAddPor.AutoSize = false;
                        avisoAddPor.Width = flowLayoutPanel1.Width - 31;
                        painel.Controls.Add(avisoAddPor);


                        AddEm avisoAddEm = new AddEm(addEmAviso);
                        painel.Controls.Add(avisoAddEm);

                        if (addPorAviso != "Equipe")
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
                            btnExcluir.Tag = codAviso;
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
                MySqlCommand apagar = new MySqlCommand("UPDATE avisos SET excluido_avisos = 1 WHERE cod_aviso = @Cod", CONEXAO);
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
                string resultadoNegar = kjNegar.DownloadString("http://" + Vars.cfgPhp + "/avisos/btnExcluir.php?cod=" + fon.Tag.ToString()).Trim();
                if (resultadoNegar == "1")
                    iniciarBw();
            }
        }

        List<string> aa;
        private void avisos_Load(object sender, EventArgs e)
        {
            iniciarBw();
            if (Properties.Settings.Default.permInt == 2)
            {
                aa = new List<string>();
                cbTurma.Clear();
                lblTurma.Visible = true;
                cbTurma.Show();
                turmas("segunda");
                turmas("terca");
                turmas("quarta");
                turmas("quinta");
                turmas("sexta");
                //flowLayoutPanel1.Hide();
                aa.Sort(StringComparer.CurrentCulture);
                foreach (string aaa in aa)
                {
                    cbTurma.AddItem(aaa);
                }
            }
        }

        public void turmas(string dia)
        {
            if (dia != "")
            {
                if (!Properties.Settings.Default.phpLocal)
                {
                    MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                    MySqlCommand checardia = new MySqlCommand("SELECT aula, " + dia + "_horario, nome_sala, nome_disc, nome_prof FROM horariosnovo INNER JOIN info_salas ON sala_horarios = cod_sala INNER JOIN profdisc ON cod_disc = " + dia +
                        "_horario INNER JOIN profs ON profid_disc = cod_prof INNER JOIN disc ON discid_disc = cod_discs WHERE nome_prof = @Nome", CONEXAO);
                    checardia.Parameters.AddWithValue("@Nome", Properties.Settings.Default.nome);
                    CONEXAO.Open();
                    try
                    {
                        int cod = Convert.ToInt32(checardia.ExecuteScalar());
                        if (cod > 0)
                        {
                            cbTurma.Enabled = true;
                            MySqlDataReader lerDias = checardia.ExecuteReader();

                            while (lerDias.Read())
                            {
                                if (!aa.Contains(lerDias["nome_sala"].ToString()))
                                    aa.Add(lerDias["nome_sala"].ToString());
                            }
                            lerDias.Close();
                            CONEXAO.Close();
                        }
                        else
                            cbTurma.Enabled = false;
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
                    string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/principal/prof.php?nome=" + Properties.Settings.Default.nome + "&dia=" + dia).Trim();
                    string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string teste in reps)
                    {
                        string[] codes = teste.Split(new string[] { "@#@" }, StringSplitOptions.RemoveEmptyEntries);
                        if (!aa.Contains(codes[2]))
                            aa.Add(codes[2]);
                    }
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Vars.atualizarData();
            string data = Vars.ano + "-" + Vars.mes + "-" + Vars.dia + " " + Vars.hora + ":" + Vars.minuto + ":" + Vars.segundo;
            if (!Properties.Settings.Default.phpLocal)
                    {
            MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
            try
            {
                MySqlCommand enviar = new MySqlCommand("INSERT INTO avisos VALUES (null, @Aviso, @Sala, @Nome, @Data, 0)", CONEXAO);
                enviar.Parameters.AddWithValue("@Aviso", txtAviso.Text);
                enviar.Parameters.AddWithValue("@Data", data);
                if (Properties.Settings.Default.permInt == 2)
                {
                    enviar.Parameters.AddWithValue("@Nome", "Professor(a) " + Properties.Settings.Default.nome);
                    enviar.Parameters.AddWithValue("@Sala", Vars.addSalaSelec(cbTurma));
                }
                else
                {
                    enviar.Parameters.AddWithValue("@Nome", Properties.Settings.Default.nome);
                    enviar.Parameters.AddWithValue("@Sala", Properties.Settings.Default.codSala);
                }
                CONEXAO.Open();
                enviar.ExecuteNonQuery();
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
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string nome = Properties.Settings.Default.nome;
                if (Properties.Settings.Default.permInt == 2)
                    nome = "Professor(a) " + Properties.Settings.Default.nome;
                string disc = Vars.discSelec;
                int codSala = 0;
                if (Properties.Settings.Default.permInt == 2)
                    codSala = Vars.addSalaSelec(cbTurma);
                else
                    codSala = Properties.Settings.Default.codSala;

                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/avisos/addAviso.php?nome=" + nome + "&aviso=" + txtAviso.Text + "&sala=" + codSala.ToString() + "&data=" + data).Trim();
                if (resultado[0] == '1')
                {
                    MessageBox.Show("Aviso Cadastrado!");
                    iniciarBw();
                }
                else
                    MessageBox.Show("Ocorreu um erro...");
            }
        }

        private void cbTurma_onItemSelected(object sender, EventArgs e)
        {

        }
    }
}
