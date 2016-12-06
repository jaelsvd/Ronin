using App.Entities;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace App.DAL
{
    public class PedimentoRepository : Conexion
    {
        #region Instancias
        
        #endregion

        #region Constructor
        public PedimentoRepository()
        {
            
        }
        #endregion

        #region Metodos
        public void AgregarPedimento(Pedimento pedimento)
        {
            try
            {
                _context.Pedimentos.Add(pedimento);
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
        public void BorrarPedimento(Pedimento pedimento)
        {
            _context.Pedimentos.Remove(pedimento);
            _context.SaveChanges();
        }
        public Pedimento TraerPedimentoPorNumero(string numPedimento)
        {
            return _context.Pedimentos.FirstOrDefault(x => x.NumPedimento == numPedimento);
        }
        public List<Pedimento> TraerTodo()
        {
            return _context.Pedimentos.OrderBy(x => x.FechaCreacion).ToList();
        }

        public Pedimento TraerPorId(int pedimentoId)
        {
            return _context.Pedimentos.FirstOrDefault(x => x.Id == pedimentoId);
        }

        public void ActualizarError(int pedimentoId, bool tieneError, string errorDesc)
        {

            var pedimento = _context.Pedimentos.Find(pedimentoId);
            pedimento.TieneError = true;
            pedimento.ErrorDesc = errorDesc;
            _context.SaveChanges();

        }

        public decimal TraerTotalImportacion()
        {
            return _context.Pedimentos.Where(x => x.EncabezadoOpClave == 1).Select(x => x.ValorComercialTotal).Sum();
        }

        public decimal TraerTotalExportacion()
        {
            return _context.Pedimentos.Where( x=> x.EncabezadoOpClave == 2).Select(x => x.ValorComercialTotal).Sum();
        }
       
        #endregion
    }
}
