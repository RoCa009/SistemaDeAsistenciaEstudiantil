using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CentroEscolar.AccesoADatos;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.LogicaDeNegocio
{
    public class GradoBL
    {
        //Creación del objeto grado
        GradoDAL grado = new GradoDAL();

        //Uso del método Obtener
        public List<Grado> Obtener()
        {
            return grado.Obtener();
        }

        //Uso del método Agregar
        public int Agregar (Grado pGrado)
        {
            return grado.Agregar(pGrado);
        }

        //Uso del método Modificar 
        public int Modificar (Grado pGrado)
        {
            return grado.Modificar(pGrado);
        }

        //Uso del método Eliminar 
        public int Eliminar (int pId)
        {
            return grado.Eliminar(pId);
        }

        //Uso del método BuscarPorID
        public Grado BuscarPorId(int pId)
        {
            return GradoDAL.BuscarPorId(pId);
        }
    }
}
