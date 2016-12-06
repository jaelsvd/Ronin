using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using App.MarzMember.Logica;
using System.Security.Claims;

namespace App.DAL
{
    public class Conexion
    {
        public static RoninDBContext _context;
        
        public Conexion()
        {
            _context = new RoninDBContext();
            _context.Database.Connection.ConnectionString = NombreConexion;
           
        }

        public static string NombreConexion { get; set; }

        public void darNombre(string nombre)
        {
            NombreConexion = nombre;
            _context.Database.Connection.ConnectionString = NombreConexion;
        }

        public string obtenerNombre()
        {

            return NombreConexion;
        }
     
    }
}
