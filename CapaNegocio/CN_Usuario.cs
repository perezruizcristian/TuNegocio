using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuario objcd_Usuario = new CD_Usuario();
        public List<Usuario> Listar() // retorna la lista que se leyo en la capa de datos 
        {// recordar que la capa Entidad se usa como puente entre las demas y es un reflejo directo de las tablas de las BD
            return objcd_Usuario.Listar();
        }
    }
}
