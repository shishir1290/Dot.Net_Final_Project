using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<Type, ID, RET>
    {
        RET Create(Type obj);
        List<Type> Read();
        Type Read(ID id);
        RET Update(Type obj, ID id);
        bool Delete(ID id);
        List<Type> SearchByName(string name);
        List<Type> SearchByCategory(int categoryId);
        List<Type> SearchByBrand(int brandId);
        Type ReadToken(string tokenString);
    }
}
