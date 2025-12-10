using MyLabApi.Data;
using MyLabApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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

        #region DATABASE
        public async Task<List<Products>> GetAllProductsDB()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetByIdDB(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Products> SaveProductDB(Products dtoProducto)
        {
            _context.Products.Add(dtoProducto);
            await _context.SaveChangesAsync();
            return await GetByIdDB(dtoProducto.Id);
        }

        public async Task<Products> UpdateProductDB(Products dtoProducto, int idProducto)
        {
            var prod = await _context.Products.FindAsync(idProducto);
            if(prod == null) return new Products();

            prod.Code = dtoProducto.Code;
            prod.Name = dtoProducto.Name;
            prod.Description = dtoProducto.Description;
            prod.Present = dtoProducto.Present;

            await _context.SaveChangesAsync();

            return await GetByIdDB(idProducto);
        }

        public async Task<bool> DeleteProductDB(int idProducto)
        {
            var prod = await _context.Products.FindAsync(idProducto);
            if(prod == null) return false;

            _context.Products.Remove(prod);

            await _context.SaveChangesAsync();
            return true;
        }

        #endregion DATABASE

        #region LIST
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

        #endregion LIST
    }
}
