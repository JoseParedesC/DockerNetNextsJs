using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLabApi.Models
{
    [Table("ventas")]
    public partial class Ventas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("fecha")]
        public DateTime Fecha { get; set; }

        [Column("codigo_factura")]
        public string Codigo_factura { get; set; } = string.Empty;

        [Column("vendedor")]
        public int Vendedor { get; set; } = string.Empty;

        [Column("comprador")]
        public int Comprador { get; set; } = string.Empty;
    }
}
