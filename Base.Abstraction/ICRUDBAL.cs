using BaseAPI.Abstraction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseAPI.Abstraction
{
    public interface ICRUDBAL<T>
    { 
        ResponseServicesDTO GetById(int id, int language);
        ResponseServicesDTO GetAll(int language);
        ResponseServicesDTO GetAllByPage(int _page, int _countByPage, int language);
        ResponseServicesDTO Save(T entity, int language);
        ResponseServicesDTO Update(T entity, int language);
        ResponseServicesDTO DeleteById(int id, int language);
    }
}
