
using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            List<BancoModel> lista;
            using (CPMEntities datos = new CPMEntities())
            {
                lista = (from d in datos.SP_Bancos(1) select new BancoModel { IdBanco = d.IdBanco, Nombre = d.Nombre, Correo = d.Correo, Telefono = d.Telefono }).ToList();
            }
            return View(lista);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(BancoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_AgregarBanco(model.Nombre, model.Telefono, model.Correo);
                    }
                    return Redirect("~/Banco/");
                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int Id)
        {
            BancoModel model = new BancoModel();
            using (CPMEntities datos = new CPMEntities()) { var tabla = datos.BANCO.Find(Id); model.IdBanco = tabla.IdBanco; model.Nombre = tabla.Nombre; model.Correo = tabla.Correo; model.Telefono = tabla.Telefono; }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(BancoModel model)
        {
            using (CPMEntities datos=new CPMEntities())
            {
                datos.sp_EditarBanco(model.IdBanco,model.Nombre,model.Telefono,model.Correo);
            }
            return Redirect("~/Banco/");
        }

        public ActionResult EliminarBanco(int Id)
        {
            using (CPMEntities datos = new CPMEntities()) datos.sp_Eliminar("Banco",Id);
            return Redirect("~/Banco/");

        }
    }
}