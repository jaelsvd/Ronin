using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPartida")]
    public class Partida
    {
        public Partida()
        {
            this.PartidaIdentificador = new HashSet<PartidaIdentificador>();
            this.PartidaGravamen = new HashSet<PartidaGravamen>();
            this.PartidaPermiso = new HashSet<PartidaPermiso>();
            this.PartidaCuentaAduanera = new HashSet<PartidaCuentaAduanera>();
            this.PartidaDatosVehiculo = new HashSet<PartidaDatosVehiculo>();
            this.PartidaMetodoValoracion = new HashSet<PartidaMetodoValoracion>();
            this.PartidaVinculacion = new HashSet<PartidaVinculacion>();
        }

        /// <summary>
        /// Identificador de la tabla Partida
        /// </summary>
        [Key]
        public int Id { get; set; }

        #region Propiedades Partida
        /// <summary>
        ///Partida 
        /// </summary>
        [DisplayName("Numero de Partida")]
        public int NumeroPartida { get; set; }
        /// <summary>
        /// Fraccion Arancelaria
        /// </summary>
        [StringLength(8, ErrorMessage = "La fraccion debe tener 8 caracteres")]
        [DisplayName("Fracción Arancelaria")]
        public string FraccionArancelaria { get; set; }
        /// <summary>
        /// Descripcion de la mercancia
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripicion de la mercancia debe ser menor de 250 caracteres")]
        [DisplayName("Descripción de Mercancía")]
        public string DescMercancia { get; set; }



        #region unidadMedidaTarifa
        /// <summary>
        ///Clave
        /// </summary>
        [DisplayName("Clave")]
        public string UnidadMedTarifaClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        [DisplayName("Descripción")]
        public string UnidadMedTarifaDesc { get; set; }
        #endregion

        /// <summary>
        ///Cantidad UMT
        /// </summary>
        //[MaxLength(18, ErrorMessage = "La cantidad no  debe ser mayor de 18 digitos")]
        [DisplayName("Cantidad UMT")]
        public decimal CantidadUnidadMedidaTarifa { get; set; }

        #region Unidad  Medida Comercial
        /// <summary>
        ///Clave
        /// </summary>
        //[MaxLength(32767, ErrorMessage = "La clave debe ser menor de 32767"), MinLength(-32768, ErrorMessage = "La clave debe ser mayor de -32768")]
        [DisplayName("Clave")]
        public string UnidadMedComerClave { get; set; }
        /// <summary>
        ///Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        [DisplayName("Descripción")]
        public string UnidadMedComerDesc { get; set; }
        #endregion

        /// <summary>
        ///Cantidad UMC
        /// </summary>
        //[MaxLength(18, ErrorMessage = "La cantidad debe ser menor de 18 digitos")]
        [DisplayName("Cantidad UMC")]
        public decimal CantidadUnidadMedidaComercial { get; set; }
        /// <summary>
        ///Precio Unitario
        /// </summary>
        //[MaxLength(19, ErrorMessage = "La cantidad debe ser menor de 19 digitos")]
        [DisplayName("Precio Unitario")]
        public decimal PrecioUnitaro { get; set; }
        /// <summary>
        ///Valor Comercial
        /// </summary>
        // [MaxLength(13, ErrorMessage = "La cantidad debe ser menor de 13 digitos")]
        [DisplayName("Valor Comercial")]
        public decimal ValorComercial { get; set; }
        /// <summary>
        ///Valor Aduana
        /// </summary>
        // [MaxLength(13, ErrorMessage = "La cantidad debe ser menor de 13 digitos")]
        [DisplayName("Valor Aduana")]
        public decimal ValorAduana { get; set; }
        /// <summary>
        ///Valor Dolares
        /// </summary>
        //[MaxLength(13, ErrorMessage = "La cantidad debe ser menor de 13 digitos")]
        [DisplayName("Valor Dolares")]
        public decimal ValorDolares { get; set; }
        /// <summary>
        ///Valor Agregado
        /// </summary>
        //[MaxLength(13, ErrorMessage = "La cantidad debe ser menor de 13 digitos")]
        [DisplayName("Valor Agregado")]
        public decimal ValorAgregado { get; set; }

        

       

        #region Pais Origen/Destino
        /// <summary>
        /// Clave
        /// </summary>
        [StringLength(3, ErrorMessage = "La clave debe ser de 3 digitos")]
        [DisplayName("Clave")]
        public string PaisOrigDestClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        [DisplayName("Descripción")]
        public string PaisOrigDestDesc { get; set; }
        #endregion

        #region Pais Vendedor/Comprador
        /// <summary>
        /// Clave
        /// </summary>
        [StringLength(3, ErrorMessage = "La clave debe ser de 3 digitos")]
        [DisplayName("Clave")]
        public string PaisVendCompClave { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripcion debe ser menor de 250 caracteres")]
        [DisplayName("Descripción")]
        public string PaisVendCompDesc { get; set; }
        #endregion


        /// <summary>
        /// Observaciones
        /// </summary>
        //[MaxLength(10000, ErrorMessage = "La descripcion debe ser menor de 10,000 caracteres")]
        [DisplayName("Descripción")]
        public string ObservacionesDesc { get; set; }

        public string CodigoMercancia { get; set; }
        public string SubDivisionFraccion { get; set; }
        public string MarcaMercancia { get; set; }
        public string ModeloMercancia { get; set; }

        #endregion

        /// <summary>
        /// El tiempo en que devuelve el webservice
        /// </summary>
        public string Tiempo { get; set; }
        /// <summary>
        /// /Define si tiene error
        /// </summary>
        [DisplayName("Error")]
        public bool TieneError { get; set; }
        /// <summary>
        /// Descripcion del error
        /// </summary>
        public string ErrorDesc { get; set; }
        /// <summary>
        /// Cantidad de intentos en la petitcion
        /// </summary>
        public int Intentos { get; set; }
        /// <summary>
        /// Fecha de registro en la Base de Datos
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        #region Relaciones
        public virtual ICollection<PartidaIdentificador> PartidaIdentificador { get; set; }

        public virtual ICollection<PartidaGravamen> PartidaGravamen { get; set; }
        public virtual ICollection<PartidaPermiso> PartidaPermiso { get; set; }
        public virtual ICollection<PartidaCuentaAduanera> PartidaCuentaAduanera { get; set; }
        public virtual ICollection<PartidaDatosVehiculo> PartidaDatosVehiculo { get; set; }
        public virtual ICollection<PartidaVinculacion> PartidaVinculacion { get; set; }
        public virtual ICollection<PartidaMetodoValoracion> PartidaMetodoValoracion { get; set; }

        /// <summary>
        /// Llave foranea de Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        public object ImpExpFechasFecha { get; set; }
        #endregion

    }
}
