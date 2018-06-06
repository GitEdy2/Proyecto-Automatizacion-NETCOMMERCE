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
    public class clsDatosUsuarios
    {
        private string cadenaConexion;

        public clsDatosUsuarios()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
        }


        public List<clsUsuarios> ListarUsuarios()
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd = new MySqlCommand("select * from tbl_Usuarios", con);

            List<clsUsuarios> listaUsuarios = new List<clsUsuarios>();

            con.Open();
            MySqlDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                clsUsuarios usuario = new clsUsuarios();

                usuario.IdUsuario = lector.GetInt32(0);
                usuario.Nombreusuario = lector.GetString(1);
                usuario.Passwordusuario = lector.GetString(2);

                usuario.Idrolempresa = lector.GetInt32(3);
                usuario.Idregistroingresos = lector.GetInt32(4);

                listaUsuarios.Add(usuario);
            }

            con.Close();

            return listaUsuarios;
        }


        public bool IngresarUsuario(clsUsuarios Usuario)
        {
            MySqlConnection con = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Usuarios(idtbl_Usuarios,nombreusuario,passwordusuario,tbl_RolEmpresa_id,tbl_RegistroIngresos_id)" +
                                                "values(@usuarioid,@nombreusuario,@passwordusuario,@rolempresa,@registroentrada)", con);

            cmd.Parameters.Add("@usuarioid", MySqlDbType.Int32).Value = Usuario.IdUsuario;
            cmd.Parameters.Add("@nombreusuario", MySqlDbType.VarChar).Value = Usuario.Nombreusuario;
            cmd.Parameters.Add("@passwordusuario", MySqlDbType.VarChar).Value = Usuario.Passwordusuario;
            cmd.Parameters.Add("@rolempresa", MySqlDbType.Int32).Value = Usuario.Idrolempresa;
            cmd.Parameters.Add("@registroentrada", MySqlDbType.Int32).Value = Usuario.Idregistroingresos;

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
