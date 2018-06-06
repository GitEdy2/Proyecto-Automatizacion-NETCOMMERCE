using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class clsUsuarios
    {
        private int idUsuario;
        private string nombreusuario;
        private string passwordusuario;

        private int idrolempresa;
        private int idregistroingresos;

        private int registroingresosid;
        private string fechaingresoregistro;



        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombreusuario { get => nombreusuario; set => nombreusuario = value; }
        public string Passwordusuario { get => passwordusuario; set => passwordusuario = value; }

        public int Idrolempresa { get => idrolempresa; set => idrolempresa = value; }
        public int Idregistroingresos { get => idregistroingresos; set => idregistroingresos = value; }

        public int Registroingresosid { get => registroingresosid; set => registroingresosid = value; }
        public string Fechaingresoregistro { get => fechaingresoregistro; set => fechaingresoregistro = value; }
    }
}
