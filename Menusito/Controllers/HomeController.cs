using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                using (CPMEntities data = new CPMEntities())
                {
                    var nombre = "";
                    int IdRoll = 0;
                    foreach (f_EmpleadoRoll_Result f in data.f_EmpleadoRoll(Convert.ToInt32(Session["User"])))
                    {
                        nombre = f.Nombre;
                        IdRoll = (int)f.idRoll;
                    }
                    ViewBag.Message = nombre;
                    Session["Nombre"] = nombre;
                    Session["Roll"] = IdRoll;
                }
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Index(InicioModel m)
        {
            Session["User"] = null;
            return Redirect("~/Login/Index");
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}