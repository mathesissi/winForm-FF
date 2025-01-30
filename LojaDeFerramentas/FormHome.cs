using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using LojaDeFerramentas.Componetes;
using MySql.Data.MySqlClient;
using static LojaDeFerramentas.Componetes.Widget;

namespace LojaDeFerramentas
{
    public partial class FormHome : Form
    {
        private MySqlConnection Conexao;
        private string _cpfCliente; 
        private int idProduto;
        public FormHome(string cpf)
        {
            InitializeComponent();
            _cpfCliente = cpf;
        }
        private void btnLateral_Click(object sender, EventArgs e)
        {

        }

        private void pagProdutos_Click(object sender, EventArgs e)
        {

        }

        private void widget5_Load(object sender, EventArgs e)
        {

        }

        private void widget1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        public void AddItem(string titulo, double preco, categorias categoria, string icone, int id)
        {
            pnl.Controls.Add(new Widget()
            {
                Titulo = titulo,
                Preco = preco,
                Categoria = categoria,
                Icone = Image.FromFile("icon/" + icone),
                Id = id
            });
        }
       
        private void FormHome_Shown(object sender, EventArgs e)
        {
            AddItem("Jogo de chave\n de fenda", 59.90, categorias.FerramentasManuais, "imgCard1.png", 1);
            AddItem("Alicate universal", 35.50, categorias.FerramentasManuais, "imgCard6.png", 2);
            AddItem("Martelo de unha", 42.00, categorias.FerramentasManuais, "imgCard7.png", 3);
            AddItem("Serra manual", 70.00, categorias.FerramentasManuais, "imgCard5.png", 4);
            AddItem("Estilete retrátil", 15.90, categorias.FerramentasManuais, "imgCard8.png", 5);

            AddItem("Esmerilhadeira\n angular", 450.00, categorias.FerramentasEletricas, "imgCard2.png", 6);
            AddItem("Lixadeira orbital", 320.00, categorias.FerramentasEletricas, "imgCard3.png", 7);

            AddItem("Paquímetro", 150.00, categorias.EquipamentosMedicao, "imgCard4.png", 8);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            abas.SelectedTab = pagProdutos;
        }

        private void btnCarrinho_Click(object sender, EventArgs e)
        {
            
           abas.SelectedTab = pagCarrinho;
           string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
           string query = @"
                    SELECT
                        i.id AS item_id,
                        f.nome AS ferramenta_nome,
                        f.marca AS ferramenta_marca,
                        f.modelo AS ferramenta_modelo,
                        i.quantidade,
                        i.preco AS preco_unitario,
                        (i.quantidade * i.preco) AS preco_total,
                        c.valorTotal AS valor_total_carrinho
                    FROM 
                        itemcarrinho i
                    INNER JOIN 
                        ferramenta f ON i.idProduto = f.id
                    INNER JOIN 
                        carrinho c ON i.idCarrinho = c.idCliente
                    WHERE 
                        c.idCliente = @cpf;
";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@cpf", _cpfCliente);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(comando))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados do cliente: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConta_Click(object sender, EventArgs e)
        {

            abas.SelectedTab = pagConta;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
            string query = "SELECT * FROM Cliente WHERE cpf = @cpf";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@cpf", _cpfCliente);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {                               
                                txtNome.Text = reader["nome"].ToString();
                                txtSobrenome.Text = reader["sobrenome"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtSenha.Text = reader["senha"].ToString();
                                txtCpf.Text = reader["cpf"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Cliente não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormHome_Load(object sender, EventArgs e)
        {
        
        }

        private void pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNome.ReadOnly = false;
            txtSobrenome.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtSenha.ReadOnly = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
            string query = "UPDATE Cliente SET nome = @nome, sobrenome = @sobrenome, email = @email, senha = @senha WHERE cpf = @cpf";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@cpf", _cpfCliente);
                        comando.Parameters.AddWithValue("@nome", txtNome.Text);
                        comando.Parameters.AddWithValue("@sobrenome", txtSobrenome.Text);
                        comando.Parameters.AddWithValue("@email", txtEmail.Text);
                        comando.Parameters.AddWithValue("@senha", txtSenha.Text);

                        comando.ExecuteNonQuery();

                        MessageBox.Show("Dados atualizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNome.ReadOnly = true;
                        txtSobrenome.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        txtSenha.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
            string deleteCliente = "DELETE FROM Cliente WHERE cpf = @cpf";
            string deleteCarrinho = "DELETE FROM Carrinho WHERE idCliente = @cpf";
            string deleteItemCarrinho = "DELETE FROM itemCarrinho WHERE idCarrinho = @cpf";
            string deleteEndereco = "DELETE FROM Endereco WHERE cpfCliente = @cpf";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                    DialogResult resultado = MessageBox.Show("Você realmente deseja deletar sua conta? Essa operação é irreversivel","Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        using (MySqlCommand comando = new MySqlCommand(deleteItemCarrinho, conexao))
                        {
                            comando.Parameters.AddWithValue("@cpf", _cpfCliente);
                            comando.ExecuteNonQuery();
                        }

                        using (MySqlCommand comando = new MySqlCommand(deleteCarrinho, conexao))
                        {
                            comando.Parameters.AddWithValue("@cpf", _cpfCliente);
                            comando.ExecuteNonQuery();
                        }

                        using (MySqlCommand comando = new MySqlCommand(deleteEndereco, conexao))
                        {
                            comando.Parameters.AddWithValue("@cpf", _cpfCliente);
                            comando.ExecuteNonQuery();
                        }

                        using (MySqlCommand comando = new MySqlCommand(deleteCliente, conexao))
                        {
                            comando.Parameters.AddWithValue("@cpf", _cpfCliente);
                            comando.ExecuteNonQuery();
                        }

                        MessageBox.Show("Conta deletada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var login = new FormLogin();
                        login.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar conta: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var login = new FormLogin();
            login.Show();
            this.Hide();
        }

        private void docker_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            abas.SelectedTab = pagEnd;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
            string query = "SELECT * FROM Endereco WHERE cpfCliente = @cpf";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@cpf", _cpfCliente);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtRua.Text = reader["rua"]?.ToString() ?? "";
                                txtBairro.Text = reader["bairro"]?.ToString() ?? "";
                                txtCEP.Text = reader["cep"]?.ToString() ?? "";
                                txtCidade.Text = reader["cidade"]?.ToString() ?? "";
                                txtNum.Text = reader["numero"]?.ToString() ?? "";

                                txtRua.ReadOnly = true;
                                txtBairro.ReadOnly = true;
                                txtCidade.ReadOnly = true;
                                txtCEP.ReadOnly = true;
                                txtNum.ReadOnly = true;

                                button2.Text = "Atualizar";
                                button3.Visible = true;

                            }
                            else
                            {
                                MessageBox.Show("Não há endereços cadastrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                              
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
            string verificarEnd = "SELECT COUNT(*) FROM Endereco WHERE cpfCliente = @cpf";
            string queryInsert = "INSERT INTO Endereco (rua, bairro, cidade, cep, numero, cpfCliente) VALUES(@rua, @bairro, @cidade, @cep, @numero, @cpf)";
            string queryUpdate = "UPDATE Endereco SET rua = @rua, bairro = @bairro, cidade = @cidade, cep = @cep, numero = @numero WHERE cpfCliente = @cpf";

            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    // Verifica se já existe um endereço para o CPF do cliente
                    using (MySqlCommand cmdVerificar = new MySqlCommand(verificarEnd, conexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@cpf", _cpfCliente);
                        int count = Convert.ToInt32(cmdVerificar.ExecuteScalar()); // Retorna a quantidade de endereços encontrados

                        string queryExecutar = count > 0 ? queryUpdate : queryInsert; // Se existe, atualiza. Se não, insere.

                        using (MySqlCommand comando = new MySqlCommand(queryExecutar, conexao))
                        {
                            comando.Parameters.AddWithValue("@cpf", _cpfCliente);
                            comando.Parameters.AddWithValue("@rua", txtRua.Text);
                            comando.Parameters.AddWithValue("@bairro", txtBairro.Text);
                            comando.Parameters.AddWithValue("@cep", txtCEP.Text);
                            comando.Parameters.AddWithValue("@cidade", txtCidade.Text);
                            comando.Parameters.AddWithValue("@numero", Convert.ToInt32(txtNum.Text));

                            comando.ExecuteNonQuery();

                            MessageBox.Show(count > 0 ? "Endereço atualizado com sucesso!" : "Endereço cadastrado com sucesso!",
                                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                           
                            txtRua.ReadOnly = true;
                            txtBairro.ReadOnly = true;
                            txtCidade.ReadOnly = true;
                            txtCEP.ReadOnly = true;
                            txtNum.ReadOnly = true;

                            button2.Text = "Alterar";
                            button3.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void barraLateral_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtRua.ReadOnly = false;
            txtRua.ReadOnly = false;
            txtBairro.ReadOnly = false;
            txtCidade.ReadOnly = false;
            txtCEP.ReadOnly = false;
            txtNum.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";
            string query = "DELETE FROM Endereco WHERE cpfCliente = @cpf";
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                    DialogResult resultado = MessageBox.Show("Você realmente deseja deletar este endereço?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {
                        using (MySqlCommand comando = new MySqlCommand(query, conexao))
                        {
                            comando.Parameters.AddWithValue("@cpf", _cpfCliente);
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Endereço deletado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int idProduto = 2;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

            using (MySqlConnection conexao = new MySqlConnection(data_source))
            {
                conexao.Open();

                string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {

                        string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                             "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                        using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }


                string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

        private void button7_Click(object sender, EventArgs e)
        {
            int idProduto = 5;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

            using (MySqlConnection conexao = new MySqlConnection(data_source))
            {
                conexao.Open();

                string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {

                        string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                             "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                        using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }


                string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

        private void btncarrinho1_Click(object sender, EventArgs e)
        {
                int idProduto = 1; 
                string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

                using (MySqlConnection conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                                    
                    string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                    using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                        cmd.ExecuteNonQuery();
                    }

                    string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                    using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", _cpfCliente); 
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null) 
                        {
                           
                            string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                            using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                            {
                                cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                                cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                        else 
                        {
                            string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                                 "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                            using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                            {
                                cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente); 
                                cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                    }

                    
                    string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                    using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                    {
                        cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        private void btncarrinho3_Click(object sender, EventArgs e)
        {
            int idProduto = 3;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

            using (MySqlConnection conexao = new MySqlConnection(data_source))
            {
                conexao.Open();

                string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {

                        string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                             "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                        using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }


                string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btncarrinho4_Click(object sender, EventArgs e)
        {
            int idProduto = 4;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

            using (MySqlConnection conexao = new MySqlConnection(data_source))
            {
                conexao.Open();

                string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {

                        string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                             "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                        using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }


                string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btncarrinho6_Click(object sender, EventArgs e)
        {
            int idProduto = 6;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

            using (MySqlConnection conexao = new MySqlConnection(data_source))
            {
                conexao.Open();

                string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {

                        string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                             "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                        using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }


                string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btncarrinho7_Click(object sender, EventArgs e)
        {
            int idProduto = 7;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

            using (MySqlConnection conexao = new MySqlConnection(data_source))
            {
                conexao.Open();

                string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {

                        string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                             "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                        using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }


                string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

        private void btncarrinho8_Click(object sender, EventArgs e)
        {
            int idProduto = 8;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

            using (MySqlConnection conexao = new MySqlConnection(data_source))
            {
                conexao.Open();

                string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {

                        string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                             "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                        using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }


                string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

        private void btncarrinho9_Click(object sender, EventArgs e)
        {
            int idProduto = 9;
            string data_source = "datasource=localhost;username=root;password=;database=lojadeferramentas";

            using (MySqlConnection conexao = new MySqlConnection(data_source))
            {
                conexao.Open();

                string criarCarrinho = "INSERT IGNORE INTO carrinho (idCliente, valorTotal) VALUES (@cpf, 0.00)";
                using (MySqlCommand cmd = new MySqlCommand(criarCarrinho, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                string verificarItem = "SELECT quantidade FROM itemcarrinho WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                using (MySqlCommand cmd = new MySqlCommand(verificarItem, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {

                        string atualizarItem = "UPDATE itemcarrinho SET quantidade = quantidade + 1 WHERE idCarrinho = @cpf AND idProduto = @idProduto";
                        using (MySqlCommand cmdUpdate = new MySqlCommand(atualizarItem, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdUpdate.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string inserirItem = "INSERT INTO itemcarrinho (idCarrinho, idProduto, quantidade, preco) " +
                                             "VALUES (@cpf, @idProduto, 1, (SELECT valor FROM ferramenta WHERE id = @idProduto))";
                        using (MySqlCommand cmdInsert = new MySqlCommand(inserirItem, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@cpf", _cpfCliente);
                            cmdInsert.Parameters.AddWithValue("@idProduto", idProduto);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }


                string atualizarValorTotal = @"
            UPDATE carrinho 
            SET valorTotal = (
                SELECT SUM(quantidade * preco) 
                FROM itemcarrinho 
                WHERE idCarrinho = @cpf
            ) 
            WHERE idCliente = @cpf";

                using (MySqlCommand cmd = new MySqlCommand(atualizarValorTotal, conexao))
                {
                    cmd.Parameters.AddWithValue("@cpf", _cpfCliente);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Produto adicionado ao carrinho!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
 }
