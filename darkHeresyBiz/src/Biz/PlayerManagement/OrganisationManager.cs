using darkHeresyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src.Biz.PlayerManagement
{
    public class OrganisationManager : BusinessLogic
    {
        public override object GetAll()
        {
            object organisationList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    organisationList = db.Organisations.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return organisationList;
        }

        public override object Get(object obj)
        {
            Organisation organisation;
            int id = (int)obj;

            if (id == 0)
            {
                return GetAll();
            }
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    organisation = db.Organisations.Find(id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return organisation;
        }

        public override object Add(object obj)
        {
            object organisationList = new List<object>();
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Organisations.Add((Organisation)obj);
                    organisationList = db.Organisations.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return organisationList;
        }

        public override void Remove(object obj)
        {
            try
            {
                using (var db = new DarkHeresyModel())
                {
                    db.Organisations.Remove((Organisation)obj);
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
                    db.Organisations.Remove(db.Organisations.First(w => w.OrganisationId == id));
                    db.Organisations.Add((Organisation)obj);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
