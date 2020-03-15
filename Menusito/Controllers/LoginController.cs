using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Menusito.Datos;
using Menusito.Models.ViewModels;

namespace Menusito.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            LogiarModel model = new LogiarModel();
            model.mensaje = "";
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(LogiarModel model)
        {
            try
            {
                string messge = "   Incompleto";
                if (ModelState.IsValid)
                {
                    int? userId;
                    using (CPMEntities datos = new CPMEntities())
                    {
                        userId = datos.Validar_Usuario(model.Usuario, model.Password).FirstOrDefault();
                        Console.WriteLine(userId.Value);
                    }
                    switch (userId.Value)
                    {
                        case -1:
                            messge = "   Usuario / Cotraseña Incorrecta";
                            break;
                        case -2:
                            messge = "    Usuario Inabilitado";
                            break;
                        default:
                            model.Id = userId.Value;
                            Session["User"] = userId.Value;
                            return Redirect("~/Home/Index");
                    }
                }
                model.mensaje = messge;
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
