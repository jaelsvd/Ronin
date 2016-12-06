namespace App.MarzMember
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            AccountEmpresas = new HashSet<AccountEmpresa>();
            EmpresaAduanas = new HashSet<EmpresaAduana>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(13)]
        public string RFC { get; set; }

        [Required]
        [StringLength(255)]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(30)]
        public string NumeroIMMEX { get; set; }

        [Required]
        [StringLength(100)]
        public string Calle { get; set; }

        [StringLength(10)]
        public string NumeroExt { get; set; }

        [StringLength(10)]
        public string NumeroInt { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoPostal { get; set; }

        [Required]
        [StringLength(50)]
        public string Colonia { get; set; }

        [Required]
        [StringLength(50)]
        public string Entidad { get; set; }

        [Required]
        [StringLength(13)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Fax { get; set; }

        [Required]
        [StringLength(255)]
        public string ActividadPreponderante { get; set; }

        [Required]
        [StringLength(255)]
        public string RepresentanteLegal { get; set; }

        [Required]
        [StringLength(13)]
        public string RFCRepresentanteLegal { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public int IdConexion { get; set; }

        public int? IdSuscription { get; set; }

        [StringLength(100)]
        public string UrlLogo { get; set; }

        [StringLength(100)]
        public string Container { get; set; }

        [StringLength(100)]
        public string Sector { get; set; }

        public bool OEA { get; set; }

        public bool CTPAT { get; set; }

        public bool IVAIEPS { get; set; }

        [StringLength(100)]
        public string Giro { get; set; }

        [StringLength(100)]
        public string ProductoExporta { get; set; }

        [StringLength(65)]
        public string ContrasenaSAT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountEmpresa> AccountEmpresas { get; set; }

        public virtual Connection Connection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EmpresaAduana> EmpresaAduanas { get; set; }
    }
}
