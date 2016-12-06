namespace App.MarzMember
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EmpresaAduana
    {
        public int Id { get; set; }

        public int IdEmpresa { get; set; }

        public int IdAduana { get; set; }

        [StringLength(3)]
        public string Clave { get; set; }

        public string Descripcion { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
