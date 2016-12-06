using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.MarzMember;

namespace App.Common
{
    public class Usuario
    {   
        public Usuario()
        { }
        static public string IdAd;
        static public Empresa Empresa;
        static public Account Cuenta;

        public void darEmpresa(Empresa e)
        {
            Empresa = e;
        }

        public Empresa obtenerEmpresa()
        {
            return Empresa;
        }

          public void darCuenta(Account a)
        {
            Cuenta = a;
        }

        public Account obtenerCuenta()
        {
            return Cuenta;
        }

       
    }
}
