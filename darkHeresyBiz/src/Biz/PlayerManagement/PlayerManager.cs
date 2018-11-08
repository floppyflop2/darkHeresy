using System.Collections.Generic;
using System.Collections;
using darkHeresyModel;
using System.Runtime.Remoting.Contexts;
using System;
using System.Data.Entity;
using System.Linq;

namespace darkHeresyBiz.src.PlayerManagement
{
    public class PlayerManager : BusinessLogic
    {
        List<Player> playerList = new List<Player>();

        public PlayerManager()
        { }

        public override object GetAll()
        {
            object playerList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    playerList = db.Players.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return playerList;
        }

        public override object Get(object obj)
        {
            Player player;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    player = db.Players.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return player;
        }

        public override object Add(object obj)
        {
            object playerList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Players.Add((Player)obj);
                    playerList = db.Players.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return playerList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Players.Remove((Player)obj);
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
                    db.Players.Remove(db.Players.First(w => w.PlayerId == id));
                    db.Players.Add((Player)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



    }
}
