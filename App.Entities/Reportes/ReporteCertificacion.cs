using System.ComponentModel.DataAnnotations;

namespace App.Entities.Reportes
{
    public partial class ReporteCertificacion
    {
        public ReporteCertificacion()
        {

        }

        public int Id { get; set; }
        public int? Anio { get; set; }
        public int? Mes { get; set; }
        public int? DocClave { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Importacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Exportacion { get; set; }
        public decimal? ImportacionValComer { get; set; }
        public decimal? ExportacionValComer { get; set; }
        public decimal? TotalImportacion { get; set; }
        public decimal? TotalExportacion { get; set; }
        public decimal? ValorAgregadoImp { get; set; }
        public decimal? ValorAgregadoExp { get; set; }
    }
}
