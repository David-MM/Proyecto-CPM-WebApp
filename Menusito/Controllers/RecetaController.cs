using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class RecetaController : Controller
    {
        // GET: Receta
        public ActionResult Index(int ID)
        {
            ResetaModel model = new ResetaModel();
            model.IdProducto = ID;
            List<RecetaDetalleModal> lstProducto = null;
            using (CPMEntities datos = new CPMEntities())
            {
                model.Producto = datos.PRODUCTO.Find(ID).Nombre;
                lstProducto = (from d in datos.SP_ProductoFiltrado(ID) select new RecetaDetalleModal { IdproductoE = d.IdProducto, Producto2 = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsProducto = lstProducto.ConvertAll(d => { return new SelectListItem() { Text = d.Producto2, Value = d.IdproductoE.ToString() }; });
            ViewBag.itemsProducto = itemsProducto;
            ViewBag.NombreProducto = model.Producto;
            ViewBag.IdProduc = ID;
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ResetaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {

                        foreach (var item in model.lstProductos)
                        {
                            datos.sp_AgregarReceta(model.IdProducto, item.IdproductoE, item.Cantidad);
                        }
                    }
                }
                return Redirect("~/Home");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult ProductosRecetas()
        {
            try
            {
                List<ProductoModel> lstProducto;
                using (CPMEntities datos = new CPMEntities())
                {
                    lstProducto = (from d in datos.SP_ListarProducosConOsinReceta(0) select new ProductoModel { IdProducto = d.IdProducto, Nombre = d.Nombre}).ToList();
                }
                return View(lstProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult ProductosProducir()
        {
            try
            {
                List<ProductoModel> lstProducto;
                using (CPMEntities datos = new CPMEntities())
                {
                    lstProducto = (from d in datos.SP_ListarProducosConOsinReceta(1) select new ProductoModel { IdProducto = d.IdProducto, Nombre = d.Nombre }).ToList();
                }
                return View(lstProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Producir(int ID)
        {
            ResetaModel model = new ResetaModel();
            List<OrdenComparModel> listaBodega = null;
            model.IdProducto = ID;
            List<RecetaDetalleModal> lstProducto = null;
            using (CPMEntities datos = new CPMEntities())
            {
                model.Producto = datos.PRODUCTO.Find(ID).Nombre;
                lstProducto = (from d in datos.Fn_ListaReceta(ID) select new RecetaDetalleModal { IdproductoE = d.IdProductoMaterial, Producto2 = d.Producto, Cantidad = d.Cantidad, Costo = d.Costo }).ToList();
                listaBodega = (from d in datos.PRO_Bodega(1) select new OrdenComparModel { IdBodega = d.IdBodega, NombreBodega = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsBodega = listaBodega.ConvertAll(d => { return new SelectListItem() { Text = d.NombreBodega, Value = d.IdBodega.ToString() }; });
            ViewBag.itemsBodega = itemsBodega;
            model.lstProductos = lstProducto;
            ViewBag.NombreProducto = model.Producto;
            return View(model);
        }

        [HttpPost]
        public ActionResult Producir(ResetaModel model)
        {
            List<RecetaDetalleModal> lstProducto = null;
            try
            {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        lstProducto = (from d2 in datos.Fn_ListaReceta(model.IdProducto) select new RecetaDetalleModal { IdproductoE = d2.IdProductoMaterial, Producto2 = d2.Producto, Cantidad = d2.Cantidad, Costo = d2.Costo }).ToList();
                        var d = datos.sp_Produccion((int)Session["User"], model.IdProducto, model.Cantidad, model.IdBodega);

                        foreach (var item in lstProducto)
                        {
                            datos.sp_ProduccionDetalle(d,item.IdproductoE,1,DateTime.Now,item.Cantidad*model.Cantidad);
                        }
                    }
                return Redirect("~/Home/");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
