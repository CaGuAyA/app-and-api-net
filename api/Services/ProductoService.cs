using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;

namespace api.Services
{
    public class ProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetProductsAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> CreateProductAsync(Producto product)
        {
            _context.Productos.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateProductAsync(Producto product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Productos.FindAsync(id);
            if (product != null)
            {
                _context.Productos.Remove(product);
                await _context.SaveChangesAsync();
            }
            return;
        }
    }
}
