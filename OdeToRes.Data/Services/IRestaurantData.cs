using OdeToRes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToRes.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetRes(int id);

       void AddRes(Restaurant Res);

       void Update(Restaurant restaurant);

        void Delete(int id);
    }
}
