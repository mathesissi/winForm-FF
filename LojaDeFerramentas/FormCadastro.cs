using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LojaDeFerramentas
{
    public partial class FormCadastro : Form
    {
        MySqlConnection Conexao;
        public FormCadastro()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var login = new FormLogin();
            login.Show();
            this.Hide();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
            Conexao = new MySqlConnection(data_source);
            string verificarCPF = "SELECT COUNT(*) FROM Cliente WHERE cpf = @cpf";
            string query = "INSERT INTO Cliente(cpf, nome, sobrenome, email, senha) VALUES(@cpf, @nome, @sobrenome, @email, @senha)";

            try
            {
                Conexao.Open();

                using (MySqlCommand comando = new MySqlCommand(verificarCPF, Conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", txtCpf.Text);
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Cliente já cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (MySqlCommand comando = new MySqlCommand(query, Conexao))
                {
                    comando.Parameters.AddWithValue("@cpf", txtCpf.Text);
                    comando.Parameters.AddWithValue("@nome", txtNome.Text);
                    comando.Parameters.AddWithValue("@sobrenome", txtSobrenome.Text);
                    comando.Parameters.AddWithValue("@email", txtEmail.Text);
                    comando.Parameters.AddWithValue("@senha", txtSenha.Text);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cliente cadastrado com sucesso", "Aviso", MessageBoxButtons.OK);
                    var home = new FormHome(txtCpf.Text);
                    home.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar cadastrar o cliente. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }            
        }

        private void cSenha_CheckedChanged(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = cSenha.Checked ? '\0' : '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSobrenome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtCpf_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Tem certeza de que deseja sair?", "Confirmar saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Apenas numeros!", "Aviso cpf");
            }
        }
    }
}
