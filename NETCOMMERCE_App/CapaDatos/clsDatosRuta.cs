using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using CapaNegocios;
using System.Web;
using System.Configuration;
using System.Data;

namespace CapaDatos
{
    public class clsDatosRuta
    {
        private string cadenaConexion;
        
        public clsDatosRuta()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
        }


        public List<clsRuta> ListarRutas()
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd = new MySqlCommand("select * from tbl_DetalleRuta", con);
      
            List<clsRuta> listaruta = new List<clsRuta>();

            con.Open();
            MySqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                clsRuta ruta = new clsRuta();

                ruta.Idruta = lector.GetInt32(0);
                ruta.Nombreruta = lector.GetString(1);
                ruta.Clienteruta = lector.GetString(2);
                ruta.Provinciaruta = lector.GetString(3);
                ruta.Cantonruta = lector.GetString(4);
                ruta.Referenciaruta = lector.GetString(5);

                listaruta.Add(ruta);
            }

            con.Close();

            return listaruta;          
        }


        public bool IngresarRuta(clsRuta Ruta)
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);

            MySqlCommand cmd = new MySqlCommand("insert into tbl_DetalleRuta(idtbl_DetalleRuta,nombre_ruta,cliente_ruta,provincia_ruta,canton_ruta,parroquia_ruta,referencia_ruta)" +
                                                "values(@idruta,@nombreruta,@clienteruta,@provinciaruta,@cantonruta,@parroquiaruta,@referenciaruta)", con);

            cmd.Parameters.Add("@idruta", MySqlDbType.Int32).Value = Ruta.Idruta;
            cmd.Parameters.Add("@nombreruta", MySqlDbType.VarChar).Value = Ruta.Nombreruta;
            cmd.Parameters.Add("@clienteruta", MySqlDbType.VarChar).Value = Ruta.Clienteruta;
            cmd.Parameters.Add("@provinciaruta", MySqlDbType.VarChar).Value = Ruta.Provinciaruta;
            cmd.Parameters.Add("@cantonruta", MySqlDbType.VarChar).Value = Ruta.Cantonruta;
            cmd.Parameters.Add("@parroquiaruta", MySqlDbType.VarChar).Value = Ruta.Parroquiaruta;
            cmd.Parameters.Add("@referenciaruta", MySqlDbType.VarChar).Value = Ruta.Referenciaruta;

            con.Open();

            int exito = cmd.ExecuteNonQuery();

            if (exito == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public DataRow BuscarCliente (string nombreruta)
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);

            MySqlDataAdapter da;

            DataSet ds = new DataSet();

            try
            {
                string mysql = "select nombreruta,cliente_ruta,provincia_ruta,canton_ruta,parroquia_ruta from tbl_DetalleRuta where nombre_ruta =" +nombreruta;
                da = new MySqlDataAdapter(mysql, con);

                da.Fill(ds, "tbl_DetalleRuta");
                da.FillSchema(ds.Tables[0], SchemaType.Mapped);

                DataRow fila = ds.Tables[0].Rows.Find(nombreruta);

                return fila;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
