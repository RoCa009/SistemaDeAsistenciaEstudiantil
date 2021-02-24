using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    public class Seccion
    {
        public int Id { get; set; }

        public int SeccionAsignada { get; set; }

        public Seccion() { }

        public Seccion(int pId, int pSeccionAsignada)
        {
            Id = pId;
            SeccionAsignada = pSeccionAsignada;
        }
    }
}
