
using ASPChangTravel.Models;
using System.Collections.Generic;
namespace ASPChangTravel.DAL{

public interface ISupir
    {
        IEnumerable<Supir> GetAll();
        Supir GetById(string id);
        void Insert(Supir sp);
        void Update(Supir sp);
        void Delete(string id);
    }
}