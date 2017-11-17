using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace DiarioDeClasse
{
    
    public partial class Form1 : Form
    {

        StringBuilder sb = new StringBuilder();
        public login login1 = new DiarioDeClasse.login() { Dock = DockStyle.Fill };
        public principal principal;
        public principalProf principalProf;
        public carregando carregando = new carregando();
        public AddTarefa addTarefa;
        public Calendario calendario;
        public Dia dia;
        public DiaProf diaProf;
        public info info;
        public selecMes selecMes;
        public turmas turmas;
        public avisos avisos;
        public Registrar registrar;


        BackgroundWorker licao, aviso, rep;

        public List<string> aLicao1 = new List<string>();
        public List<string> aLicao2 = new List<string>();
        public List<string> aAviso1 = new List<string>();
        public List<string> aAviso2 = new List<string>();
        public List<string> aRep1 = new List<string>();
        public List<string> aRep2 = new List<string>();



        public void iniciarBw()
        {
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

        private BackgroundWorker CreateBackgroundWorkerLicao()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += licao_DoWork;
            bw.RunWorkerCompleted += licao_RunWorkerCompleted;
            return bw;
        }

        private BackgroundWorker CreateBackgroundWorkerAviso()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += aviso_DoWork;
            bw.RunWorkerCompleted += aviso_RunWorkerCompleted;
            return bw;
        }

        private BackgroundWorker CreateBackgroundWorkerRep()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += rep_DoWork;
            bw.RunWorkerCompleted += rep_RunWorkerCompleted;
            return bw;
        }

        private void rep_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAObw = new MySqlConnection(Vars.Cfg);
                MySqlCommand checarTarefas = new MySqlCommand("SELECT * FROM licoes INNER JOIN profdisc ON licoes.disc = cod_disc INNER JOIN info_salas ON sala = cod_sala INNER JOIN disc ON discid_disc = cod_discs WHERE avaliado = 0 AND nome_sala = @Sala", CONEXAObw);
                checarTarefas.Parameters.AddWithValue("@Sala", Properties.Settings.Default.sala);
                try
                {
                    CONEXAObw.Open();
                    MySqlDataReader lerTarefas = checarTarefas.ExecuteReader();
                    while (lerTarefas.Read())
                    {
                        if (!aRep1.Contains(lerTarefas["cod"].ToString()))
                            aRep1.Add(lerTarefas["cod"].ToString());
                    }
                    lerTarefas.Close();
                }
                catch (Exception erro)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                }
                finally
                {
                    CONEXAObw.Close();
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/codRep.php?sala=" + Properties.Settings.Default.sala).Trim();
                string[] codes = resultado.Split(new string[] { "@#@", " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string aa in codes)
                {
                    if (!aRep1.Contains(aa))
                        aRep1.Add(aa);
                }
            }
            try
            {
                if (!aRep1.SequenceEqual(aRep2) && !principal.rep.IsBusy)
                {
                    if (principal.rep != null)
                    {
                        principal.rep.CancelAsync();
                    }
                    principal.rep = principal.CreateBackgroundWorkerRep();
                    principal.rep.RunWorkerAsync();
                    aRep2.Clear();
                    Invoke(new Action(() =>
                    {
                        piscarLaranja.Flash(this);
                    }));
                    if (!btnInicio.selected)
                        btnInicio.Normalcolor = Color.Red;
                }
            }
            catch { }
            finally
            {
                aRep1.Clear();
            }
        }

        private void aviso_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAObw = new MySqlConnection(Vars.Cfg);
                MySqlCommand checarAvisos = new MySqlCommand("SELECT * FROM avisos WHERE excluido_avisos = 0 AND sala_aviso = '" + Properties.Settings.Default.codSala + "' OR sala_aviso = 0 ORDER BY adicionadoem_aviso DESC;", CONEXAObw);
                try
                {
                    CONEXAObw.Open();
                    MySqlDataReader lerAvisos = checarAvisos.ExecuteReader();
                    while (lerAvisos.Read())
                    {
                        if (!aAviso1.Contains(lerAvisos["cod_aviso"].ToString()))
                            aAviso1.Add(lerAvisos["cod_aviso"].ToString());
                    }
                    lerAvisos.Close();
                }
                catch (Exception ee)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show(ee.Message);
                }
                finally
                {
                    CONEXAObw.Close();
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/codAviso.php?sala=" + Properties.Settings.Default.codSala).Trim();
                string[] codes = resultado.Split(new string[] { "@#@", " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string aa in codes)
                {
                    if (!aAviso1.Contains(aa))
                        aAviso1.Add(aa);
                }
            }
            try
            {
                if (!aAviso1.SequenceEqual(aAviso2) && !principal.aviso.IsBusy)
                {
                    if (principal.aviso != null)
                    {
                        principal.aviso.CancelAsync();
                    }
                    principal.aviso = principal.CreateBackgroundWorkerAviso();
                    principal.aviso.RunWorkerAsync();
                    aAviso2.Clear();
                    Invoke(new Action(() =>
                    {
                        piscarLaranja.Flash(this);
                    }));
                    if (!btnInicio.selected)
                        btnInicio.Normalcolor = Color.Red;
                }
            }
            catch { }
            finally
            {
                aAviso1.Clear();
            }
        }

        private void licao_DoWork(object sender, DoWorkEventArgs e)
        {
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


            sb.Append("LICAO1= ");
            foreach (string aaa in aLicao1)
            {
                sb.Append(aaa);
            }
            sb.Append("\r\nLICAO2= ");
            foreach (string aaa in aLicao2)
            {
                sb.Append(aaa);
            }
            sb.Append("\r\n\r\n\r\n");
            File.AppendAllText("log.txt", sb.ToString());
            sb.Clear();
            try
            {
                if (!aLicao1.SequenceEqual(aLicao2) && !principal.licao.IsBusy)
                {
                    if (principal.licao != null)
                    {
                        principal.licao.CancelAsync();
                    }
                    principal.licao = principal.CreateBackgroundWorkerLicao();
                    principal.licao.RunWorkerAsync();
                    aLicao2.Clear();
                    Invoke(new Action(() =>
                    {
                        piscarLaranja.Flash(this);
                    }));
                    if (!btnInicio.selected)
                        btnInicio.Normalcolor = Color.Red;
                    SoundPlayer audio = new SoundPlayer("lvl.wav"); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name
                    audio.Play();
                }
            }
            finally
            {
                aLicao1.Clear();
            }
        }

        void licaoSemana(string dia, string mes)
        {
            if (!Properties.Settings.Default.phpLocal)
            {
                MySqlConnection CONEXAOlicao = new MySqlConnection(Vars.Cfg);
                MySqlCommand checarLicoes = new MySqlCommand("SELECT cod FROM licoes INNER JOIN profdisc ON licoes.disc = cod_disc INNER JOIN disc ON discid_disc = cod_discs WHERE mesentrega = @Mes AND diaentrega = @Dia AND avaliado > 0 AND sala = '" + Properties.Settings.Default.codSala + "';", CONEXAOlicao);
                try
                {
                    CONEXAOlicao.Open();
                    checarLicoes.Parameters.AddWithValue("@Mes", mes);
                    checarLicoes.Parameters.AddWithValue("@Dia", dia);
                    MySqlDataReader lerLicoes = checarLicoes.ExecuteReader();

                    while (lerLicoes.Read())
                    {
                        if (!aLicao1.Contains(lerLicoes["cod"].ToString()))
                            aLicao1.Add(lerLicoes["cod"].ToString());
                    }
                    lerLicoes.Close();
                }
                catch (Exception erro)
                {
                    if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                    MessageBox.Show("Houve um erro no MySql:\r\n" + erro.Message);
                }
                finally
                {
                    CONEXAOlicao.Close();
                }
            }
            else
            {
                WebClient kj = new WebClient();
                kj.Encoding = System.Text.Encoding.UTF8;
                string resultado = kj.DownloadString("http://" + Vars.cfgPhp + "/codLicao.php?sala=" + Properties.Settings.Default.codSala + "&dia=" + dia + "&mes=" + mes).Trim();
                string[] codes = resultado.Split(new string[] { "@#@", " " }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string aa in codes)
                {
                    aLicao1.Add(aa);
                }
            }
        }

        public string checarDia(string aa)
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

        /*public void FontFamily(string aaa, FontFamily grr)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();

            Stream fontStream = this.GetType().Assembly.GetManifestResourceStream(aaa);
            System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
            Byte[] fontData = new Byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            Marshal.Copy(fontData, 0, data, (int)fontStream.Length);
            uint cFonts = 0;
            AddFontMemResourceEx(data, (uint)fontData.Length, IntPtr.Zero, ref cFonts);
            pfc.AddMemoryFont(data, (int)fontStream.Length);
            fontStream.Close();
            Marshal.FreeCoTaskMem(data);
            grr = new FontFamily(pfc.Families.First().Name, pfc);
        }*/


        public PrivateFontCollection pfc;

        public Form1()
        {
            InitializeComponent();


            Vars.teste = panelTudo;
            Vars.af = this;

            Vars.FontFamily("DiarioDeClasse.Fontes.TrajanPro-Bold.otf", this);
            Vars.FontFamily("DiarioDeClasse.Fontes.Lobster-Regular.ttf", this);
            Vars.FontFamily("DiarioDeClasse.Fontes.Raleway-Bold.ttf", this);
            Vars.FontFamily("DiarioDeClasse.Fontes.Cooper Std Black.ttf", this);

            this.BackColor = Vars.corFundo;
            header.BackColor = Vars.corFundoHeader;
            lblTit.ForeColor = Vars.corTit;
            btnInicio.Normalcolor = Color.DimGray;
            btnHorario.Normalcolor = Color.DimGray;
            btnCalendario.Normalcolor = Color.DimGray;
            btnTurmas.Normalcolor = Color.DimGray;
            btnCfg.Normalcolor = Color.DimGray;
            sideBar.BackColor = Color.DimGray;
            btnMenu.Tag = 0;
            sideBar.Width = 50;
            if (Properties.Settings.Default.fullsc == 1)
                btnMax_Click(btnMax, null);
            else
                this.Width = 715;
            btnMenu.Location = new System.Drawing.Point(0, 0);
            btnMenu.Image = Properties.Resources.icons8_Forward_64px_1;
            if (Properties.Settings.Default.phpLocal)
                bunifuCheckbox1.Checked = true;
            else
                bunifuCheckbox1.Checked = false;
            Vars.transpPB(pictureBox1);
            Vars.transpPB(logoUD);

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (Vars.logado)
            {
                btnMenu.Location = new System.Drawing.Point(181, 0);
                if (btnMenu.Tag.ToString() == "0")
                {
                    btnMenu.Tag = 1;
                    btnMenu.Image = Properties.Resources.icons8_Back_64px_1;
                    sideBar.Visible = false;
                    if (this.Width == 715)
                        this.Width = 900;
                    sideBar.Width = 235;
                    transMenu.Show(sideBar);
                    transLogo.Show(panelLabels);
                    transLogo.Show(panel2);
                }
                else
                {
                    btnMenu.Tag = 0;
                    transLogo.HideSync(panel2);
                    transLogo.HideSync(panelLabels);
                    sideBar.Visible = false;
                    sideBar.Width = 50;
                    if (this.Width == 900)
                        this.Width = 715;
                    btnMenu.Location = new System.Drawing.Point(0, 0);
                    btnMenu.Image = Properties.Resources.icons8_Forward_64px_1;
                    transMenu2.Show(sideBar);
                }
            }
            else
                MessageBox.Show("Logar antes");
        }

        public void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            btnInicio.Normalcolor = Vars.corFundoSide;
            btnInicio.selected = true;
            panelTudo.Hide();
            panelTudo.Controls.Clear();
            panelTudo.Show();
            if (Properties.Settings.Default.permInt == 2)
            {
                if (principalProf == null)
                    principalProf = new principalProf();
                panelTudo.Controls.Add(principalProf);
            }
            else
            {
                if (principal == null || principal.panelVerif.Controls.Count > 15 || principal.flowLayoutPanel1.Controls.Count > 15)
                {
                    //nullBw();
                    principal = new principal(){ Dock = DockStyle.Fill };
                }
                panelTudo.Controls.Add(principal);
            }
        }

        private void logoUD_Click(object sender, EventArgs e)
        {
        }

        private void btnFechar_MouseEnter(object sender, EventArgs e)
        {
            btnFechar.BackColor = Color.FromArgb(200, Color.Gray);
        }

        private void btnFechar_MouseLeave(object sender, EventArgs e)
        {
            btnFechar.BackColor = Color.Transparent;
        }

        private void btnMin_MouseEnter(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.FromArgb(200, Color.Gray);
        }

        private void btnMin_MouseLeave(object sender, EventArgs e)
        {
            btnMin.BackColor = Color.Transparent;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_MouseEnter(object sender, EventArgs e)
        {
            bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
        }

        private void bunifuImageButton1_MouseLeave(object sender, EventArgs e)
        {
            bunifuImageButton1.BackColor = Color.Transparent;
        }

        public void nullBw()
        {
            try
            {
                principal.aviso = null;
                principal.licao = null;
                principal.rep = null;
                aviso = null;
                licao = null;
                rep = null;
            }
            catch (Exception e)
            {
                if (Properties.Settings.Default.permInt == 3 || Properties.Settings.Default.permInt == 9)
                MessageBox.Show(e.Message);
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            btnMenu_Click(btnMenu, null);
            Vars.logado = false;
            if (Properties.Settings.Default.permInt != 3 || Properties.Settings.Default.permInt != 9)
            {
                Properties.Settings.Default.permInt = 0;
            }
            Properties.Settings.Default.nome = "";
            Properties.Settings.Default.usuario = "";
            Properties.Settings.Default.sala = "";
            Properties.Settings.Default.lembrarsenha = 0;
            Properties.Settings.Default.Save();
            btnInicio.Normalcolor = Color.DimGray;
            btnHorario.Normalcolor = Color.DimGray;
            btnCalendario.Normalcolor = Color.DimGray;
            btnTurmas.Normalcolor = Color.DimGray;
            btnCfg.Normalcolor = Color.DimGray;
            sideBar.BackColor = Color.DimGray;
            panel1.Enabled = false;
            login1 = new login();
            panelTudo.Controls.Clear();
            panelTudo.Controls.Add(login1);
            nullBw();
            principal = null;
            principalProf = null;
            addTarefa = null;
            calendario = null;
            dia = null;
            diaProf = null;
            info = null;
            avisos = null;
            registrar = null;
        }

        private void btnMenu_MouseEnter(object sender, EventArgs e)
        {
            btnMenu.BackColor = Color.FromArgb(200, Color.Gray);
        }

        private void btnMenu_MouseLeave(object sender, EventArgs e)
        {
            btnMenu.BackColor = Color.Transparent;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            btnHorario.selected = true;
            panelTudo.Hide();
            panelTudo.Controls.Clear();
            panelTudo.Show();
            if (info == null || !info.label7.Visible)
                info = new info(Properties.Settings.Default.sala) { Dock = DockStyle.Fill };
            panelTudo.Controls.Add(info);
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            btnCalendario.selected = true;
            panelTudo.Hide();
            panelTudo.Controls.Clear();
            panelTudo.Show();
            if (selecMes == null)
                selecMes = new selecMes() { Dock = DockStyle.Fill };
            panelTudo.Controls.Add(selecMes);
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            btnTurmas.selected = true;
            panelTudo.Hide();
            panelTudo.Controls.Clear();
            panelTudo.Show();
            if (turmas == null)
                turmas = new turmas();
            panelTudo.Controls.Add(turmas);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            frmAval aa = new frmAval();
            transAval.Show(aa);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carregando.Dock = DockStyle.Fill;
            panelTudo.Controls.Add(carregando);
            login1.Dock = DockStyle.Fill;
            panelTudo.Controls.Add(login1);
            //if
            
        }

        private void licao_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Properties.Settings.Default.permInt != 2 && licao != null && !licao.IsBusy)
                licao.RunWorkerAsync();
        }
        private void aviso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Properties.Settings.Default.permInt != 2 && aviso != null && !aviso.IsBusy)
                aviso.RunWorkerAsync();
        }
        private void rep_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Properties.Settings.Default.permInt == 1 && rep != null && !rep.IsBusy)
                rep.RunWorkerAsync();
        }

        private void btnCfg_Click(object sender, EventArgs e)
        {
            btnCfg.selected = true;
            panelTudo.Hide();
            panelTudo.Controls.Clear();
            panelTudo.Show();
            avisos = new avisos();
            panelTudo.Controls.Add(avisos);
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {
                Properties.Settings.Default.phpLocal = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.phpLocal = false;
                Properties.Settings.Default.Save();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        public void btnMax_Click(object sender, EventArgs e)
        {
            if (this.Width != Screen.PrimaryScreen.WorkingArea.Width)
            {
                this.Left = Top = 0;
                this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Normal;
                Properties.Settings.Default.fullsc = 1;
                Properties.Settings.Default.Save();
            }
            else
            {
                this.Size = new Size(715, 600);
                this.CenterToScreen();
                Properties.Settings.Default.fullsc = 0;
                Properties.Settings.Default.Save();
            }

            if (btnMenu.Tag.ToString() == "1")
            {
                sideBar.Width = 50;
                panel2.Hide();
                panelLabels.Hide();
                sideBar.Visible = false;
                if (this.Width == 900)
                    this.Width = 715;
                btnMenu.Location = new System.Drawing.Point(0, 0);
                btnMenu.Image = Properties.Resources.icons8_Forward_64px_1;
                transMenu2.Show(sideBar);
            }

            if (principal != null)
            {
                principal = new principal() { Dock = DockStyle.Fill };
            }
            if (dia != null)
            {
                dia = new Dia() { Dock = DockStyle.Fill };
            }
            if (diaProf != null)
            {
                diaProf = new DiaProf() { Dock = DockStyle.Fill };
            }
            foreach (Control grr in panelTudo.Controls)
            {
                if (grr is principal)
                {
                    panelTudo.Hide();
                    panelTudo.Controls.Clear();
                    panelTudo.Show();
                    panelTudo.Controls.Add(principal);
                }
                if (grr is Dia)
                {
                    panelTudo.Hide();
                    panelTudo.Controls.Clear();
                    panelTudo.Show();
                    panelTudo.Controls.Add(dia);
                }
            }
        }

        private void btnMax_MouseEnter(object sender, EventArgs e)
        {
            btnMax.BackColor = Color.FromArgb(200, Color.Gray);
        }

        private void btnMax_MouseLeave(object sender, EventArgs e)
        {
            btnMax.BackColor = Color.Transparent;
        }

        private void logoUD_MouseClick(object sender, MouseEventArgs e)
        {
            if (Vars.HitTest((PictureBox)sender, e.X, e.Y))
                System.Diagnostics.Process.Start("http://site.portalanchieta.com.br");
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Vars.HitTest((PictureBox)sender, e.X, e.Y))
                System.Diagnostics.Process.Start("http://user404.000webhostapp.com/UserDev/userdev.html");
        }
    }
}
