using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.MarzMember.Repositorios
{
    public class AccountRepository
    {
        private MarzMemberContext _context;
        public AccountRepository()
        {
            _context = new MarzMemberContext();
        }

        public Account TraerPorIdAd(string userIdAd)
        {
            return _context.Accounts.Where(x => x.UserIdAD == userIdAd).FirstOrDefault();
        }
    }
}
