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
        // Objeto
        SeccionBL seccion = new SeccionBL();
        // Obtener
        public List<Seccion> Obtener()
        {
            return seccion.Obtener();
        }
        // Agregar 
        public int Agregar (Seccion pSeccion)
        {
            return seccion.Agregar(pSeccion);
        }
        // Modificar 
        public int Modificar (Seccion pSeccion)
        {
            return seccion.Modificar(pSeccion);
        }
        // Eliminar 
        public int Eliminar (Seccion pSeccion)
        {
            return seccion.Eliminar(pSeccion);
        }
        // BuscarPorId
        public Seccion BuscarPorId(int pId)
        {
            return SeccionDAL.BuscarPorId(pId);
        }
    }
}
