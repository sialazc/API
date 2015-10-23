using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ServiceGroupe
    {
        #region Singleton
        private ServiceGroupe() { }
        private static ServiceGroupe _instance;
        public static ServiceGroupe Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceGroupe();
                return _instance;
            }
        }
        #endregion

        #region Add
        public bool Add(Groupe group)
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    manager.Groupe.Add(group);
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

        public List<Groupe> LoadAll()
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    return manager.Groupe.ToList();
                }
            }
            catch
            {

                return null;
            }
        }

        public Groupe LoadByPrimaryKey(int GroupId)
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    return manager.Groupe.Where(x => x.Id == GroupId).First();
                }
            }
            catch
            {

                return null;
            }
        }

        public List<Groupe> LoadByField(string Field, string Value)
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    switch (Field)
                    {
                        case "Nom":
                            return manager.Groupe.Where(x => x.Nom == Value).ToList();
                            break;
                        case "Description":
                            return manager.Groupe.Where(x => x.Description == Value).ToList();
                            break;
                        default:
                            return null;
                            break;
                    }

                }
            }
            catch
            {

                return null;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    manager.Groupe.Remove(manager.Groupe.Where(x=>x.Id == Id).First());
                    manager.SaveChanges();
                    return true;
                }
            }
            catch
            {

                return false;
            }
        }

        public bool Update(Groupe groupe)
        {
            try
            {
                using (APIEntities manager = new APIEntities())
                {
                    Groupe groupeE = manager.Groupe.Where(x => x.Id == groupe.Id).First();
                    manager.Groupe.Attach(groupeE);
                    manager.Entry(groupeE).State = System.Data.Entity.EntityState.Modified;
                    manager.SaveChanges();
                    return true;
                }
            }
            catch
            {

                return false;
            }
        }
    }
}