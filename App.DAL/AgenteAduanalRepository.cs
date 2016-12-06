using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;
namespace App.DAL
{
    public class AgenteAduanalRepository : Conexion
    {
        private AgentesAduanales _agenteEntity;
        public AgenteAduanalRepository()
        {
            _agenteEntity = new AgentesAduanales();
        }

        public List<int> TraerPatentes()
        {
            var patenteString = _context.AgenteAduanal.Select(x => x.Patente).ToList();

            List<int> patentes = new List<int>();
            
            foreach(var p in patenteString)
            {
                patentes.Add(Convert.ToInt32(p));
            }


            return patentes;
             
        } 
    }
}
