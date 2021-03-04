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
        AulaDAL aula = new AulaDAL();
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
        public int Eliminar (int pId)
        {
            return aula.Eliminar(pId);
        }
        // BuscarPorId
        public Aula BuscarPorId(int pId)
        {
            return AulaDAL.BuscarPorId(pId);
        }
    }
}
