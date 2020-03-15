using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class TransaccionController : Controller
    {
        // GET: Transaccion
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Compra()
        {
            List<TransaccionModel> lista;
            using (CPMEntities datos = new CPMEntities())
            {
                lista = (from d in datos.SP_ListarTransaccionesPendientes("C") select new TransaccionModel { IdOrden = d.IDMovimiento, Nombre = d.ASolicitud }).ToList();
            }
            return View(lista);
        }
        public ActionResult Venta()
        {
            
            using (CPMEntities datos = new CPMEntities())
            {
                return View();
            }
        }

    }
}