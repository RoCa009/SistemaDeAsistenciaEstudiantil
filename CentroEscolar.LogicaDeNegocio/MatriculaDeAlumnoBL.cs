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
        // Objeto
        MatriculaDeAlumnoDAL matriculadealumno = new MatriculaDeAlumnoDAL();
        // Obtener
        public List<MatriculaDeAlumno> Obtener()
        {
            return matriculadealumno.Obtener();
        }
        // Agregar
        public int Agregar(MatriculaDeAlumno pMatriculaDeAlumno)
        {
            return matriculadealumno.Agregar(pMatriculaDeAlumno);
        }
        // Modificar
        public int Modificar(MatriculaDeAlumno pMatriculaDeAlumno)
        {
            return matriculadealumno.Modificar(pMatriculaDeAlumno);
        }
        // Eliminar
        public int Eliminar(int pId)
        {
            return matriculadealumno.Eliminar(pId);
        }
        // BuscarPorId
        public MatriculaDeAlumno BuscarPorId(int pId)
        {
            return MatriculaDeAlumnoDAL.BuscarPorId(pId);
        }
    }
}
