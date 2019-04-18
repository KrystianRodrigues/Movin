using M0v1n.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace M0v1n.Repositories
{
    public class Funcoes
    {
        public static bool AutenticarUsuario(string login, string senha)
        {
            Context _db = new Context();
            var usu = (from u in _db.Usuarios where u.EmailUsuario == login && u.SenhaUsuario == senha select u).SingleOrDefault();
            if (usu == null)
            {
                var loc = (from u in _db.Locadores where u.EmailLocador == login && u.SenhaLocador == senha select u).SingleOrDefault();
                if (loc == null)
                {
                    return false;
                }
                FormsAuthentication.SetAuthCookie(loc.EmailLocador, false);
                //HttpContext.Current.Response.Cookies["Usuario"].Value = query.Email;
                //HttpContext.Current.Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(10);
                HttpContext.Current.Session["Usuario"] = loc.EmailLocador;
                return true;
            }

            FormsAuthentication.SetAuthCookie(usu.EmailUsuario, false);
            //HttpContext.Current.Response.Cookies["Usuario"].Value = query.Email;
            //HttpContext.Current.Response.Cookies["Usuario"].Expires = DateTime.Now.AddDays(10);
            HttpContext.Current.Session["Usuario"] = usu.EmailUsuario;
            return true;
        }

       

        public static Usuario GetUsuario()
        {
            string _login = HttpContext.Current.User.Identity.Name;
            //if (HttpContext.Current.Request.Cookies.Count > 0 || HttpContext.Current.Request.Cookies["Usuario"] != null)
            if (HttpContext.Current.Session.Count > 0 || HttpContext.Current.Session["Usuario"] != null)
            {
                _login = HttpContext.Current.Session["Usuario"].ToString();
                //_login = HttpContext.Current.Request.Cookies["Usuario"].Value.ToString();
                if (_login == "")
                {
                    return null;
                }
                else
                {
                    Context _db = new Context();
                    Usuario usuario = (from u in _db.Usuarios
                                       where u.EmailUsuario == _login
                                       select u).SingleOrDefault();
                    return usuario;
                }
            }
            else
            {
                return null;
            }
        }
        public static Usuario GetUsuario(string _login)
        {
            if (_login == "")
            {
                return null;
            }
            else
            {
                Context _db = new Context();
                Usuario usuario = (from u in _db.Usuarios
                                   where u.EmailUsuario == _login
                                   select u).SingleOrDefault();
                return usuario;
            }
        }
        public static Locador GetLocador()
        {
            string _login = HttpContext.Current.User.Identity.Name;
            //if (HttpContext.Current.Request.Cookies.Count > 0 || HttpContext.Current.Request.Cookies["Usuario"] != null)
            if (HttpContext.Current.Session.Count > 0 || HttpContext.Current.Session["Usuario"] != null)
            {
                _login = HttpContext.Current.Session["Usuario"].ToString();
                //_login = HttpContext.Current.Request.Cookies["Usuario"].Value.ToString();
                if (_login == "")
                {
                    return null;
                }
                else
                {
                    Context _db = new Context();
                    Locador locador = (from u in _db.Locadores
                                       where u.EmailLocador == _login
                                       select u).SingleOrDefault();
                    return locador;
                }
            }
            else
            {
                return null;
            }
        }
        public static Locador GetLocador(string _login)
        {
            if (_login == "")
            {
                return null;
            }
            else
            {
                Context _db = new Context();
                Locador locador = (from u in _db.Locadores
                                   where u.EmailLocador == _login
                                   select u).SingleOrDefault();
                return locador;
            }
        }
        public static void Deslogar()
        {
            HttpContext.Current.Session["Usuario"] = "";
            //HttpContext.Current.Response.Cookies["Usuario"].Value = "";
            FormsAuthentication.SignOut();
        }
    }
}