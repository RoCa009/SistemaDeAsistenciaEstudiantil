using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.AccesoADatos
{
    class MatriculaDeAlumnoDAL
    {
        // Metodo Leer
        public List<MatriculaDeAlumno> Obtener()
        {
            List<MatriculaDeAlumno> ListaMatriculaDeAlumnos = new List<MatriculaDeAlumno>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from matriculadealumnos";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListaMatriculaDeAlumnos.Add(new MatriculaDeAlumno(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), 
                        reader.GetInt32(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), 
                        reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14) ));
                }

                con.Close();
            }

            return ListaMatriculaDeAlumnos;
        }

        //Metodo Agregar
        public int Agregar(MatriculaDeAlumno pMatriculaDeAlumno)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "insert into matriculadealumnos(dui, nombreencargado, nombresalumno, apellidosalumno," +
                "edad, sexo, direccion, telefono, correo, idprofesor, idgrado, idseccion, idhorario, idaula) " +
                "values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '10}', '{11}', '{12}', '{13}', '{14}')";
                string ssql = string.Format(sentencia, pMatriculaDeAlumno.DUI, pMatriculaDeAlumno.NombreEncargado, pMatriculaDeAlumno.NombresAlumno, pMatriculaDeAlumno.ApellidosAlumno, 
                pMatriculaDeAlumno.Edad, pMatriculaDeAlumno.Sexo, pMatriculaDeAlumno.Direccion, pMatriculaDeAlumno.Telefono, pMatriculaDeAlumno.Correo,
                pMatriculaDeAlumno.IdProfesor, pMatriculaDeAlumno.IdGrado, pMatriculaDeAlumno.IdSeccion, pMatriculaDeAlumno.IdHorario, pMatriculaDeAlumno.IdAula);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Modificar
        public int Modificar(MatriculaDeAlumno pMatriculaDeAlumno)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "update matriculadealumnos set dui='{0}', nombreencargado='{1}', nombresalumno='{2}', apellidosalumno='{3}'," +
                "edad='{4}', sexo='{5}', direccion='{6}', telefono='{7}', correo='{8}', idprofesor='{9}', idgrado='{10}', idseccion='{11}', idhorario='{12}', idaula='{13}' where id={14} ";
                string ssql = string.Format(sentencia, pMatriculaDeAlumno.DUI, pMatriculaDeAlumno.NombreEncargado, pMatriculaDeAlumno.NombresAlumno, pMatriculaDeAlumno.ApellidosAlumno,
                pMatriculaDeAlumno.Edad, pMatriculaDeAlumno.Sexo, pMatriculaDeAlumno.Direccion, pMatriculaDeAlumno.Telefono, pMatriculaDeAlumno.Correo,
                pMatriculaDeAlumno.IdProfesor, pMatriculaDeAlumno.IdGrado, pMatriculaDeAlumno.IdSeccion, pMatriculaDeAlumno.IdHorario, pMatriculaDeAlumno.IdAula, pMatriculaDeAlumno.Id);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Eliminar
        public int Eliminar(int pId)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "delete from matriculadealumnos where id={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        // Metodo BuscarPorId
        public static MatriculaDeAlumno BuscarPorId(int pId)
        {
            MatriculaDeAlumno matriculadealumno = new MatriculaDeAlumno();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "select * from matriculadealumnos where id={0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    matriculadealumno.Id = reader.GetInt32(0);
                    matriculadealumno.DUI = reader.GetString(1);
                    matriculadealumno.NombreEncargado = reader.GetString(2);
                    matriculadealumno.NombresAlumno = reader.GetString(3);
                    matriculadealumno.ApellidosAlumno = reader.GetString(4);
                    matriculadealumno.Edad = reader.GetInt32(5);
                    matriculadealumno.Sexo = reader.GetString(6);
                    matriculadealumno.Direccion = reader.GetString(7);
                    matriculadealumno.Telefono = reader.GetString(8);
                    matriculadealumno.Correo = reader.GetString(9);
                    matriculadealumno.IdProfesor = reader.GetInt32(10);
                    matriculadealumno.IdGrado = reader.GetInt32(11);
                    matriculadealumno.IdSeccion = reader.GetInt32(12);
                    matriculadealumno.IdHorario = reader.GetInt32(13);
                    matriculadealumno.IdAula = reader.GetInt32(14);
                }

                con.Close();
            }

            return matriculadealumno;
        }
    }
}
