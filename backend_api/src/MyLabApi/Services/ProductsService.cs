using MyLabApi.Data;
using MyLabApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyLabApi.Services
{
    public class ProductsService
    {
        private List<Products> productosList = Products.ProductosPorDefecto;
        private readonly DatabaseContext _context;

        public ProductsService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Products>> GetAllProductsDB()
        {
            return await _context.Products.ToListAsync();
        }

        public List<Products> GetAllProducts()
        {
            return productosList;
        }

        public Products GetProductById(int id)
        {
            return productosList.FirstOrDefault(t => t.Id == id);
        }

        public Products SaveProduct(Products dataProducto)
        {
            productosList.Add(dataProducto);

            return GetProductById(dataProducto.Id);
        }

        public Products UpdateProduct(Products dataProducto, int idProducto)
        {
            productosList
                .Where(p => p.Id == idProducto)
                .ToList()
                .ForEach(p => {
                    p.Code = dataProducto.Code;
                    p.Name = dataProducto.Name;
                    p.Description = dataProducto.Description;
                    p.Present = dataProducto.Present;
                });

            return GetProductById(idProducto);
        }

        public void DeleteProduct(int idProducto)
        {
            var prod_delete = GetProductById(idProducto);

            productosList.Remove(prod_delete);
        }
    }
}
