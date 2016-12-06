using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MarzMember.Repositorios
{
    class EmpresaRepository
    {
        private MarzMemberContext _context;

        public EmpresaRepository()
        {
            _context = new MarzMemberContext();
        }

    }
}
