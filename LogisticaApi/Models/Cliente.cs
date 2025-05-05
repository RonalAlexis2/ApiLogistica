namespace LogisticaApi.Models
{
    public class Cliente
    {
        public int Id { get; set; } // Clave primaria
        public string Nombre { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }
}

