using App.Entities;
using App.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
     public  class ListaPedimentoBusiness
    {
        #region Instancias
        private ListaPedimentoRepository _listaPedimentoRepo;
        private PedimentosListaRepository _pedimentosListaRepo;
        #endregion
        #region Constructor
        public ListaPedimentoBusiness()
        {
            _listaPedimentoRepo = new ListaPedimentoRepository();
            _pedimentosListaRepo = new PedimentosListaRepository();

        }
        #endregion
        #region Metodos
        /// <summary>
        /// Agrega el listado de Pedimentos
        /// </summary>
        /// <param name="listaPedimento"></param>
        public void AgregarListaPedimento(ListaPedimento listaPedimento)
        {
            _listaPedimentoRepo.AgregarListaPedimento(listaPedimento);
        }
        /// <summary>
        /// Borrar el listado de Pedimentos
        /// </summary>
        /// <param name="id"></param>
        public void BorrarListaPedimento(int id)
        {
            PedimentosLista pedimentosLista = _pedimentosListaRepo.TraerporListaPedimentoId(id);
            _pedimentosListaRepo.BorrarPedimentoLista(pedimentosLista);

            ListaPedimento listaPedimento = _listaPedimentoRepo.TraerPorId(id);
            _listaPedimentoRepo.BorrarListaPedimento(listaPedimento);
        }
        /// <summary>
        /// Traer todos las Listas de Pedimentos
        /// </summary>
        /// <returns></returns>
        public List<ListaPedimento> TraerTodo()
        {
            return _listaPedimentoRepo.TraerTodo();
        }
        /// <summary>
        /// Traer una lista de Pedimento por su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ListaPedimento TraerListaPedimento(int id)
        {
            ListaPedimento listaPedimento = _listaPedimentoRepo.TraerPorId(id);
            return listaPedimento;
        }
        #endregion

    }
}
