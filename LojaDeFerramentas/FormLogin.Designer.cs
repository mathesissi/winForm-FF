
namespace LojaDeFerramentas
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cSenha = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(359, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 22);
            this.label2.TabIndex = 41;
            this.label2.Text = "Login";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(319, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 49;
            this.label6.Text = "Senha";
            // 
            // cSenha
            // 
            this.cSenha.AutoSize = true;
            this.cSenha.Location = new System.Drawing.Point(324, 208);
            this.cSenha.Name = "cSenha";
            this.cSenha.Size = new System.Drawing.Size(95, 17);
            this.cSenha.TabIndex = 46;
            this.cSenha.Text = "Mostrar Senha";
            this.cSenha.UseVisualStyleBackColor = true;
            this.cSenha.CheckedChanged += new System.EventHandler(this.cSenha_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.btnCadastro);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Location = new System.Drawing.Point(-1, -20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 400);
            this.panel1.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(11, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Não é cadastrado? faça um agora";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(50, 337);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 13);
            this.linkLabel1.TabIndex = 0;
            // 
            // btnCadastro
            // 
            this.btnCadastro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastro.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastro.Location = new System.Drawing.Point(77, 327);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(122, 30);
            this.btnCadastro.TabIndex = 18;
            this.btnCadastro.Text = "Cadastrar-se";
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click_1);
            // 
            // btnSair
            // 
            this.btnSair.AutoSize = true;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.Black;
            this.btnSair.Location = new System.Drawing.Point(537, 7);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(21, 22);
            this.btnSair.TabIndex = 11;
            this.btnSair.Text = "X";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(322, 174);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(199, 26);
            this.txtSenha.TabIndex = 52;
            // 
            // txtCpf
            // 
            this.txtCpf.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCpf.Location = new System.Drawing.Point(322, 103);
            this.txtCpf.MaxLength = 11;
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(199, 26);
            this.txtCpf.TabIndex = 51;
            this.txtCpf.Tag = "";
            this.txtCpf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCpf_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(319, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "CPF";
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(379, 251);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 27);
            this.btnLogin.TabIndex = 55;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LojaDeFerramentas.Properties.Resources.Component_1;
            this.pictureBox1.Location = new System.Drawing.Point(73, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 361);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cSenha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cSenha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Label btnSair;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
    }
}