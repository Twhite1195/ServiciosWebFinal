using ServicioWebAvance2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ServicioWebAvance2.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LogIn(string usuario, string password)
        {
            // Lista usuarios
            UsuariosController controller = new UsuariosController();
            List<Usuario> listUsuarios = controller.ListUsuarios();
            Boolean encontrado = false;
            foreach (var user in listUsuarios)
            {
                if (user.Nombre_Usuario.Equals(usuario) && user.Pass_Usuario.Equals(password))
                {
                    encontrado = true;
                    break;
                }
            }

            if (encontrado)
            {
                FormsAuthentication.SetAuthCookie(usuario, false);
                return Json(1);
            }
            else
            {
                return Json(-1);
            }


        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/");
        }
    }
}