
namespace LojaDeFerramentas.Componetes
{
    partial class Widget
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.precoC = new System.Windows.Forms.Label();
            this.tituloC = new System.Windows.Forms.Label();
            this.imgC = new System.Windows.Forms.PictureBox();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.btnCarrinho = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgC)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnCarrinho);
            this.panel1.Controls.Add(this.precoC);
            this.panel1.Controls.Add(this.tituloC);
            this.panel1.Controls.Add(this.imgC);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 148);
            this.panel1.TabIndex = 1;
            // 
            // precoC
            // 
            this.precoC.AutoSize = true;
            this.precoC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoC.Location = new System.Drawing.Point(131, 104);
            this.precoC.Name = "precoC";
            this.precoC.Size = new System.Drawing.Size(130, 33);
            this.precoC.TabIndex = 2;
            this.precoC.Text = "R$59.90";
            this.precoC.Click += new System.EventHandler(this.label1_Click);
            // 
            // tituloC
            // 
            this.tituloC.AutoSize = true;
            this.tituloC.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloC.Location = new System.Drawing.Point(132, 23);
            this.tituloC.Name = "tituloC";
            this.tituloC.Size = new System.Drawing.Size(156, 48);
            this.tituloC.TabIndex = 1;
            this.tituloC.Text = "Jogo de chave\r\nde fenda";
            this.tituloC.Click += new System.EventHandler(this.tituloC_Click);
            // 
            // imgC
            // 
            this.imgC.Image = global::LojaDeFerramentas.Properties.Resources.imgCard_1;
            this.imgC.Location = new System.Drawing.Point(-1, 18);
            this.imgC.Name = "imgC";
            this.imgC.Size = new System.Drawing.Size(140, 119);
            this.imgC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgC.TabIndex = 0;
            this.imgC.TabStop = false;
            this.imgC.Click += new System.EventHandler(this.imgC_Click);
            // 
            // btnCarrinho
            // 
            this.btnCarrinho.BackColor = System.Drawing.Color.Transparent;
            this.btnCarrinho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarrinho.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCarrinho.FlatAppearance.BorderSize = 0;
            this.btnCarrinho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarrinho.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarrinho.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCarrinho.Image = global::LojaDeFerramentas.Properties.Resources.icons8_carrinho_32;
            this.btnCarrinho.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarrinho.Location = new System.Drawing.Point(262, 95);
            this.btnCarrinho.Name = "btnCarrinho";
            this.btnCarrinho.Size = new System.Drawing.Size(55, 50);
            this.btnCarrinho.TabIndex = 9;
            this.btnCarrinho.UseVisualStyleBackColor = false;
            this.btnCarrinho.Click += new System.EventHandler(this.btnProdutos_Click_1);
            // 
            // Widget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.panel1);
            this.Name = "Widget";
            this.Size = new System.Drawing.Size(326, 154);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        public System.Windows.Forms.Label precoC;
        public System.Windows.Forms.Label tituloC;
        public System.Windows.Forms.PictureBox imgC;
        private System.Windows.Forms.Button btnCarrinho;
    }
}
