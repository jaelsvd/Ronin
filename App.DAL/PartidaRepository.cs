using App.Entities;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace App.DAL
{
    public class PartidaRepository : Conexion
    {
        #region Instancias
        
        #endregion

        #region Constructor
        public PartidaRepository()
        {
           
        }
        #endregion

        #region Métodos Públicos
        public void AgregarPartida(Partida partida)
        {
            try
            {
                _context.Partidas.Add(partida);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }

            }
           
        }

        public void BorrarPartida(Partida partida)
        {
            _context.Partidas.Remove(partida);
            _context.SaveChanges();
        }
        public Partida TraerPartidaPorNumero(int numPartida)
        {
            return _context.Partidas.FirstOrDefault(x => x.NumeroPartida == numPartida);
        }

        public List<Partida> TraerTodo()
        {
           return _context.Partidas.OrderBy(x => x.FechaCreacion).ToList();
        }

        public Partida TraerPorId(int partidaId)
        {
            return _context.Partidas.FirstOrDefault(x => x.Id == partidaId);
        }
        public List<Partida> TraerPorPedimentoId(int id)
        {
            return _context.Partidas.Where(x => x.PedimentoId == id).OrderBy(x => x.NumeroPartida).ToList();
        }

        public Partida TraerPorPedimentoIdNumeroPartida(int pedimentoId, int numeroPartida)
        {
            return _context.Partidas.Where(x => x.PedimentoId == pedimentoId).FirstOrDefault( x => x.NumeroPartida == numeroPartida);
        }

        public List<int> TraerPorNumero(int pedimentoId)
        {
            return _context.Partidas.Where(x => x.PedimentoId == pedimentoId).Select(x =>   x.NumeroPartida ).ToList();
        }

        public List<PartidaGravamen> TraerGravamenClave(int partidaId)
        {
            return _context.PartidaGravamenes.Where(x => x.PartidaId == partidaId).ToList();
            
        }
        
        public PartidaImporte TraerImporte(int gravamenId)
        {
            return _context.PartidaImportes.Where(x => x.PartidaGravamenId == gravamenId).FirstOrDefault();
        }
         
        #endregion
    }
}
