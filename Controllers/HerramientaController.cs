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
    public class HerramientaController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Herramientas> herramientas = new List<Herramientas>();
        // GET: Herramienta
        public ActionResult Herramienta_Vista()
        {
            herramientas = new List<Herramientas>();
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM HERRAMIENTAS", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Herramientas nuevaHerramienta = new Herramientas();
                        nuevaHerramienta.Id = Convert.ToInt32(dr["Id"]);
                        nuevaHerramienta.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        nuevaHerramienta.Herramienta = dr["Herramienta"].ToString();
                        nuevaHerramienta.Descripcion = dr["Descripcion"].ToString();
                        herramientas.Add(nuevaHerramienta);
                    }
                }
                oconexion.Close();
            }
            return View(herramientas);


        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Registrar(Herramientas herramientas)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_Registrar", oconexion);
                cmd.Parameters.AddWithValue("Id", herramientas.Id);
                cmd.Parameters.AddWithValue("Cantidad", herramientas.Cantidad);
                cmd.Parameters.AddWithValue("Herramienta", herramientas.Herramienta);
                cmd.Parameters.AddWithValue("Descripcion", herramientas.Descripcion);

                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();

                oconexion.Close();
            }

            return RedirectToAction("Registrar", "Herramienta");

        }
    }
}