using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsDataStage")]
    public class DataStage
    {
        /// <summary>
        /// Identificador de la tabla DataStage
        /// </summary>
        [Key]
        public int Id { get; set; }

        #region Propiedades DataStage
        /// <summary>
        /// Nombre del archivo
        /// </summary>
        public string NombreArchivo { get; set; }
        /// <summary>
        /// Nombre del Creador del Zip
        /// </summary>
        public string NombreCreador { get; set; }
        /// <summary>
        /// Fecha inicial para generar DataStage Zip
        /// </summary>
        [Required(ErrorMessage = "Seleccione una fecha inicial")]
        public DateTime FechaInicial { get; set; }
        /// <summary>
        /// Fecha Final para generar DataStage Zip
        /// </summary>
        [Required(ErrorMessage = "Seleccione una fecha final")]
        public DateTime FechaFinal { get; set; }
        /// <summary>
        /// Ruta URL donde se guarda el archivo Zip
        /// </summary>
        public string URLZip { get; set; }
        /// <summary>
        /// Fecha en la que se genero el DataStage Zip
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        #endregion
    }
}
