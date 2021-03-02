using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIProject.Models;

namespace WebAPIProject.Services
{
    public interface IHouseService
    {
        House GetHouse(string houseName);
        List<House> GetHouses();
        void AddHouse(House house);
        void DeleteHouseById(int houseId);
        House UpDateHouseById(int houseIdToEdit, House houseEditValues);
    }
}
