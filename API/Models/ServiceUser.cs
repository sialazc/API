using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ServiceUser
    {
        #region Singleton
        private ServiceUser() { }
        private static ServiceUser _instance;
        public static ServiceUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceUser();
                return _instance;
            }
        }
        #endregion

        public bool Login(string login, string password, string apiKey)
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    User loggedUser = manager.User.Where(x => x.Login == login && x.Password == password && apiKey == Global.ApiKey).First();
                    return loggedUser != null;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}