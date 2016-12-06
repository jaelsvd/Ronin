using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;
using App.DAL;

namespace App.BLL
{
    public class PedimentoListaBusiness
    {
       
        private PedimentosListaRepository _pedimentosListaRepo;


        public PedimentoListaBusiness()
        {
            
            _pedimentosListaRepo = new PedimentosListaRepository();

        }


        public List<PedimentosLista> TraerTodo()
        {
            return _pedimentosListaRepo.TraerTodo();
        }
    }
}
