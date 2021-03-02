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
        // Objeto
        GradoDAL grado = new GradoDAL();
        // Obtener
        public List<Grado> Obtener()
        {
            return grado.Obtener();
        }
        // Agregar
        public int Agregar (Grado pGrado)
        {
            return grado.Agregar(pGrado);
        }
        // Modificar
        public int Modificar (Grado pGrado)
        {
            return grado.Modificar(pGrado);
        }
        // Eliminar
        public int Eliminar (int pId)
        {
            return grado.Eliminar(pId);
        }
        // BuscarPorId
        public Grado BuscarPorId(int pId)
        {
            return GradoDAL.BuscarPorId(pId);
        }
    }
}
