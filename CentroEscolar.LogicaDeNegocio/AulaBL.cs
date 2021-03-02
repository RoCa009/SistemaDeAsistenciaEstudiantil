using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CentroEscolar.AccesoADatos;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.LogicaDeNegocio
{
    public class AulaBL
    {
        //Creación del objeto Aula
        AulaDAL aula = new AulaDAL();

        //Uso del método Obtener
        public List<Aula> Obtener()
        {
            return aula.Obtener();
        }

        //Uso del método Agregar
        public int Agregar (Aula pAula)
        {
            return aula.Agregar(pAula);
        }

        //Uso del método Modificar
        public int Modificar (Aula pAula)
        {
            return aula.Modificar(pAula);
        }

        //Uso del método Eliminar
        public int Eliminar (int pId)
        {
            return aula.Eliminar(pId);
        }

        //Uso de Buscar por ID
        public Aula BuscarPorId(int pId)
        {
            return AulaDAL.BuscarPorId(pId);
        }
    }
}
