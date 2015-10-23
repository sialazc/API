using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class GroupeController : Controller
    {
        [HttpPost]
        public ActionResult Add(string token = "")
        {

            try
            {
                if (!ServiceToken.Instance.IsValidToken(token))
                    throw new Exception("Token non valide");
                string nom = Request.Form.Get("Nom");
                if(string.IsNullOrEmpty(nom))
                    throw new Exception("Nom du groupe obligatoire");
                string description = Request.Form.Get("Description");
                Groupe groupe = new Groupe();
                groupe.Nom = nom;
                groupe.Description = description;
                if (ServiceGroupe.Instance.Add(groupe))
                    return Json(groupe);
                else
                    throw new Exception("Erreur d'enregistrement du groupe");
            }
            catch (Exception e)
            {
                var dict = new Dictionary<object, object>();
                dict.Add("Error", e.Message);
                return Json(dict);
            }
        }
        [HttpGet]
        public ActionResult LoadAll(string token = "")
        {

            try
            {
                if (!ServiceToken.Instance.IsValidToken(token))
                    throw new Exception("Token non valide");

                List<Groupe> ListGroupe = ServiceGroupe.Instance.LoadAll();
                if (ListGroupe == null)
                    throw new Exception("Erreur de selection des groupes");
                return Json(ListGroupe, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var dict = new Dictionary<object, object>();
                dict.Add("Error", e.Message);
                return Json(dict, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Load(string token = "")
        {

            try
            {
                if (!ServiceToken.Instance.IsValidToken(token))
                    throw new Exception("Token non valide");
                string GroupId = Request.Form.Get("GroupId");
                int Id = 0;
                if (!int.TryParse(GroupId, out Id))
                    throw new Exception("Group Id non accepté");
                Groupe Groupe = ServiceGroupe.Instance.LoadByPrimaryKey(Id);
                if (Groupe == null)
                    throw new Exception("Erreur de selection du groupe");
                return Json(Groupe);
            }
            catch (Exception e)
            {
                var dict = new Dictionary<object, object>();
                dict.Add("Error", e.Message);
                return Json(dict);
            }
        }

        [HttpPost]
        public ActionResult Delete(string token = "")
        {
            var dict = new Dictionary<object, object>();
            try
            {
                if (!ServiceToken.Instance.IsValidToken(token))
                    throw new Exception("Token non valide");
                string GroupId = Request.Form.Get("GroupId");
                int Id = 0;
                if (!int.TryParse(GroupId, out Id))
                    throw new Exception("Group Id non accepté");
               bool result = ServiceGroupe.Instance.Delete(Id);
               return Json(result);
            }
            catch (Exception e)
            {
                
                dict.Add("Error", e.Message);
                return Json(dict);
            }
        }

        [HttpPost]
        public ActionResult Update(string token = "")
        {
            var dict = new Dictionary<object, object>();
            try
            {
                if (!ServiceToken.Instance.IsValidToken(token))
                    throw new Exception("Token non valide");
                string GroupId = Request.Form.Get("GroupId");
                int Id = 0;
                if (!int.TryParse(GroupId, out Id))
                    throw new Exception("Group Id non accepté");
                string nom = Request.Form.Get("Nom");
                string description = Request.Form.Get("Description");
                Groupe groupe = new Groupe();
                groupe.Id = Id;
                groupe.Nom = nom;
                groupe.Description = description;
                if (ServiceGroupe.Instance.Update(groupe))
                    return Json(groupe);
                else
                    throw new Exception("Erreur d'enregistrement du groupe");
            }
            catch (Exception e)
            {

                dict.Add("Error", e.Message);
                return Json(dict);
            }
        }


        [HttpPost]
        public ActionResult LoadBy(string token = "")
        {
            try
            {
                if (!ServiceToken.Instance.IsValidToken(token))
                    throw new Exception("Token non valide");
                string[] Fields = { "Nom", "Description" };
                string Field = Request.Form.Get("Field");
                if (!Fields.Contains(Field))
                    throw new Exception("Champ " + Field + " non existant");
                string Value = Request.Form.Get("Value");

                List<Groupe> ListGroupe = ServiceGroupe.Instance.LoadByField(Field, Value);
                if (ListGroupe == null)
                    throw new Exception("Erreur de selection des groupes");
                return Json(ListGroupe);
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