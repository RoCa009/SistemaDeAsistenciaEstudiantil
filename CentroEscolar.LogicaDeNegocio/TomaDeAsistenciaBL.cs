using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CentroEscolar.AccesoADatos;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.LogicaDeNegocio
{
    public class TomaDeAsistenciaBL
    {
        // Objeto
        TomaDeAsistenciaDAL tomadeasistencia = new TomaDeAsistenciaDAL();
        // Obtener
        public List<TomaDeAsistencia> Obtener()
        {
            return tomadeasistencia.Obtener();
        }
        // Agregar
        public int Agregar(TomaDeAsistencia pTomaDeAsistencia)
        {
            return tomadeasistencia.Agregar(pTomaDeAsistencia);
        }
        // Modificar
        public int Modificar(TomaDeAsistencia pTomaDeAsistencia)
        {
            return tomadeasistencia.Modificar(pTomaDeAsistencia);
        }
        // Eliminar
        public int Eliminar(int pId)
        {
            return tomadeasistencia.Eliminar(pId);
        }
        // BuscarPorId
        public TomaDeAsistencia BuscarPorId(int pId)
        {
            return TomaDeAsistenciaDAL.BuscarPorId(pId);
        }
    }
}
