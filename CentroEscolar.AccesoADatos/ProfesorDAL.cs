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
    public class ProfesorDAL
    {
        // Metodo Leer
        public List<Profesor> Obtener()
        {
            List<Profesor> ListaProfesores = new List<Profesor>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from profesores";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListaProfesores.Add(new Profesor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), 
                        reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)));
                }

                con.Close();
            }

            return ListaProfesores;
        }

        //Metodo Agregar
        public int Agregar(Profesor pProfesor)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "insert into profesores(dui, nombres, apellidos, edad, sexo, direccion, telefono, correo) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";
                string ssql = string.Format(sentencia, pProfesor.DUI, pProfesor.Nombres, pProfesor.Apellidos, pProfesor.Edad, pProfesor.Sexo, pProfesor.Direccion, pProfesor.Telefono, pProfesor.Correo);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Modificar
        public int Modificar(Profesor pProfesor)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "update profesores set dui='{0}', nombres='{1}', apellidos='{2}', edad='{3}', sexo='{4}', direccion='{5}', telefono='{6}', correo='{7}' where id={8}";
                string ssql = string.Format(sentencia, pProfesor.DUI, pProfesor.Nombres, pProfesor.Apellidos, pProfesor.Edad, pProfesor.Sexo, pProfesor.Direccion, pProfesor.Telefono, pProfesor.Correo, pProfesor.Id);
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
                string sentencia = "delete from profesores where id={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        // Metodo BuscarPorId
        public static Profesor BuscarPorId(int pId)
        {
            Profesor profesor = new Profesor();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "select * from profesores where id={0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    profesor.Id = reader.GetInt32(0);
                    profesor.DUI = reader.GetString(1);
                    profesor.Nombres = reader.GetString(2);
                    profesor.Apellidos = reader.GetString(3);
                    profesor.Edad = reader.GetInt32(4);
                    profesor.Sexo = reader.GetString(5);
                    profesor.Direccion = reader.GetString(6);
                    profesor.Telefono = reader.GetString(7);
                    profesor.Correo = reader.GetString(8);

                }

                con.Close();
            }

            return profesor;
        }
    }
}
