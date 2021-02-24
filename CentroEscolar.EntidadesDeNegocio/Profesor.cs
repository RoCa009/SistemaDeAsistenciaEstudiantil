using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    public class Profesor
    {
        public int Id { get; set; }

        public string DUI{ get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public int Edad { get; set; }

        public string Sexo { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public Profesor() { }

        public Profesor(int pId, string pDUI, string pNombres, string pApellidos, int pEdad, 
            string pSexo, string pDireccion, string pTelefono, string pCorreo)
        {
            Id = pId;
            DUI = pDUI;
            Nombres = pNombres;
            Apellidos = pApellidos;
            Edad = pEdad;
            Sexo = pSexo;
            Direccion = pDireccion;
            Telefono = pTelefono;
            Correo = pCorreo;
        }
    }
}
