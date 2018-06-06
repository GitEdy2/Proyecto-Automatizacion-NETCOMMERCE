using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class clsDetalleGrupoTrabajo
    {
        private int idgrupotrabajo;

        private int idintegrantegrupo;
        private int idtipointegrante;

        public int Idgrupotrabajo { get => idgrupotrabajo; set => idgrupotrabajo = value; }

        public int Idintegrantegrupo { get => idintegrantegrupo; set => idintegrantegrupo = value; }
        public int Idtipointegrante { get => idtipointegrante; set => idtipointegrante = value; }
    }
}
