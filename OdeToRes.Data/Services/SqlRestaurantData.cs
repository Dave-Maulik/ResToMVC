using OdeToRes.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToRes.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToResDbContext db;

        public SqlRestaurantData(OdeToResDbContext db)
        {
            this.db = db;
        }
        public void AddRes(Restaurant Res)
        {
            db.Restaurants.Add(Res);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var res = db.Restaurants.Find(id);
            db.Restaurants.Remove(res);
            db.SaveChanges();
            
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants;
        }

        public Restaurant GetRes(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);

            /*
             *  return from r in db.Restaruant 
             *  order by r.Name
             *  select r
             */
        }

        public void Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
