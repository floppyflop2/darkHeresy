﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyBiz.src
{
    public abstract class BusinessLogic : IDisposable
    {
        public virtual object GetAll()
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual object Get(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual int Check(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual object Add(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Remove(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Modify(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
