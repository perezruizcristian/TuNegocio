using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            List<Rol> lista = new List<Rol>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    string query = "select IdRol,Descripcion from Rol ";

                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);//pasamos el comando por medio del objeto cmd(comando) 


                    cmd.CommandType = CommandType.Text;//El tipo de comando es textual 
                    oConexion.Open();//Abrimos la conexion
                    using (SqlDataReader dr = cmd.ExecuteReader()) //sqlDataReader es el encargado de leer el resultado del comando que nosotros enviamos 
                    {// se guarda lo leido en la variable "Dr" 
                        while (dr.Read()) //mientras siga leyendo los registros uno por uno los va almacenando en la lista 
                        {
                            lista.Add(new Rol()
                            {
                                IdRol = Convert.ToInt32(dr["IdRol"]),
                                Descripcion = dr["Descripcion"].ToString()

                            }) ; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Rol>();
                }
            }
            return lista;
        }
    }
}
