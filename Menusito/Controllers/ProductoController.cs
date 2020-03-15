using Menusito.Datos;
using Menusito.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Menusito.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            try
            {
                List<ProductoModel> lstProducto;
                using (CPMEntities datos = new CPMEntities())
                {
                    lstProducto = (from d in datos.PRO_Productos(1) select new ProductoModel { IdProducto = d.ID, Nombre = d.Producto, ExistenciaMinima = d.ExistenciaMinima, Precio = d.Precio }).ToList();
                }
                return View(lstProducto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ProductoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_AgregarProducto(model.Nombre, model.ExistenciaMinima, model.Precio);
                    }
                    return Redirect("~/Producto");
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
                ProductoModel model = new ProductoModel();

                using (CPMEntities datos = new CPMEntities())
                {
                    var tabla = datos.PRODUCTO.Find(Id);
                    model.IdProducto = tabla.IdProducto;
                    model.Nombre = tabla.Nombre;
                    model.ExistenciaMinima = tabla.ExistenciaMinima;
                    model.Precio = tabla.Precio;
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Editar(ProductoModel model)
        {
            try
            {
                using (CPMEntities datos = new CPMEntities())
                {
                    datos.sp_EditarProducto(model.IdProducto, model.Nombre, model.ExistenciaMinima, model.Precio);
                }
                return Redirect("~/Producto");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult EliminarProducto(int Id)
        {
            using (CPMEntities datos = new CPMEntities())
            {
                datos.sp_Eliminar("Producto", Id);
            }
            return Redirect("~/Producto");

        }
    }
}
