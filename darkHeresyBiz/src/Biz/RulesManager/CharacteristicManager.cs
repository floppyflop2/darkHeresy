using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class CharacteristicManager : BusinessLogic
    {
        public override object GetAll()
        {
            object characteristicList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    characteristicList = db.Characteristics.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return characteristicList;
        }

        public override object Get(object obj)
        {
            Characteristic characteristic;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    characteristic = db.Characteristics.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return characteristic;
        }

        public override object Add(object obj)
        {
            object characteristicList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Characteristics.Add((Characteristic)obj);
                    characteristicList = db.Characteristics.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return characteristicList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Characteristics.Remove((Characteristic)obj);
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
                    db.Characteristics.Remove(db.Characteristics.First(w => w.CharacteristicId == id));
                    db.Characteristics.Add((Characteristic)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
