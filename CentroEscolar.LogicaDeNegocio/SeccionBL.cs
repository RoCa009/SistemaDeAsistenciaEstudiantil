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
        SeccionBL seccion = new SeccionBL();

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
        public int Eliminar (Seccion pSeccion)
        {
            return seccion.Eliminar(pSeccion);
        }
    }
}
