using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class PersonalInfoManager : BusinessLogic
    {
        public override object GetAll()
        {
            object personalInfoList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    personalInfoList = db.PersonalInfos.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return personalInfoList;
        }

        public override object Get(object obj)
        {
            PersonalInfo personalInfo;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    personalInfo = db.PersonalInfos.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return personalInfo;
        }

        public override object Add(object obj)
        {
            object personalInfoList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.PersonalInfos.Add((PersonalInfo)obj);
                    personalInfoList = db.PersonalInfos.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return personalInfoList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.PersonalInfos.Remove((PersonalInfo)obj);
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
                    db.PersonalInfos.Remove(db.PersonalInfos.First(w => w.PersonalInfoId == id));
                    db.PersonalInfos.Add((PersonalInfo)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
