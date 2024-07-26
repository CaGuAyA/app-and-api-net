using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app.Controlador;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace app
{
    public partial class Form1 : Form
    {
        private readonly ProductoControlador _controller;

        public Form1()
        {
            InitializeComponent();
            _controller = new ProductoControlador();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await _controller.LoadProducts(dataGridView1);
        }

        private async void btn_adicionar_Click(object sender, EventArgs e)
        {
            await _controller.AddProduct(textBoxName.Text, decimal.Parse(textBoxPrice.Text));
            await _controller.LoadProducts(dataGridView1);
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await _controller.UpdateProduct(int.Parse(textBoxId.Text), textBoxName.Text, decimal.Parse(textBoxPrice.Text));
            await _controller.LoadProducts(dataGridView1);
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await _controller.DeleteProduct(int.Parse(textBoxId.Text));
            await _controller.LoadProducts(dataGridView1);
        }
    }
}
