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
    public partial class info : UserControl
    {

        BackgroundWorker bwSala;

        public nha[,] discs = new nha[5, 9];

        public string sala = "";

        public bool profH = false;

        public info(string nomeSala)
        {
            InitializeComponent();
            sala = nomeSala;
            btnVoltar.Visible = false;
        }

        public info(string nomeSala, bool aaa)
        {
            InitializeComponent();
            sala = nomeSala;
            profH = aaa;
            btnVoltar.Visible = true;
        }

        public bool prof;

        public MySqlConnection CONEXAOaaa = new MySqlConnection(Vars.Cfg);

        public void aaa(int fon, string dia)
        {
            string aula = "";
            string nomeDisc = "";
            string nomeProf = "";
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlCommand checardia = new MySqlCommand("SELECT aula, " + dia + "_horario, nome_sala, nome_disc, nome_prof FROM horariosnovo INNER JOIN info_salas ON sala_horarios = cod_sala INNER JOIN profdisc ON cod_disc = " + dia +
                "_horario INNER JOIN profs ON profid_disc = cod_prof INNER JOIN disc ON discid_disc = cod_discs WHERE nome_sala = @Sala ORDER BY sala_horarios ASC, aula ASC;", CONEXAOaaa);
                try
                {
                    switch (sala)
                    {
                        case "2º EMC B/D":
                            if (radioButton1.Checked)
                                checardia.Parameters.AddWithValue("@Sala", "2º EMC D");
                            else
                                checardia.Parameters.AddWithValue("@Sala", sala);
                            break;
                        case "1º EMC B/D":
                            if (radioButton1.Checked)
                                checardia.Parameters.AddWithValue("@Sala", "1º EMC D");
                            else
                                checardia.Parameters.AddWithValue("@Sala", sala);
                            break;
                        default:
                            checardia.Parameters.AddWithValue("@Sala", sala);
                            break;
                    }
                    MySqlDataReader lerDias = checardia.ExecuteReader();

                    while (lerDias.Read())
                    {
                        aula = lerDias["aula"].ToString();
                        nomeDisc = lerDias["nome_disc"].ToString();
                        nomeProf = lerDias["nome_prof"].ToString();
                        Invoke(new Action(() =>
                        {
                            discs[fon, (Convert.ToInt32(aula) - 1)].Text = nomeDisc + "\r\n" + nomeProf.ToUpper();
                        }));
                        if (Properties.Settings.Default.nome == nomeProf && Properties.Settings.Default.permInt == 2)
                            Invoke(new Action(() =>
                            {
                                discs[fon, (Convert.ToInt32(aula) - 1)].ForeColor = SystemColors.MenuHighlight;
                            }));
                    }
                    lerDias.Close();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Headers.Add(HttpRequestHeader.Cookie, "_omappvp=G5GhtGuSdJu5So7EDrrDiXhnthCQH1ef5OO17BgyGznZmG1kCycMBjYLZKiZBgjL4iFKDovjhwKM3YeNNK8czcGJInsytSUt; expires=Thu, 31-Aug-28 01:00:12 GMT; path=/");
                kj.Encoding = System.Text.Encoding.UTF8;
                string salaa = "";

                switch (sala)
                {
                    case "2º EMC B/D":
                        if (radioButton1.Checked)
                            salaa = "2º EMC D";
                        else
                            salaa = sala;
                        break;
                    case "1º EMC B/D":
                        if (radioButton1.Checked)
                            salaa = "1º EMC D";
                        else
                            salaa = sala;
                        break;
                    default:
                        salaa = sala;
                        break;
                }

                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/infoaaa.php?sala=" + salaa + "&dia=" + dia).Trim();
                string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string teste in reps)
                {
                    string[] codes = teste.Split(new string[] { "@#@" }, StringSplitOptions.RemoveEmptyEntries);
                    if (codes.Length != 0)
                    {
                        aula = codes[0];
                        nomeDisc = codes[1];
                        nomeProf = codes[2];
                        Invoke(new Action(() =>
                        {
                            discs[fon, (Convert.ToInt32(aula) - 1)].Text = nomeDisc + "\r\n" + nomeProf.ToUpper();
                        }));
                        if (Properties.Settings.Default.nome == nomeProf && Properties.Settings.Default.permInt == 2)
                            Invoke(new Action(() =>
                            {
                                discs[fon, (Convert.ToInt32(aula) - 1)].ForeColor = SystemColors.MenuHighlight;
                            }));
                    }
                    else
                    {
                        aula = "";
                        nomeDisc = "";
                        nomeProf = "";
                        int i = 7;
                        while (i != 10)
                        {
                            Invoke(new Action(() =>
                            {
                                discs[fon, i - 1].Text = nomeDisc + "\r\n" + nomeProf.ToUpper();
                            }));
                            if (Properties.Settings.Default.nome == nomeProf && Properties.Settings.Default.permInt == 2)
                                Invoke(new Action(() =>
                                {
                                    discs[fon, i - 1].ForeColor = SystemColors.MenuHighlight;
                                }));
                            i++;
                        }
                    }

                    
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                foreach (Control grr in tableLayoutPanel1.Controls)
                {
                    if (grr is nha)
                        if (grr.Name[grr.Name.Length - 2] != 'l')
                            if ((Convert.ToInt32(grr.Name[grr.Name.Length - 2].ToString() + grr.Name[grr.Name.Length - 1].ToString()) >= 31))
                            {
                                grr.Text = "";
                            }
                }
                iniciarBw();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                foreach (Control grr in tableLayoutPanel1.Controls)
                {
                    if (grr is nha)
                        if (grr.Name[grr.Name.Length - 2] != 'l')
                            if ((Convert.ToInt32(grr.Name[grr.Name.Length - 2].ToString() + grr.Name[grr.Name.Length - 1].ToString()) >= 31))
                            {
                                grr.Text = "";
                            }
                }
                iniciarBw();
            }

        }

        private BackgroundWorker CreateBackgroundWorker()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bwSala_DoWork;
            return bw;
        }

        private void bwSala_DoWork(object sender, DoWorkEventArgs e)
        {
            bwSala.WorkerSupportsCancellation = true;
            if (!Properties.Settings.Default.phpLocal)
                this.CONEXAOaaa.Open();
            this.aaa(0, "segunda");
            this.aaa(1, "terca");
            this.aaa(2, "quarta");
            this.aaa(3, "quinta");
            this.aaa(4, "sexta");
            if (!Properties.Settings.Default.phpLocal)
                this.CONEXAOaaa.Close();
            if (this.label1.Text.Contains(Properties.Settings.Default.sala))
            {
                StringCollection aaa = new StringCollection();
                foreach (nha aa in discs)
                {
                    aaa.Add(aa.Text);
                }
                Properties.Settings.Default.teste = aaa;
                Properties.Settings.Default.Save();
            }
        }

        public void iniciarBw()
        {
            if (bwSala != null)
            {
                bwSala.CancelAsync();
            }
            bwSala = CreateBackgroundWorker();
            this.CONEXAOaaa.Close();
            bwSala.RunWorkerAsync();

            
        }

        private void info_Load(object sender, EventArgs e)
        {
            int dia = 0;
            int aula = 0;
            for (int k = 1; k < 46; k++)
            {
                nha nha = new nha("lbl" + k.ToString());
                tableLayoutPanel1.Controls.Add(nha);
                discs[dia, aula] = nha;
                discs[dia, aula].ForeColor = Vars.corfontetxt;
                if (dia == 4)
                {
                    dia = 0;
                    aula++;
                }
                else
                    dia++;
            }

            foreach (Control grr in tableLayoutPanel4.Controls)
            {
                if (grr is Label)
                {
                    var aaa = (Label)grr;
                    aaa.Font = new System.Drawing.Font(Vars.ff[0], aaa.Font.Size, FontStyle.Bold);
                }
            }

            label7.Font = new Font(Vars.ff[0], label7.Font.Size, label7.Font.Style);



            if (sala == "2º EMC B/D" || sala == "1º EMC B/D")
            {
                radioButton1.Show();
                radioButton2.Show();
            }

            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                MySqlCommand checarSalas = new MySqlCommand("SELECT * FROM info_salas INNER JOIN profs ON coord = cod_prof WHERE nome_sala = @Nome", CONEXAO);
                checarSalas.Parameters.AddWithValue("@Nome", sala);
                try
                {
                    CONEXAO.Open();

                    int cod = Convert.ToInt32(checarSalas.ExecuteScalar());

                    if (cod > 0)
                    {
                        MySqlDataReader lerSalas = checarSalas.ExecuteReader();

                        while (lerSalas.Read())
                        {
                            label1.Text = lerSalas["nome_sala"] + " (ID " + lerSalas["cod_sala"] + ")";
                            label2.Text = "Sala de aula: " + lerSalas["numero_sala"] + ", Bloco " + lerSalas["bloco"] + " " + lerSalas["andar"] + "º andar";
                            label3.Text = "Coordenador(a): " + lerSalas["nome_prof"];
                            label4.Text = "Curso: " + lerSalas["curso"];
                            label6.Text = lerSalas["rep1"].ToString();
                            if (lerSalas["rep2"].ToString() != "")
                                label6.Text += " e " + lerSalas["rep2"];
                            if (lerSalas["nome_sala"].ToString() == Properties.Settings.Default.sala)
                                label7.Show();
                            if (label6.Text == "")
                                label6.Text = "Desconhecido (s)!";


                        }
                        lerSalas.Close();
                    }
                    else
                    {
                        MySqlCommand checarSalas2 = new MySqlCommand("SELECT * FROM info_salas WHERE nome_sala = @Nome", CONEXAO);
                        checarSalas2.Parameters.AddWithValue("@Nome", sala);
                        MySqlDataReader lerSalas2 = checarSalas2.ExecuteReader();

                        while (lerSalas2.Read())
                        {
                            label1.Text = lerSalas2["nome_sala"] + " (ID " + lerSalas2["cod_sala"] + ")";
                            label2.Text = "Sala de aula: " + lerSalas2["numero_sala"] + ", Bloco " + lerSalas2["bloco"] + " " + lerSalas2["andar"] + "º andar";
                            label3.Text = "Coordenador(a): Desconhecido!";
                            label4.Text = "Curso: " + lerSalas2["curso"];
                            label6.Text = lerSalas2["rep1"].ToString();
                            if (lerSalas2["rep2"].ToString() != "")
                                label6.Text += " e " + lerSalas2["rep2"];
                            if (lerSalas2["nome_sala"].ToString() == Properties.Settings.Default.sala)
                                label7.Show();
                            if (label6.Text == "")
                                label6.Text = "Desconhecido(s)!";

                        }
                        lerSalas2.Close();
                    }
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
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/infoSalas.php?sala=" + sala).Trim();
                string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string teste in reps)
                {
                    string[] codes = teste.Split(new string[] { "@#@" }, StringSplitOptions.None);
                    label1.Text = codes[1] + " (ID " + codes[2] + ")";
                    label2.Text = "Sala de aula: " + codes[3] + ", Bloco " + codes[4] + " " + codes[5] + "º andar";
                    if (resultado[0] == '1')
                    {
                        label3.Text = "Coordenador(a): " + codes[6];
                        label4.Text = "Curso: " + codes[7];
                        label6.Text = codes[8];
                        if (codes[9] != "")
                            label6.Text += " e " + codes[9];
                        if (codes[1] == Properties.Settings.Default.sala)
                            label6.Show();
                        if (label6.Text == "")
                            label6.Text = "Desconhecido (s)!";
                    }
                    else
                    {
                        label3.Text = "Coordenador(a): Desconhecido!";
                        label4.Text = "Curso: " + codes[6];
                        label6.Text = codes[7];
                        if (codes[8] != "")
                            label6.Text += " e " + codes[8];
                        if (codes[1] == Properties.Settings.Default.sala)
                            label6.Show();
                        if (label6.Text == "")
                            label6.Text = "Desconhecido (s)!";
                    }
                }
            }

            foreach (Control aa in this.Controls)
            {
                if (aa is Bunifu.Framework.UI.BunifuThinButton2)
                {
                    var aaa = (Bunifu.Framework.UI.BunifuThinButton2)aa;
                    if (aaa.ButtonText == "" || aaa.ButtonText == "ThinButton" || !aaa.Visible)
                        aaa.Visible = false;
                    else
                        aaa.Show();
                    aaa.Refresh();
                }
            }

            iniciarBw();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (profH)
            {
                Vars.teste.Controls.Clear();
                Vars.teste.Controls.Add(Vars.af.principalProf);
            }
            else
            {
                Vars.teste.Controls.Clear();
                Vars.teste.Controls.Add(Vars.af.turmas);
            }
        }

        private void btnVoltar_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void info_VisibleChanged(object sender, EventArgs e)
        {
            foreach (Control aa in this.Controls)
            {
                if (aa is Bunifu.Framework.UI.BunifuThinButton2)
                {
                    var aaa = (Bunifu.Framework.UI.BunifuThinButton2)aa;
                    if (aaa.ButtonText == "" || aaa.ButtonText == "ThinButton" || !aaa.Visible)
                        aaa.Visible = false;
                    else
                        aaa.Show();
                    aaa.Refresh();
                }
            }
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            foreach (Control grr in tableLayoutPanel1.Controls)
            {
                if (grr is nha)
                {
                    Single aa = Convert.ToInt32((((nha)grr).Height/5));
                    ((nha)grr).Font = new System.Drawing.Font("Courier New", aa);
                }
            }

            foreach (Control grr in tableLayoutPanel4.Controls)
            {
                if (grr is Label)
                {
                    var aaa = (Label)grr;
                    Single aa = Convert.ToInt32(((aaa).Height/1.3));
                    aaa.Font = new System.Drawing.Font(Vars.ff[0], aa, FontStyle.Bold);
                }
            }
            foreach (Control grr in tableLayoutPanel2.Controls)
            {
                var aaa = (Label)grr;
                Single aa = Convert.ToInt32(((aaa).Height / 1.5));
                string fon = aa.ToString();
                aaa.Font = new System.Drawing.Font("Courier New", aa);
                fon += (aaa).Height.ToString();
            }
        }
    }

    public class nha : Label
    {
        public nha(string nome)
        {
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Font = new System.Drawing.Font("Courier New", 8F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = nome;
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tag = this.Height / this.Font.Size;
        }
    }

}
