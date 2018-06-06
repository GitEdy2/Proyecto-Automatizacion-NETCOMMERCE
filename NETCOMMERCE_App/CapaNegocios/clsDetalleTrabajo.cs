using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class clsDetalleTrabajo
    {
        private int detalletrabajoid;

        private int tipotrabajoid;
        private string descripcion1tipotrabajo;
        private string descripcion2tipotrabajo;

        private int postesid;
        private string detallepostes;
        private int numeropostes;

        private int retenidasid;
        private string detalleretenidas;
        private int numeroretenidas;

        private int fibraid;
        private string detallefibra;
        private int metrosfibra;



        public int Detalletrabajoid { get => detalletrabajoid; set => detalletrabajoid = value; }

        public int Tipotrabajoid { get => tipotrabajoid; set => tipotrabajoid = value; }
        public string Descripcion1tipotrabajo { get => descripcion1tipotrabajo; set => descripcion1tipotrabajo = value; }
        public string Descripcion2tipotrabajo { get => descripcion2tipotrabajo; set => descripcion2tipotrabajo = value; }

        public int Postesid { get => postesid; set => postesid = value; }
        public string Detallepostes { get => detallepostes; set => detallepostes = value; }
        public int Numeropostes { get => numeropostes; set => numeropostes = value; }

        public int Retenidasid { get => retenidasid; set => retenidasid = value; }
        public string Detalleretenidas { get => detalleretenidas; set => detalleretenidas = value; }
        public int Numeroretenidas { get => numeroretenidas; set => numeroretenidas = value; }

        public int Fibraid { get => fibraid; set => fibraid = value; }
        public string Detallefibra { get => detallefibra; set => detallefibra = value; }
        public int Metrosfibra { get => metrosfibra; set => metrosfibra = value; }
    }
}
