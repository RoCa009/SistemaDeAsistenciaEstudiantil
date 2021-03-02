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
<<<<<<< HEAD

        ProfesorDAL profesor = new ProfesorDAL();

        public List<Profesor> Obtener()
        {
            return profesor.Obtener();
        }

        //Uso del método Agregar
=======
        // Objeto
        ProfesorDAL profesor = new ProfesorDAL();        
        // Obtener
        public List<Profesor> Obtener()
        {
            return profesor.Obtener();
        } 
        // Agregar
>>>>>>> 481bd8e96a6ce383d0595cc443a7fd422ce3522d
        public int Agregar(Profesor pProfesor)
        {
            return profesor.Agregar(pProfesor);
        }
<<<<<<< HEAD

=======
        // Modificar
>>>>>>> 481bd8e96a6ce383d0595cc443a7fd422ce3522d
        public int Modificar(Profesor pProfesor)
        {
            return profesor.Modificar(pProfesor);
        }
        // Eliminar
        public int Eliminar(int pId)
        {
            return profesor.Eliminar(pId);
        }
        // BuscarPorId
        public Profesor BuscarPorId(int pId)
        {
            return ProfesorDAL.BuscarPorId(pId);
        }

    }
}