﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.AccesoADatos
{
    public class GradoDAL
    {
        // Metodo Obtener
        public List<Grado> Obtener()
        {
            List<Grado> ListaGrados = new List<Grado>();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string ssql = "select * from grados";
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ListaGrados.Add(new Grado (reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), 
                        reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)));
                }

                con.Close();
            }

            return ListaGrados;
        }

        //Metodo Agregar
        public int Agregar(Grado pGrado)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "insert into grados(gradoasignado, idprofesor, idseccion, idhorario, idaula) values('{0}', '{1}', '{2}', '{3}', '{4}')";
                string ssql = string.Format(sentencia, pGrado.GradoAsignado, pGrado.IdProfesor, pGrado.IdSeccion, pGrado.IdHorario, pGrado.IdAula);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        //Metodo Modificar
        public int Modificar(Grado pGrado)
        {
            int resultado = 0;
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "update grados set gradoasignado='{0}', idprofesor='{1}', idseccion='{2}', idhorario='{3}', idaula='{4}' where id={5}";
                string ssql = string.Format(sentencia, pGrado.GradoAsignado, pGrado.IdProfesor, pGrado.IdSeccion, pGrado.IdHorario, pGrado.IdAula, pGrado.Id);
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
                string sentencia = "delete from grados where id={0} ";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                resultado = comando.ExecuteNonQuery();

                con.Close();
            }

            return resultado;
        }

        // Metodo BuscarPorId
        public static Grado BuscarPorId(int pId)
        {
            Grado grado = new Grado();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string sentencia = "select * from grados where id={0}";
                string ssql = string.Format(sentencia, pId);
                SqlCommand comando = new SqlCommand(ssql, con);
                comando.CommandType = CommandType.Text;
                IDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    grado.Id = reader.GetInt32(0);
                    grado.GradoAsignado = reader.GetString(1);
                    grado.IdProfesor = reader.GetInt32(2);
                    grado.IdSeccion = reader.GetInt32(3);
                    grado.IdHorario = reader.GetInt32(4);
                    grado.IdAula = reader.GetInt32(5);
                }

                con.Close();
            }

            return grado;
        }
    }
}
