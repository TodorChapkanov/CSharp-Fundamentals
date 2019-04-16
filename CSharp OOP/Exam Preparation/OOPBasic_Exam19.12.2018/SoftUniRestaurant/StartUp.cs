using SoftUniRestaurant.Core;
using SoftUniRestaurant.IO;
using SoftUniRestaurant.Models.Factories;

namespace SoftUniRestaurant
{
    public  class StartUp
    {
        public static void Main()
        {

            var restaurantController = new RestaurantController
                ();

            var writer = new Writer();
            var reader = new Reader();
            var engine = new Engine(restaurantController, writer, reader);
            engine.Run();
        }
    }
}
