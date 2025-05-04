using studentdbfinal1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studentdb.Models.Repositories
{
    public interface Istudentrepository
    {
        IEnumerable<Studentquery1> SelectAll();
        Studentquery1 SelectByID(int id);
        void Insert(Studentquery1 obj);
        void Update(Studentquery1 obj);
        void Delete(int id);
        void Save();
    }
}