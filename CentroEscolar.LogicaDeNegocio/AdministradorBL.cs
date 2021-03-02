using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CentroEscolar.AccesoADatos;
using CentroEscolar.EntidadesDeNegocio;

namespace CentroEscolar.LogicaDeNegocio
{
    public class AdministradorBL
    {
        // Objeto
        AdministradorDAL administrador = new AdministradorDAL();
        // Obtener
        public List<Administrador> Obtener()
        {
            return administrador.Obtener();
        }
        // Agregar
        public int Agregar(Administrador pAdministrador)
        {
            return administrador.Agregar(pAdministrador);
        }
        // Modificar
        public int Modificar(Administrador pAdministrador)
        {
            return administrador.Modificar(pAdministrador);
        }
        //Eliminar
        public int Eliminar(int pId)
        {
            return administrador.Eliminar(pId);
        }
        // Ingresar
        public Administrador Ingresar(Administrador pAdministrador)
        {
            return administrador.Ingresar(pAdministrador);
        }
    }
}
