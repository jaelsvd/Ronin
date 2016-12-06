using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entities
{
    [Table("DsPedimentoProveedorComprador")]
    public class PedimentoProveedorComprador
    {
        /// <summary>
        /// Id de la entidad
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Id Fiscal
        /// </summary>
        [DisplayName("Id Fiscal")]
        public string ProvCompIdFiscalProvComprador { get; set; }
        /// <summary>
        /// Proveedor/Comprador
        /// </summary>
        [DisplayName("Proveedor/Comprador")]
        public string ProvCompProveedorComprador { get; set; }
        /// <summary>
        /// Valor Moneda Externa
        /// </summary>
        [DisplayName("Valor Moneda Externa")]
        public decimal ProvCompValorMonedaExt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Valor Doláres")]
        public decimal ProvCompValorDolares { get; set; }

        #region Domicilio
        /// <summary>
        /// Nombre de la Calle del provedor
        /// </summary>
        [DisplayName("Calle")]
        public string ProvCompDomCalle { get; set; }
        /// <summary>
        /// Numero Exterior
        /// </summary>
        [DisplayName("Número Exterior")]
        public string ProvCompDomNumExterior { get; set; }
        /// <summary>
        /// Numero interior
        /// </summary>
        [DisplayName("Número Interior")]
        public string ProvCompDomNumInterior { get; set; }
        /// <summary>
        /// Ciudad, Municipio
        /// </summary>
        [DisplayName("Ciudad Municipio")]
        public string ProvCompDomCdMunicipio { get; set; }
        /// <summary>
        /// Codigo Postal
        /// </summary>
        [DisplayName("CP")]
        public string ProvCompDomCP { get; set; }
        /// <summary>
        /// Domicilio Pais
        /// </summary>
        public string ProvCompDomPais { get; set; }
        #endregion
        #region Pais
        /// <summary>
        /// Clave
        /// </summary>
        [DisplayName("Clave")]
        public string ProvCompPaisClave { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        [DisplayName("Descripción")]
        public string ProvCompPaisDesc { get; set; }
        #endregion

        #region Moneda

        /// <summary>
        /// Moneda Clave
        /// </summary>
        [DisplayName("Clave")]
        public string ProvCompMonedaClave { get; set; }
        /// <summary>
        /// Moneda Descripcion
        /// </summary>
        [DisplayName("Descripción")]
        public string ProvCompMonedaDesc { get; set; }

        #endregion

        #region Relaciones
        /// <summary>
        /// Llave foranea de Pedimento
        /// </summary>
        public int PedimentoId { get; set; }
        public virtual Pedimento Pedimento { get; set; }
        #endregion
    }
}
