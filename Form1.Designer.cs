namespace DiarioDeClasse
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.sideBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.logoUD = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelLabels = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.lblSala = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnMenu = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCfg = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnTurmas = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCalendario = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnHorario = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnInicio = new Bunifu.Framework.UI.BunifuFlatButton();
            this.header = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMax = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnFechar = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCheckbox1 = new Bunifu.Framework.UI.BunifuCheckbox();
            this.btnMin = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTit = new System.Windows.Forms.Label();
            this.bunifuImageButton3 = new Bunifu.Framework.UI.BunifuImageButton();
            this.panelTudo = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.transMenu = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.transLogo = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.transMenu2 = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.transAval = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.sideBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.header.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // sideBar
            // 
            this.sideBar.Controls.Add(this.panel1);
            this.transAval.SetDecoration(this.sideBar, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.sideBar, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.sideBar, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.sideBar, BunifuAnimatorNS.DecorationType.None);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.Location = new System.Drawing.Point(0, 40);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(235, 560);
            this.sideBar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelLabels);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.btnCfg);
            this.panel1.Controls.Add(this.btnTurmas);
            this.panel1.Controls.Add(this.btnCalendario);
            this.panel1.Controls.Add(this.btnHorario);
            this.panel1.Controls.Add(this.btnInicio);
            this.transAval.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 560);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bunifuImageButton1);
            this.panel2.Controls.Add(this.logoUD);
            this.panel2.Controls.Add(this.pictureBox1);
            this.transAval.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 371);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 189);
            this.panel2.TabIndex = 10;
            this.panel2.Visible = false;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton1.Image = global::DiarioDeClasse.Properties.Resources.icons8_Exit_64px;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(167, 98);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(59, 86);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 4;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 0;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            this.bunifuImageButton1.MouseEnter += new System.EventHandler(this.bunifuImageButton1_MouseEnter);
            this.bunifuImageButton1.MouseLeave += new System.EventHandler(this.bunifuImageButton1_MouseLeave);
            // 
            // logoUD
            // 
            this.logoUD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transMenu2.SetDecoration(this.logoUD, BunifuAnimatorNS.DecorationType.None);
            this.transAval.SetDecoration(this.logoUD, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.logoUD, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.logoUD, BunifuAnimatorNS.DecorationType.None);
            this.logoUD.Image = global::DiarioDeClasse.Properties.Resources.anchieta;
            this.logoUD.Location = new System.Drawing.Point(6, 3);
            this.logoUD.Name = "logoUD";
            this.logoUD.Size = new System.Drawing.Size(226, 89);
            this.logoUD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoUD.TabIndex = 3;
            this.logoUD.TabStop = false;
            this.logoUD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.logoUD_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transMenu2.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.transAval.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Image = global::DiarioDeClasse.Properties.Resources.devLogo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 98);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // panelLabels
            // 
            this.panelLabels.Controls.Add(this.lblId);
            this.panelLabels.Controls.Add(this.lblSala);
            this.panelLabels.Controls.Add(this.lblNome);
            this.transAval.SetDecoration(this.panelLabels, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.panelLabels, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.panelLabels, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.panelLabels, BunifuAnimatorNS.DecorationType.None);
            this.panelLabels.Location = new System.Drawing.Point(0, 41);
            this.panelLabels.Name = "panelLabels";
            this.panelLabels.Size = new System.Drawing.Size(236, 90);
            this.panelLabels.TabIndex = 9;
            this.panelLabels.Visible = false;
            // 
            // lblId
            // 
            this.transMenu2.SetDecoration(this.lblId, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.lblId, BunifuAnimatorNS.DecorationType.None);
            this.transAval.SetDecoration(this.lblId, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.lblId, BunifuAnimatorNS.DecorationType.None);
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblId.Location = new System.Drawing.Point(3, 68);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(233, 21);
            this.lblId.TabIndex = 14;
            this.lblId.Text = "ID";
            // 
            // lblSala
            // 
            this.transMenu2.SetDecoration(this.lblSala, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.lblSala, BunifuAnimatorNS.DecorationType.None);
            this.transAval.SetDecoration(this.lblSala, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.lblSala, BunifuAnimatorNS.DecorationType.None);
            this.lblSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSala.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblSala.Location = new System.Drawing.Point(3, 34);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(233, 21);
            this.lblSala.TabIndex = 13;
            this.lblSala.Text = "Sala";
            // 
            // lblNome
            // 
            this.transMenu2.SetDecoration(this.lblNome, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.lblNome, BunifuAnimatorNS.DecorationType.None);
            this.transAval.SetDecoration(this.lblNome, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.lblNome, BunifuAnimatorNS.DecorationType.None);
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblNome.Location = new System.Drawing.Point(3, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(233, 21);
            this.lblNome.TabIndex = 12;
            this.lblNome.Text = "Nome";
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.btnMenu.Image = global::DiarioDeClasse.Properties.Resources.icons8_Back_64px_1;
            this.btnMenu.ImageActive = null;
            this.btnMenu.Location = new System.Drawing.Point(180, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(54, 40);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 4;
            this.btnMenu.TabStop = false;
            this.btnMenu.Tag = "1";
            this.btnMenu.Zoom = 0;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            this.btnMenu.MouseEnter += new System.EventHandler(this.btnMenu_MouseEnter);
            this.btnMenu.MouseLeave += new System.EventHandler(this.btnMenu_MouseLeave);
            // 
            // btnCfg
            // 
            this.btnCfg.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCfg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCfg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCfg.BorderRadius = 0;
            this.btnCfg.ButtonText = "   Opções e Configurações";
            this.btnCfg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnCfg, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnCfg, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnCfg, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnCfg, BunifuAnimatorNS.DecorationType.None);
            this.btnCfg.DisabledColor = System.Drawing.Color.Gray;
            this.btnCfg.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCfg.Iconimage = global::DiarioDeClasse.Properties.Resources.icons8_Settings_64px;
            this.btnCfg.Iconimage_right = null;
            this.btnCfg.Iconimage_right_Selected = null;
            this.btnCfg.Iconimage_Selected = null;
            this.btnCfg.IconMarginLeft = 0;
            this.btnCfg.IconMarginRight = 0;
            this.btnCfg.IconRightVisible = true;
            this.btnCfg.IconRightZoom = 0D;
            this.btnCfg.IconVisible = true;
            this.btnCfg.IconZoom = 64D;
            this.btnCfg.IsTab = true;
            this.btnCfg.Location = new System.Drawing.Point(0, 325);
            this.btnCfg.Name = "btnCfg";
            this.btnCfg.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCfg.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(94)))));
            this.btnCfg.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCfg.selected = false;
            this.btnCfg.Size = new System.Drawing.Size(236, 48);
            this.btnCfg.TabIndex = 7;
            this.btnCfg.Text = "   Opções e Configurações";
            this.btnCfg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCfg.Textcolor = System.Drawing.Color.White;
            this.btnCfg.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCfg.Click += new System.EventHandler(this.btnCfg_Click);
            // 
            // btnTurmas
            // 
            this.btnTurmas.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnTurmas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnTurmas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTurmas.BorderRadius = 0;
            this.btnTurmas.ButtonText = "   Lista de Turmas";
            this.btnTurmas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnTurmas, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnTurmas, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnTurmas, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnTurmas, BunifuAnimatorNS.DecorationType.None);
            this.btnTurmas.DisabledColor = System.Drawing.Color.Gray;
            this.btnTurmas.Iconcolor = System.Drawing.Color.Transparent;
            this.btnTurmas.Iconimage = global::DiarioDeClasse.Properties.Resources.icons8_Classroom_64px;
            this.btnTurmas.Iconimage_right = null;
            this.btnTurmas.Iconimage_right_Selected = null;
            this.btnTurmas.Iconimage_Selected = null;
            this.btnTurmas.IconMarginLeft = 0;
            this.btnTurmas.IconMarginRight = 0;
            this.btnTurmas.IconRightVisible = true;
            this.btnTurmas.IconRightZoom = 0D;
            this.btnTurmas.IconVisible = true;
            this.btnTurmas.IconZoom = 64D;
            this.btnTurmas.IsTab = true;
            this.btnTurmas.Location = new System.Drawing.Point(0, 278);
            this.btnTurmas.Name = "btnTurmas";
            this.btnTurmas.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnTurmas.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(94)))));
            this.btnTurmas.OnHoverTextColor = System.Drawing.Color.White;
            this.btnTurmas.selected = false;
            this.btnTurmas.Size = new System.Drawing.Size(236, 48);
            this.btnTurmas.TabIndex = 6;
            this.btnTurmas.Text = "   Lista de Turmas";
            this.btnTurmas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTurmas.Textcolor = System.Drawing.Color.White;
            this.btnTurmas.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTurmas.Click += new System.EventHandler(this.bunifuFlatButton4_Click);
            // 
            // btnCalendario
            // 
            this.btnCalendario.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnCalendario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCalendario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalendario.BorderRadius = 0;
            this.btnCalendario.ButtonText = "   Calendário";
            this.btnCalendario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnCalendario, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnCalendario, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnCalendario, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnCalendario, BunifuAnimatorNS.DecorationType.None);
            this.btnCalendario.DisabledColor = System.Drawing.Color.Gray;
            this.btnCalendario.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCalendario.Iconimage = global::DiarioDeClasse.Properties.Resources.icons8_Calendar_64px;
            this.btnCalendario.Iconimage_right = null;
            this.btnCalendario.Iconimage_right_Selected = null;
            this.btnCalendario.Iconimage_Selected = null;
            this.btnCalendario.IconMarginLeft = 0;
            this.btnCalendario.IconMarginRight = 0;
            this.btnCalendario.IconRightVisible = true;
            this.btnCalendario.IconRightZoom = 0D;
            this.btnCalendario.IconVisible = true;
            this.btnCalendario.IconZoom = 64D;
            this.btnCalendario.IsTab = true;
            this.btnCalendario.Location = new System.Drawing.Point(0, 231);
            this.btnCalendario.Name = "btnCalendario";
            this.btnCalendario.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCalendario.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(94)))));
            this.btnCalendario.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCalendario.selected = false;
            this.btnCalendario.Size = new System.Drawing.Size(236, 48);
            this.btnCalendario.TabIndex = 5;
            this.btnCalendario.Text = "   Calendário";
            this.btnCalendario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalendario.Textcolor = System.Drawing.Color.White;
            this.btnCalendario.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalendario.Click += new System.EventHandler(this.btnCalendario_Click);
            // 
            // btnHorario
            // 
            this.btnHorario.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnHorario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnHorario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHorario.BorderRadius = 0;
            this.btnHorario.ButtonText = "   Horário da Turma";
            this.btnHorario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnHorario, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnHorario, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnHorario, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnHorario, BunifuAnimatorNS.DecorationType.None);
            this.btnHorario.DisabledColor = System.Drawing.Color.Gray;
            this.btnHorario.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHorario.Iconimage = global::DiarioDeClasse.Properties.Resources.icons8_Clock_64px;
            this.btnHorario.Iconimage_right = null;
            this.btnHorario.Iconimage_right_Selected = null;
            this.btnHorario.Iconimage_Selected = null;
            this.btnHorario.IconMarginLeft = 0;
            this.btnHorario.IconMarginRight = 0;
            this.btnHorario.IconRightVisible = true;
            this.btnHorario.IconRightZoom = 0D;
            this.btnHorario.IconVisible = true;
            this.btnHorario.IconZoom = 64D;
            this.btnHorario.IsTab = true;
            this.btnHorario.Location = new System.Drawing.Point(0, 184);
            this.btnHorario.Name = "btnHorario";
            this.btnHorario.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnHorario.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(94)))));
            this.btnHorario.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHorario.selected = false;
            this.btnHorario.Size = new System.Drawing.Size(236, 48);
            this.btnHorario.TabIndex = 4;
            this.btnHorario.Text = "   Horário da Turma";
            this.btnHorario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHorario.Textcolor = System.Drawing.Color.White;
            this.btnHorario.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHorario.Click += new System.EventHandler(this.btnHorario_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInicio.BorderRadius = 0;
            this.btnInicio.ButtonText = "   Início";
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnInicio, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnInicio, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnInicio, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnInicio, BunifuAnimatorNS.DecorationType.None);
            this.btnInicio.DisabledColor = System.Drawing.Color.Gray;
            this.btnInicio.Iconcolor = System.Drawing.Color.Transparent;
            this.btnInicio.Iconimage = global::DiarioDeClasse.Properties.Resources.icons8_Home_64px;
            this.btnInicio.Iconimage_right = null;
            this.btnInicio.Iconimage_right_Selected = null;
            this.btnInicio.Iconimage_Selected = null;
            this.btnInicio.IconMarginLeft = 0;
            this.btnInicio.IconMarginRight = 0;
            this.btnInicio.IconRightVisible = true;
            this.btnInicio.IconRightZoom = 0D;
            this.btnInicio.IconVisible = true;
            this.btnInicio.IconZoom = 64D;
            this.btnInicio.IsTab = true;
            this.btnInicio.Location = new System.Drawing.Point(0, 137);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnInicio.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(94)))));
            this.btnInicio.OnHoverTextColor = System.Drawing.Color.White;
            this.btnInicio.selected = false;
            this.btnInicio.Size = new System.Drawing.Size(236, 48);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "   Início";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Textcolor = System.Drawing.Color.White;
            this.btnInicio.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // header
            // 
            this.header.Controls.Add(this.panel3);
            this.header.Controls.Add(this.lblTit);
            this.header.Controls.Add(this.bunifuImageButton3);
            this.transAval.SetDecoration(this.header, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.header, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.header, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.header, BunifuAnimatorNS.DecorationType.None);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(900, 40);
            this.header.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnMax);
            this.panel3.Controls.Add(this.btnFechar);
            this.panel3.Controls.Add(this.bunifuCheckbox1);
            this.panel3.Controls.Add(this.btnMin);
            this.transAval.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.panel3, BunifuAnimatorNS.DecorationType.None);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(638, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(262, 40);
            this.panel3.TabIndex = 4;
            // 
            // btnMax
            // 
            this.btnMax.BackColor = System.Drawing.Color.Transparent;
            this.btnMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnMax, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnMax, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnMax, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnMax, BunifuAnimatorNS.DecorationType.None);
            this.btnMax.Image = global::DiarioDeClasse.Properties.Resources.icons8_Rectangular_64px;
            this.btnMax.ImageActive = null;
            this.btnMax.Location = new System.Drawing.Point(183, 0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(40, 40);
            this.btnMax.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMax.TabIndex = 67;
            this.btnMax.TabStop = false;
            this.btnMax.Zoom = 0;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            this.btnMax.MouseEnter += new System.EventHandler(this.btnMax_MouseEnter);
            this.btnMax.MouseLeave += new System.EventHandler(this.btnMax_MouseLeave);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnFechar, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnFechar, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnFechar, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnFechar, BunifuAnimatorNS.DecorationType.None);
            this.btnFechar.Image = global::DiarioDeClasse.Properties.Resources.icons8_Multiply_64px;
            this.btnFechar.ImageActive = null;
            this.btnFechar.Location = new System.Drawing.Point(222, 0);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(40, 40);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFechar.TabIndex = 0;
            this.btnFechar.TabStop = false;
            this.btnFechar.Zoom = 0;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            this.btnFechar.MouseEnter += new System.EventHandler(this.btnFechar_MouseEnter);
            this.btnFechar.MouseLeave += new System.EventHandler(this.btnFechar_MouseLeave);
            // 
            // bunifuCheckbox1
            // 
            this.bunifuCheckbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.bunifuCheckbox1.Checked = false;
            this.bunifuCheckbox1.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.bunifuCheckbox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transMenu2.SetDecoration(this.bunifuCheckbox1, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.bunifuCheckbox1, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.bunifuCheckbox1, BunifuAnimatorNS.DecorationType.None);
            this.transAval.SetDecoration(this.bunifuCheckbox1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuCheckbox1.ForeColor = System.Drawing.Color.White;
            this.bunifuCheckbox1.Location = new System.Drawing.Point(113, 12);
            this.bunifuCheckbox1.Name = "bunifuCheckbox1";
            this.bunifuCheckbox1.Size = new System.Drawing.Size(20, 20);
            this.bunifuCheckbox1.TabIndex = 66;
            this.bunifuCheckbox1.OnChange += new System.EventHandler(this.bunifuCheckbox1_OnChange);
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transAval.SetDecoration(this.btnMin, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.btnMin, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.btnMin, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.btnMin, BunifuAnimatorNS.DecorationType.None);
            this.btnMin.Image = global::DiarioDeClasse.Properties.Resources.icons8_Minus_Math__64px;
            this.btnMin.ImageActive = null;
            this.btnMin.Location = new System.Drawing.Point(144, 0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(40, 40);
            this.btnMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMin.TabIndex = 1;
            this.btnMin.TabStop = false;
            this.btnMin.Zoom = 0;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            this.btnMin.MouseEnter += new System.EventHandler(this.btnMin_MouseEnter);
            this.btnMin.MouseLeave += new System.EventHandler(this.btnMin_MouseLeave);
            // 
            // lblTit
            // 
            this.transMenu2.SetDecoration(this.lblTit, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.lblTit, BunifuAnimatorNS.DecorationType.None);
            this.transAval.SetDecoration(this.lblTit, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.lblTit, BunifuAnimatorNS.DecorationType.None);
            this.lblTit.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTit.Location = new System.Drawing.Point(51, -3);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(236, 47);
            this.lblTit.TabIndex = 3;
            this.lblTit.Text = "Diário de Classe";
            this.lblTit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuImageButton3
            // 
            this.bunifuImageButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton3.Cursor = System.Windows.Forms.Cursors.Default;
            this.transAval.SetDecoration(this.bunifuImageButton3, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.bunifuImageButton3, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.bunifuImageButton3, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.bunifuImageButton3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton3.Image = global::DiarioDeClasse.Properties.Resources.DC_icone;
            this.bunifuImageButton3.ImageActive = null;
            this.bunifuImageButton3.Location = new System.Drawing.Point(12, 4);
            this.bunifuImageButton3.Name = "bunifuImageButton3";
            this.bunifuImageButton3.Size = new System.Drawing.Size(32, 32);
            this.bunifuImageButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton3.TabIndex = 2;
            this.bunifuImageButton3.TabStop = false;
            this.bunifuImageButton3.Zoom = 0;
            // 
            // panelTudo
            // 
            this.transAval.SetDecoration(this.panelTudo, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this.panelTudo, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this.panelTudo, BunifuAnimatorNS.DecorationType.None);
            this.transMenu2.SetDecoration(this.panelTudo, BunifuAnimatorNS.DecorationType.None);
            this.panelTudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTudo.Location = new System.Drawing.Point(235, 40);
            this.panelTudo.Name = "panelTudo";
            this.panelTudo.Size = new System.Drawing.Size(665, 560);
            this.panelTudo.TabIndex = 2;
            this.panelTudo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.header;
            this.bunifuDragControl1.Vertical = true;
            // 
            // transMenu
            // 
            this.transMenu.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.transMenu.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 1F;
            this.transMenu.DefaultAnimation = animation2;
            // 
            // transLogo
            // 
            this.transLogo.AnimationType = BunifuAnimatorNS.AnimationType.HorizBlind;
            this.transLogo.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.transLogo.DefaultAnimation = animation3;
            this.transLogo.MaxAnimationTime = 200;
            // 
            // transMenu2
            // 
            this.transMenu2.AnimationType = BunifuAnimatorNS.AnimationType.Leaf;
            this.transMenu2.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 1F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 0;
            animation4.Padding = new System.Windows.Forms.Padding(0);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 0F;
            animation4.TransparencyCoeff = 0F;
            this.transMenu2.DefaultAnimation = animation4;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.lblTit;
            this.bunifuDragControl2.Vertical = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // transAval
            // 
            this.transAval.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.transAval.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.transAval.DefaultAnimation = animation1;
            this.transAval.MaxAnimationTime = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(174)))), ((int)(((byte)(206)))));
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelTudo);
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.header);
            this.transMenu2.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.transAval.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.transMenu.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.transLogo.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::DiarioDeClasse.Properties.Resources.Icone;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sideBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLabels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.header.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel panelTudo;
        private Bunifu.Framework.UI.BunifuImageButton btnMin;
        private Bunifu.Framework.UI.BunifuImageButton btnFechar;
        private System.Windows.Forms.Label lblTit;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton3;
        private BunifuAnimatorNS.BunifuTransition transLogo;
        private BunifuAnimatorNS.BunifuTransition transMenu;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private BunifuAnimatorNS.BunifuTransition transMenu2;
        private System.Windows.Forms.PictureBox logoUD;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Bunifu.Framework.UI.BunifuFlatButton btnCfg;
        public Bunifu.Framework.UI.BunifuFlatButton btnTurmas;
        public Bunifu.Framework.UI.BunifuFlatButton btnCalendario;
        public Bunifu.Framework.UI.BunifuFlatButton btnHorario;
        public Bunifu.Framework.UI.BunifuFlatButton btnInicio;
        public System.Windows.Forms.Panel panelLabels;
        public System.Windows.Forms.Label lblId;
        public System.Windows.Forms.Label lblSala;
        public System.Windows.Forms.Label lblNome;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        public System.Windows.Forms.Timer timer1;
        public BunifuAnimatorNS.BunifuTransition transAval;
        public System.Windows.Forms.Panel sideBar;
        public System.Windows.Forms.Panel panel1;
        public Bunifu.Framework.UI.BunifuCheckbox bunifuCheckbox1;
        private Bunifu.Framework.UI.BunifuImageButton btnMax;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        public Bunifu.Framework.UI.BunifuImageButton btnMenu;
    }
}

