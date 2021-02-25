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
    public class HorarioDAL
    {
        // Metodo Leer
        public List<Horario> Obtener()
        {
            List<Horario> ListaHorarios = new List<Horario>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from horarios";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListaHorarios.Add(new Horario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                }

                con.Close();
            }

            return ListaHorarios;
        }

        //Metodo Agregar
        public int Agregar(Horario pHorario)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "insert into horarios(horariodeclase, horaentrada, horasalida) values('{0}', '{1}', '{2}')";
                string ssql = string.Format(sentencia, pHorario.HorarioDeClase, pHorario.HoraEntrada, pHorario.HoraSalida);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Modificar
        public int Modificar(Horario pHorario)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "update horarios set horariodeclase='{0}', horaentrada='{1}', horasalida='{2}' where id={3} ";
                string ssql = string.Format(sentencia, pHorario.HorarioDeClase, pHorario.HoraEntrada, pHorario.HoraSalida, pHorario.Id);
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
                string sentencia = "delete from horarios where id={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        // Metodo BuscarPorId
        public static Horario BuscarPorId(int pId)
        {
            Horario horario = new Horario();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "select * from horarios where id={0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    horario.Id = reader.GetInt32(0);
                    horario.HorarioDeClase = reader.GetString(1);
                    horario.HoraEntrada = reader.GetString(2);
                    horario.HoraSalida = reader.GetString(3);
                }

                con.Close();
            }

            return horario;
        }
    }
}