using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HolidaySearchLibrary.Models;

namespace HolidaySearchLibrary
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
    }
}
