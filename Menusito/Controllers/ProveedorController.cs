using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            try
            {
                List<ProveedorModel> listaProveedores;
                using (CPMEntities datos = new CPMEntities())
                {
                    listaProveedores = (from d in datos.Fn_Proveedor(1) select new ProveedorModel { ID = (int)d.ID, Nombre = d.NombreProveedor, Ciudad = d.Ciudad, Pais = d.Pais, Contacto = d.Contacto, Telefono = d.Telefono, Correo = d.Correo, LimCredito = (Double)d.LimiteCredito, DeudaPagar = (Double)d.Deuda, CreditoDisponible = (Double)d.CreditoDisponible }).ToList();
                }
                return View(listaProveedores);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public ActionResult Agregar()
        {
            List<ProveedorModel> listaCiudad = null;
            List<ProveedorModel> listaPais = null;
            using (CPMEntities datos = new CPMEntities())
            {
                listaCiudad = (from d in datos.CIUDAD select new ProveedorModel { IdC = d.IdCiudad, Nombre = d.Nombre }).ToList();
                listaPais = (from d in datos.PAIS select new ProveedorModel { IdP = d.IdPais, Pais = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsCiudad = listaCiudad.ConvertAll(d => { return new SelectListItem() { Text = d.Nombre.ToString(), Value = d.IdC.ToString() }; });
            List<SelectListItem> itemsPais = listaPais.ConvertAll(d => { return new SelectListItem() { Text = d.Pais.ToString(), Value = d.IdP.ToString() }; });
            ViewBag.itemsCiudad = itemsCiudad;
            ViewBag.itemsPais = itemsPais;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ProveedorModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_AgregarProveedor(model.IdC, model.Nombre, model.Contacto, model.Telefono, model.Correo, model.LimCredito);
                    }
                    return Redirect("~/Proveedor");
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
                List<ProveedorModel> listaCiudad = null;
                List<ProveedorModel> listaPais = null;
                ProveedorModel model = new ProveedorModel();
                using (CPMEntities datos = new CPMEntities())
                {
                    listaCiudad = (from d in datos.CIUDAD select new ProveedorModel { IdC = d.IdCiudad, Ciudad = d.Nombre }).ToList();
                    listaPais = (from d in datos.PAIS select new ProveedorModel { IdP = d.IdPais, Pais = d.Nombre }).ToList();
                }
                List<SelectListItem> itemsCiudad = listaCiudad.ConvertAll(d => { return new SelectListItem() { Text = d.Ciudad.ToString(), Value = d.IdC.ToString(), Selected = false }; });
                List<SelectListItem> itemsPais = listaPais.ConvertAll(d => { return new SelectListItem() { Text = d.Pais.ToString(), Value = d.IdP.ToString(), Selected = false }; });
                ViewBag.itemsCiudad = itemsCiudad;
                ViewBag.itemsPais = itemsPais;
                using (CPMEntities datos = new CPMEntities())
                {
                    var tabla = datos.PROVEEDOR.Find(Id);
                    model.ID = tabla.IdProveedor;
                    model.Nombre = tabla.Nombre;
                    model.Contacto = tabla.Contacto;
                    model.IdC = tabla.IdCiudad;
                    model.Telefono = tabla.Telefono;
                    model.Correo = tabla.Correo;
                    model.LimCredito = tabla.LimiteCredito;
                    var t = datos.CIUDAD.Find(model.IdC);
                    model.IdP = t.IdPais;
                }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Editar(ProveedorModel model)
        {
            try
            {
                using (CPMEntities datos = new CPMEntities())
                {
                    datos.sp_EditarProveedor(model.ID, model.IdC, model.Nombre, model.Contacto, model.Telefono, model.Correo, model.LimCredito);
                }
                return Redirect("~/Proveedor");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public ActionResult EliminarProveedor(int Id)
        {
            using (CPMEntities datos = new CPMEntities())
            {
                datos.sp_Eliminar("PROVEEDOR", Id);
            }
            return Redirect("~/Proveedor");

        }
    }
}