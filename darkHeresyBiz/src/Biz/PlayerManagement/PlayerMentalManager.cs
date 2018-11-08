using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerMentalManagement
{
    public class PlayerMentalManager : BusinessLogic
    {
        public override object GetAll()
        {
            object playerMentalList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    playerMentalList = db.PlayerMentals.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return playerMentalList;
        }

        public override object Get(object obj)
        {
            PlayerMental playerMental;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    playerMental = db.PlayerMentals.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return playerMental;
        }

        public override object Add(object obj)
        {
            object playerMentalList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.PlayerMentals.Add((PlayerMental)obj);
                    playerMentalList = db.PlayerMentals.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return playerMentalList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.PlayerMentals.Remove((PlayerMental)obj);
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
                    db.PlayerMentals.Remove(db.PlayerMentals.First(w => w.PlayerMentalId == id));
                    db.PlayerMentals.Add((PlayerMental)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
