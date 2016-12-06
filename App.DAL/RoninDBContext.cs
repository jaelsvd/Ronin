using App.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;

namespace App.DAL
{
    /// <summary>
    /// Esta clase define la Base de Datos
    /// </summary>
    public partial class RoninDBContext: DbContext
    {

        Conexion _conexion;
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //_conexion = new Conexion();
            //this.Database.Connection.ConnectionString = _conexion.obtenerNombre();
        }

        public RoninDBContext() : base("RoninDbConnName")
        {

          

        }

   

        /// <summary>
        /// Se define la tabla Pedimentos en la BD
        /// </summary>
        public DbSet<Pedimento> Pedimentos { get; set; }
        /// <summary>
        /// Se define la tabla PedimentoTasas en la BD
        /// </summary>
        public DbSet<PedimentoTasa> PedimentoTasas { get; set; }
        /// <summary>
        /// Se define la tabla PedimentoIdentificadores en la BD
        /// </summary>
        public DbSet<PedimentoIdentificador> PedimentoIdentificadores { get; set; }
        /// <summary>
        /// Se define la tabla PedimentoImpExpFechas en la BD
        /// </summary>
        public DbSet<PedimentoImpExpFechas> PedimentoImpExpFechas { get; set; }
        /// <summary>
        /// Se define la tabla Partidas en la BD
        /// </summary>
        public DbSet<Partida> Partidas { get; set; }
        /// <summary>
        /// Se define la tabla PartidaIdentificadores en la BD
        /// </summary>
        public DbSet<PartidaIdentificador> PartidaIdentificadores { get; set; }
        /// <summary>
        /// Se define la tabla PartidaTasas en la BD
        /// </summary>
        public DbSet<PartidaTasa> PartidaTasas { get; set; }
        /// <summary>
        /// Se defina la tabla PartidaGravamenes en la BD
        /// </summary>
        public DbSet<PartidaGravamen> PartidaGravamenes { get; set; }
        /// <summary>
        /// Se define la tabla PartidaImportes en la BD
        /// </summary>
        public DbSet<PartidaImporte> PartidaImportes { get; set; }
        /// <summary>
        /// Se define la tabla PartidaDatosVehiculo en la BD
        /// </summary>
        public DbSet<PartidaDatosVehiculo> PartidaDatosVehiculo { get; set; }
        /// <summary>
        /// Se defina la tabala ListaPedimentos en la BD
        /// </summary>
        public DbSet<ListaPedimento> ListaPedimentos { get; set; }
        /// <summary>
        /// Se define la tabla PedimentosLista en la BD
        /// </summary>
        public DbSet<PedimentosLista> PedimentosLista { get; set; }
        /// <summary>
        /// Se define la tabla DataStage en la BD
        /// </summary>
        public DbSet<DataStage> DataStage { get; set; }
        public DbSet<PedimentoTransporte> PedimentoTransporte { get; set; }
        public DbSet<PedimentoGuia> PedimentoGuia { get; set; }
        public DbSet<PedimentoDiferenciaContribucion> PedimentoDiferenciaContribucion { get; set; }
        public DbSet<PedimentoContenedor> PedimentoContenedor { get; set; }
        public DbSet<PedimentoFactura> PedimentoFactura { get; set; }
        public DbSet<PedimentoCuentaAduanera> PedimentoCuentaAduanera { get; set; }
        public DbSet<PedimentoDescargo> PedimentoDescargo { get; set; }
        public DbSet<PedimentoDestinatario> PedimentoDestinatario { get; set; }
        public DbSet<PartidaPermiso> PartidaPermiso { get; set; }
        public DbSet<PartidaCuentaAduanera> PartidaCuentaAduanera { get; set; }
        public DbSet<AgentesAduanales> AgenteAduanal { get; set; }   
        public DbSet<PartidaMetodoValoracion> PartidaMetodoValoracion { get; set; }
        public DbSet<PartidaVinculacion> PartidaVinculacion { get; set; }

    }
}
