using System;

namespace App.Entities.Reportes
{
    public partial class ReporteFactura
    {
        public int Patente { get; set; }
        public string Pedimento { get; set; }
        public string Aduana { get; set; }
        public string Clave { get; set; }
        public string TipoOperacion { get; set; }
        public DateTime FechaPago { get; set; }
        public string RectificadoPor { get; set; }
        public string RectificaPedimento { get; set; }
        public string Factura { get; set; }
        public string COVE { get; set; }
        public string IDEmisor { get; set; }
        public string Emisor { get; set; }
        public string IDDestinatario { get; set; }
        public string Destinatario { get; set; }
        public DateTime? FechaFactura { get; set; }
    }
}
