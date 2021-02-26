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
    public class AulaDAL
    {
        // Metodo Leer
        public List<Aula> Obtener()
        {
            List<Aula> ListaAulas = new List<Aula>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from aulas";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListaAulas.Add(new Aula(reader.GetInt32(0), reader.GetInt32(1)));
                }

                con.Close();
            }

            return ListaAulas;
        }

        //Metodo Agregar
        public int Agregar(Aula pAula)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "insert into aulas(numerodeaula) values('{0}')";
                string ssql = string.Format(sentencia, pAula.NumeroDeAula);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Modificar
        public int Modificar(Aula pAula)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "update aulas set numerodeaula='{0}' where id={1} ";
                string ssql = string.Format(sentencia, pAula.NumeroDeAula, pAula.Id);
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
                string sentencia = "delete from aulas where id={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        // Metodo BuscarPorId
        public static Aula BuscarPorId(int pId)
        {
            Aula Aula = new Aula();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "select * from aulas where id={0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    Aula.Id = reader.GetInt32(0);
                    Aula.NumeroDeAula = reader.GetInt32(1);
                }

                con.Close();
            }

            return Aula;
        }
    }
}
