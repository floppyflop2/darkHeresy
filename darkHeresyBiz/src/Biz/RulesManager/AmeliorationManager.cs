using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class AmeliorationManager : BusinessLogic
    {
        public override object GetAll()
        {
            object ameliorationList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    ameliorationList = db.Ameliorations.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return ameliorationList;
        }

        public override object Get(object obj)
        {
            Amelioration amelioration;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    amelioration = db.Ameliorations.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return amelioration;
        }

        public override object Add(object obj)
        {
            object ameliorationList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Ameliorations.Add((Amelioration)obj);
                    ameliorationList = db.Ameliorations.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return ameliorationList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Ameliorations.Remove((Amelioration)obj);
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
                    db.Ameliorations.Remove(db.Ameliorations.First(w => w.AmeliorationId == id));
                    db.Ameliorations.Add((Amelioration)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
