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
    public partial class principalProf : UserControl
    {
        public principalProf()
        {
            InitializeComponent();
            Vars.af.principal = null;
        }
        MySqlConnection CONEXAOaaa = new MySqlConnection(Vars.Cfg);

        public Label[,] discs = new Label[5, 9];
        BackgroundWorker horario;

        private void clickLblProf(object sender, EventArgs e)
        {
            Label lbl = sender as Label;

            string[] stringSeparators = new string[] { "\r\n" };
            string[] testee = lbl.Text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Vars.teste.Controls.Clear();
                Vars.af.info = new info(testee[0], true);
                Vars.teste.Controls.Add(Vars.af.info);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void enterLblProf(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = Color.Gold;
        }

        private void leaveLblProf(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(205)))));
        }

        private void frmPrincipal_Shown(object sender, EventArgs e)
        {
            Vars.af.lblNome.Text = Properties.Settings.Default.nome;
            Vars.af.lblSala.Text = Properties.Settings.Default.sala;
            Vars.af.lblId.Text = "ID: " + Properties.Settings.Default.cod;
            int i = 44;

            int dia = 4;
            int aula = 8;

            foreach (Control c in Controls)
            {
                if (c is Label)
                {
                    if (c.Name == "lbl" + (i + 1).ToString())
                    {
                        discs[dia, aula] = (Label)c;
                        if (aula == 0)
                        {
                            aula = 8;
                            dia--;
                        }
                        else
                            aula--;
                        i--;
                    }
                }
            }
            iniciarBw();
        }

        public void aaa(int fon, string dia)
        {
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlCommand checardia = new MySqlCommand("SELECT aula, " + dia + "_horario, nome_sala, nome_disc, nome_prof FROM horariosnovo INNER JOIN info_salas ON sala_horarios = cod_sala INNER JOIN profdisc ON cod_disc = " + dia +
                    "_horario INNER JOIN profs ON profid_disc = cod_prof INNER JOIN disc ON discid_disc = cod_discs WHERE nome_prof = @Nome ORDER BY nome_sala DESC, sala_horarios ASC, aula ASC;", CONEXAOaaa);
                try
                {
                    checardia.Parameters.AddWithValue("@Nome", Properties.Settings.Default.nome);
                    MySqlDataReader lerDias = checardia.ExecuteReader();

                    while (lerDias.Read())
                    {

                        Invoke(new Action(() =>
                        {
                            discs[fon, (Convert.ToInt32(lerDias["aula"]) - 1)].Text = lerDias["nome_sala"].ToString() + "\r\n" + lerDias["nome_disc"].ToString();
                        }));
                    }
                    lerDias.Close();
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
                    if (codes.Length != 0)
                    {
                        Invoke(new Action(() =>
                        {
                            discs[fon, (Convert.ToInt32(codes[0]) - 1)].Text = codes[2] + "\r\n" + codes[1].ToString();
                        }));
                    }
                    else
                    {
                        int i = 7;
                        while (i != 10)
                        {
                            Invoke(new Action(() =>
                            {
                                discs[fon, i - 1].Text = "" + "\r\n" + "";
                            }));
                            if (Properties.Settings.Default.nome == "" && Properties.Settings.Default.permInt == 2)
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


        private void horario_DoWork(object sender, DoWorkEventArgs e)
        {

            Invoke(new Action(() =>
            {
                this.label1.Visible = true;
                this.lblSegunda.Visible = true;
                this.lblTerça.Visible = true;
                this.lblQuarta.Visible = true;
                this.lblQuinta.Visible = true;
                this.lblSexta.Visible = true;
            }));
            try
            {
                if (!Properties.Settings.Default.phpLocal)
                    this.CONEXAOaaa.Open();
                this.aaa(0, "segunda");
                this.aaa(1, "terca");
                this.aaa(2, "quarta");
                this.aaa(3, "quinta");
                this.aaa(4, "sexta");
                if (!Properties.Settings.Default.phpLocal)
                    this.CONEXAOaaa.Close();
                Invoke(new Action(() =>
                {
                    foreach (Label lbl in discs)
                    {
                        lbl.Visible = true;
                        if (lbl.Text != "")
                        {
                            lbl.Cursor = Cursors.Hand;
                            lbl.Click += new EventHandler(clickLblProf);
                            lbl.MouseEnter += new EventHandler(enterLblProf);
                            lbl.MouseLeave += new EventHandler(leaveLblProf);
                        }
                    }
                }));

            }
            catch (Exception eeee)
            {
                if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                MessageBox.Show(eeee.Message);
            }


        }

        public void iniciarBw()
        {
            if (horario != null)
            {
                horario.CancelAsync();
            }
            horario = CreateBackgroundWorkerHorario();
            horario.RunWorkerAsync();
        }

        private BackgroundWorker CreateBackgroundWorkerHorario()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += horario_DoWork;
            return bw;
        }

        private void principalProf_Load(object sender, EventArgs e)
        {
            iniciarBw();
        }

    }

}
