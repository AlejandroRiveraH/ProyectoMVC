using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoMVC.Models
{
    public class Colaboradores
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Registro { get; set; }
    }
}