using MyLabApi.Data;
using MyLabApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyLabApi.Services
{
    public class VentasService
    {
        private List<Ventas> ventasList = new List<Ventas>();
        // private readonly DatabaseContext _context;

        // public VentasService(DatabaseContext context)
        // {
        //     _context = context;
        // }

        // public Task<List<Ventas>> GetAllVentas()
        // {
        //     return await _context.Ventas.ToListAsync();
        // }

        public List<Ventas> GetAllVentas()
        {
            return ventasList;
        }

        public Ventas GetSellById(int id)
        {
            return ventasList.FirstOrDefault(t => t.Id == id);
        }

        public Ventas SaveSell(Ventas dataVenta)
        {
            ventasList.Add(dataVenta);

            return GetSellById(dataVenta.Id);
        }

        public Ventas UpdateSell(Ventas dataVenta, int idVenta)
        {
            ventasList
                .Where(p => p.Id == idVenta)
                .ToList()
                .ForEach(p => {
                    p.Fecha = dataVenta.Fecha;
                    p.Codigo_factura = dataVenta.Codigo_factura;
                    p.Vendedor = dataVenta.Vendedor;
                    p.Comprador = dataVenta.Comprador;
                });

            return GetSellById(idVenta);
        }

        public void DeleteSell(int idVenta)
        {
            var prod_delete = GetSellById(idVenta);

            ventasList.Remove(prod_delete);
        }
    }
}
