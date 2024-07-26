using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using app.Modelo;
using app.Servicio;

namespace app.Controlador
{
    internal class ProductoControlador
    {
        private readonly ProductoServicios _apiService;

        public ProductoControlador()
        {
            _apiService = new ProductoServicios();
        }

        public async Task LoadProducts(DataGridView dataGridView)
        {
            var products = await _apiService.GetProductsAsync();
            dataGridView.DataSource = products;
        }

        public async Task AddProduct(string name, decimal price)
        {
            var product = new Producto { Nombre = name, Precio = price };
            await _apiService.CreateProductAsync(product);
        }

        public async Task UpdateProduct(int id, string name, decimal price)
        {
            var product = new Producto { Id = id, Nombre = name, Precio = price };
            await _apiService.UpdateProductAsync(id, product);
        }

        public async Task DeleteProduct(int id)
        {
            await _apiService.DeleteProductAsync(id);
        }
    }
}
