using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimento")]
    public class Pedimento
    {
        public Pedimento()
        {
            this.TasasPedimento = new HashSet<PedimentoTasa>();
            this.IdentificadoresPedimento = new HashSet<PedimentoIdentificador>();
            this.PedimentoImpExpFechas = new HashSet<PedimentoImpExpFechas>();
            this.PedimentoProveedorComprador = new HashSet<PedimentoProveedorComprador>();
            this.PedimentoTransporte = new HashSet<PedimentoTransporte>();
            this.PedimentoGuia = new HashSet<PedimentoGuia>();
            this.PedimentoContenedor = new HashSet<PedimentoContenedor>();
            this.PedimentoFactura = new HashSet<PedimentoFactura>();
            this.PedimentoCuentaAduanera = new HashSet<PedimentoCuentaAduanera>();
            this.PedimentoDescargo = new HashSet<PedimentoDescargo>();
            this.PedimentoDestinatario = new HashSet<PedimentoDestinatario>();
            this.PedimentoDiferenciaContribucion = new HashSet<PedimentoDiferenciaContribucion>();
        }
        /// <summary>
        /// Id de la tabla Pedimento
        /// </summary>
        [Key]
        public int Id { get; set; }

        #region Propiedades de Pedimento 

        /// <summary>
        /// Número de Pedimento
        /// </summary>
        [StringLength(7, ErrorMessage = "El numero de pedimento debe tener 7 caracteres")]
        [DisplayName("Pedimento")]
        public string NumPedimento { get; set; }
        /// <summary>
        /// Observaciones de Pedimento
        /// </summary>
        //[MaxLength(120, ErrorMessage = "La observación no debe ser mayor de 120 carácteres")]
        [DisplayName("Observaciones")]
        public string ObservacionesPedimento { get; set; }
        /// <summary>
        /// Cantidad de partidas que muestra un pedimento
        /// </summary>
        [DisplayName("Partidas")]
        public int CantidadPartidas { get; set; }
        /// <summary>
        /// Patente del Pedimento
        /// </summary>
        public int Patente { get; set; }
        /// <summary>
        /// Aduana del Pedimento
        /// </summary>
        public string Aduana { get; set; }


        #region Encabezado del Pedimento

        #region tipoOperacion
        /// <summary>
        /// Clave
        /// </summary>
        [DisplayName("Clave")]
        public int EncabezadoOpClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250")]
        [DisplayName("Operación")]
        public string EncabezadoOpDesc { get; set; }
        #endregion

        #region claveDocumento
        /// <summary>
        /// Clave
        /// </summary>
        [StringLength(6)]
        [DisplayName("Clave")]
        public string EncabezadoClavDocClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        [DisplayName("Descripción")]
        public string EncabezadoClavDocDescripcion { get; set; }
        #endregion

        #region Destino
        /// <summary>
        /// Destino - Clave
        /// </summary>
        [DisplayName("Clave")]
        public int EncabezadoDestinoClave { get; set; }
        /// <summary>
        /// Destino Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        [DisplayName("Descripción")]
        public string EncabezadoDestionDesc { get; set; }
        #endregion

        #region aduEntradaSalida
        /// <summary>
        /// Clave
        /// </summary>
        [DisplayName("Clave")]
        public int EncabezadoAduEntSalidaClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        [DisplayName("Descripción")]
        public string EncabezadoAduEntSalidaDesc { get; set; }
        #endregion

        /// <summary>
        /// Destino - Tipo de Cambio
        /// </summary>
        [DisplayName("TC")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal EncabezadoTipoCambio { get; set; }
        /// <summary>
        /// Destino - Peso Bruto
        /// </summary>
        [DisplayName("Peso Bruto")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal EncabezadoPesoBruto { get; set; }

        #region medTranspSalida
        /// <summary>
        /// Clave
        /// </summary>
        [DisplayName("Clave")]
        public int EncabezadoMedTranspSalClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        [DisplayName("Descripción")]
        public string EncabezadoMedTranspSalDesc { get; set; }
        #endregion

        #region medTranspArribo
        /// <summary>
        /// Clave
        /// </summary>
        [DisplayName("Clave")]
        public int EncabezadoMedTranspArriboClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        [DisplayName("Descripción")]
        public string EncabezadoMedTranspArriboDesc { get; set; }
        #endregion

        #region medTranspEntrada
        /// <summary>
        /// medTranspEntrada - Clave
        /// </summary>
        [DisplayName("Clave")]
        public int EncabezadoMedTranspEntradaClave { get; set; }
        /// <summary>
        ///  Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        [DisplayName("Descripción")]
        public string EncabezadoMedTranspEntradaDesc { get; set; }

        #endregion

        /// <summary>
        ///  curpApodMand
        /// </summary>
        [StringLength(18)]
        [DisplayName("CURP")]
        public string CurpApoderadoMandatario { get; set; }
        /// <summary>
        ///  rfcAASocFactura
        /// </summary>
        //[MaxLength(13, ErrorMessage = "El RFC no debe ser mayor de 13"), MinLength(9, ErrorMessage = "El RFC no debe ser menor de 9")]
        [DisplayName("RFC")]
        public string RFCAduanalSocFactura { get; set; }
        /// <summary>
        /// Valor Dolares
        /// </summary>
        [DisplayName("Valor Dolares")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorAduanaTotalDolares { get; set; }
        /// <summary>
        ///  Valor Aduana Total
        /// </summary>
        [DisplayName("Valor Aduana Total")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorAduanaTotal { get; set; }
        /// <summary>
        ///  Valor Comercial Total
        /// </summary>
        [DisplayName("Valor Comercial Total")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal ValorComercialTotal { get; set; }
        #endregion

        #region Rectificaciones

        public int aduOrigRectificacionClav { get; set; }
        public string aduOrigRectificacionDesc { get; set; }
        public int aduDespRectificacionClav { get; set; }
        public string aduDespRectificacionDesc { get; set; }
        public string ClavDocRectificacionClave { get; set; }
        public string ClavDocRectificacionDesc { get; set; }
        public DateTime? FechaPagoRectificacion { get; set; }
        public int PedimentoOriginalRectificacion { get; set; }
        public int PatenteOriginalRectificacion { get; set; }
        public DateTime? FechaOriginalRectificacion { get; set; }
        #endregion

        #region Datos del Importador/Exportador
        /// <summary>
        /// rfcImpExp -
        /// RFC del Importador Exportador
        /// </summary>
        [DisplayName("RFC")]
        public string ImpExpRfcImpExp { get; set; }
        /// <summary>
        /// curpImpExp -
        /// CURP del Importador / Exportador
        /// </summary>
        [DisplayName("CURP")]
        public string ImpExpCurpImpExp { get; set; }
        /// <summary>
        /// razSocImpExp -
        /// Razon Social del Importador Exportador
        /// </summary>
        //[MaxLength(120, ErrorMessage = "La razón social no debe ser mayor de 120 carácteres")]
        [DisplayName("Razón Social")]
        public string ImpExpRazSocImpExp { get; set; }
        /// <summary>
        /// Calle del domicilio del Importador/Exportador
        /// </summary>

        #region Domicilio
        /// <summary>
        /// Nombre de la Calle 
        /// </summary>
        //[MaxLength(80, ErrorMessage = "La calle no puede tener mas 80 carácteres")]
        [DisplayName("Calle")]
        public string ImpExpDomCalle { get; set; }
        /// <summary>
        /// Numero Exterior del Domicilio
        /// </summary>
        //[MaxLength(10, ErrorMessage = "El número exterior no puede ser mayor de 10 carácteres")]
        [DisplayName("Número Exterior")]
        public string ImpExpNumDomExterior { get; set; }
        /// <summary>
        /// Numero Exterior del Domicilio
        /// </summary>
        //[MaxLength(10, ErrorMessage = "El número exterior no puede ser mayor de 10 carácteres")]
        [DisplayName("Número Interior")]
        public string ImpExpNumDomInterior { get; set; }
        /// <summary>
        /// Ciudad de Municipio
        /// </summary>
        //[MaxLength(80, ErrorMessage = "El CD de Municipio no puede ser mayor de 80 carácteres")]
        [DisplayName("Ciudad de Municipio")]
        public string ImpExpDomCdMunicipio { get; set; }
        /// <summary>
        /// Codigo Postal
        /// </summary>
        //[MaxLength(10, ErrorMessage = "El CP no puede ser mayor de 10 carácteres")]
        [DisplayName("CP")]
        public string ImpExpDomCP { get; set; }
        #endregion

        /// <summary>
        /// Seguros
        /// </summary>
        //[MaxLength(12, ErrorMessage = "El Seguro no debe ser mayor de 12 carácteres")]
        [DisplayName("Seguros")]
        public decimal ImpExpSeguros { get; set; }
        /// <summary>
        /// Fletes
        /// </summary>
       // [MaxLength(12, ErrorMessage = "El Flete no debe ser mayor de 12 carácteres")]
        [DisplayName("Fletes")]
        public decimal ImpExpFletes { get; set; }
        /// <summary>
        /// Embalajes
        /// </summary>
        //[MaxLength(12, ErrorMessage = "El Embalaje no debe ser mayor de 12 carácteres")]
        [DisplayName("Embalajes")]
        public decimal ImpExpEmbalajes { get; set; }
        /// <summary>
        /// Incrementables
        /// </summary>
        [DisplayName("Incrementables")]
        public decimal ImpExpIncrementables { get; set; }



        #region aduDespacho
        /// <summary>
        /// Clave
        /// </summary>
        [DisplayName("Clave")]
        public int ImpExpAudoDespachoClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        [DisplayName("Descripción")]
        public string ImpExpAudoDespachoDesc { get; set; }

        #endregion

        #region Fechas

        //Tabla fechas va aqui

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Efectivo")]
        public decimal ImpExpEfectivo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Otros")]
        public decimal ImpExpOtros { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Total")]
        public decimal ImpExpTotal { get; set; }

        #region Pais
        /// <summary>
        /// Clave de pais de Importador/Exportador
        /// </summary>
        [StringLength(3)]
        [DisplayName("Clave")]
        public string ImpExpPaisClave { get; set; }
        /// <summary>
        /// Descripcion de Pais de Importador Exportador
        /// </summary>
        //[MaxLength(250, ErrorMessage = "La descripción no debe ser mayor de 250 carácteres")]
        [DisplayName("Descripción")]
        public string ImpExpPaisDesc { get; set; }
        #endregion

        #endregion


        

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

        /// <summary>
        /// Llave Foranea ListaPedimento
        /// </summary>
        public int ListaPedimentoId { get; set; }
        public ListaPedimento ListaPedimento { get; set; }
        /// <summary>
        /// Relacion con Identificadores
        /// </summary>
        public virtual ICollection<PedimentoIdentificador> IdentificadoresPedimento { get; set; }
        /// <summary>
        /// Relacion con Tasas
        /// </summary>
        public virtual ICollection<PedimentoTasa> TasasPedimento { get; set; }
        /// <summary>
        /// Relacion con Partidas
        /// </summary>
        public virtual ICollection<Partida> Partida { get; set; }
        /// <summary>
        /// relacion con fechas de Importacion y Exportacion
        /// </summary>
        public virtual ICollection<PedimentoImpExpFechas> PedimentoImpExpFechas { get; set; }
        /// <summary>
        /// Relacion con Proveedor/Comprador
        /// </summary>
        public virtual ICollection<PedimentoProveedorComprador> PedimentoProveedorComprador { get; set; }
        /// <summary>
        /// Relacion con tabla Pedimento Transporte
        /// </summary>
        public virtual ICollection<PedimentoTransporte> PedimentoTransporte { get; set; }
        /// <summary>
        /// Relacion con trabla Guia
        /// </summary>
        public virtual ICollection<PedimentoGuia> PedimentoGuia { get; set; }
        /// <summary>
        /// Relacion con tabla P
        /// </summary>
        public virtual ICollection<PedimentoContenedor> PedimentoContenedor { get; set; }
        /// <summary>
        /// Relacion con tabla Factura
        /// </summary>
        public virtual ICollection<PedimentoFactura> PedimentoFactura { get; set; }
        /// <summary>
        /// Relacion con tabla Cuenta Aduanera
        /// </summary>
        public virtual ICollection<PedimentoCuentaAduanera> PedimentoCuentaAduanera { get; set; }
        /// <summary>
        /// Relacion con tabla Descargo
        /// </summary>
        public virtual ICollection<PedimentoDescargo> PedimentoDescargo { get; set; }
        /// <summary>
        /// Relacion con tabla Destinatario
        /// </summary>
        public virtual ICollection<PedimentoDestinatario> PedimentoDestinatario { get; set; }

        public virtual ICollection<PedimentoDiferenciaContribucion> PedimentoDiferenciaContribucion { get; set; }
        #endregion
    }
}
