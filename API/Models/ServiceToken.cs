using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ServiceToken
    {
        #region Singleton
        private ServiceToken() { }
        private static ServiceToken _instance;
        public static ServiceToken Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceToken();
                return _instance;
            }
        }
        #endregion

        #region Add
        public bool Add(Token token)
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    manager.Token.Add(token);
                    manager.SaveChanges();
                    return true;
                }
            }
            catch
            {

                return false;
            }
        }
        #endregion

        public bool IsValidToken(string token)
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    return manager.Token.Where(x => x.SessionToken == token && DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(DateTime.Now)).Count() != 0;
                }
            }
            catch
            {

                return false;
            }
        }

        public string GenerateToken()
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    Token token = null;
                    int count = manager.Token.Count();
                    if (count != 0)
                    {
                        List<Token> elements = manager.Token.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(DateTime.Now)).ToList();
                        if(elements != null && elements.Count > 0){
                            token = elements.First();
                        }
                    }
                        

                    if (token == null)
                    {
                        token = new Token();
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(DateTime.Now.Ticks.ToString());
                        token.SessionToken = System.Convert.ToBase64String(plainTextBytes);
                        token.Date = DateTime.Now;
                        manager.Token.Add(token);
                        manager.SaveChanges();
                        return token.SessionToken;
                    }
                    else
                        return token.SessionToken;
                }
            }
            catch
            {
                return "";
            }
        }
    }
}