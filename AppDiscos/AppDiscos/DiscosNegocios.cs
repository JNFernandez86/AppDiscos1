using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppDiscos
{
    class DiscosNegocios
    {
        public List<Discos> listar()

        {
            // crear instancia de sqlconnection, sqlcommand y datareader
            List<Discos> lista = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.;database=DISCOS_DB; integrated security=true";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select Id, Titulo,CantidadCanciones, UrlImagenTapa from DISCOS;";
                cmd.Connection = conexion;

                conexion.Open();
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Discos disc = new Discos();

                    disc.Id = (int)lector["Id"];
                    disc.Titulo = (string)lector["Titulo"];
                    disc.CantidadCanciones = (int)lector["CantidadCanciones"];
                    disc.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    lista.Add(disc); 
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

     
    }
}
