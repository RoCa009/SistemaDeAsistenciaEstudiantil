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
        public string DUI { get; set; }
        public int IdSeccion { get; set; }
        public int IdHorario { get; set; }
        public int IdAula { get; set; }
    }
}
