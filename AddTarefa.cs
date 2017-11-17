using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace DiarioDeClasse
{
    public partial class AddTarefa : UserControl
    {
        List<string> aaa;
        List<string> discList;
        public MySqlConnection CONEXAOaaa = new MySqlConnection(Vars.Cfg);
        public AddTarefa()
        {
            InitializeComponent();
            
            
        }
        public void ifProf()
        {
            aaa = new List<string>();
            string dia = Vars.diaNome2;
            if (dia != "")
            {
                if (!Properties.Settings.Default.phpLocal)
                {
                    lblTurma.Visible = true;
                    cbTurma.Visible = true;
                    cbDisc.Visible = false;

                    MySqlCommand checarProf = new MySqlCommand("SELECT aula, " + dia + "_horario, nome_sala, nome_disc, nome_prof FROM horariosnovo INNER JOIN info_salas ON sala_horarios = cod_sala INNER JOIN profdisc ON cod_disc = " + dia +
                        "_horario INNER JOIN profs ON profid_disc = cod_prof INNER JOIN disc ON discid_disc = cod_discs WHERE nome_sala = @Turma AND nome_prof = @Nome ORDER BY sala_horarios ASC, aula ASC;", CONEXAOaaa);
                    checarProf.Parameters.AddWithValue("@Nome", Properties.Settings.Default.nome);
                    checarProf.Parameters.AddWithValue("@Turma", cbTurma.selectedValue);
                    try
                    {
                        int cod = Convert.ToInt32(checarProf.ExecuteScalar());
                        if (cod > 0)
                        {
                            MySqlDataReader lerDias = checarProf.ExecuteReader();
                            while (lerDias.Read())
                            {
                                if (!aaa.Contains(lerDias["nome_disc"]))
                                    aaa.Add(lerDias["nome_disc"].ToString());
                            }
                            lerDias.Close();
                        }
                        else
                        {
                            cbDisc2.Clear();
                            cbDisc2.Enabled = false;
                        }
                        
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
                    string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/add/ifProf.php?dia=" + dia + "&sala=" + cbTurma.selectedValue + "&nome=" + Properties.Settings.Default.nome).Trim();
                    if (resultado[0] != '0')
                    {
                        string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.None);
                        foreach (string teste in reps)
                        {
                            if (!aaa.Contains(teste) && teste != "")
                                aaa.Add(teste);
                        } 
                    }
                    else
                    {
                        cbDisc2.Clear();
                        cbDisc2.Enabled = false;
                    }
                }
                foreach (string aaaa in aaa)
                {
                    cbDisc2.AddItem(aaaa);
                }
                cbDisc2.selectedIndex = 0;
            }
            else
            {
                cbDisc2.Clear();
                cbDisc2.Enabled = false;
            }
        }

        
        string anexo = "";

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            if (openFile1.ShowDialog() == DialogResult.OK)
                anexo = openFile1.FileName;
        }
        public string sala = Properties.Settings.Default.sala;

        public string selecionado = "";

        

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);



            if (
                true
               )
            {




                
                    string anexoNome = "";
                    if (anexo != "")
                    {
                        try
                        {
                            using (var w = new WebClient())
                            {
                                /*string clientID = "7596799570c2677";
                                w.Headers.Add("Authorization", "Client-ID " + clientID);
                                var values = new NameValueCollection
								{
									{ "image", Convert.ToBase64String(File.ReadAllBytes(anexo)) }
								};
                                byte[] response = w.UploadValues("https://api.imgur.com/3/upload.xml", values);
                                XmlDocument doc = new XmlDocument();
                                Stream stream = new MemoryStream(response);
                                var document = XDocument.Load(stream);
                                var arr = document.Descendants("link").Select(x => (string)x).ToArray();
                                anexoNome = arr[0];*/

                                System.Net.WebClient Client = new System.Net.WebClient();
                                Client.Headers.Add("Content-Type", "binary/octet-stream");
                                byte[] result = Client.UploadFile("http://localhost/upload.php", "POST", anexo);
                                String s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                                anexoNome = "http://localhost/upload/" + s;



                            }
                        }
                        catch (Exception erro)
                        {
                            if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                            MessageBox.Show("Houve um erro no Imgur:\r\n" + erro.Message);
                        }
                    }
                    Vars.atualizarData();
                    string data = Vars.ano + "-" + Vars.mes + "-" + Vars.dia + " " + Vars.hora + ":" + Vars.minuto + ":" + Vars.segundo;

                    if (!Properties.Settings.Default.phpLocal)
                    {
                        try
                        {
                            MySqlCommand enviar = new MySqlCommand("INSERT INTO licoes VALUES (null, @Licao, @Resumo, @DiaEntrega, @MesEntrega, @AdicionadoPor, @AdicionadoEm, @Sala, @Disc, '" + anexoNome + "', @Avaliado)", CONEXAO);
                            CONEXAO.Open();
                            enviar.Parameters.AddWithValue("@Licao", txtTarefa.Text);
                            enviar.Parameters.AddWithValue("@Resumo", txtResumo.Text);
                            enviar.Parameters.AddWithValue("@AdicionadoEm", data);
                            enviar.Parameters.AddWithValue("@Avaliado", Properties.Settings.Default.permInt);
                            if (Properties.Settings.Default.permInt == 2)
                                checarSelec();
                            enviar.Parameters.AddWithValue("@Disc", Vars.discSelec);
                            if (Vars.diaSelec != "")
                            {
                                enviar.Parameters.AddWithValue("@DiaEntrega", Vars.diaSelec);
                                enviar.Parameters.AddWithValue("@MesEntrega", Vars.mesSelec);
                            }
                            else
                            {
                                enviar.Parameters.AddWithValue("@DiaEntrega", Vars.diaSelec);
                                enviar.Parameters.AddWithValue("@MesEntrega", Vars.mesSelec);
                            }
                            if (Properties.Settings.Default.permInt == 2)
                            {
                                enviar.Parameters.AddWithValue("@AdicionadoPor", "Professor(a) " + Properties.Settings.Default.nome);
                                enviar.Parameters.AddWithValue("@Sala", Vars.addSalaSelec(cbTurma));
                            }
                            else
                            {
                                enviar.Parameters.AddWithValue("@AdicionadoPor", Properties.Settings.Default.nome);
                                enviar.Parameters.AddWithValue("@Sala", Properties.Settings.Default.codSala);
                            }
                            enviar.ExecuteNonQuery();
                            CONEXAO.Close();
                        }
                        catch (Exception erro)
                        {
                            if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                            MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                        }
                        finally
                        {
                            CONEXAO.Close();
                            MessageBox.Show("Tarefa Cadastrada!");
                            //this.Close();
                        }
                    }
                    else
                    {
                        WebClient kj = new WebClient();
                        kj.Encoding = System.Text.Encoding.UTF8;
                        string nome = Properties.Settings.Default.nome;
                        if (Properties.Settings.Default.permInt == 2)
                            nome = "Professor(a) " + Properties.Settings.Default.nome;
                        string licao = txtTarefa.Text;
                        string resumo = txtResumo.Text;
                        if (Properties.Settings.Default.permInt == 2)
                            checarSelec();
                        string disc = Vars.discSelec;
                        int codSala = 0;
                        if (Properties.Settings.Default.permInt == 2)
                            codSala = Vars.addSalaSelec(cbTurma);
                        else
                            codSala = Properties.Settings.Default.codSala;
                        MessageBox.Show("http://" + Vars.cfgPhp + "/add/addLicao.php?nome=" + nome + "&licao=" + licao + "&resumo=" + resumo
                            + "&dia=" + Vars.diaSelec + "&mes=" + Vars.mesSelec + "&codSala=" + codSala.ToString() + "&data=" + data + "&disc=" + disc + "&anexo=" + anexoNome + "&aval=" +
                            Properties.Settings.Default.permInt);
                        string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/add/addLicao.php?nome=" + nome + "&licao=" + licao + "&resumo=" + resumo
                            + "&dia=" + Vars.diaSelec + "&mes=" + Vars.mesSelec + "&codSala=" + codSala.ToString() + "&data=" + data + "&disc=" + disc + "&anexo=" + anexoNome + "&aval=" +
                            Properties.Settings.Default.permInt).Trim();
                        if (resultado[0] == '1')
                            MessageBox.Show("Tarefa Cadastrada!");
                        else
                            MessageBox.Show("Ocorreu um erro...");
                    }

            }
            else
                MessageBox.Show("Existem campos vazios!");
        }
        public string prof;

        private void cbDisc_onItemSelected(object sender, EventArgs e)
        {
            if (cbDisc.Text == "Várias Matérias")
            {
                lblProf.Show();
                lblProf.Text = "Professor: Vários";
            }
            else
            {
                checarDisc();
                lblProf.Show();
            }
        }
        public void checarDia()
        {
            if (Vars.diaNome != "sab" && Vars.diaNome != "dom")
            {
                switch (Vars.diaNome)
                {
                    case "seg":
                        Vars.diaNome2 = "Segunda";
                        break;
                    case "ter":
                        Vars.diaNome2 = "Terca";
                        break;
                    case "qua":
                        Vars.diaNome2 = "Quarta";
                        break;
                    case "qui":
                        Vars.diaNome2 = "Quinta";
                        break;
                    case "sex":
                        Vars.diaNome2 = "Sexta";
                        break;
                    default:
                        Vars.diaNome2 = "";
                        break;
                }
            }
            else
                Vars.diaNome2 = "";
        }
        public void inserirDisc()
        {
            discList = new List<string>();
            string dia = Vars.diaNome2;
            if (dia != "")
            {
                if (!Properties.Settings.Default.phpLocal)
                {
                    MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                    MySqlCommand checarDisc = new MySqlCommand("SELECT aula, " + dia + "_horario, nome_sala, nome_disc, nome_prof FROM horariosnovo INNER JOIN info_salas ON sala_horarios = cod_sala INNER JOIN profdisc ON cod_disc = " + dia +
                        "_horario INNER JOIN profs ON profid_disc = cod_prof INNER JOIN disc ON discid_disc = cod_discs WHERE nome_sala = @Sala ORDER BY sala_horarios ASC, aula ASC;", CONEXAO);
                    checarDisc.Parameters.AddWithValue("@Sala", Properties.Settings.Default.sala);
                    try
                    {
                        CONEXAO.Open();
                        int cod = Convert.ToInt32(checarDisc.ExecuteScalar());
                        if (cod > 0)
                        {
                            cbDisc.Enabled = true;
                            MySqlDataReader lerDisc = checarDisc.ExecuteReader();
                            while (lerDisc.Read())
                            {
                                if (!discList.Contains(lerDisc["nome_disc"]))
                                    discList.Add(lerDisc["nome_disc"].ToString());
                            }
                            lerDisc.Close();
                            CONEXAO.Close();
                        }
                        else
                        {
                            cbDisc.Enabled = false;
                            cbDisc.Clear();
                        }
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
                    string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/add/inserirDisc.php?dia=" + dia + "&sala=" + Properties.Settings.Default.sala).Trim();
                    if (resultado[0] != '0')
                    {
                        string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.None);
                        foreach (string teste in reps)
                        {
                            if (!discList.Contains(teste) && teste != "")
                                discList.Add(teste);
                        }
                    }
                    else
                    {
                        cbDisc.Clear();
                        cbDisc.Enabled = false;
                    }
                }
                foreach (string aaaa in discList)
                {
                    cbDisc.AddItem(aaaa);
                }
            }
            else
            {
                cbDisc.Enabled = false;
                cbDisc.Clear();
            }
        }

        public void checarDisc()
        {
            string dia = Vars.diaNome2;
            if (dia != "")
            {
                if (!Properties.Settings.Default.phpLocal)
                {
                    MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                    MySqlCommand checarDisc = new MySqlCommand("SELECT aula, " + dia + "_horario, nome_sala, nome_disc, nome_prof, cod_disc FROM horariosnovo INNER JOIN info_salas ON sala_horarios = cod_sala INNER JOIN profdisc ON cod_disc = " + dia +
                    "_horario INNER JOIN profs ON profid_disc = cod_prof INNER JOIN disc ON discid_disc = cod_discs WHERE nome_sala = @Sala AND nome_disc = @Disc", CONEXAO);
                    checarDisc.Parameters.AddWithValue("@Sala", Properties.Settings.Default.sala);
                    checarDisc.Parameters.AddWithValue("@Disc", cbDisc.selectedValue);
                    try
                    {
                        CONEXAO.Open();
                        MySqlDataReader lerDisc = checarDisc.ExecuteReader();
                        while (lerDisc.Read())
                        {
                            lblProf.Text = "Seu professor de\r\n" + cbDisc.selectedValue + " é:\r\n" + lerDisc["nome_prof"].ToString();
                            Vars.discSelec = lerDisc["cod_disc"].ToString();
                        }
                        lerDisc.Close();
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
                    string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/add/checarProfDisc.php?dia=" + dia + "&sala=" + Properties.Settings.Default.sala + "&disc=" + cbDisc.selectedValue).Trim();
                    if (resultado[0] != '0')
                    {
                        string[] reps = resultado.Split(new string[] { "@#@" }, StringSplitOptions.None);
                        lblProf.Text = "Seu professor de\r\n" + cbDisc.selectedValue + " é:\r\n" + reps[0];
                        Vars.discSelec = reps[1];
                    }
                }
            }
        }


        List<string> aa;
        public void turmas()
        {
            aa = new List<string>();
            string dia = Vars.diaNome2;
            if (dia != "")
            {
                if (!Properties.Settings.Default.phpLocal)
                {
                    MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                    MySqlCommand checardia = new MySqlCommand("SELECT aula, " + dia + "_horario, nome_sala, nome_disc, nome_prof, aula FROM horariosnovo INNER JOIN info_salas ON sala_horarios = cod_sala INNER JOIN profdisc ON cod_disc = " + dia +
                        "_horario INNER JOIN profs ON profid_disc = cod_prof INNER JOIN disc ON discid_disc = cod_discs WHERE nome_prof = @Nome ORDER BY aula ASC", CONEXAO);
                    checardia.Parameters.AddWithValue("@Nome", Properties.Settings.Default.nome);
                    try
                    {
                        CONEXAO.Open();
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
                            aa.Sort(StringComparer.CurrentCulture);
                            foreach (string aaa in aa)
                            {
                                cbTurma.AddItem(aaa);
                            }
                        }
                        else
                            cbTurma.Enabled = false;
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
                    string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/add/turmas.php?dia=" + dia + "&nome=" + Properties.Settings.Default.nome).Trim();
                    if (resultado[0] != '0')
                    {
                        string[] reps = resultado.Split(new string[] { "@#@" }, StringSplitOptions.None);
                        foreach (string teste in reps)
                        {
                            if (!aa.Contains(teste) && teste != "")
                                aa.Add(teste);
                        }
                    }
                }
                foreach (string aaa in aa)
                {
                    cbTurma.AddItem(aaa);
                }
            }
        }
        public void checarSelec()
        {
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                MySqlCommand checardia = new MySqlCommand("SELECT * FROM profdisc INNER JOIN profs ON cod_prof = profid_disc INNER JOIN disc ON discid_disc = cod_discs WHERE nome_prof = @Nome AND nome_disc = @Disc", CONEXAO);
                try
                {
                    CONEXAO.Open();
                    checardia.Parameters.AddWithValue("@Nome", Properties.Settings.Default.nome);
                    checardia.Parameters.AddWithValue("@Disc", cbDisc2.selectedValue);

                    MySqlDataReader lerDias = checardia.ExecuteReader();

                    while (lerDias.Read())
                    {
                        Vars.discSelec = lerDias["cod_disc"].ToString();
                    }
                    lerDias.Close();
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
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/add/checarSelec.php?disc=" + cbDisc2.selectedValue + "&nome=" + Properties.Settings.Default.nome).Trim();
                Vars.discSelec = resultado;
            }
        }

        public void cbTurma_onItemSelected(object sender, EventArgs e)
        {
            if (Vars.teste.Controls.Contains(this))
            {
                cbDisc2.Show();
                cbDisc2.Enabled = true;
                cbDisc2.Clear();
                if (!Properties.Settings.Default.phpLocal)
                    CONEXAOaaa.Open();
                ifProf();
                if (!Properties.Settings.Default.phpLocal)
                    CONEXAOaaa.Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.permInt == 2)
            {
                Vars.teste.Controls.Clear();
                Vars.af.diaProf = new DiaProf();
                Vars.teste.Controls.Add(Vars.af.diaProf);
            }
            else
            {
                Vars.teste.Controls.Clear();
                Vars.af.dia = new Dia();
                Vars.teste.Controls.Add(Vars.af.dia);
            }
                Vars.atualizarData();
            
        }

        private void AddTarefa_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.permInt > 0)
                btnEnviar.Text = "Adicionar";
            if (Properties.Settings.Default.permInt == 2)
            {
                label4.Show();
                label4.Text = "Selecione sua disciplina:";
                cbDisc.Hide();

            }



            cbDisc.Enabled = true;

            DateTime dateValue = new DateTime(2017, Convert.ToInt32(Vars.mesSelec), Convert.ToInt32(Vars.diaSelec));
            Vars.diaNome = dateValue.ToString("ddd");
            checarDia();
            if (Properties.Settings.Default.permInt == 2)
            {
                cbTurma.Show();
                lblTurma.Visible = true;
                cbTurma.Clear();
                turmas();
            }
            else
            {
                inserirDisc();
            }
        }
    }
}
