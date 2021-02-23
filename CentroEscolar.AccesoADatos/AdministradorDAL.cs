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
    public class AdministradorDAL
    {
        // Metodo Leer
        public List<Administrador> Obtener()
        {
            List<Administrador> ListaAdministradors = new List<Administrador>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from administradores";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListaAdministradors.Add(new Administrador(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }

                con.Close();
            }

            return ListaAdministradors;
        }

        //Metodo Agregar
        public int Agregar(Administrador pAdministrador)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "insert into administradores(nombre, correo, contrasena) values('{0}', '{1}', '{2}')";
                string ssql = string.Format(sentencia, pAdministrador.Nombre, pAdministrador.Correo, pAdministrador.Contrasena);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Modificar
        public int Modificar(Administrador pAdministrador)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "update administradores set nombre='{0}', correo='{1}', contrasena='{2}' where id={3} ";
                string ssql = string.Format(sentencia, pAdministrador.Nombre, pAdministrador.Correo, pAdministrador.Contrasena, pAdministrador.Id);
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
                string sentencia = "delete from administradores where id={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        // Metodo Ingresar
        public Administrador Ingresar(Administrador pAdministrador)
        {
            Administrador administrador = new Administrador();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from administradores where correo=@correo";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@correo", pAdministrador.Correo);
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["Contrasena"].ToString() == pAdministrador.Contrasena)
                    {
                        administrador.Id = reader.GetInt32(0);
                        administrador.Nombre = reader.GetString(1);
                        administrador.Correo = reader.GetString(2);
                        administrador.Contrasena = reader.GetString(3);
                    }
                    else
                        return null;                    
                }
                else
                    return null;
                
                con.Close();
            }

            return administrador;
        }
    }
}
