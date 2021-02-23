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
    public class TomaDeAsistenciaDAL
    {
        // Metodo Leer
        public List<TomaDeAsistencia> Obtener()
        {
            List<TomaDeAsistencia> ListaTomaDeAsistencias = new List<TomaDeAsistencia>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from tomadeasistencias";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListaTomaDeAsistencias.Add(new TomaDeAsistencia(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), 
                        reader.GetString(6), reader.GetString(7), reader.GetString(8) ));
                }

                con.Close();
            }

            return ListaTomaDeAsistencias;
        }

        //Metodo Agregar
        public int Agregar(TomaDeAsistencia pTomaDeAsistencia)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "insert into tomadeasistencias(fecha, idprofesor, idalumno, idgrado, idseccion, asistencia, llegotarde, justificacionllegadatarde) " +
                "values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";
                string ssql = string.Format(sentencia, pTomaDeAsistencia.Fecha, pTomaDeAsistencia.IdProfesor, pTomaDeAsistencia.IdAlumno, 
                pTomaDeAsistencia.IdGrado, pTomaDeAsistencia.IdSeccion, pTomaDeAsistencia.Asistencia, pTomaDeAsistencia.LlegoTarde, pTomaDeAsistencia.JustificacionLlegadaTarde);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Modificar
        public int Modificar(TomaDeAsistencia pTomaDeAsistencia)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "update tomadeasistencias set fecha='{0}', idprofesor='{1}', idalumno='{2}', idgrado='{3}', idseccion='{4}', asistencia='{5}', llegotarde='{6}', justificacionllegadatarde='{7}' where id={8} ";
                string ssql = string.Format(sentencia, pTomaDeAsistencia.Fecha, pTomaDeAsistencia.IdProfesor, pTomaDeAsistencia.IdAlumno, pTomaDeAsistencia.IdGrado, pTomaDeAsistencia.IdSeccion,
                pTomaDeAsistencia.Asistencia, pTomaDeAsistencia.LlegoTarde, pTomaDeAsistencia.JustificacionLlegadaTarde, pTomaDeAsistencia.Id);
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
                string sentencia = "delete from tomadeasistencias where id={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        // Metodo BuscarPorId
        public static TomaDeAsistencia BuscarPorId(int pId)
        {
            TomaDeAsistencia tomadeasistencia = new TomaDeAsistencia();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "select * from tomadeasistencias where id={0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    tomadeasistencia.Id = reader.GetInt32(0);
                    tomadeasistencia.Fecha = reader.GetDateTime(1);
                    tomadeasistencia.IdProfesor = reader.GetInt32(2);
                    tomadeasistencia.IdAlumno = reader.GetInt32(3);
                    tomadeasistencia.IdGrado = reader.GetInt32(4);
                    tomadeasistencia.IdSeccion = reader.GetInt32(5);
                    tomadeasistencia.Asistencia = reader.GetString(6);
                    tomadeasistencia.LlegoTarde = reader.GetString(7);
                    tomadeasistencia.JustificacionLlegadaTarde = reader.GetString(8);
                }

                con.Close();
            }

            return tomadeasistencia;
        }
    }
}
