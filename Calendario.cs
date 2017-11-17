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
    public partial class Calendario : UserControl
    {
        BackgroundWorker bwMes;
        public string mes = "";

        private BackgroundWorker CreateBackgroundWorker()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += bwMes_DoWork;
            return bw;
        }

        public void iniciarBw()
        {
            if (bwMes != null)
            {
                bwMes.CancelAsync();
            }
            bwMes = CreateBackgroundWorker();
            bwMes.RunWorkerAsync();
        }

        private void bwMes_DoWork(object sender, DoWorkEventArgs e)
        {
            arrumarDias();
        }
        
        public Calendario(string qualquercoisa)
        {
            InitializeComponent();
            mes = qualquercoisa;

            a1.Tag = ad1.Text = Vars.mesSelecArray[0];
            a2.Tag = ad2.Text = Vars.mesSelecArray[1];
            a3.Tag = ad3.Text = Vars.mesSelecArray[2];
            a4.Tag = ad4.Text = Vars.mesSelecArray[3];
            a5.Tag = ad5.Text = Vars.mesSelecArray[4];
            a6.Tag = ad6.Text = Vars.mesSelecArray[5];
            a7.Tag = ad7.Text = Vars.mesSelecArray[6];
            a8.Tag = ad8.Text = Vars.mesSelecArray[7];
            a9.Tag = ad9.Text = Vars.mesSelecArray[8];
            a10.Tag = ad10.Text = Vars.mesSelecArray[9];
            a11.Tag = ad11.Text = Vars.mesSelecArray[10];
            a12.Tag = ad12.Text = Vars.mesSelecArray[11];
            a13.Tag = ad13.Text = Vars.mesSelecArray[12];
            a14.Tag = ad14.Text = Vars.mesSelecArray[13];
            a15.Tag = ad15.Text = Vars.mesSelecArray[14];
            a16.Tag = ad16.Text = Vars.mesSelecArray[15];
            a17.Tag = ad17.Text = Vars.mesSelecArray[16];
            a18.Tag = ad18.Text = Vars.mesSelecArray[17];
            a19.Tag = ad19.Text = Vars.mesSelecArray[18];
            a20.Tag = ad20.Text = Vars.mesSelecArray[19];
            a21.Tag = ad21.Text = Vars.mesSelecArray[20];
            a22.Tag = ad22.Text = Vars.mesSelecArray[21];
            a23.Tag = ad23.Text = Vars.mesSelecArray[22];
            a24.Tag = ad24.Text = Vars.mesSelecArray[23];
            a25.Tag = ad25.Text = Vars.mesSelecArray[24];
            a26.Tag = ad26.Text = Vars.mesSelecArray[25];
            a27.Tag = ad27.Text = Vars.mesSelecArray[26];
            a28.Tag = ad28.Text = Vars.mesSelecArray[27];
            a29.Tag = ad29.Text = Vars.mesSelecArray[28];
            a30.Tag = ad30.Text = Vars.mesSelecArray[29];
            a31.Tag = ad31.Text = Vars.mesSelecArray[30];
            a32.Tag = ad32.Text = Vars.mesSelecArray[31];
            a33.Tag = ad33.Text = Vars.mesSelecArray[32];
            a34.Tag = ad34.Text = Vars.mesSelecArray[33];
            a35.Tag = ad35.Text = Vars.mesSelecArray[34];
        }
        public void arrumarDias()
        {
            foreach (Control aa in tableLayoutPanel2.Controls)
            {
                if (aa is TableLayoutPanel)
                {
                    foreach (Control aaa in aa.Controls)
                    {
                        if (aaa is FlowLayoutPanel)
                        {
                            Invoke(new Action(() =>
                {
                    ((FlowLayoutPanel)aaa).Controls.Clear();
                }));
                        }
                    }
                }
            }

                if (Properties.Settings.Default.permInt == 2)
                {
                    if (!Properties.Settings.Default.phpLocal)
                    {
                        MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                        MySqlCommand checardia = new MySqlCommand("SELECT * FROM licoes INNER JOIN profdisc on cod_disc = disc INNER JOIN profs on cod_prof = profid_disc INNER JOIN disc on cod_discs = discid_disc INNER JOIN info_salas on cod_sala = sala WHERE mesentrega = @Mes AND avaliado > 0 AND nome_prof = @Nome", CONEXAO);
                        try
                        {
                            CONEXAO.Open();
                            checardia.Parameters.AddWithValue("@Mes", Vars.mesSelec);
                            checardia.Parameters.AddWithValue("@Nome", Properties.Settings.Default.nome);

                            MySqlDataReader lerDias = checardia.ExecuteReader();

                            while (lerDias.Read())
                            {
                                Vars.diaRetorno = lerDias["diaentrega"].ToString();
                                Vars.resumo = lerDias["nome_sala"].ToString();
                                checarDias(Convert.ToInt32(lerDias["diaentrega"]), lerDias["nome_sala"].ToString() + ";");
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
                        string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/calendario/resumosProf.php?mes=" + Vars.mesSelec + "&nome=" + Properties.Settings.Default.nome).Trim();
                        string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string teste in reps)
                        {
                            string[] codes = teste.Split(new string[] { "@#@" }, StringSplitOptions.RemoveEmptyEntries);
                            Vars.diaRetorno = codes[0];
                            Vars.resumo = codes[1];
                            checarDias(Convert.ToInt32(codes[0]), codes[1]);
                        }

                    }
                }
                else
                {
                    if (!Properties.Settings.Default.phpLocal)
                    {
                        MySqlConnection CONEXAO = new MySqlConnection(Vars.Cfg);
                        MySqlCommand checardia = new MySqlCommand("SELECT * FROM licoes WHERE mesentrega = @Mes AND avaliado > 0 AND sala = @Sala", CONEXAO);
                        try
                        {
                            CONEXAO.Open();
                            checardia.Parameters.AddWithValue("@Mes", Vars.mesSelec);
                            checardia.Parameters.AddWithValue("@Sala", Properties.Settings.Default.codSala);

                            MySqlDataReader lerDias = checardia.ExecuteReader();

                            while (lerDias.Read())
                            {
                                Vars.diaRetorno = lerDias["diaentrega"].ToString();
                                Vars.resumo = lerDias["resumo"].ToString() + ";";
                                checarDias(Convert.ToInt32(lerDias["diaentrega"]), lerDias["resumo"].ToString() + ";");
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
                        string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/calendario/resumos.php?mes=" + Vars.mesSelec + "&sala=" + Properties.Settings.Default.codSala).Trim();
                        string[] reps = resultado.Split(new string[] { "&&&" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string teste in reps)
                        {
                            string[] codes = teste.Split(new string[] { "@#@" }, StringSplitOptions.RemoveEmptyEntries);
                            Vars.diaRetorno = codes[0];
                            Vars.resumo = codes[1];
                            checarDias(Convert.ToInt32(codes[0]), codes[1]);
                        }
                    }

                }



        }
        public void checarDias(int dia, string resumo)
        {
            foreach (Control aaa in tableLayoutPanel2.Controls)
            {
                if (aaa is TableLayoutPanel)
                {
                    foreach (Control aaaa in aaa.Controls)
                    {
                        if (aaaa is FlowLayoutPanel)
                        {
                            var aaaaa = (FlowLayoutPanel)aaaa;
                            if (aaaaa.Tag.ToString() != "")
                            {
                                Invoke(new Action(() =>
                                {
                                    if (Convert.ToInt32(aaaa.Tag).Equals(dia))
                                    {
                                        testee teste = new testee(resumo);
                                        aaaaa.Controls.Add(teste);
                                        FontStyle estilo = FontStyle.Regular;
                                        if (teste.Font.Bold)
                                            estilo = FontStyle.Bold;
                                        teste.Font = new System.Drawing.Font(teste.Font.FontFamily, 9F, estilo);
                                        teste.Tag = 9F;
                                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width )
                                            teste.Font = new System.Drawing.Font(teste.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(teste.Tag) * 1.5), estilo);
                                    }
                                    
                                }));
                            }
                        }
                    }
                }
            }
        }

        public void Label_Click(object sender, EventArgs e)
        {
            Vars.diaSelec = ((TableLayoutPanel)sender).Tag.ToString();
            if (Properties.Settings.Default.permInt == 2)
            {
                Vars.teste.Controls.Clear();
                Vars.af.diaProf = new DiaProf() { Dock = DockStyle.Fill };
                Vars.teste.Controls.Add(Vars.af.diaProf);
            }
            else
            {
                Vars.teste.Controls.Clear();
                Vars.af.dia = new Dia() { Dock = DockStyle.Fill };
                Vars.teste.Controls.Add(Vars.af.dia);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            arrumarDias();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Vars.teste.Controls.Clear();
            if (Vars.af.selecMes == null)
                Vars.af.selecMes = new selecMes();
            Vars.teste.Controls.Add(Vars.af.selecMes);
        }

        private void Calendario_Load(object sender, EventArgs e)
        {
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

            foreach (Control aaa in tableLayoutPanel2.Controls)
            {
                if (aaa is TableLayoutPanel)
                {
                    Invoke(new Action(() =>
                    {
                        ((TableLayoutPanel)aaa).BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    }));
                    foreach (Control aaaa in aaa.Controls)
                    {
                        if (aaaa is FlowLayoutPanel)
                        {
                            var aaaaa = (FlowLayoutPanel)aaaa;
                            if (aaaaa.Tag != null || aaaaa.Tag.ToString() != "")
                            {
                                Invoke(new Action(() =>
                                {
                                    ((TableLayoutPanel)aaa).Tag = aaaaa.Tag;
                                    ((TableLayoutPanel)aaa).Cursor = Cursors.Hand;
                                    ((TableLayoutPanel)aaa).Click += new EventHandler(Label_Click);
                                }));
                            }
                        }
                    }
                }
            }
            Invoke(new Action(() =>
            {
                /*if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                    foreach (Control aa in tableLayoutPanel2.Controls)
                    {
                        if (aa is TableLayoutPanel)
                        {
                            foreach (Control aaa in aa.Controls)
                            {
                                if (aaa is FlowLayoutPanel)
                                {
                                    foreach (Control aaaa in aaa.Controls)
                                    {
                                        if (aaaa is Label)
                                        {
                                            FontStyle estilo = FontStyle.Regular;
                                            if (aaaa.Font.Bold)
                                                estilo = FontStyle.Bold;
                                            if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                                                aaaa.Font = new System.Drawing.Font(aaaa.Font.FontFamily, Convert.ToInt32(aaaa.Height / (aaaa.Height / aaaa.Font.Size / 1.5)), estilo);
                                        }
                                    }
                                }
                            }
                        }
                    }*/

                foreach (Control aa in tableLayoutPanel2.Controls)
                {
                    if (aa is Label)
                        aa.Tag = aa.Height / aa.Font.Size;
                    if (aa is TableLayoutPanel)
                    {
                        foreach (Control aaa in aa.Controls)
                        {
                            if (aaa is Label)
                                aaa.Tag = aaa.Height / aaa.Font.Size;
                        }
                    }
                }

                bunifuThinButton21.Tag = bunifuThinButton21.Height / bunifuThinButton21.Font.Size;
                bunifuThinButton22.Tag = bunifuThinButton22.Height / bunifuThinButton22.Font.Size;
            }));
        }

        private void Calendario_VisibleChanged(object sender, EventArgs e)
        {
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
            //iniciarBw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            iniciarBw();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel32_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel36_Paint(object sender, PaintEventArgs e)
        {

        }

        private void a30_Click(object sender, EventArgs e)
        {
            Label_Click((((Control)sender).Parent), null);
        }

        private void tableLayoutPanel2_Resize(object sender, EventArgs e)
        {
            foreach (Control aa in tableLayoutPanel2.Controls)
            {
                if (aa is Label)
                    Vars.resize(aa);
                if (aa is TableLayoutPanel)
                {
                    foreach (Control aaa in aa.Controls)
                    {
                        if (aaa is Label)
                            Vars.resize(aaa);
                        if (aaa is FlowLayoutPanel)
                        {
                            foreach (Control aaaa in aaa.Controls)
                            {
                                if (aaaa is testee)
                                {
                                    if (FormWindowState.Minimized != Vars.af.WindowState)
                                    {
                                        FontStyle estilo = FontStyle.Regular;
                                        if (aaaa.Font.Bold)
                                            estilo = FontStyle.Bold;
                                        if (Vars.af.Width == Screen.PrimaryScreen.WorkingArea.Width)
                                            aaaa.Font = new System.Drawing.Font(aaaa.Font.FontFamily, Convert.ToInt32(Convert.ToInt32(aaaa.Tag) * 1.5), estilo);
                                            else
                                                aaaa.Font = new System.Drawing.Font(aaaa.Font.FontFamily, 9F, estilo);
                                    }
                                }
                            }
                            aaa.Invalidate();
                        }
                    }
                }
            }
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
    }

    class testee : Label
    {
        public testee(string texto)
        {
            this.Font = new System.Drawing.Font("Century Gothic", 9F, FontStyle.Bold);
            this.ForeColor = Vars.corTxt;
            this.AutoSize = true;
            this.Text = texto;
            this.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Click += new EventHandler(clic);
            this.Margin = new System.Windows.Forms.Padding(0);
        }

        void clic(object sender, EventArgs e)
        {
            Vars.af.calendario.Label_Click(((FlowLayoutPanel)(((testee)sender).Parent)).Parent, null);
        }
    }

}
