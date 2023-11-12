using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVC.Models
{
    public class Herramientas
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string Herramienta { get; set; }
        public string Descripcion { get; set; }
    }
}