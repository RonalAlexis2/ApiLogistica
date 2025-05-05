
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticaApi.Models
{
    public class EnvioTerrestre
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }

        public int BodegaId { get; set; }
        [ForeignKey("BodegaId")]
        public Bodega? Bodega { get; set; }

        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string PlacaVehiculo { get; set; } = string.Empty;
        public string NumeroGuia { get; set; } = string.Empty;
        public decimal PrecioEnvio { get; set; }

        // Nuevas propiedades para el precio normal y con descuento
        public decimal PrecioNormal { get; set; }
        public decimal PrecioConDescuento { get; set; }

        // Lógica para aplicar el descuento
        public void CalcularDescuento()
        {
            PrecioNormal = PrecioEnvio;

            if (Producto.Cantidad > 10) // Descuento si la cantidad es mayor a 10
            {
                PrecioConDescuento = PrecioEnvio * 0.95m; // 5% de descuento
            }
            else
            {
                PrecioConDescuento = PrecioEnvio;
            }
        }
    }

}

