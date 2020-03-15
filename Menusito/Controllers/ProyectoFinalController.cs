using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Menusito.Datos;
using Menusito.Models.ViewModels;

namespace Menusito.Controllers
{
    public class ProyectoFinalController : Controller
    {
        // GET: ProyectoFinal
        public ActionResult Index()
        {
            List<ListaUsuarioModel> lista;
            using (CPMEntities datos = new CPMEntities())
            {
                lista = (from d in datos.vw_UsuariosActivos select new ListaUsuarioModel{Id = d.IdUsuario,Usuario = d.Nombre,Contra = d.Contrasenia,Estado = d.Estado}).ToList();
            }
            return View(lista);
        }
        public ActionResult Agregar()
        {
            List<AgregarUsuarioModel> listaEmp = null;
            List<AgregarUsuarioModel> listaRol = null;
            using (CPMEntities datos = new CPMEntities())
            {
                listaRol=(from d in datos.DEPARTAMENTO select new AgregarUsuarioModel { IdRol=d.IdDepartamento,Nombre=d.Nombre}).ToList();
                listaEmp = (from d in datos.EMPLEADO select new AgregarUsuarioModel { IdEmp = d.IdEmpleado, NombreEmp = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsEmp = listaEmp.ConvertAll(d =>{return new SelectListItem(){Text = d.NombreEmp.ToString(),Value = d.IdEmp.ToString(),Selected = false};});
            List<SelectListItem> items = listaRol.ConvertAll(d => { return new SelectListItem() { Text = d.Nombre, Value = d.IdRol.ToString() }; });
            ViewBag.items = items;
            ViewBag.itemsEmp = itemsEmp;
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(AgregarUsuarioModel model) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos=new CPMEntities())
                    {
                        datos.sp_AgregarUsuario(model.IdEmp,model.Usuario,model.Contra,model.IdRol);
                    }
                    return Redirect("~/ProyectoFinal/");
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
            List<AgregarUsuarioModel> lista = null;
            List<AgregarUsuarioModel> listaEmpleado = null;
            using (CPMEntities datos = new CPMEntities())
            {
                lista = (from d in datos.DEPARTAMENTO select new AgregarUsuarioModel { IdRol = d.IdDepartamento, Nombre = d.Nombre }).ToList();
                listaEmpleado = (from d in datos.EMPLEADO select new AgregarUsuarioModel { IdEmp = d.IdEmpleado, NombreEmp = d.Nombre }).ToList();
            }
            List<SelectListItem> items = lista.ConvertAll(d => { return new SelectListItem() { Text = d.Nombre, Value = d.IdRol.ToString() }; });
            List<SelectListItem> itemsEmp = listaEmpleado.ConvertAll(d =>{return new SelectListItem(){Text = d.NombreEmp.ToString(),Value = d.IdEmp.ToString(),Selected = false};});
            ViewBag.items = items;
            ViewBag.itemsEmp = itemsEmp;

            AgregarUsuarioModel model = new AgregarUsuarioModel();
            using (CPMEntities datos=new CPMEntities())
            {
                var tabla = datos.USUARIO.Find(Id);
                model.Usuario = tabla.Nombre;
                model.Contra = tabla.Contrasenia;
                model.Id = tabla.IdUsuario;
                model.IdEmp = tabla.IdEmpleado;
                model.IdRol = tabla.Rol;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(AgregarUsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<AgregarUsuarioModel> lista = null;
                    using (CPMEntities datos = new CPMEntities())
                    {
                        lista = (from d in datos.DEPARTAMENTO select new AgregarUsuarioModel { IdRol = d.IdDepartamento, Nombre = d.Nombre }).ToList();

                        datos.sp_EditarUsuario(model.Id, model.Usuario, model.Contra, model.IdRol);
                    }
                    return Redirect("~/ProyectoFinal/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ActionResult Eliminar(int Id)
        {
            AgregarUsuarioModel model = new AgregarUsuarioModel();
            using (CPMEntities datos = new CPMEntities())
            {
                var tabla = datos.sp_Eliminar("USUARIO", Id);
            }
            return Redirect("~/ProyectoFinal/");
        }

        public ActionResult Empleado()
        {
            List<ListaEmpleadoModel> listaEmpleado;
            using (CPMEntities datos = new CPMEntities())
            {
                listaEmpleado = (from d in datos.vw_EmpleadosActivos select new ListaEmpleadoModel{Id = d.IdEmpleado, Nombre = d.Nombre,Estado = (int)d.Estado}).ToList();
            }
            return View(listaEmpleado);
        }
        public ActionResult AgregarEmpleado()
        {
            List<AgregarEmpleadoModel> listaDepto = null;
            using (CPMEntities datos = new CPMEntities())
            {
                listaDepto = (from d in datos.DEPARTAMENTO select new AgregarEmpleadoModel { IdDeptoD = d.IdDepartamento, NombreDepto = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsDepto = listaDepto.ConvertAll(d =>{return new SelectListItem(){Text = d.NombreDepto.ToString(),Value = d.IdDeptoD.ToString(),Selected = false};});
            ViewBag.itemsDepto = itemsDepto;
            return View();
        }
        [HttpPost]
        public ActionResult AgregarEmpleado(AgregarEmpleadoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_AgregarEmpleado(model.IdDeptoD, model.Nombre);
                    }
                    return Redirect("~/ProyectoFinal/Empleado");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult EditarEmpleado(int Id)
        {
            List<AgregarEmpleadoModel> listaDepto = null;
            AgregarEmpleadoModel model = new AgregarEmpleadoModel();
            using (CPMEntities datos=new CPMEntities())
            {
                listaDepto = (from d in datos.DEPARTAMENTO select new AgregarEmpleadoModel { IdDeptoD = d.IdDepartamento, NombreDepto = d.Nombre }).ToList();
            }
            List<SelectListItem> itemsDepto = listaDepto.ConvertAll(d => { return new SelectListItem() { Text = d.NombreDepto.ToString(), Value = d.IdDeptoD.ToString(), Selected = false }; });
            ViewBag.itemsDepto = itemsDepto;
            using (CPMEntities datos = new CPMEntities()){var tabla = datos.EMPLEADO.Find(Id);model.IdDeptoD = tabla.IdDepartamento;model.Nombre = tabla.Nombre;model.idEmpleado = tabla.IdEmpleado;}

            
            return View(model);
        }
        [HttpPost]
        public ActionResult EditarEmpleado(AgregarEmpleadoModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (CPMEntities datos = new CPMEntities())
                    {
                        datos.sp_EditarEmpleado(model.idEmpleado, model.Nombre, model.IdDeptoD);

                    }
                    return Redirect("~/ProyectoFinal/Empleado");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult EliminarEmpleado(int Id)
        {
            using (CPMEntities datos = new CPMEntities())
            {
                var tabla = datos.sp_Eliminar("EMPLEADO", Id);
            }
            return Redirect("~/ProyectoFinal/Empleado");

        }
               
    }

}