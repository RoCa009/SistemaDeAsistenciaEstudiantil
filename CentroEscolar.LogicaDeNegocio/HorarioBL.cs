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
        // Objeto
        HorarioDAL horario = new HorarioDAL();
        // Obtener
        public List<Horario> Obtener()
        {
            return horario.Obtener();
        }
        // Agregar
        public int Agregar(Horario pHorario)
        {
            return horario.Agregar(pHorario);
        }
        // Modificar
        public int Modificar(Horario pHorario)
        {
            return horario.Modificar(pHorario);
        }
        // Eliminar
        public int Eliminar(int pId)
        {
            return horario.Eliminar(pId);
        }
        // BuscarPorId
        public Horario BuscarPorId(int pId)
        {
            return HorarioDAL.BuscarPorId(pId);
        }

    }
}
