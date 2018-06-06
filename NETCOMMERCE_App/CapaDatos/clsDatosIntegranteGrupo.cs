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
    public class clsDatosIntegranteGrupo
    {
        private string cadenaConexion;

        public clsDatosIntegranteGrupo()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
        }


        public List<clsIntegranteGrupo> ListarIntegrantesGrupo()
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd = new MySqlCommand("select * from tbl_IntegranteGrupo", con);

            List<clsIntegranteGrupo> listaintegrantes = new List<clsIntegranteGrupo>();

            con.Open();
            MySqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                clsIntegranteGrupo integrante = new clsIntegranteGrupo();

                integrante.Idintegrantegrupo = lector.GetInt32(0);
                integrante.Nombreintegrantegrupo = lector.GetString(1);

                integrante.Idtipointegrante = lector.GetInt32(2);

                listaintegrantes.Add(integrante);              
            }

            con.Close();

            return listaintegrantes;
        }


        public bool IngresarIntegranteGrupo (clsIntegranteGrupo integrante)
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd = new MySqlCommand("insert into tbl_IntegranteGrupo(idtbl_IntegranteGrupo,nombre_integrantegrupo,tbl_TipoIntegranteGrupo_id)" +
                                                "values(@integranteid,@nombreintegrante,@tipointegrante)", con);

            cmd.Parameters.Add("@integranteid", MySqlDbType.Int32).Value = integrante.Idintegrantegrupo;
            cmd.Parameters.Add("@nombreintegrante", MySqlDbType.VarChar).Value = integrante.Nombreintegrantegrupo;

            cmd.Parameters.Add("@tipointegrante", MySqlDbType.Int32).Value = integrante.Idtipointegrante;

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
