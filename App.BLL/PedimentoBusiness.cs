using App.DAL;
using App.Entities;
using System.Collections.Generic;

namespace App.BLL
{
    /// <summary>
    /// Esta clase interactua con la capa de datos en el modulo pedimento
    /// </summary>
    public class PedimentoBusiness
    {
        #region Instancias
        /// <summary>
        /// Repositorio Pedimento que interactua con la capa de datos
        /// </summary>
        PedimentoRepository _pedimentoRepo;
        
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa la instancia pedimento en el repositorio
        /// </summary>
        public PedimentoBusiness()
        {
            _pedimentoRepo = new PedimentoRepository();
            
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Agrega pedimento a la BD
        /// </summary>
        /// <param name="pedimento">Datos de la tabla pedimento</param>
        public void AgregarPedimento(Pedimento pedimento)
        {
            if (PedimentoExistente(pedimento))
            {
                throw new PedimentoAlreadyExistException();
            }

            _pedimentoRepo.AgregarPedimento(pedimento);
        }
        /// <summary>
        /// Elimina un pedimento de la BD
        /// </summary>
        /// <param name="id">id de pedimento que se desea eliminar</param>
        public void BorrarPedimento(int id)
        {
            Pedimento pedimento = _pedimentoRepo.TraerPorId(id);

            if(PedimentoExistentePorId(pedimento))
            {
                

                _pedimentoRepo.BorrarPedimento(pedimento);
            }                 
        }
        /// <summary>
        /// Consulta pedimentos por su ID
        /// </summary>
        /// <param name="id">El Id del pedimento que se desea ver</param>
        /// <returns>Regresa un pedimento</returns>
        public Pedimento TraerPorId(int id)
        {
            Pedimento pedimento = _pedimentoRepo.TraerPorId(id);
            return pedimento;
        }

        /// <summary>
        /// Consulta todos los pedimentos registrados en la BD
        /// </summary>
        /// <returns>Regresa todos los pedimentos</returns>
        public List<Pedimento> TraerTodo()
        {
            return _pedimentoRepo.TraerTodo();
        }
        /// <summary>
        /// Verifica si ese pedimento ya existe por medio de su numero de pedimento
        /// </summary>
        /// <param name="pedimento">Objeto que trae datos de un pedimento</param>
        /// <returns>regresa una respuesta de si existe o no</returns>
        private bool PedimentoExistente(Pedimento pedimento)
        {
            var pedimentoBLA = _pedimentoRepo.TraerPedimentoPorNumero(pedimento.NumPedimento);
            return pedimentoBLA != null;
        }
        /// <summary>
        /// Verifica si ese pedimento ya existe por medio de su ID
        /// </summary>
        /// <param name="pedimento">Objeto que trae datos de un pedimento</param>
        /// <returns>regresa una respuesta de si existe o no</returns>
        private bool PedimentoExistentePorId(Pedimento pedimento)
        {
            var pedimentoBLA = _pedimentoRepo.TraerPorId(pedimento.Id);
            return pedimentoBLA != null;
        }


        public decimal TraerTotalImportacion()
        {
            return _pedimentoRepo.TraerTotalImportacion();
        }

        public decimal TraerTotalExportacion()
        {
            return _pedimentoRepo.TraerTotalExportacion();
        }
        #endregion
    }
}
