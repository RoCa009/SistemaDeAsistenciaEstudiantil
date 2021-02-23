using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    public class Administrador
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contrasena { get; set; }

        public Administrador() { }

        public Administrador(int pId, string pNombre, string pCorreo, string pContrasena)
        {
            Id = pId;
            Nombre = pNombre;
            Correo = pCorreo;
            Contrasena = pContrasena;
        }
    }
}
