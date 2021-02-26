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
        AulaBL aula = new AulaBL();

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
        public int Eliminar (Aula pAula)
        {
            return aula.Eliminar(pAula);
        }
    }
}
