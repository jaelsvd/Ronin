using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsListaPedimento")]
    public class ListaPedimento

    {
        public ListaPedimento()
        {
            this.PedimentosLista = new HashSet<PedimentosLista>();
            this.Pedimento = new HashSet<Pedimento>();
        }

        /// <summary>
        /// Id de Listado de Pedimento
        /// </summary>
        /// 
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Campo para saber si tiene error el request.
        /// </summary>
        public bool TieneError { get; set; }
        /// <summary>
        /// Descripcion del error
        /// </summary>
        public string ErrorDesc { get; set; }
        /// <summary>
        /// Fecha y Hora de cracion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }         
        /// <summary>
        /// Error en la peticion
        /// </summary>
        public bool ErrorPeticion { get; set; }
        /// <summary>
        /// El tiempo en que devuelve el webservice
        /// </summary>
        public string Tiempo { get; set; }
        /// <summary>
        /// Fecha de inicio de la consulta del listado
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Fecha final de la consulta del listado
        /// </summary>
        public DateTime FechaFinal { get; set; }
        /// <summary>
        /// Cantidad de intentos en la petitcion
        /// </summary>
        public int Intentos { get; set; }

        public int Patente { get; set; }

        public string Aduana { get; set; }

        #region Relaciones

        /// <summary>
        /// Relacion con Entidad PedimentosLista
        /// </summary>
        public virtual ICollection<PedimentosLista> PedimentosLista { get; set; }
        /// <summary>
        /// Relacion con Entidad Pedimento
        /// </summary>
        public virtual ICollection<Pedimento> Pedimento { get; set; }

        #endregion


    }
}
