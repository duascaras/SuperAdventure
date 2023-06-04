namespace SuperAdventure
{
    partial class SuperAdventure
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboArmas = new System.Windows.Forms.ComboBox();
            this.cboPocoes = new System.Windows.Forms.ComboBox();
            this.btnUsarArma = new System.Windows.Forms.Button();
            this.btnUsarPocao = new System.Windows.Forms.Button();
            this.btnNorte = new System.Windows.Forms.Button();
            this.btnLeste = new System.Windows.Forms.Button();
            this.btnSul = new System.Windows.Forms.Button();
            this.btnOeste = new System.Windows.Forms.Button();
            this.rtbLocal = new System.Windows.Forms.RichTextBox();
            this.rtbMensagens = new System.Windows.Forms.RichTextBox();
            this.dgvInventorio = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.btnMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventorio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit Points:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Experience:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Level:";
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.AutoSize = true;
            this.lblHitPoints.Location = new System.Drawing.Point(110, 19);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(0, 15);
            this.lblHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(110, 45);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(0, 15);
            this.lblGold.TabIndex = 5;
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(110, 73);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(0, 15);
            this.lblExperience.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(110, 99);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 15);
            this.lblLevel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(617, 531);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Selecione a ação";
            // 
            // cboArmas
            // 
            this.cboArmas.FormattingEnabled = true;
            this.cboArmas.Location = new System.Drawing.Point(369, 559);
            this.cboArmas.Name = "cboArmas";
            this.cboArmas.Size = new System.Drawing.Size(121, 23);
            this.cboArmas.TabIndex = 9;
            // 
            // cboPocoes
            // 
            this.cboPocoes.FormattingEnabled = true;
            this.cboPocoes.Location = new System.Drawing.Point(369, 593);
            this.cboPocoes.Name = "cboPocoes";
            this.cboPocoes.Size = new System.Drawing.Size(121, 23);
            this.cboPocoes.TabIndex = 10;
            // 
            // btnUsarArma
            // 
            this.btnUsarArma.Location = new System.Drawing.Point(620, 559);
            this.btnUsarArma.Name = "btnUsarArma";
            this.btnUsarArma.Size = new System.Drawing.Size(75, 23);
            this.btnUsarArma.TabIndex = 11;
            this.btnUsarArma.Text = "Usar";
            this.btnUsarArma.UseVisualStyleBackColor = true;
            btnUsarArma.Click += btnUsarArma_Click;
            // 
            // btnUsarPocao
            // 
            this.btnUsarPocao.Location = new System.Drawing.Point(620, 593);
            this.btnUsarPocao.Name = "btnUsarPocao";
            this.btnUsarPocao.Size = new System.Drawing.Size(75, 23);
            this.btnUsarPocao.TabIndex = 12;
            this.btnUsarPocao.Text = "Usar";
            this.btnUsarPocao.UseVisualStyleBackColor = true;
            btnUsarPocao.Click += btnUsarPocao_Click;
            // 
            // btnNorte
            // 
            this.btnNorte.Location = new System.Drawing.Point(493, 433);
            this.btnNorte.Name = "btnNorte";
            this.btnNorte.Size = new System.Drawing.Size(75, 23);
            this.btnNorte.TabIndex = 13;
            this.btnNorte.Text = "Norte";
            this.btnNorte.UseVisualStyleBackColor = true;
            btnNorte.Click += btnNorte_Click;
            // 
            // btnLeste
            // 
            this.btnLeste.Location = new System.Drawing.Point(573, 457);
            this.btnLeste.Name = "btnLeste";
            this.btnLeste.Size = new System.Drawing.Size(75, 23);
            this.btnLeste.TabIndex = 14;
            this.btnLeste.Text = "Leste";
            this.btnLeste.UseVisualStyleBackColor = true;
            btnLeste.Click += btnLeste_Click;
            // 
            // btnSul
            // 
            this.btnSul.Location = new System.Drawing.Point(493, 487);
            this.btnSul.Name = "btnSul";
            this.btnSul.Size = new System.Drawing.Size(75, 23);
            this.btnSul.TabIndex = 15;
            this.btnSul.Text = "Sul";
            this.btnSul.UseVisualStyleBackColor = true;
            btnSul.Click += btnSul_Click;
            // 
            // btnOeste
            // 
            this.btnOeste.Location = new System.Drawing.Point(412, 457);
            this.btnOeste.Name = "btnOeste";
            this.btnOeste.Size = new System.Drawing.Size(75, 23);
            this.btnOeste.TabIndex = 16;
            this.btnOeste.Text = "Oeste";
            this.btnOeste.UseVisualStyleBackColor = true;
            btnOeste.Click += btnOeste_Click;
            // 
            // rtbLocal
            // 
            this.rtbLocal.Location = new System.Drawing.Point(347, 19);
            this.rtbLocal.Name = "rtbLocal";
            this.rtbLocal.ReadOnly = true;
            this.rtbLocal.Size = new System.Drawing.Size(360, 105);
            this.rtbLocal.TabIndex = 17;
            this.rtbLocal.Text = "";
            // 
            // rtbMensagens
            // 
            this.rtbMensagens.Location = new System.Drawing.Point(347, 130);
            this.rtbMensagens.Name = "rtbMensagens";
            this.rtbMensagens.ReadOnly = true;
            this.rtbMensagens.Size = new System.Drawing.Size(360, 286);
            this.rtbMensagens.TabIndex = 18;
            this.rtbMensagens.Text = "";
            // 
            // dgvInventorio
            // 
            this.dgvInventorio.AllowUserToAddRows = false;
            this.dgvInventorio.AllowUserToDeleteRows = false;
            this.dgvInventorio.AllowUserToResizeRows = false;
            this.dgvInventorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventorio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventorio.Enabled = false;
            this.dgvInventorio.Location = new System.Drawing.Point(16, 130);
            this.dgvInventorio.MultiSelect = false;
            this.dgvInventorio.Name = "dgvInventorio";
            this.dgvInventorio.ReadOnly = true;
            this.dgvInventorio.RowHeadersVisible = false;
            this.dgvInventorio.RowTemplate.Height = 25;
            this.dgvInventorio.Size = new System.Drawing.Size(312, 309);
            this.dgvInventorio.TabIndex = 19;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Enabled = false;
            this.dgvQuests.Location = new System.Drawing.Point(16, 446);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.RowTemplate.Height = 25;
            this.dgvQuests.Size = new System.Drawing.Size(312, 189);
            this.dgvQuests.TabIndex = 20;
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(493, 458);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 23);
            this.btnMap.TabIndex = 21;
            this.btnMap.Text = "Mapa";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // SuperAdventure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.dgvInventorio);
            this.Controls.Add(this.rtbMensagens);
            this.Controls.Add(this.rtbLocal);
            this.Controls.Add(this.btnOeste);
            this.Controls.Add(this.btnSul);
            this.Controls.Add(this.btnLeste);
            this.Controls.Add(this.btnNorte);
            this.Controls.Add(this.btnUsarPocao);
            this.Controls.Add(this.btnUsarArma);
            this.Controls.Add(this.cboPocoes);
            this.Controls.Add(this.cboArmas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SuperAdventure";
            this.Text = "My Game";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventorio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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