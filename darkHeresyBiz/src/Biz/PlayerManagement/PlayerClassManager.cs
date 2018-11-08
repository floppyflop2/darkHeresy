using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class PlayerClassManager : BusinessLogic
    {
        public override object GetAll()
        {
            object playerClassList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    playerClassList = db.PlayerClasses.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return playerClassList;
        }

        public override object Get(object obj)
        {
            PlayerClass playerClass;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    playerClass = db.PlayerClasses.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return playerClass;
        }

        public override object Add(object obj)
        {
            object playerClassList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.PlayerClasses.Add((PlayerClass)obj);
                    playerClassList = db.PlayerClasses.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return playerClassList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.PlayerClasses.Remove((PlayerClass)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override void Modify(object obj)
        {
            int id = Check(obj);
            if (id == -1)
                return;
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.PlayerClasses.Remove(db.PlayerClasses.First(w => w.PlayerClassId == id));
                    db.PlayerClasses.Add((PlayerClass)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
