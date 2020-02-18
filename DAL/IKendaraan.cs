

using System.Collections.Generic;
using ASPChangTravel.Models;

namespace ASPChangTravel.DAL{
    public interface IKendaraan
    {
        IEnumerable<Kendaraan> GetAll();
        Kendaraan GetByno_plat(string no_plat);
        void Insert(Kendaraan ken);
        void Update(Kendaraan ken);
        void Delete(string no_plat);

    IEnumerable<Kendaraan> GetAllByMerk(string merk);
    }
}