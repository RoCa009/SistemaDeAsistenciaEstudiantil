using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    class Horario
    {
        public int Id { get; set; }

        public string HorarioDeClase { get; set; }

        public DateTime HoraEntrada { get; set; }

        public DateTime HoraSalida { get; set; }

    }
}
