using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class DepositoController : Controller
    {
        // GET: Deposito
        public ActionResult Index()
        {
            List<DepositoModel> lista;
            using (CPMEntities datos = new CPMEntities())
            {
                lista = (from d in datos.SP_Deposito() select new DepositoModel { IdDeposito = d.IdDeposito, NombreBanco = d.Banco, Descripcion = d.Descripcion, NCuenta = d.Cuenta, IdUsuario = d.IdUsuario, NombreUsuario = d.Usuario, IdCuenta = d.IdCuenta, IdCliente = d.IdCliente, NombreCliente = d.Cliente, Fecha = d.Fecha, Valor = d.Valor }).ToList();
            }
            return View(lista);
        }
        public ActionResult Agregar()
        {
            List<DepositoModel> ListaCuenta = null;
            List<DepositoModel> ListaCliente = null;
            using (CPMEntities datos = new CPMEntities())
            {
                ListaCuenta = (from d in datos.SP_ListarCuentas(1) select new DepositoModel { IdCuenta = d.IdCuenta, NCuenta = d.Numero_de_Cuenta }).ToList();
                ListaCliente = (from d in datos.Fn_Cliente(1) select new DepositoModel { IdCliente = d.ID, NombreCliente = d.Nombrecliente }).ToList();
            }
            List<SelectListItem> itemsCuenta = ListaCuenta.ConvertAll(d => { return new SelectListItem() { Text = d.NCuenta.ToString(), Value = d.IdCuenta.ToString(), Selected = false }; });
            List<SelectListItem> itemCliente = ListaCliente.ConvertAll(d => { return new SelectListItem() { Text = d.NombreCliente.ToString(), Value = d.IdCliente.ToString(), Selected = false }; });
            ViewBag.itemsCuenta = itemsCuenta;
            ViewBag.itemCliente = itemCliente;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(DepositoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_AgregarDeposito((int)Session["User"], model.IdCuenta, model.IdCliente, model.Valor);
                    }
                    return Redirect("~/Deposito/");
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