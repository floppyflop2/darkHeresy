using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class WeaponManager: BusinessLogic
    {
        public override object GetAll()
        {
            object weaponList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    weaponList = db.Weapons.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return weaponList;
        }

        public override object Get(object obj)
        {
            Weapon weapon;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    weapon = db.Weapons.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return weapon;
        }

        public override object Add(object obj)
        {
            object weaponList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Weapons.Add((Weapon)obj);
                    weaponList = db.Weapons.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return weaponList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Weapons.Remove((Weapon)obj);
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
                    //test
                    db.Weapons.Remove(db.Weapons.First(w => w.WeaponId == id));
                    db.Weapons.Add((Weapon)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
