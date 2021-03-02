using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CentroEscolar.AccesoADatos;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.LogicaDeNegocio
{
    public class SeccionBL
    {
        //Creación del objeto seccion
        SeccionDAL seccion = new SeccionDAL();

        //Uso del método Obtener
        public List<Seccion> Obtener()
        {
            return seccion.Obtener();
        }

        //Uso del método Agregar 
        public int Agregar (Seccion pSeccion)
        {
            return seccion.Agregar(pSeccion);
        }

        //Uso del método Modificar 
        public int Modificar (Seccion pSeccion)
        {
            return seccion.Modificar(pSeccion);
        }

        //Uso del método Eliminar 
        public int Eliminar (int pId)
        {
            return seccion.Eliminar(pId);
        }

        //Uso del método BuscarPorId
        public Seccion BuscarPorId(int pId)
        {
            return SeccionDAL.BuscarPorId(pId);
        }
    }
}
