using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CentroEscolar.AccesoADatos;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.LogicaDeNegocio
{
    public class MatriculaDeAlumnoBL
    {
        MatriculaDeAlumnoDAL matriculadealumno = new MatriculaDeAlumnoDAL();

        public List<MatriculaDeAlumno> Obtener()
        {
            return matriculadealumno.Obtener();
        }

        public int Agregar(MatriculaDeAlumno pMatriculaDeAlumno)
        {
            return matriculadealumno.Agregar(pMatriculaDeAlumno);
        }

        public int Modificar(MatriculaDeAlumno pMatriculaDeAlumno)
        {
            return matriculadealumno.Modificar(pMatriculaDeAlumno);
        }

        public int Eliminar(int pId)
        {
            return matriculadealumno.Eliminar(pId);
        }
    }
}
