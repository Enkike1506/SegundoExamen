using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SegundoExamen.CapaModelo
{
    public class ClsDetalleReparacion
    {
        public static int DetalleID { get; set; }
        public static int ReparacionID { get; set; }
        public static string Descripcion { get; set; }
        public static string FechaInicio { get; set; }
        public static string FechaFin { get; set; }
    }
}