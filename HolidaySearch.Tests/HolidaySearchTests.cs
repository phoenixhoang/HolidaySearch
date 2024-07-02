using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidaySearchLibrary;

namespace HolidaySearch.Tests
{
    public class HolidaySearchTests
    {
        private readonly string flightsFilePath = @"data/Flights.json";
        private readonly string hotelsFilePath = @"data/Hotels.json";

        [Fact]
        public void LoadingFlightsShouldReturnAllFlightsAvailable()
        {
            var dataLoader = new DataLoader();
            var flights = dataLoader.LoadFlights(flightsFilePath);

            Assert.NotNull(flights);
            Assert.Equal(12, flights.Count);
        }
        [Fact]
        public void LoadingHotelsShouldReturnAllHotelsAvailable()
        {
            var dataLoader = new DataLoader();
            var hotels = dataLoader.LoadHotels(hotelsFilePath);

            Assert.NotNull(hotels);
            Assert.Equal(13, hotels.Count);
        }

    }
}
