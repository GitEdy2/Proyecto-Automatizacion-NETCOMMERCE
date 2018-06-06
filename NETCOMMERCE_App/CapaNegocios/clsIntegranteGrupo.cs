using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class clsIntegranteGrupo
    {
        private int idintegrantegrupo;
        private string nombreintegrantegrupo;

        private int idtipointegrante;
        private string descripciontipointegrante;



        public int Idintegrantegrupo { get => idintegrantegrupo; set => idintegrantegrupo = value; }
        public string Nombreintegrantegrupo { get => nombreintegrantegrupo; set => nombreintegrantegrupo = value; }

        public int Idtipointegrante { get => idtipointegrante; set => idtipointegrante = value; }
        public string Descripciontipointegrante { get => descripciontipointegrante; set => descripciontipointegrante = value; }
    }
}
