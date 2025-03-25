using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Rol
    {

        private CD_Rol objcd_rol = new CD_Rol();
        public List<Rol> Listar() // retorna la lista que se leyo en la capa de datos 
        {// recordar que la capa Entidad se usa como puente entre las demas y es un reflejo directo de las tablas de las BD
            return objcd_rol.Listar();
        }

    }
}
