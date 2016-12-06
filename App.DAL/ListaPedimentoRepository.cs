using App.Entities;
using System.Collections.Generic;
using System.Linq;


namespace App.DAL
{
    public class ListaPedimentoRepository : Conexion
    {
        #region Instancias
        
        #endregion

        #region Constructor
        public ListaPedimentoRepository()
        {
            
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inserta el Listado de Pedimentos
        /// </summary>
        /// <param name="listaPedimento"></param>
        public void AgregarListaPedimento(ListaPedimento listaPedimento)
        {
            _context.ListaPedimentos.Add(listaPedimento);
            _context.SaveChanges();
        }
        /// <summary>
        /// Elimina el Listado de Pedimentos
        /// </summary>
        /// <param name="listaPedimento"></param>
        public void BorrarListaPedimento(ListaPedimento listaPedimento)
        {
            _context.ListaPedimentos.Remove(listaPedimento);
            _context.SaveChanges();

        }

        /// <summary>
        /// Trae todos los listados de pedimentos
        /// </summary>
        /// <returns></returns>
        public List<ListaPedimento> TraerTodo()
        {
            return _context.ListaPedimentos.OrderBy(x => x.FechaCreacion).ToList();

        }

        /// <summary>
        /// Trae el listado del pedimento por id
        /// </summary>
        /// <param name="listaPedimentoId"></param>
        /// <returns></returns>
        public ListaPedimento TraerPorId(int listaPedimentoId)
        {
            return _context.ListaPedimentos.FirstOrDefault(x => x.Id == listaPedimentoId);
        }


        public void ActualizarError(int listaPedimentoId , bool tieneError, string errorDesc)
        {

            var listaPedimento = _context.ListaPedimentos.Find(listaPedimentoId);
            listaPedimento.TieneError = true;
            listaPedimento.ErrorDesc = errorDesc;
            _context.SaveChanges();

        }




        #endregion

    }
}
