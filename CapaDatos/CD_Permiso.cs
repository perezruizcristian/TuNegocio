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
    public class CD_Permiso
    {
        public List<Permiso> Listar(int idUsuario)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    /* StringBuilder query = new StringBuilder();
                     query.AppendLine("select p.IdRol,p.NombreMenu from PERMISO p");
                     query.AppendLine("inner join ROL r on r.IdRol = p.IdRol");
                     query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                     query.AppendLine("where u.IdUsuario =  @idusuario");*/

                    string query = "select p.IdRol,p.NombreMenu from PERMISO " +
                        "p inner join ROL r on r.IdRol = p.IdRol inner join USUARIO" +
                        " u on u.IdRol = r.IdRol where u.IdUsuario = @idusuario ";

                    SqlCommand cmd = new SqlCommand(query.ToString (), oConexion);//pasamos el comando por medio del objeto cmd(comando) 

                    cmd.Parameters.AddWithValue("@idusuario", idUsuario);

                    cmd.CommandType = CommandType.Text;//El tipo de comando es textual 
                    oConexion.Open();//Abrimos la conexion
                    using (SqlDataReader dr = cmd.ExecuteReader()) //sqlDataReader es el encargado de leer el resultado del comando que nosotros enviamos 
                    {// se guarda lo leido en la variable "Dr" 
                        while (dr.Read()) //mientras siga leyendo los registros uno por uno los va almacenando en la lista 
                        {
                            lista.Add(new Permiso()
                            {
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"])} ,
                                NombreMenu = dr["NombreMenu"].ToString()
                            });
                        }
                    }


                }
                catch (Exception ex)
                {
                    lista = new List<Permiso>();
                }
            }
            return lista;
        }
    }
}
