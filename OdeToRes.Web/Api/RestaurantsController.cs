using OdeToRes.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToRes.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        public IEnumerable<Data.Models.Restaurant> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
