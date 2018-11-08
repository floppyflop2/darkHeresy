using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class ItemManager : BusinessLogic
    {

        public override object GetAll()
        {
            object itemList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    itemList = db.Items.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return itemList;
        }

        public override object Get(object obj)
        {
            Item item;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    item = db.Items.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return item;
        }

        public override object Add(object obj)
        {
            object itemList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Items.Add((Item)obj);
                    itemList = db.Items.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return itemList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Items.Remove((Item)obj);
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
                    db.Items.Remove(db.Items.First(w => w.ItemId == id));
                    db.Items.Add((Item)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
