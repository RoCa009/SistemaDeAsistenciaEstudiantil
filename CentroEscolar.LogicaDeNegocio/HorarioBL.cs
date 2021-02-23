using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CentroEscolar.AccesoADatos;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.LogicaDeNegocio
{
    public class HorarioBL
    {
        HorarioDAL horario = new HorarioDAL();

        public List<Horario> Obtener()
        {
            return horario.Obtener();
        }

        public int Agregar(Horario pHorario)
        {
            return horario.Agregar(pHorario);
        }

        public int Modificar(Horario pHorario)
        {
            return horario.Modificar(pHorario);
        }

        public int Eliminar(int pId)
        {
            return horario.Eliminar(pId);
        }


    }
}
