using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Menusito.Models.ViewModels;

namespace Menusito.Controllers
{
    public class ChequeController : Controller
    {
        // GET: Cheque
        public ActionResult Index()
        {
            List<ChequeModel> lista;
            using (CPMEntities datos = new CPMEntities())
            {
                lista = (from d in datos.SP_Cheques() select new ChequeModel { IdCheque = d.IdCheque,NombreBanco=d.Banco,Descripcion=d.Descripcion,NCuenta=d.Cuenta, IdUsuario= d.IdUsuario, NombreUsuario= d.Usuario, IdCuenta= d.IdCuenta, Idproveedor= d.IdProveedor, NombreProveedor= d.Proveedor, Fecha = d.Fecha, Valor= d.Valor}).ToList();
            }
            return View(lista);
        }
        public ActionResult Agregar() 
        {
            List<ChequeModel> ListaCuenta = null;
            List<ChequeModel> ListaProveedor = null;
            using (CPMEntities datos=new CPMEntities())
            {
                ListaCuenta = (from d in datos.SP_ListarCuentas(1) select new ChequeModel { IdCuenta=d.IdCuenta,NCuenta=d.Numero_de_Cuenta }).ToList();
                ListaProveedor = (from d in datos.Fn_Proveedor(1) select new ChequeModel { Idproveedor=d.ID,NombreProveedor=d.NombreProveedor }).ToList();
            }
            List<SelectListItem> itemsCuenta = ListaCuenta.ConvertAll(d => { return new SelectListItem() { Text = d.NCuenta.ToString(), Value = d.IdCuenta.ToString(), Selected = false }; });
            List<SelectListItem> itemsProveedor = ListaProveedor.ConvertAll(d => { return new SelectListItem() { Text = d.NombreProveedor.ToString(), Value = d.Idproveedor.ToString(), Selected = false }; });
            ViewBag.itemsCuenta = itemsCuenta;
            ViewBag.itemsProveedor = itemsProveedor;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ChequeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_AgregarCheque((int)Session["User"], model.IdCuenta, model.Idproveedor, model.Valor);
                    }
                    return Redirect("~/Cheque/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}