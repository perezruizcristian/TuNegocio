using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Permiso
    {
        private CD_Permiso objcd_Permiso = new CD_Permiso();
        public List<Permiso> Listar(int IdUsuario) // retorna la lista que se leyo en la capa de datos 
        {// recordar que la capa Entidad se usa como puente entre las demas y es un reflejo directo de las tablas de las BD
            return objcd_Permiso.Listar(IdUsuario );
        }
    }
}
