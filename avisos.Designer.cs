namespace DiarioDeClasse
{
    partial class avisos
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtAviso = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.cbTurma = new Bunifu.Framework.UI.BunifuDropdown();
            this.lblTurma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnviar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(323, 554);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // txtAviso
            // 
            this.txtAviso.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAviso.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAviso.HintForeColor = System.Drawing.Color.Empty;
            this.txtAviso.HintText = "";
            this.txtAviso.isPassword = false;
            this.txtAviso.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtAviso.LineIdleColor = System.Drawing.Color.Gray;
            this.txtAviso.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtAviso.LineThickness = 3;
            this.txtAviso.Location = new System.Drawing.Point(334, 37);
            this.txtAviso.Margin = new System.Windows.Forms.Padding(4);
            this.txtAviso.Name = "txtAviso";
            this.txtAviso.Size = new System.Drawing.Size(326, 262);
            this.txtAviso.TabIndex = 41;
            this.txtAviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cbTurma
            // 
            this.cbTurma.BackColor = System.Drawing.Color.Transparent;
            this.cbTurma.BorderRadius = 3;
            this.cbTurma.DisabledColor = System.Drawing.Color.Gray;
            this.cbTurma.ForeColor = System.Drawing.Color.White;
            this.cbTurma.Items = new string[0];
            this.cbTurma.Location = new System.Drawing.Point(407, 338);
            this.cbTurma.Name = "cbTurma";
            this.cbTurma.NomalColor = System.Drawing.Color.Navy;
            this.cbTurma.onHoverColor = System.Drawing.Color.Navy;
            this.cbTurma.selectedIndex = -1;
            this.cbTurma.Size = new System.Drawing.Size(146, 30);
            this.cbTurma.TabIndex = 71;
            this.cbTurma.Visible = false;
            this.cbTurma.onItemSelected += new System.EventHandler(this.cbTurma_onItemSelected);
            // 
            // lblTurma
            // 
            this.lblTurma.AutoSize = true;
            this.lblTurma.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTurma.Location = new System.Drawing.Point(332, 343);
            this.lblTurma.Name = "lblTurma";
            this.lblTurma.Size = new System.Drawing.Size(68, 18);
            this.lblTurma.TabIndex = 70;
            this.lblTurma.Text = "Turma:";
            this.lblTurma.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label1.Location = new System.Drawing.Point(333, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 18);
            this.label1.TabIndex = 72;
            this.label1.Text = "Digite o texto do aviso:";
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
            this.btnEnviar.Location = new System.Drawing.Point(433, 452);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(84)))), ((int)(((byte)(114)))));
            this.btnEnviar.OnHovercolor = System.Drawing.Color.SeaGreen;
            this.btnEnviar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnEnviar.selected = false;
            this.btnEnviar.Size = new System.Drawing.Size(120, 38);
            this.btnEnviar.TabIndex = 73;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEnviar.Textcolor = System.Drawing.Color.White;
            this.btnEnviar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // avisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTurma);
            this.Controls.Add(this.lblTurma);
            this.Controls.Add(this.txtAviso);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "avisos";
            this.Size = new System.Drawing.Size(665, 560);
            this.Load += new System.EventHandler(this.avisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtAviso;
        private Bunifu.Framework.UI.BunifuDropdown cbTurma;
        private System.Windows.Forms.Label lblTurma;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton btnEnviar;
    }
}
