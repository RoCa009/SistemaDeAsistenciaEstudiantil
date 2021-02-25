using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    public class Grado
    {
        public int Id { get; set; }

        public string GradoAsignado { get; set; }

        public int IdProfesor { get; set; }

        public int IdSeccion { get; set; }

        public int IdHorario { get; set; }

        public int IdAula { get; set; }

        public Grado() { }

        public Grado(int pId, string pGradoAsignado, int pIdProfesor, int pIdSeccion, int pIdHorario, int pIdAula)
        {
            Id = pId;
            GradoAsignado = pGradoAsignado;
            IdProfesor = pIdProfesor;
            IdSeccion = pIdSeccion;
            IdHorario = pIdHorario;
            IdAula = pIdAula;
        }
    }
}
