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
    public class SeccionDAL
    {
        // Metodo Leer
        public List<Seccion> Obtener()
        {
            List<Seccion> ListaSecciones = new List<Seccion>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from secciones";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListaSecciones.Add(new Seccion(reader.GetInt32(0), reader.GetInt32(1)));
                }

                con.Close();
            }

            return ListaSecciones;
        }

        //Metodo Agregar
        public int Agregar(Seccion pSeccion)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "insert into secciones(id, secciones) values('{0}', '{1}')";
                string ssql = string.Format(sentencia, pSeccion.Id, pSeccion.SeccionAsignada);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Modificar
        public int Modificar(Seccion pSeccion)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "update secciones(id, seccionasignada) values('{0}', '{1}')";
                string ssql = string.Format(sentencia, pSeccion.Id, pSeccion.SeccionAsignada);
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
                string sentencia = "delete from secciones where id={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        // Metodo BuscarPorId
        public static Seccion BuscarPorId(int pId)
        {
            Seccion Seccion = new Seccion();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "select * from secciones where id={0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Seccion.Id = reader.GetInt32(0);
                    Seccion.SeccionAsignada = reader.GetInt32(1);
                }

                con.Close();
            }

            return Seccion;
        }
    }
}
