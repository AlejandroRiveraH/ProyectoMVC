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
    public class ColaboradorController : Controller
    {
        private static string conexion = ConfigurationManager.ConnectionStrings["cadena"].ToString();

        private static List<Colaboradores> oColaboradores = new List<Colaboradores>();
        // GET: Colaboradores
        public ActionResult Colaborador_Vista()
        {
            oColaboradores = new List<Colaboradores>();
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM  COLABORADORES", oconexion);
                cmd.CommandType = CommandType.Text;
                oconexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Colaboradores nuevaColaborador = new Colaboradores();

                        nuevaColaborador.Id = Convert.ToInt32(dr["Id"]);
                        nuevaColaborador.Identificacion = dr["Identificacion"].ToString();
                        nuevaColaborador.Nombre = dr["Nombre"].ToString();
                        nuevaColaborador.Apellidos = dr["Apellidos"].ToString();
                        nuevaColaborador.Fecha_Registro = Convert.ToDateTime(dr["Fecha_Registro"]);
                        oColaboradores.Add(nuevaColaborador);
                    }
                }
                oconexion.Close();
            }
            return View(oColaboradores);


        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Registrar(Colaboradores colaboradores)
        {
            using (SqlConnection oconexion = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("Insertar_Colaborador", oconexion);
                cmd.Parameters.AddWithValue("Id", colaboradores.Id);
                cmd.Parameters.AddWithValue("Identificacion", colaboradores.Identificacion);
                cmd.Parameters.AddWithValue("Nombre", colaboradores.Nombre);
                cmd.Parameters.AddWithValue("Apellidos", colaboradores.Apellidos);
                cmd.Parameters.AddWithValue("Fecha_Registro", Convert.ToDateTime(colaboradores.Fecha_Registro));

                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();

                oconexion.Close();
            }

            return RedirectToAction("Registrar", "Colaborador");

        }
    }
    
}