using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    public class TomaDeAsistencia
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int IdProfesor { get; set; }

        public int IdAlumno { get; set; }

        public int IdGrado { get; set; }

        public int IdSeccion { get; set; }

        public string Asistencia { get; set; }

        public string LlegoTarde { get; set; }

        public string JustificacionLlegadaTarde { get; set; }


        public TomaDeAsistencia() { }

        public TomaDeAsistencia(int pId, DateTime pFecha, int pIdProfesor, int pIdAlumno, int pIdGrado, int pIdSeccion, 
            string pAsistencia, string pLlegoTarde, string pJustificacionLlegadaTarde)
        {
            Id = pId;
            Fecha = pFecha;
            IdProfesor = pIdProfesor;
            IdAlumno = pIdAlumno;
            IdGrado = pIdGrado;
            IdSeccion = pIdSeccion;
            Asistencia = pAsistencia;
            LlegoTarde = pLlegoTarde;
            JustificacionLlegadaTarde = pJustificacionLlegadaTarde;
        }
    }
}
