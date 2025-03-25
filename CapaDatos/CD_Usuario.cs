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
    public class CD_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    string query = "select IdUsuario, Documento, Correo, NombreCompleto, Clave, Estado from Usuario ";
                    SqlCommand cmd = new SqlCommand(query, oConexion);//pasamos el comando por medio del objeto cmd(comando) 
                    cmd.CommandType = CommandType.Text;//El tipo de comando es textual 
                    oConexion.Open();//Abrimos la conexion
                    using (SqlDataReader dr = cmd.ExecuteReader()) //sqlDataReader es el encargado de leer el resultado del comando que nosotros enviamos 
                    {// se guarda lo leido en la variable "Dr" 
                        while (dr.Read()) //mientras siga leyendo los registros uno por uno los va almacenando en la lista 
                        {
                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]) 
                            }) ;
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Usuario>(); 
                }
            }
            return lista;
        }
    }
}
