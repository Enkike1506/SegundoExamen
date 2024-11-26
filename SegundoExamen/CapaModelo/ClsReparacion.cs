using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegundoExamen.CapaModelo
{
    public class ClsReparacion
    {
        public static int ReparacionID { get; set; }
        public static int EquipoID { get; set; }
        public static string FechaSolicitud { get; set; }
        public static string Estado { get; set; }
    }
}