using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Login()
        {
            try
            {
                string login = Request.Form.Get("Login");
                string password = Request.Form.Get("Password");
                string apiKey = Request.Form.Get("ApiKey");
                string token = "";
                if (ServiceUser.Instance.Login(login, password, apiKey))
                    token = ServiceToken.Instance.GenerateToken();
                if (string.IsNullOrEmpty(token))
                    throw new Exception("Token de session non créer");
                var dict = new Dictionary<object, object>();
                dict.Add("Token", token);
                return Json(dict);

            }
            catch (Exception e)
            {
                var dict = new Dictionary<object, object>();
                dict.Add("Error", e.Message);
                return Json(dict);
            }
        }
	}
}