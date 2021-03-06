﻿using System.ComponentModel.DataAnnotations;

namespace App.Entities.Reportes
{
    public partial class ImpVSExpAnual
    {
        public int Id { get; set; }
        public int? Anio { get; set; }
        public string Clave { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Importacion { get; set; }
        /// <summary>
        /// El valor comercial en Importacion ya trae el valor agregado
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ImportacionValComercial { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? Exportacion { get; set; }
        /// <summary>
        /// El valor Comercial ya trae el Valor Agregado incluido
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ExportacionValComercial { get; set; }
        public decimal? ValorAgregadoImp { get; set; }
        public decimal? ValorAgregadoExp { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ExportVA { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ExportSinVA { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ExportSinVAMenosImport { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal? ExportConVAMenosImport { get; set; }
    }
}
