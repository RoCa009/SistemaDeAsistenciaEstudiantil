using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public Usuario() { }

        public Usuario(int pId, string pNombre, string pCorreo, string pContraseña)
        {
            Id = pId;
            Nombre = pNombre;
            Correo = pCorreo;
            Contraseña = pContraseña;
        }
    }
}
