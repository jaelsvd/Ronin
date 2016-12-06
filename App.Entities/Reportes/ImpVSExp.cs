using System.ComponentModel.DataAnnotations;

namespace App.Entities.Reportes
{
    public partial class ImpVSExp
    {
        public int Id { get; set; }
        public int? Anio { get; set; }
        public string Clave { get; set; }
        public string ClaveIN { get; set; }
        public string ClaveRT { get; set; }
        public string ClaveV1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Importacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Exportacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ExportacionValComercial { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ImportacionValComercial { get; set; }
        public decimal? ValorAgregadoImp { get; set; }
        public decimal? ValorAgregadoExp { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ExportVA { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ExportSinVA { get; set; }


    }
}
