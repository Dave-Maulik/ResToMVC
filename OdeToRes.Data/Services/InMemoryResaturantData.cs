using OdeToRes.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToRes.Data.Services
{
    public class InMemoryResaturantData : IRestaurantData 
    {
        private List<Restaurant> restaurants;
        public InMemoryResaturantData()
        {
          
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 01 , Name = "Maulik's Kitchen" , cuisines = CuisineTypes.Indian },
                new Restaurant { Id = 02 , Name = "Pizza Palace" , cuisines = CuisineTypes.Indian},
                new Restaurant { Id = 03 , Name = "The Maxican" , cuisines = CuisineTypes.Maxican},
                new Restaurant { Id = 04 , Name = "Taj Mahal Palace" , cuisines = CuisineTypes.None}
            };
        }

        public void AddRes(Restaurant Res)
        {
            restaurants.Add(Res);
            Res.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Delete(int id)
        {
            var res = GetRes(id);
            if (res != null)
            {
                restaurants.Remove(res);
            }
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Id);  
        }

        public Restaurant GetRes(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Update(Restaurant restaurant)
        {
            var old = GetRes(restaurant.Id) ;
            if (old != null)
            {
                old.Name = restaurant.Name;
                old.cuisines = restaurant.cuisines;
            }
        }
    }
}
