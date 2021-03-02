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
        // Objeto
        AulaBL aula = new AulaBL();
        // Obtener
        public List<Aula> Obtener()
        {
            return aula.Obtener();
        }
        // Agregar
        public int Agregar (Aula pAula)
        {
            return aula.Agregar(pAula);
        }
        // Modificar
        public int Modificar (Aula pAula)
        {
            return aula.Modificar(pAula);
        }
        // Eliminar
        public int Eliminar (Aula pAula)
        {
            return aula.Eliminar(pAula);
        }
        // ObtenerPorId
        public Aula Ingresar(Aula pAula)
        {
            return aula.Ingresar(pAula);
        }
    }
}
