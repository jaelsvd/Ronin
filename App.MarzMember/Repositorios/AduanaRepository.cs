using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.MarzMember.Repositorios
{
    public class AduanaRepository
    {
        private EmpresaAduana _empresaAduanaEntity;
        private MarzMemberContext _context;
        public AduanaRepository()
        {
            _empresaAduanaEntity = new EmpresaAduana();
            _context = new MarzMemberContext();
        }

    }   
}
