using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEscolar.EntidadesDeNegocio
{
    public class Horario
    {
        public int Id { get; set; }

        public string HorarioDeClase { get; set; }

        public string HoraEntrada { get; set; }

        public string HoraSalida { get; set; }

        public Horario() { }

        public Horario(int pId, string pHorarioDeClase, string pHoraEntrada, string pHoraSalida)
        {
            Id = pId;
            HorarioDeClase = pHorarioDeClase;
            HoraEntrada = pHoraEntrada;
            HoraSalida = pHoraSalida;
        }

    }
}
