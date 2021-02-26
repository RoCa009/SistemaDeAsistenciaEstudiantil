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
        //Creación del objeto profesor
        ProfesorBL profesor = new ProfesorBL();

        //Uso del método Obtener para hacer la lista
        public List<Profesor> Obtener()
        {
            return profesor.Obtener();
        }

        //Uso del método Agregar
        public int Agregar (Profesor pProfesor)
        {
            return profesor.Agregar(pProfesor);
        }

        //Uso del método Modificar 
        public int Modificar (Profesor pProfesor)
        {
            return profesor.Modificar(pProfesor);
        }

        //Uso del método Eliminar
        public int Eliminar (Profesor pProfesor)
        {
            return profesor.Eliminar(pProfesor);
        }
        //Fin de los métodos para generar acciones : )
    }
}
