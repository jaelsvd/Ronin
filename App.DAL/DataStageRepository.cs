using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;

namespace App.DAL
{
    public class DataStageRepository : Conexion
    {
        #region Instancias
       
        #endregion

        #region Constructor
        public DataStageRepository()
        {
           
        }
        #endregion


        #region Métodos Públicos
        public void AgregarDataStage(DataStage dataStage)
        {
            _context.DataStage.Add(dataStage);
            _context.SaveChanges();
        }
        public void BorrarDataStage(DataStage dataStage)
        {
            _context.DataStage.Remove(dataStage);
            _context.SaveChanges();
        }
        public List<DataStage> TraerTodo()
        {
            return _context.DataStage.OrderBy(x => x.FechaCreacion).ToList();
        }
        public DataStage TraerPorId(int id)
        {
            return _context.DataStage.FirstOrDefault(x => x.Id == id);
        }


        public List<PedimentoImpExpFechas> TraerPedimentosPorFecha(DateTime fechaInico, DateTime fechaFin)
        {

            var p= _context.PedimentoImpExpFechas.Where(x => x.ImpExpFechasFechaEntradaTipoClave == 2 && x.ImpExpFechasFecha >= fechaInico && x.ImpExpFechasFecha <= fechaFin).ToList();
            return p;

        }
        #endregion
    }
}
