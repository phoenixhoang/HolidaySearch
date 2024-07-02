using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HolidaySearchLibrary
{
    public class DataLoader
    {
        public List<Flight> LoadFlights(string filePath)
        {
            var flightsJson = File.ReadAllText(filePath);
            var flights = JsonConvert.DeserializeObject<List<Flight>>(flightsJson);
            return flights;
        }

        public List<Hotel> LoadHotels(string filePath)
        {
            var hotelsJson = File.ReadAllText(filePath);
            var hotels = JsonConvert.DeserializeObject<List<Hotel>>(hotelsJson);
            return hotels;
        }
    }
}
