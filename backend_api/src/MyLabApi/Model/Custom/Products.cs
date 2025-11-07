using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLabApi.Models
{
    
    public partial class Products
    {
        public static List<Products> ProductosPorDefecto { get; } = GenerarProductos();

        public static List<Products> GenerarProductos()
        {
            var productos = new List<Products>
            {
                new Products { Id = 1, Code = "P001", Name = "Producto A", Description = "Descripción del Producto A", Present = "Unidad" },
                new Products { Id = 2, Code = "P002", Name = "Producto B", Description = "Descripción del Producto B", Present = "Caja" },
                new Products { Id = 3, Code = "P003", Name = "Producto C", Description = "Descripción del Producto C", Present = "Paquete" },
                new Products { Id = 4, Code = "P004", Name = "Producto D", Description = "Descripción del Producto D", Present = "Unidad" },
                new Products { Id = 5, Code = "P005", Name = "Producto E", Description = "Descripción del Producto E", Present = "Caja" }
            };

            return productos;
        }
    }
}
