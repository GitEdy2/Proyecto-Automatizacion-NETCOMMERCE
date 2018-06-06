using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class clsRuta
    {
        private int idruta;
        private string nombreruta;
        private string clienteruta;
        private string provinciaruta;
        private string cantonruta;
        private string parroquiaruta;
        private string referenciaruta;


        public string Nombreruta { get => nombreruta; set => nombreruta = value; }
        public string Clienteruta { get => clienteruta; set => clienteruta = value; }
        public string Provinciaruta { get => provinciaruta; set => provinciaruta = value; }
        public string Cantonruta { get => cantonruta; set => cantonruta = value; }
        public string Referenciaruta { get => referenciaruta; set => referenciaruta = value; }
        public int Idruta { get => idruta; set => idruta = value; }
        public string Parroquiaruta { get => parroquiaruta; set => parroquiaruta = value; }
    }
}
