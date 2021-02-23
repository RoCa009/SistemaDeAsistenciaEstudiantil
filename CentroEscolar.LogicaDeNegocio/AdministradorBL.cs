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
        AdministradorDAL administrador = new AdministradorDAL();

        public List<Administrador> Obtener()
        {
            return administrador.Obtener();
        }

        public int Agregar(Administrador pAdministrador)
        {
            return administrador.Agregar(pAdministrador);
        }

        public int Modificar(Administrador pAdministrador)
        {
            return administrador.Modificar(pAdministrador);
        }

        public int Eliminar(int pId)
        {
            return administrador.Eliminar(pId);
        }

        public Administrador Ingresar(Administrador pAdministrador)
        {
            return administrador.Ingresar(pAdministrador);
        }
    }
}
