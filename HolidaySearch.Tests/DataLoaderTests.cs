using HolidaySearchLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch.Tests
{
    public class DataLoaderTests
    {
        private readonly string _flightsFilePath = @"data/Flights.json";
        private readonly string _hotelsFilePath = @"data/Hotels.json";
        private readonly DataLoader _dataLoader;

        public DataLoaderTests()
        {
            // Arrange
            _dataLoader = new DataLoader();

        }
        [Fact]
        public void LoadingFlightsShouldReturnAllFlightsAvailable()
        {
            //Act
            var flights = _dataLoader.LoadFlights(_flightsFilePath);

            //Assert
            Assert.NotNull(flights);
            Assert.Equal(12, flights.Count);
        }
        [Fact]
        public void LoadingHotelsShouldReturnAllHotelsAvailable()
        {
            //Act
            var hotels = _dataLoader.LoadHotels(_hotelsFilePath);

            //Assert
            Assert.NotNull(hotels);
            Assert.Equal(13, hotels.Count);
        }
        [Fact]
        public void LoadingFlightsShouldReturnCorrectDataFromFlightWithId3()
        {
            //Act
            var flights = _dataLoader.LoadFlights(_flightsFilePath);
            var flight = flights.FirstOrDefault(flights => flights.Id == 3);

            //Assert
            Assert.NotNull(flights);
            Assert.Equal("Trans American Airlines", flight.Airline);
            Assert.Equal("MAN", flight.From);
            Assert.Equal("PMI", flight.To);
            Assert.Equal(170, flight.Price);
            Assert.Equal(new DateTime(2023, 06, 15), flight.DepartureDate);
        }
        [Fact]
        public void LoadingHotelsShouldReturnCorrectDataFromHotelWithId5()
        {
            //Act
            var hotels = _dataLoader.LoadHotels(_hotelsFilePath);
            var hotel = hotels.FirstOrDefault(hotels => hotels.Id == 5);

            //Assert
            Assert.NotNull(hotels);
            Assert.Equal("Sol Katmandu Park & Resort", hotel.Name);
            Assert.Equal(new DateTime(2023, 06, 15), hotel.ArrivalDate);
            Assert.Equal(60, hotel.PricePerNight);
            Assert.Contains("PMI", hotel.LocalAirports);
            Assert.Equal(10, hotel.Nights);
        }
    }
}
