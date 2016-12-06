namespace App.MarzMember
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MarzMemberContext : DbContext
    {
        public MarzMemberContext() : base("MarzMemberConnName")
        {
        }

        public virtual DbSet<AccountEmpresa> AccountEmpresas { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Connection> Connections { get; set; }
        public virtual DbSet<EmpresaAduana> EmpresaAduanas { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.AccountEmpresas)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.IdAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Connection>()
                .Property(e => e.Server)
                .IsUnicode(false);

            modelBuilder.Entity<Connection>()
                .Property(e => e.Database)
                .IsUnicode(false);

            modelBuilder.Entity<Connection>()
                .HasMany(e => e.Empresas)
                .WithRequired(e => e.Connection)
                .HasForeignKey(e => e.IdConexion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmpresaAduana>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.RFC)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.RazonSocial)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.NumeroIMMEX)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.NumeroExt)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.NumeroInt)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.CodigoPostal)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Colonia)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Entidad)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Fax)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.ActividadPreponderante)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.RepresentanteLegal)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.RFCRepresentanteLegal)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.UrlLogo)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Container)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Giro)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.ProductoExporta)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.ContrasenaSAT)
                .IsUnicode(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.AccountEmpresas)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.IdEmpresa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empresa>()
                .HasMany(e => e.EmpresaAduanas)
                .WithRequired(e => e.Empresa)
                .HasForeignKey(e => e.IdEmpresa)
                .WillCascadeOnDelete(false);
        }
    }
}
