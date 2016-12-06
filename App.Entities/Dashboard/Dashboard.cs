using System.ComponentModel.DataAnnotations;

namespace App.Entities.Dashboard
{
    public partial class Dashboard
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Importacion { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Exportacion { get; set; }
        public decimal ImportacionValComercial { get; set; }
        public decimal ExportacionValComercial { get; set; }
        public decimal ValorAgregadoImp { get; set; }
        public decimal ValorAgregadoExp { get; set; }
    }
}
