using Menusito.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menusito.Filters
{
    public class VerificacionSeccion : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}