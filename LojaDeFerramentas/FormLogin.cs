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
    public partial class FormLogin : Form
    {
        MySqlConnection Conexao;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void cSenha_CheckedChanged(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = cSenha.Checked ? '\0' : '*';
        }

        private void btnCadastro_Click_1(object sender, EventArgs e)
        {
            var login = new FormCadastro();
            login.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
            String query = "SELECT * FROM Cliente WHERE cpf = @Cpf AND senha = @Senha";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@Cpf", txtCpf.Text.Trim());
                        comando.Parameters.AddWithValue("@Senha", txtSenha.Text.Trim());

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read()) // Se encontrou o usuário
                            {
                                var home = new FormHome(txtCpf.Text.Trim());
                                home.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Nenhum usuário foi encontrado", "Conta não encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao fazer login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Tem certeza de que deseja sair?", "Confirmar saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

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
