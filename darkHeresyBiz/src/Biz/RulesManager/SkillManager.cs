using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class SkillManager : BusinessLogic
    {
        public override object GetAll()
        {
            object skillList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    skillList = db.Skills.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return skillList;
        }

        public override object Get(object obj)
        {
            Skill skill;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    skill = db.Skills.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return skill;
        }

        public override object Add(object obj)
        {
            object skillList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Skills.Add((Skill)obj);
                    skillList = db.Skills.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return skillList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Skills.Remove((Skill)obj);
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
                    db.Skills.Remove(db.Skills.First(w => w.SkillId == id));
                    db.Skills.Add((Skill)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
