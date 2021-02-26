using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CentroEscolar.AccesoADatos;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.LogicaDeNegocio
{
    public class ProfesorBL
    {

        ProfesorDAL profesor = new ProfesorDAL();

        public List<Profesor> Obtener()
        {
            return profesor.Obtener();
        }

        public int Agregar(Profesor pProfesor)
        {
            return profesor.Agregar(pProfesor);
        }

        public int Modificar(Profesor pProfesor)
        {
            return profesor.Modificar(pProfesor);
        }

        public int Eliminar(int pId)
        {
            return profesor.Eliminar(pId);
        }

        public Profesor BuscarPorId(int pId)
        {
            return ProfesorDAL.BuscarPorId(pId);
        }
    }
}
