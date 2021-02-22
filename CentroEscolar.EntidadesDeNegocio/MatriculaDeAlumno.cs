using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    public class MatriculaDeAlumno
    {
        public int Id { get; set; }

        public string DUI { get; set; }

        public string NombreEncargado { get; set; }

        public string NombresAlumno { get; set; }

        public string ApellidosAlumno { get; set; }

        public int Edad { get; set; }

        public string Sexo { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public int IdProfesor { get; set; }

        public int IdGrado { get; set; }

        public int IdSeccion { get; set; }

        public int IdHorario { get; set; }

        public int IdAula { get; set; }

        public MatriculaDeAlumno() { }

        public MatriculaDeAlumno(int pId, string pDUI, string pNombreEncargado, string pNombresAlumno, string pApellidosAlumno,
            int pEdad, string pSexo, string pDireccion, string pTelefono, string pCorreo,
            int pIdProfesor, int pIdGrado, int pIdSeccion, int pIdHorario, int pIdAula)
        {
            Id = pId;
            DUI = pDUI;
            NombreEncargado = pNombreEncargado;
            NombresAlumno = pNombresAlumno;
            ApellidosAlumno = pApellidosAlumno;
            Edad = pEdad;
            Sexo = pSexo;
            Direccion = pDireccion;
            Telefono = pTelefono;
            Correo = pCorreo;
            IdProfesor = pIdProfesor;
            IdGrado = pIdGrado;
            IdSeccion = pIdSeccion;
            IdHorario = pIdHorario;
            IdAula = pIdAula;
        }
    }
}
