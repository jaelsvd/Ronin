namespace App.MarzMember
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            AccountEmpresas = new HashSet<AccountEmpresa>();
        }

        public int Id { get; set; }

        [Required]
        public string UserIdAD { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdRole { get; set; }

        public int IdLanguage { get; set; }

        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        public int ActualCompany { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountEmpresa> AccountEmpresas { get; set; }
    }
}
