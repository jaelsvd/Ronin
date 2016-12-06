using System.ComponentModel.DataAnnotations;

namespace App.Entities.Reportes
{
   public partial class ReporteIva
    {
        public ReporteIva()
        { }
        public int Id { get; set; }
        public int? Anio { get; set; }
        public int? Mes { get; set; }
        public string FormaPagoDesc { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Importe { get; set; }
        public long? CantidadPedimentos { get; set; }

    }
}
