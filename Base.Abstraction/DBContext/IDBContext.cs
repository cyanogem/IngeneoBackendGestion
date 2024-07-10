using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Abstraction.DBContext
{
    public interface IDBContext<T> : ICRUD<T>
    {
          
    }
}
