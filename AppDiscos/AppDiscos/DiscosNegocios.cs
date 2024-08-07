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
                cmd.CommandText = "select d.Id, Titulo,CantidadCanciones as 'Cantidad Pistas', UrlImagenTapa, e.Descripcion AS 'Estilo Musical', t.Descripcion AS 'Tipo Edicion' " +
                    "from DISCOS d, ESTILOS e, TIPOSEDICION t " +
                    "where d.IdEstilo = e.Id and t.Id= d.IdTipoEdicion;";
                cmd.Connection = conexion;

                conexion.Open();
                lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    Discos disc = new Discos();

                    disc.Id = (int)lector["Id"];
                    disc.Titulo = (string)lector["Titulo"];
                    disc.CantidadCanciones = (int)lector["Cantidad Pistas"];
                    disc.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    disc.Estilo = new Estilo();
                    disc.Estilo.Descripcion = (string)lector["Estilo Musical"];
                    disc.TipoEdicion = new TipoEdicion();
                    disc.TipoEdicion.Descripcion = (string)lector["Tipo Edicion"];
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
