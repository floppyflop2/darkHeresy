using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class ClassEvolutionManager : BusinessLogic
    {
        public override object GetAll()
        {
            object classEvolutionList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    classEvolutionList = db.ClassEvolutions.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return classEvolutionList;
        }

        public override object Get(object obj)
        {
            ClassEvolution classEvolution;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    classEvolution = db.ClassEvolutions.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return classEvolution;
        }

        public override object Add(object obj)
        {
            object classEvolutionList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.ClassEvolutions.Add((ClassEvolution)obj);
                    classEvolutionList = db.ClassEvolutions.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return classEvolutionList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.ClassEvolutions.Remove((ClassEvolution)obj);
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
                    db.ClassEvolutions.Remove(db.ClassEvolutions.First(w => w.ClassEvolutionId == id));
                    db.ClassEvolutions.Add((ClassEvolution)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
