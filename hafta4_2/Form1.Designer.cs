namespace hafta4
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOyunaBasla = new System.Windows.Forms.Button();
            this.btnOyunuBitir = new System.Windows.Forms.Button();
            this.pnlOyunAlani = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxCiftSayilar = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSure = new System.Windows.Forms.Label();
            this.timerHareket = new System.Windows.Forms.Timer(this.components);
            this.pnlOyunAlani.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOyunaBasla
            // 
            this.btnOyunaBasla.Location = new System.Drawing.Point(30, 192);
            this.btnOyunaBasla.Name = "btnOyunaBasla";
            this.btnOyunaBasla.Size = new System.Drawing.Size(75, 23);
            this.btnOyunaBasla.TabIndex = 0;
            this.btnOyunaBasla.Text = "Oyuna Başla";
            this.btnOyunaBasla.UseVisualStyleBackColor = true;
            this.btnOyunaBasla.Click += new System.EventHandler(this.btnOyunaBasla_Click);
            // 
            // btnOyunuBitir
            // 
            this.btnOyunuBitir.Location = new System.Drawing.Point(696, 183);
            this.btnOyunuBitir.Name = "btnOyunuBitir";
            this.btnOyunuBitir.Size = new System.Drawing.Size(75, 23);
            this.btnOyunuBitir.TabIndex = 1;
            this.btnOyunuBitir.Text = "Oyunu bitir";
            this.btnOyunuBitir.UseVisualStyleBackColor = true;
            // 
            // pnlOyunAlani
            // 
            this.pnlOyunAlani.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlOyunAlani.Controls.Add(this.label3);
            this.pnlOyunAlani.Location = new System.Drawing.Point(140, 30);
            this.pnlOyunAlani.Name = "pnlOyunAlani";
            this.pnlOyunAlani.Size = new System.Drawing.Size(402, 386);
            this.pnlOyunAlani.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Oyun alanı";
            // 
            // lbxCiftSayilar
            // 
            this.lbxCiftSayilar.FormattingEnabled = true;
            this.lbxCiftSayilar.Location = new System.Drawing.Point(557, 30);
            this.lbxCiftSayilar.Name = "lbxCiftSayilar";
            this.lbxCiftSayilar.Size = new System.Drawing.Size(120, 368);
            this.lbxCiftSayilar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Süre";
            // 
            // lblSure
            // 
            this.lblSure.AutoSize = true;
            this.lblSure.Location = new System.Drawing.Point(727, 272);
            this.lblSure.Name = "lblSure";
            this.lblSure.Size = new System.Drawing.Size(30, 13);
            this.lblSure.TabIndex = 5;
            this.lblSure.Text = "60sn";
            // 
            // timerHareket
            // 
            this.timerHareket.Interval = 1000;
            this.timerHareket.Tick += new System.EventHandler(this.timerHareket_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxCiftSayilar);
            this.Controls.Add(this.pnlOyunAlani);
            this.Controls.Add(this.btnOyunuBitir);
            this.Controls.Add(this.btnOyunaBasla);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnlOyunAlani.ResumeLayout(false);
            this.pnlOyunAlani.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOyunaBasla;
        private System.Windows.Forms.Button btnOyunuBitir;
        private System.Windows.Forms.Panel pnlOyunAlani;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxCiftSayilar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSure;
        private System.Windows.Forms.Timer timerHareket;
    }
}

