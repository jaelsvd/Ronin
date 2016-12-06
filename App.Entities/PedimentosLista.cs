using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities

{
    [Table("DsPedimentosLista")]
    public class PedimentosLista
    {
        /// <summary>
        /// Id de la tabla
        /// </summary>
        [Key]
        public int Id { get; set; }

        #region Propiedades PedimentosLista
        public bool TieneError { get; set; }
        /// <summary>
        /// Clave de la Aduana
        /// </summary>
        public string AduanaClave { get; set; }
        /// <summary>
        /// Descripcion de la Aduana
        /// </summary>
        public string AduanaDesc { get; set; }
        /// <summary>
        /// Patente
        /// </summary>
        public int Patente { get; set; }
        /// <summary>
        /// Numero Documento Agente
        /// </summary>
        public string FolioPedimento { get; set; }

        #endregion

        /// <summary>
        /// Fecha de registro en la Base de Datos
        /// </summary>
        /// 
        public DateTime FechaCreacion { get; set; }

        #region Relaciones
        /// <summary>
        /// Llave Foranea ListaPedimento
        /// </summary>
        public int ListaPedimentoId { get; set; }
        public ListaPedimento ListaPedimento { get; set; }

        #endregion

    }
}
