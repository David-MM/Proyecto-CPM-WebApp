using System;
using Menusito.Datos;
using Menusito.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class RequisicionController : Controller
    {
        // GET: Requisicion
        public ActionResult Index()
        {
            List<RequisicioModel> listacliente = null;
            List<RequisicioModel> listaProducto = null;
            List<RequisicioModel> listaBodega = null;
            using (CPMEntities datos = new CPMEntities())
            {
                listacliente = (from d in datos.Fn_Cliente(1) select new RequisicioModel { IdCliente = d.ID, NombreCliente = d.Nombrecliente }).ToList();
                listaProducto = (from d in datos.PRO_Productos(1) select new RequisicioModel { IdProducto = d.ID, NombreProducto = d.Producto, Valor = d.Precio }).ToList();
                listaBodega = (from d in datos.PRO_Bodega(1) select new RequisicioModel { IdBodega = d.IdBodega, NombreBodega = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsCliente = listacliente.ConvertAll(d => { return new SelectListItem() { Text = d.NombreCliente, Value = d.IdCliente.ToString() }; });
            List<SelectListItem> itemsProducto = listaProducto.ConvertAll(d => { return new SelectListItem() { Text = d.NombreProducto, Value = d.IdProducto.ToString() }; });
            List<SelectListItem> itemsBodega = listaBodega.ConvertAll(d => { return new SelectListItem() { Text = d.NombreBodega, Value = d.IdBodega.ToString() }; });
            ViewBag.itemsCliente = itemsCliente;
            ViewBag.itemsProducto = itemsProducto;
            ViewBag.itemsBodega = itemsBodega;
            return View();
        }
        [HttpPost]
        public ActionResult Index(RequisicioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_Requisito((int)Session["User"], model.IdCliente, "C");

                        foreach (var item in model.DetalleRequisicion)
                        {
                            datos.sp_RequisitoDetalle(1,item.IdProducto,item.IdBodega,item.Cantidad,item.Valor,item.ISV);
                        }
                    }
                }
                return Redirect("~/Home/");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public JsonResult Producto(int IdProducto)
        {
            using (CPMEntities datos = new CPMEntities())
            {
                var bodegas = Json(datos.SP_ConsultarProductoEnBodega(IdProducto).ToList(), JsonRequestBehavior.AllowGet);
                return bodegas;
            }
        }

    }
}