namespace LogisticaApi.Models
{
    public class Producto
    {
        internal int Cantidad;

        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double Peso { get; set; }
    }
}

