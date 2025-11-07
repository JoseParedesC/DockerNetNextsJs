using MyLabApi.Data;
using MyLabApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLabApi.Services
{
    public class ProductsService
    {
        private readonly DatabaseContext _context;

        public ProductsService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
