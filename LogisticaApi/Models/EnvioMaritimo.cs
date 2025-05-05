using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticaApi.Models
{
    public class EnvioMaritimo
    {
        private decimal PrecioEnvio;

        public int Id { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }

        public int PuertoId { get; set; }
        [ForeignKey("PuertoId")]
        public Puerto? Puerto { get; set; }

        public DateTime FechaEnvio { get; set; }
        public string Destino { get; set; } = string.Empty;
        public string Estado { get; set; } = "En tránsito"; // Por defecto

        public decimal PrecioNormal { get; set; }
        public decimal PrecioConDescuento { get; set; }

        public void CalcularDescuento()
        {
            PrecioNormal = PrecioEnvio;

            if (Producto.Cantidad > 10) // Descuento si la cantidad es mayor a 10
            {
                PrecioConDescuento = PrecioEnvio * 0.97m; // 3% de descuento
            }
            else
            {
                PrecioConDescuento = PrecioEnvio;
            }
        }


    }


}
