using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public interface IRepository<TReturnType, TKeyType>
    {
        TReturnType GetOne(TKeyType key);
        IQueryable<TReturnType> GetAll();
    }
}
