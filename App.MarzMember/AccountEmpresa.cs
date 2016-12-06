namespace App.MarzMember
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountEmpresa")]
    public partial class AccountEmpresa
    {
        public int Id { get; set; }

        public int IdAccount { get; set; }

        public int IdEmpresa { get; set; }

        public bool StatusEmpresa { get; set; }

        public virtual Account Account { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
