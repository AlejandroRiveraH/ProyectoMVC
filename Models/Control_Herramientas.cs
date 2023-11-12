using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVC.Models
{
    public class Control_Herramientas
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Herramienta { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha_Registro { get; set; }
        public DateTime Fecha_Entrega { get; set; }
    }
}