namespace SuperAdventure
{
    partial class EspiritosDoMal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblHitPoints = new Label();
            lblGold = new Label();
            lblExperience = new Label();
            lblLevel = new Label();
            label5 = new Label();
            cboArmas = new ComboBox();
            cboPocoes = new ComboBox();
            btnUsarArma = new Button();
            btnUsarPocao = new Button();
            btnNorte = new Button();
            btnLeste = new Button();
            btnSul = new Button();
            btnOeste = new Button();
            rtbLocal = new RichTextBox();
            rtbMensagens = new RichTextBox();
            dgvInventorio = new DataGridView();
            dgvQuests = new DataGridView();
            btnMap = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventorio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvQuests).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(26, 15);
            label1.TabIndex = 0;
            label1.Text = "HP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 46);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Ouro:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 74);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Experiência:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 100);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 3;
            label4.Text = "Nível:";
            // 
            // lblHitPoints
            // 
            lblHitPoints.AutoSize = true;
            lblHitPoints.Location = new Point(110, 19);
            lblHitPoints.Name = "lblHitPoints";
            lblHitPoints.Size = new Size(0, 15);
            lblHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            lblGold.AutoSize = true;
            lblGold.Location = new Point(110, 45);
            lblGold.Name = "lblGold";
            lblGold.Size = new Size(0, 15);
            lblGold.TabIndex = 5;
            // 
            // lblExperience
            // 
            lblExperience.AutoSize = true;
            lblExperience.Location = new Point(110, 73);
            lblExperience.Name = "lblExperience";
            lblExperience.Size = new Size(0, 15);
            lblExperience.TabIndex = 6;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Location = new Point(110, 99);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(0, 15);
            lblLevel.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(617, 531);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 8;
            label5.Text = "Selecione a ação";
            // 
            // cboArmas
            // 
            cboArmas.FormattingEnabled = true;
            cboArmas.Location = new Point(369, 559);
            cboArmas.Name = "cboArmas";
            cboArmas.Size = new Size(121, 23);
            cboArmas.TabIndex = 9;
            // 
            // cboPocoes
            // 
            cboPocoes.FormattingEnabled = true;
            cboPocoes.Location = new Point(369, 593);
            cboPocoes.Name = "cboPocoes";
            cboPocoes.Size = new Size(121, 23);
            cboPocoes.TabIndex = 10;
            // 
            // btnUsarArma
            // 
            btnUsarArma.Location = new Point(620, 559);
            btnUsarArma.Name = "btnUsarArma";
            btnUsarArma.Size = new Size(75, 23);
            btnUsarArma.TabIndex = 11;
            btnUsarArma.Text = "Usar";
            btnUsarArma.UseVisualStyleBackColor = true;
            btnUsarArma.Click += btnUsarArma_Click;
            // 
            // btnUsarPocao
            // 
            btnUsarPocao.Location = new Point(620, 593);
            btnUsarPocao.Name = "btnUsarPocao";
            btnUsarPocao.Size = new Size(75, 23);
            btnUsarPocao.TabIndex = 12;
            btnUsarPocao.Text = "Usar";
            btnUsarPocao.UseVisualStyleBackColor = true;
            btnUsarPocao.Click += btnUsarPocao_Click;
            // 
            // btnNorte
            // 
            btnNorte.Location = new Point(493, 429);
            btnNorte.Name = "btnNorte";
            btnNorte.Size = new Size(75, 23);
            btnNorte.TabIndex = 13;
            btnNorte.Text = "Norte";
            btnNorte.UseVisualStyleBackColor = true;
            btnNorte.Click += btnNorte_Click;
            // 
            // btnLeste
            // 
            btnLeste.Location = new Point(573, 457);
            btnLeste.Name = "btnLeste";
            btnLeste.Size = new Size(75, 23);
            btnLeste.TabIndex = 14;
            btnLeste.Text = "Leste";
            btnLeste.UseVisualStyleBackColor = true;
            btnLeste.Click += btnLeste_Click;
            // 
            // btnSul
            // 
            btnSul.Location = new Point(494, 487);
            btnSul.Name = "btnSul";
            btnSul.Size = new Size(75, 23);
            btnSul.TabIndex = 15;
            btnSul.Text = "Sul";
            btnSul.UseVisualStyleBackColor = true;
            btnSul.Click += btnSul_Click;
            // 
            // btnOeste
            // 
            btnOeste.Location = new Point(412, 457);
            btnOeste.Name = "btnOeste";
            btnOeste.Size = new Size(75, 23);
            btnOeste.TabIndex = 16;
            btnOeste.Text = "Oeste";
            btnOeste.UseVisualStyleBackColor = true;
            btnOeste.Click += btnOeste_Click;
            // 
            // rtbLocal
            // 
            rtbLocal.Location = new Point(347, 19);
            rtbLocal.Name = "rtbLocal";
            rtbLocal.ReadOnly = true;
            rtbLocal.Size = new Size(360, 105);
            rtbLocal.TabIndex = 17;
            rtbLocal.Text = "";
            // 
            // rtbMensagens
            // 
            rtbMensagens.Location = new Point(347, 130);
            rtbMensagens.Name = "rtbMensagens";
            rtbMensagens.ReadOnly = true;
            rtbMensagens.Size = new Size(360, 286);
            rtbMensagens.TabIndex = 18;
            rtbMensagens.Text = "";
            // 
            // dgvInventorio
            // 
            dgvInventorio.AllowUserToAddRows = false;
            dgvInventorio.AllowUserToDeleteRows = false;
            dgvInventorio.AllowUserToResizeRows = false;
            dgvInventorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventorio.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvInventorio.Enabled = false;
            dgvInventorio.Location = new Point(16, 130);
            dgvInventorio.MultiSelect = false;
            dgvInventorio.Name = "dgvInventorio";
            dgvInventorio.ReadOnly = true;
            dgvInventorio.RowHeadersVisible = false;
            dgvInventorio.RowTemplate.Height = 25;
            dgvInventorio.Size = new Size(312, 309);
            dgvInventorio.TabIndex = 19;
            // 
            // dgvQuests
            // 
            dgvQuests.AllowUserToAddRows = false;
            dgvQuests.AllowUserToDeleteRows = false;
            dgvQuests.AllowUserToResizeRows = false;
            dgvQuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQuests.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvQuests.Enabled = false;
            dgvQuests.Location = new Point(16, 446);
            dgvQuests.MultiSelect = false;
            dgvQuests.Name = "dgvQuests";
            dgvQuests.ReadOnly = true;
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.RowTemplate.Height = 25;
            dgvQuests.Size = new Size(312, 189);
            dgvQuests.TabIndex = 20;
            // 
            // btnMap
            // 
            btnMap.Location = new Point(494, 457);
            btnMap.Name = "btnMap";
            btnMap.Size = new Size(75, 23);
            btnMap.TabIndex = 21;
            btnMap.Text = "Mapa";
            btnMap.UseVisualStyleBackColor = true;
            btnMap.Click += btnMap_Click;
            // 
            // EspiritosDoMal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 651);
            Controls.Add(btnMap);
            Controls.Add(dgvQuests);
            Controls.Add(dgvInventorio);
            Controls.Add(rtbMensagens);
            Controls.Add(rtbLocal);
            Controls.Add(btnOeste);
            Controls.Add(btnSul);
            Controls.Add(btnLeste);
            Controls.Add(btnNorte);
            Controls.Add(btnUsarPocao);
            Controls.Add(btnUsarArma);
            Controls.Add(cboPocoes);
            Controls.Add(cboArmas);
            Controls.Add(label5);
            Controls.Add(lblLevel);
            Controls.Add(lblExperience);
            Controls.Add(lblGold);
            Controls.Add(lblHitPoints);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EspiritosDoMal";
            Text = "Espíritos do Mal";
            ((System.ComponentModel.ISupportInitialize)dgvInventorio).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvQuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblHitPoints;
        private Label lblGold;
        private Label lblExperience;
        private Label lblLevel;
        private Label label5;
        private ComboBox cboArmas;
        private ComboBox cboPocoes;
        private Button btnUsarArma;
        private Button btnUsarPocao;
        private Button btnNorte;
        private Button btnLeste;
        private Button btnSul;
        private Button btnOeste;
        private RichTextBox rtbLocal;
        private RichTextBox rtbMensagens;
        private DataGridView dgvInventorio;
        private DataGridView dgvQuests;
        private Button btnMap;
    }
}