using App.DAL;
using App.Entities;
using System.Collections.Generic;

namespace App.BLL
{
     public class PartidaBusiness
    {
        #region Instancias 
        PartidaRepository _partidaRepo;
        #endregion

        #region Constructor
        public PartidaBusiness()
        {
            _partidaRepo = new PartidaRepository();
        }
        #endregion

        #region Métodos Públicos
        public void AgregarPartida(Partida partida)
        {
            if(PartidaExistente(partida))
            {
                throw new PartidaAlreadyExistException();
            }

            _partidaRepo.AgregarPartida(partida);
        }
        public void BorrarPartida(int id)
        {
            Partida partida = _partidaRepo.TraerPorId(id);
            if(PartidaExistentePorId(partida))
            {
                _partidaRepo.BorrarPartida(partida);
            }
        }
        public Partida TraerPorId(int id)
        {
            Partida partida = _partidaRepo.TraerPorId(id);
            return partida;
        }
        public List<Partida> TraerPorPedimentoId(int id)
        {
            var partida = _partidaRepo.TraerPorPedimentoId(id);
            return partida;
        }
        private bool PartidaExistente(Partida partida)
        {
            var partidaBLA = _partidaRepo.TraerPartidaPorNumero(partida.NumeroPartida);
            return partidaBLA != null;
        }
        public List<Partida> TraerTodo()
        {
            return _partidaRepo.TraerTodo();
        }
        private bool PartidaExistentePorId(Partida partida)
        {
            var partidaBLA = _partidaRepo.TraerPorId(partida.Id);
            return partidaBLA != null;
        }
        public Partida TraerPorPedimentoIdNumeroPartida(int pedimentoId, int numeroPartida)
        {
            return _partidaRepo.TraerPorPedimentoIdNumeroPartida(pedimentoId, numeroPartida);
        }


        #endregion
    }
}
