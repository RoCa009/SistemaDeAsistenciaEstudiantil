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
        TomaDeAsistenciaDAL tomadeasistencia = new TomaDeAsistenciaDAL();

        public List<TomaDeAsistencia> Obtener()
        {
            return tomadeasistencia.Obtener();
        }

        public int Agregar(TomaDeAsistencia pTomaDeAsistencia)
        {
            return tomadeasistencia.Agregar(pTomaDeAsistencia);
        }

        public int Modificar(TomaDeAsistencia pTomaDeAsistencia)
        {
            return tomadeasistencia.Modificar(pTomaDeAsistencia);
        }

        public int Eliminar(int pId)
        {
            return tomadeasistencia.Eliminar(pId);
        }
    }
}
