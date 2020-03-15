using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteModel> lista;
            using (CPMEntities datos = new CPMEntities())
            {
                lista = (from d in datos.Fn_Cliente(1) select new ClienteModel { IdCliente=d.ID,Ciudad=d.Ciudad,Nombre=d.Nombrecliente,Pais=d.Pais,Contacto=d.Contacto,Telefono=d.Telefono,Correo=d.Correo,LimCredito=d.LimiteCredito,DeudaPagar=d.Deuda,CreditoDisponible=d.CreditoDisponible,Descuento=d.Descuento}).ToList();
            }
            return View(lista);
        }
        public ActionResult Agregar()
        {
            List<ClienteModel> listaCiudad = null;
            List<ClienteModel> listaPais = null;
            using (CPMEntities datos = new CPMEntities())
            {
                listaCiudad = (from d in datos.CIUDAD select new ClienteModel { IdCiudad = d.IdCiudad, Nombre = d.Nombre }).ToList();
                listaPais = (from d in datos.PAIS select new ClienteModel { IdPais = d.IdPais, Pais = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsCiudad = listaCiudad.ConvertAll(d => { return new SelectListItem() { Text = d.Nombre.ToString(), Value = d.IdCiudad.ToString(), Selected = false }; });
            List<SelectListItem> itemsPais = listaPais.ConvertAll(d => { return new SelectListItem() { Text = d.Pais.ToString(), Value = d.IdPais.ToString(), Selected = false }; });
            ViewBag.itemsCiudad = itemsCiudad;
            ViewBag.itemsPais = itemsPais;
            return View();
        }
       
        [HttpPost]
        public ActionResult Agregar(ClienteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_AgregarCliente(model.IdCiudad,model.Nombre,model.Contacto, model.Telefono, model.Correo, model.LimCredito,model.Descuento/100);
                    }
                    return Redirect("~/Cliente/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int  Id)
        {
            try
            {
                List<ClienteModel> listaCiudad = null;
                List<ClienteModel> listaPais = null;
                ClienteModel model = new ClienteModel();
                using (CPMEntities datos = new CPMEntities())
                {
                    listaCiudad = (from d in datos.CIUDAD select new ClienteModel { IdCiudad = d.IdCiudad, Nombre = d.Nombre }).ToList();
                    listaPais = (from d in datos.PAIS select new ClienteModel { IdPais = d.IdPais, Pais = d.Nombre }).ToList();
                }
                List<SelectListItem> itemsCiudad = listaCiudad.ConvertAll(d => { return new SelectListItem() { Text = d.Nombre.ToString(), Value = d.IdCiudad.ToString(), Selected = false }; });
                List<SelectListItem> itemsPais = listaPais.ConvertAll(d => { return new SelectListItem() { Text = d.Pais.ToString(), Value = d.IdPais.ToString(), Selected = false }; });
                ViewBag.itemsCiudad = itemsCiudad;
                ViewBag.itemsPais = itemsPais;
                using (CPMEntities datos = new CPMEntities()) { var tabla = datos.CLIENTE.Find(Id); model.IdCliente = tabla.IdCliente; model.Nombre = tabla.Nombre;model.Contacto = tabla.Contacto; model.IdCiudad = tabla.IdCiudad; model.Telefono = tabla.Telefono; model.Correo = tabla.Correo; model.LimCredito = tabla.LimiteCredito;model.Descuento = tabla.Descuento; var Idpais = datos.CIUDAD.Find(model.IdCiudad);model.IdPais = Idpais.IdPais; }
                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Editar(ClienteModel model)
        {
            try
            {
                using (CPMEntities datos=new CPMEntities())
                {
                    datos.sp_EditarCliente(model.IdCliente, model.IdCiudad, model.Nombre,model.Contacto, model.Telefono, model.Correo, model.LimCredito,model.Descuento);
                }
                return Redirect("~/Cliente/");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public ActionResult EliminarCliente(int Id)
        {
            using (CPMEntities datos = new CPMEntities())datos.sp_EliminarCliente(Id);
            return Redirect("~/Cliente/");

        }
    }
}