using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LojaDeFerramentas.Componetes
{
    public partial class Widget : UserControl
    {

        private categorias _categoria;
        private double _preco;

        public event EventHandler OnSelect = null;
        public event EventHandler AdicionarAoCarrinho;
        public Widget()
        {
            InitializeComponent();
        }

        private void imgC_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
        public enum categorias { FerramentasManuais, FerramentasEletricas, EquipamentosMedicao }
        public categorias Categoria { get => _categoria; set => _categoria = value; }

        public string Titulo { get => tituloC.Text; set => tituloC.Text = value; }
        public double Preco { get => _preco; set { _preco = value; precoC.Text = _preco.ToString("C2"); } }
        public Image Icone { get => imgC.Image; set => imgC.Image = value; }
        public int Id { get; set; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {

        }

        private void tituloC_Click(object sender, EventArgs e)
        {

        }

        private void btnProdutos_Click_1(object sender, EventArgs e)
        {
            AdicionarAoCarrinho?.Invoke(this, EventArgs.Empty);
        }
    }
}
