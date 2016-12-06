using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;


namespace App.DAL
{
    public class PedimentosListaRepository : Conexion
    {
        #region Instancias
        
        #endregion

        #region Constructor
        public PedimentosListaRepository()
        {
            
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Inserta el Pedimento del Listado
        /// </summary>
        /// <param name="pedimentosLista"></param>
        public void AgregarPedimentoLista(PedimentosLista pedimentosLista)
        {
            _context.PedimentosLista.Add(pedimentosLista);
            _context.SaveChanges();
        }
        /// <summary>
        /// Elimina el Pedimento del listado
        /// </summary>
        /// <param name="listaPedimento"></param>
        public void BorrarPedimentoLista(PedimentosLista pedimentosLista)
        {
            _context.PedimentosLista.Remove(pedimentosLista);
            _context.SaveChanges();

        }

        /// <summary>
        /// Trae todos los Pedimentos de la Lista
        /// </summary>
        /// <returns></returns>
        public List<PedimentosLista> TraerTodo()
        {

            return _context.PedimentosLista.OrderBy(x => x.FechaCreacion).ToList();

        }

        /// <summary>
        /// Trae  el pedimento del listado por id
        /// </summary>
        /// <param name="listaPedimentoId"></param>
        /// <returns></returns>
        public PedimentosLista TraerPorId(int pedimentoListaId)
        {
            return _context.PedimentosLista.FirstOrDefault(x => x.Id == pedimentoListaId);
        }

          public PedimentosLista TraerporListaPedimentoId(int listaPedimentoId)
        {
            return _context.PedimentosLista.FirstOrDefault(x => x.ListaPedimentoId == listaPedimentoId);
        }
        #endregion


    }
}
