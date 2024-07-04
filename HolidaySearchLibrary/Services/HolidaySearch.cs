using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary.Services
{
    public class HolidaySearch
    {
        private readonly List<Flight> _flights;
        private readonly List<Hotel> _hotels;
        public HolidaySearch(DataLoader dataLoader, string flightsFilePath, string hotelsFilePath)
        {
            _flights = dataLoader.LoadFlights(flightsFilePath);
            _hotels = dataLoader.LoadHotels(hotelsFilePath);
        }

        public List<(Flight Flight, Hotel Hotel)> Search(string departingFrom, string travellingTo, DateTime departureDate, int duration)
        {
            var results = new List<(Flight Flight, Hotel Hotel)>();



            return results;
        }
    }
}