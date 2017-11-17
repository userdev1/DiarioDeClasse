namespace DiarioDeClasse
{
    partial class login
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

        #region código gerado pelo Component Designer

        /// <summary> 
        /// Método necessário para o suporte do Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblTit = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDesc = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cbHost = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtUser = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtPass = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.button1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblVersao = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.swt = new Bunifu.Framework.UI.BunifuiOSSwitch();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel9, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 560);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lblTit);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(659, 33);
            this.panel9.TabIndex = 57;
            this.panel9.Resize += new System.EventHandler(this.lblTit_Resize);
            // 
            // lblTit
            // 
            this.lblTit.BackColor = System.Drawing.Color.Transparent;
            this.lblTit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.lblTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(55)))), ((int)(((byte)(48)))));
            this.lblTit.Location = new System.Drawing.Point(0, 0);
            this.lblTit.Margin = new System.Windows.Forms.Padding(0);
            this.lblTit.Name = "lblTit";
            this.lblTit.Size = new System.Drawing.Size(659, 33);
            this.lblTit.TabIndex = 56;
            this.lblTit.Text = "Acesse seu perfil";
            this.lblTit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.panel10, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 55);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(665, 505);
            this.tableLayoutPanel2.TabIndex = 55;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDesc);
            this.panel2.Controls.Add(this.cbHost);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(226, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 74);
            this.panel2.TabIndex = 0;
            // 
            // btnDesc
            // 
            this.btnDesc.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesc.BorderRadius = 0;
            this.btnDesc.ButtonText = "Desconectar";
            this.btnDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesc.DisabledColor = System.Drawing.Color.Gray;
            this.btnDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDesc.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDesc.Iconimage = global::DiarioDeClasse.Properties.Resources.icons8_Disconnected_64px_5;
            this.btnDesc.Iconimage_right = null;
            this.btnDesc.Iconimage_right_Selected = null;
            this.btnDesc.Iconimage_Selected = null;
            this.btnDesc.IconMarginLeft = 0;
            this.btnDesc.IconMarginRight = 0;
            this.btnDesc.IconRightVisible = true;
            this.btnDesc.IconRightZoom = 0D;
            this.btnDesc.IconVisible = true;
            this.btnDesc.IconZoom = 60D;
            this.btnDesc.IsTab = false;
            this.btnDesc.Location = new System.Drawing.Point(0, 24);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnDesc.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(94)))));
            this.btnDesc.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDesc.selected = false;
            this.btnDesc.Size = new System.Drawing.Size(211, 50);
            this.btnDesc.TabIndex = 62;
            this.btnDesc.Text = "Desconectar";
            this.btnDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDesc.Textcolor = System.Drawing.Color.White;
            this.btnDesc.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click_1);
            this.btnDesc.Resize += new System.EventHandler(this.resize);
            // 
            // cbHost
            // 
            this.cbHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.cbHost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHost.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbHost.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.cbHost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cbHost.FormattingEnabled = true;
            this.cbHost.Items.AddRange(new object[] {
            "Servidor",
            "Servidor Local",
            "Localhost"});
            this.cbHost.Location = new System.Drawing.Point(0, 0);
            this.cbHost.Name = "cbHost";
            this.cbHost.Size = new System.Drawing.Size(211, 24);
            this.cbHost.TabIndex = 49;
            this.cbHost.SelectedIndexChanged += new System.EventHandler(this.cbHost_SelectedIndexChanged_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DiarioDeClasse.Properties.Resources.devFavicon;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(3, 339);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(215, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtUser);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(221, 84);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 84);
            this.panel3.TabIndex = 1;
            this.panel3.Resize += new System.EventHandler(this.panel3_Resize);
            // 
            // txtUser
            // 
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUser.Font = new System.Drawing.Font("Century Gothic", 23F);
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUser.HintForeColor = System.Drawing.Color.Empty;
            this.txtUser.HintText = "Usuário";
            this.txtUser.isPassword = false;
            this.txtUser.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtUser.LineIdleColor = System.Drawing.Color.Gray;
            this.txtUser.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtUser.LineThickness = 6;
            this.txtUser.Location = new System.Drawing.Point(0, 0);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 15, 4, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(221, 84);
            this.txtUser.TabIndex = 58;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtPass);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(221, 168);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(221, 84);
            this.panel4.TabIndex = 2;
            this.panel4.Resize += new System.EventHandler(this.panel4_Resize);
            // 
            // txtPass
            // 
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPass.Font = new System.Drawing.Font("Century Gothic", 23F);
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPass.HintForeColor = System.Drawing.Color.Empty;
            this.txtPass.HintText = "Senha";
            this.txtPass.isPassword = true;
            this.txtPass.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPass.LineIdleColor = System.Drawing.Color.Gray;
            this.txtPass.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPass.LineThickness = 6;
            this.txtPass.Location = new System.Drawing.Point(0, 0);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 15, 4, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(221, 84);
            this.txtPass.TabIndex = 59;
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPass.OnValueChanged += new System.EventHandler(this.txtPass_OnValueChanged_1);
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.button1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(236, 351);
            this.panel6.Margin = new System.Windows.Forms.Padding(15);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(191, 54);
            this.panel6.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.BorderRadius = 0;
            this.button1.ButtonText = "Login";
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.DisabledColor = System.Drawing.Color.Gray;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Iconcolor = System.Drawing.Color.Transparent;
            this.button1.Iconimage = global::DiarioDeClasse.Properties.Resources.icons8_Enter_64px_5;
            this.button1.Iconimage_right = null;
            this.button1.Iconimage_right_Selected = null;
            this.button1.Iconimage_Selected = null;
            this.button1.IconMarginLeft = 0;
            this.button1.IconMarginRight = 0;
            this.button1.IconRightVisible = true;
            this.button1.IconRightZoom = 0D;
            this.button1.IconVisible = true;
            this.button1.IconZoom = 60D;
            this.button1.IsTab = false;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.button1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(94)))));
            this.button1.OnHoverTextColor = System.Drawing.Color.White;
            this.button1.selected = false;
            this.button1.Size = new System.Drawing.Size(191, 54);
            this.button1.TabIndex = 61;
            this.button1.Text = "Login";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button1.Textcolor = System.Drawing.Color.White;
            this.button1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.Resize += new System.EventHandler(this.resize);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(452, 430);
            this.panel7.Margin = new System.Windows.Forms.Padding(10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(203, 65);
            this.panel7.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.BorderRadius = 0;
            this.button2.ButtonText = "Registrar";
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.DisabledColor = System.Drawing.Color.Gray;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Iconcolor = System.Drawing.Color.Transparent;
            this.button2.Iconimage = global::DiarioDeClasse.Properties.Resources.icons8_Add_User_Male_64px_5;
            this.button2.Iconimage_right = null;
            this.button2.Iconimage_right_Selected = null;
            this.button2.Iconimage_Selected = null;
            this.button2.IconMarginLeft = 0;
            this.button2.IconMarginRight = 0;
            this.button2.IconRightVisible = true;
            this.button2.IconRightZoom = 0D;
            this.button2.IconVisible = true;
            this.button2.IconZoom = 60D;
            this.button2.IsTab = false;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.button2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(64)))), ((int)(((byte)(94)))));
            this.button2.OnHoverTextColor = System.Drawing.Color.White;
            this.button2.selected = false;
            this.button2.Size = new System.Drawing.Size(203, 65);
            this.button2.TabIndex = 60;
            this.button2.Text = "Registrar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.button2.Textcolor = System.Drawing.Color.White;
            this.button2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            this.button2.Resize += new System.EventHandler(this.resize);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.lblVersao);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 420);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(221, 85);
            this.panel8.TabIndex = 6;
            this.panel8.Resize += new System.EventHandler(this.panel8_Resize);
            // 
            // lblVersao
            // 
            this.lblVersao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersao.Font = new System.Drawing.Font("Courier New", 15F);
            this.lblVersao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblVersao.Location = new System.Drawing.Point(0, 0);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(221, 85);
            this.lblVersao.TabIndex = 53;
            this.lblVersao.Text = "Versão atual:";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblVersao.Visible = false;
            this.lblVersao.Click += new System.EventHandler(this.lblVersao_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label5);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(442, 336);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(223, 84);
            this.panel10.TabIndex = 56;
            this.panel10.Resize += new System.EventHandler(this.panel10_Resize);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Courier New", 15F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 84);
            this.label5.TabIndex = 48;
            this.label5.Text = "Não tem um cadastro?";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(221, 252);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(221, 84);
            this.tableLayoutPanel3.TabIndex = 65;
            this.tableLayoutPanel3.Resize += new System.EventHandler(this.tableLayoutPanel3_Resize);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Courier New", 18F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label4.Size = new System.Drawing.Size(221, 54);
            this.label4.TabIndex = 64;
            this.label4.Text = "Lembrar Senha";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.swt);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 54);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(221, 30);
            this.panel5.TabIndex = 65;
            // 
            // swt
            // 
            this.swt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.swt.BackColor = System.Drawing.Color.Transparent;
            this.swt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("swt.BackgroundImage")));
            this.swt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.swt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swt.Location = new System.Drawing.Point(96, 5);
            this.swt.Margin = new System.Windows.Forms.Padding(5);
            this.swt.Name = "swt";
            this.swt.OffColor = System.Drawing.Color.Gray;
            this.swt.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(202)))), ((int)(((byte)(94)))));
            this.swt.Size = new System.Drawing.Size(35, 20);
            this.swt.TabIndex = 63;
            this.swt.Value = false;
            this.swt.OnValueChange += new System.EventHandler(this.checkBox1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 560);
            this.panel1.TabIndex = 0;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "login";
            this.Size = new System.Drawing.Size(665, 560);
            this.Load += new System.EventHandler(this.login_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuFlatButton btnDesc;
        private System.Windows.Forms.ComboBox cbHost;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuFlatButton button1;
        private Bunifu.Framework.UI.BunifuFlatButton button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTit;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Bunifu.Framework.UI.BunifuiOSSwitch swt;
        private System.Windows.Forms.Panel panel5;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtUser;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPass;


    }
}
