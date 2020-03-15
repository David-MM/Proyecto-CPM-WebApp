using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class OrdenCompraController : Controller
    {
        public ActionResult Index()
        {
            List<OrdenComparModel> listaProveedor = null;
            List<OrdenComparModel> listaProducto = null;
            List<OrdenComparModel> listaBodega = null;
            using (CPMEntities datos = new CPMEntities())
            {
                listaProveedor = (from d in datos.Fn_Proveedor(1) select new OrdenComparModel { IdProveedor = d.ID, NombreProveedor = d.NombreProveedor }).ToList();
                listaProducto = (from d in datos.PRO_Productos(1) select new OrdenComparModel { IdProducto = d.ID, NombreProducto = d.Producto, Valor = d.Precio }).ToList();
                listaBodega = (from d in datos.PRO_Bodega(1) select new OrdenComparModel { IdBodega = d.IdBodega, NombreBodega = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsProveedor = listaProveedor.ConvertAll(d => { return new SelectListItem() { Text = d.NombreProveedor, Value = d.IdProveedor.ToString() }; });
            List<SelectListItem> itemsProducto = listaProducto.ConvertAll(d => { return new SelectListItem() { Text = d.NombreProducto, Value = d.IdProducto.ToString() }; });
            List<SelectListItem> itemsBodega = listaBodega.ConvertAll(d => { return new SelectListItem() { Text = d.NombreBodega, Value = d.IdBodega.ToString() }; });
            ViewBag.itemsProveedor = itemsProveedor;
            ViewBag.itemsProducto = itemsProducto;
            ViewBag.itemsBodega = itemsBodega;
            return View();
        }
        [HttpPost]
        public ActionResult Index(OrdenComparModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        //datos.sp_Requisito((int)Session["User"], model.IdProveedor, "C");
                        datos.sp_OrdenCompra((int)Session["User"], model.IdProveedor, "C");

                        foreach (var item in model.DetalleOrendenCompra)
                        {
                            //datos.sp_RequisitoDetalle(1, item.IdProducto, item.IdBodega, item.Cantidad, item.Valor, item.ISV);
                            datos.sp_OrdenCompraDetalle(1, item.IdProducto, item.IdBodega, DateTime.Now, item.Cantidad, item.Valor, item.ISV);
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

        public int Proveedor(int IdProveedor)
        {
            using (CPMEntities datos = new CPMEntities())
            {
                var bodegas = Json(datos.PROVEEDOR.Find(IdProveedor), JsonRequestBehavior.AllowGet);
                return 1;
            }
        }
    }
}
