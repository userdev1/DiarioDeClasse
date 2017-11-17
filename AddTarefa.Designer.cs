namespace DiarioDeClasse
{
    partial class AddTarefa
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTurma = new System.Windows.Forms.Label();
            this.lblProf = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTarefa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResumo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDisc2 = new Bunifu.Framework.UI.BunifuDropdown();
            this.cbTurma = new Bunifu.Framework.UI.BunifuDropdown();
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.cbDisc = new Bunifu.Framework.UI.BunifuDropdown();
            this.btnFechar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnEnviar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAnexar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTurma.Location = new System.Drawing.Point(39, 392);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(68, 18);
            this.lblTurma.TabIndex = 61;
            this.lblTurma.Text = "Turma:";
            this.lblTurma.Visible = false;
            // 
            // lblProf
            // 
            this.lblProf.AutoSize = true;
            this.lblProf.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblProf.Location = new System.Drawing.Point(343, 170);
            this.lblProf.Name = "lblProf";
            this.lblProf.Size = new System.Drawing.Size(238, 18);
            this.lblProf.TabIndex = 59;
            this.lblProf.Text = "Selecione o professor :";
            this.lblProf.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Location = new System.Drawing.Point(331, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 18);
            this.label5.TabIndex = 58;
            this.label5.Text = "Anexar uma imagem (opcional):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Location = new System.Drawing.Point(343, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 18);
            this.label4.TabIndex = 55;
            this.label4.Text = "Selecione a disciplina :";
            // 
            // txtTarefa
            // 
            this.txtTarefa.BackColor = System.Drawing.SystemColors.Window;
            this.txtTarefa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTarefa.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtTarefa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.txtTarefa.Location = new System.Drawing.Point(42, 191);
            this.txtTarefa.Multiline = true;
            this.txtTarefa.Name = "txtTarefa";
            this.txtTarefa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTarefa.Size = new System.Drawing.Size(225, 159);
            this.txtTarefa.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label2.Location = new System.Drawing.Point(39, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 18);
            this.label2.TabIndex = 50;
            this.label2.Text = "Detalhes da tarefa:";
            // 
            // txtResumo
            // 
            this.txtResumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResumo.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.txtResumo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.txtResumo.Location = new System.Drawing.Point(42, 98);
            this.txtResumo.Name = "txtResumo";
            this.txtResumo.Size = new System.Drawing.Size(192, 20);
            this.txtResumo.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(39, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 18);
            this.label1.TabIndex = 48;
            this.label1.Text = "Título da tarefa:";
            // 
            // cbDisc2
            // 
            this.cbDisc2.BackColor = System.Drawing.Color.Transparent;
            this.cbDisc2.BorderRadius = 3;
            this.cbDisc2.DisabledColor = System.Drawing.Color.Gray;
            this.cbDisc2.ForeColor = System.Drawing.Color.White;
            this.cbDisc2.Items = new string[0];
            this.cbDisc2.Location = new System.Drawing.Point(396, 98);
            this.cbDisc2.Name = "cbDisc2";
            this.cbDisc2.NomalColor = System.Drawing.Color.Navy;
            this.cbDisc2.onHoverColor = System.Drawing.Color.Navy;
            this.cbDisc2.selectedIndex = -1;
            this.cbDisc2.Size = new System.Drawing.Size(172, 30);
            this.cbDisc2.TabIndex = 67;
            this.cbDisc2.Visible = false;
            // 
            // cbTurma
            // 
            this.cbTurma.BackColor = System.Drawing.Color.Transparent;
            this.cbTurma.BorderRadius = 3;
            this.cbTurma.DisabledColor = System.Drawing.Color.Gray;
            this.cbTurma.ForeColor = System.Drawing.Color.White;
            this.cbTurma.Items = new string[0];
            this.cbTurma.Location = new System.Drawing.Point(113, 392);
            this.cbTurma.Name = "cbTurma";
            this.cbTurma.NomalColor = System.Drawing.Color.Navy;
            this.cbTurma.onHoverColor = System.Drawing.Color.Navy;
            this.cbTurma.selectedIndex = -1;
            this.cbTurma.Size = new System.Drawing.Size(138, 30);
            this.cbTurma.TabIndex = 69;
            this.cbTurma.Visible = false;
            this.cbTurma.onItemSelected += new System.EventHandler(this.cbTurma_onItemSelected);
            // 
            // openFile1
            // 
            this.openFile1.FileName = "openFileDialog1";
            // 
            // cbDisc
            // 
            this.cbDisc.BackColor = System.Drawing.Color.Transparent;
            this.cbDisc.BorderRadius = 3;
            this.cbDisc.DisabledColor = System.Drawing.Color.Gray;
            this.cbDisc.ForeColor = System.Drawing.Color.White;
            this.cbDisc.Items = new string[0];
            this.cbDisc.Location = new System.Drawing.Point(387, 98);
            this.cbDisc.Name = "cbDisc";
            this.cbDisc.NomalColor = System.Drawing.Color.Navy;
            this.cbDisc.onHoverColor = System.Drawing.Color.Navy;
            this.cbDisc.selectedIndex = -1;
            this.cbDisc.Size = new System.Drawing.Size(172, 30);
            this.cbDisc.TabIndex = 73;
            this.cbDisc.onItemSelected += new System.EventHandler(this.cbDisc_onItemSelected);
            // 
            // btnFechar
            // 
            this.btnFechar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFechar.BorderRadius = 0;
            this.btnFechar.ButtonText = "Voltar";
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.DisabledColor = System.Drawing.Color.Gray;
            this.btnFechar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFechar.Iconimage = global::DiarioDeClasse.Properties.Resources.Return_64px;
            this.btnFechar.Iconimage_right = null;
            this.btnFechar.Iconimage_right_Selected = null;
            this.btnFechar.Iconimage_Selected = null;
            this.btnFechar.IconMarginLeft = 0;
            this.btnFechar.IconMarginRight = 0;
            this.btnFechar.IconRightVisible = true;
            this.btnFechar.IconRightZoom = 0D;
            this.btnFechar.IconVisible = true;
            this.btnFechar.IconZoom = 65D;
            this.btnFechar.IsTab = false;
            this.btnFechar.Location = new System.Drawing.Point(533, 509);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnFechar.OnHovercolor = System.Drawing.Color.SeaGreen;
            this.btnFechar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnFechar.selected = false;
            this.btnFechar.Size = new System.Drawing.Size(120, 38);
            this.btnFechar.TabIndex = 72;
            this.btnFechar.Text = "Voltar";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFechar.Textcolor = System.Drawing.Color.White;
            this.btnFechar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEnviar.BorderRadius = 0;
            this.btnEnviar.ButtonText = "Enviar";
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.DisabledColor = System.Drawing.Color.Gray;
            this.btnEnviar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnEnviar.Iconimage = global::DiarioDeClasse.Properties.Resources.send_button;
            this.btnEnviar.Iconimage_right = null;
            this.btnEnviar.Iconimage_right_Selected = null;
            this.btnEnviar.Iconimage_Selected = null;
            this.btnEnviar.IconMarginLeft = 0;
            this.btnEnviar.IconMarginRight = 0;
            this.btnEnviar.IconRightVisible = true;
            this.btnEnviar.IconRightZoom = 0D;
            this.btnEnviar.IconVisible = true;
            this.btnEnviar.IconZoom = 65D;
            this.btnEnviar.IsTab = false;
            this.btnEnviar.Location = new System.Drawing.Point(267, 466);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnEnviar.OnHovercolor = System.Drawing.Color.SeaGreen;
            this.btnEnviar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEnviar.selected = false;
            this.btnEnviar.Size = new System.Drawing.Size(120, 38);
            this.btnEnviar.TabIndex = 71;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEnviar.Textcolor = System.Drawing.Color.White;
            this.btnEnviar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnAnexar
            // 
            this.btnAnexar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnAnexar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnAnexar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnexar.BorderRadius = 0;
            this.btnAnexar.ButtonText = "Anexar";
            this.btnAnexar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnexar.DisabledColor = System.Drawing.Color.Gray;
            this.btnAnexar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAnexar.Iconimage = global::DiarioDeClasse.Properties.Resources.attach_clipboard_button;
            this.btnAnexar.Iconimage_right = null;
            this.btnAnexar.Iconimage_right_Selected = null;
            this.btnAnexar.Iconimage_Selected = null;
            this.btnAnexar.IconMarginLeft = 0;
            this.btnAnexar.IconMarginRight = 0;
            this.btnAnexar.IconRightVisible = true;
            this.btnAnexar.IconRightZoom = 0D;
            this.btnAnexar.IconVisible = true;
            this.btnAnexar.IconZoom = 65D;
            this.btnAnexar.IsTab = false;
            this.btnAnexar.Location = new System.Drawing.Point(405, 304);
            this.btnAnexar.Name = "btnAnexar";
            this.btnAnexar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnAnexar.OnHovercolor = System.Drawing.Color.SeaGreen;
            this.btnAnexar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAnexar.selected = false;
            this.btnAnexar.Size = new System.Drawing.Size(120, 38);
            this.btnAnexar.TabIndex = 70;
            this.btnAnexar.Text = "Anexar";
            this.btnAnexar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAnexar.Textcolor = System.Drawing.Color.White;
            this.btnAnexar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnexar.Click += new System.EventHandler(this.btnAnexar_Click);
            // 
            // AddTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbDisc);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnAnexar);
            this.Controls.Add(this.cbTurma);
            this.Controls.Add(this.cbDisc2);
            this.Controls.Add(this.lblTurma);
            this.Controls.Add(this.lblProf);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTarefa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResumo);
            this.Controls.Add(this.label1);
            this.Name = "AddTarefa";
            this.Size = new System.Drawing.Size(665, 560);
            this.Load += new System.EventHandler(this.AddTarefa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTurma;
        private System.Windows.Forms.Label lblProf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTarefa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResumo;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDropdown cbDisc2;
        private Bunifu.Framework.UI.BunifuDropdown cbTurma;
        private Bunifu.Framework.UI.BunifuFlatButton btnAnexar;
        private Bunifu.Framework.UI.BunifuFlatButton btnEnviar;
        private Bunifu.Framework.UI.BunifuFlatButton btnFechar;
        private System.Windows.Forms.OpenFileDialog openFile1;
        private Bunifu.Framework.UI.BunifuDropdown cbDisc;
    }
}
