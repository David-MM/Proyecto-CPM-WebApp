using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult Index()
        {
            List<CuentaModel> lista;
            using (CPMEntities datos= new CPMEntities())
            {
                lista=(from d in datos.SP_Cuentas(1) select new CuentaModel { IdCuenta=d.IdCuenta,IdBanco=d.IdBanco,NombreBanco=d.Nombre,Saldo=d.Saldo,NCuenta=d.NCuenta}).ToList();
            }
            return View(lista);
        }
        public ActionResult Agregar()
        {
            List<CuentaModel> listaBanco= null;
            using (CPMEntities datos = new CPMEntities())
            {
                listaBanco = (from d in datos.SP_Bancos(1) select new CuentaModel { IdBanco = d.IdBanco, NombreBanco = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsBanco = listaBanco.ConvertAll(d => { return new SelectListItem() { Text = d.NombreBanco.ToString(), Value = d.IdBanco.ToString(), Selected = false }; });
            ViewBag.itemsBanco = itemsBanco;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(CuentaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_AgregarCuenta(model.NCuenta,model.IdBanco,model.Saldo);
                    }
                    return Redirect("~/Cuenta/");
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
            try
            {
                List<CuentaModel> listaBanco = null;
                CuentaModel model = new CuentaModel();
                using (CPMEntities datos = new CPMEntities())
                {
                    listaBanco = (from d in datos.SP_Bancos(1) select new CuentaModel { IdBanco = d.IdBanco, NombreBanco = d.Nombre }).ToList();
                    var tabla = datos.CUENTA.Find(Id); model.IdCuenta = tabla.IdCuenta; model.Saldo = tabla.Saldo; model.NCuenta = tabla.NCuenta;model.IdBanco = tabla.IdBanco;
                }
                List<SelectListItem> itemsBanco = listaBanco.ConvertAll(d => { return new SelectListItem() { Text = d.NombreBanco.ToString(), Value = d.IdBanco.ToString(), Selected = false }; });
                ViewBag.itemsBanco = itemsBanco;
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Editar(CuentaModel model)
        {
            try
            {
                using (CPMEntities datos = new CPMEntities())
                {
                    datos.sp_EditarCuenta(model.IdCuenta,model.NCuenta,model.IdBanco,model.Saldo);
                }
                return Redirect("~/Cuenta/");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public ActionResult EliminarCuenta(int Id)
        {
            using (CPMEntities datos = new CPMEntities()) datos.sp_Eliminar("Cuenta",Id);
            return Redirect("~/Cuenta/");

        }
    }
}