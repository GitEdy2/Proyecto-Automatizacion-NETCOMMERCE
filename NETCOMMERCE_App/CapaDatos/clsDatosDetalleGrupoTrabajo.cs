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
    public class clsDatosDetalleGrupoTrabajo
    {
        private string cadenaConexion;


        public clsDatosDetalleGrupoTrabajo()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
        }


        public List<clsDetalleGrupoTrabajo> ListarGruposTrabajo()
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd = new MySqlCommand("select * from tbl_DetalleGrupoTrabajo", con);

            List<clsDetalleGrupoTrabajo> listagrupotrabajo = new List<clsDetalleGrupoTrabajo>();

            con.Open();
            MySqlDataReader lector = cmd.ExecuteReader();

            while(lector.Read())
            {
                clsDetalleGrupoTrabajo grupotrabajo = new clsDetalleGrupoTrabajo();

                grupotrabajo.Idgrupotrabajo = lector.GetInt32(0);
                grupotrabajo.Idintegrantegrupo = lector.GetInt32(1);

                listagrupotrabajo.Add(grupotrabajo);
            }

            con.Close();

            return listagrupotrabajo;
        }


        public bool IngresarGrupoTrabajo (clsDetalleGrupoTrabajo grupotrabajo)
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd = new MySqlCommand("insert into tbl_DetalleGrupoTrabajo(idtbl_DetalleGrupoTrabajo,tbl_IntegranteGrupo_id,tbl_TipoIntegranteGrupo_id)" +
                                                "values(@grupotrabajoid,@integrantegrupoid,@tipointegranteid)", con);

            cmd.Parameters.Add("@grupotrabajoid", MySqlDbType.Int32).Value = grupotrabajo.Idgrupotrabajo;

            cmd.Parameters.Add("@integrantegrupoid", MySqlDbType.Int32).Value = grupotrabajo.Idintegrantegrupo;
            cmd.Parameters.Add("@tipointegranteid", MySqlDbType.Int32).Value = grupotrabajo.Idtipointegrante;

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
    }
}
