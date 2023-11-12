using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoMVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ProyectoMVC.Controllers
{
    public class Control_HerramientaController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Control_Herramientas> oControl_Herramientas = new List<Control_Herramientas>();

        // GET: Control_Herramienta
        public ActionResult Control_Herramienta_Vista()
        {
            oControl_Herramientas = new List<Control_Herramientas>();

            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM  CONTROL_HERRAMIENTAS", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Control_Herramientas nuevoControl_Herramientas = new Control_Herramientas();

                        nuevoControl_Herramientas.Id = Convert.ToInt32(dr["Id"]);
                        nuevoControl_Herramientas.Identificacion = dr["Identificacion"].ToString();
                        nuevoControl_Herramientas.Herramienta = dr["Herramienta"].ToString();
                        nuevoControl_Herramientas.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        nuevoControl_Herramientas.Fecha_Registro = Convert.ToDateTime(dr["Fecha_Registro"]);
                        nuevoControl_Herramientas.Fecha_Entrega = Convert.ToDateTime(dr["Fecha_Entrega"]);
                        oControl_Herramientas.Add(nuevoControl_Herramientas);
                    }
                }
                oconexion.Close();
            }
            return View(oControl_Herramientas);


        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Registrar(Control_Herramientas control_Herramientas)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("Control_Herramienta", oconexion);
                cmd.Parameters.AddWithValue("Id", control_Herramientas.Id);
                cmd.Parameters.AddWithValue("Identificacion", control_Herramientas.Identificacion);
                cmd.Parameters.AddWithValue("Herramienta", control_Herramientas.Herramienta);
                cmd.Parameters.AddWithValue("Cantidad", control_Herramientas.Cantidad);
                cmd.Parameters.AddWithValue("Fecha_Registro", Convert.ToDateTime(control_Herramientas.Fecha_Registro));
                cmd.Parameters.AddWithValue("Fecha_Entrega", Convert.ToDateTime(control_Herramientas.Fecha_Entrega));
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();

                oconexion.Close();
            }

            return RedirectToAction("Registrar", "Control_Herramienta");

        }
    }
}