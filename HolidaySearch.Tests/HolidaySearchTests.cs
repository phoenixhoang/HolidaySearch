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
        [Fact]
        public void LoadingFlightsShouldReturnCorrectDataFromFlightWithId3()
        {
            var dataLoader = new DataLoader();
            var flights = dataLoader.LoadFlights(flightsFilePath);
            var flight = flights.FirstOrDefault(flights => flights.Id == 3);

            Assert.NotNull(flights);
            Assert.Equal("Trans American Airlines", flight.Airline);
            Assert.Equal("MAN", flight.From);
            Assert.Equal("PMI", flight.To);
            Assert.Equal(170, flight.Price);
            Assert.Equal(new DateTime(2023,06,15), flight.DepartureDate);
        }
        [Fact]
        public void LoadingHotelsShouldReturnCorrectDataFromHotelWithId5()
        {
            var dataLoader = new DataLoader();
            var hotels = dataLoader.LoadHotels(hotelsFilePath);
            var hotel = hotels.FirstOrDefault(hotels => hotels.Id == 5);

            Assert.NotNull(hotels);
            Assert.Equal("Sol Katmandu Park & Resort", hotel.Name);
            Assert.Equal(new DateTime(2023, 06, 15), hotel.ArrivalDate);
            Assert.Equal(60, hotel.PricePerNight);
            Assert.Contains("PMI", hotel.LocalAirports);
            Assert.Equal(10, hotel.Nights);
        }
    }
}
