using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HolidaySearchLibrary.Services;

namespace HolidaySearchTests
{
    public class DataLoaderTests
    {
        private readonly string _flightsFilePath = @"data/Flights.json";
        private readonly string _hotelsFilePath = @"data/Hotels.json";
        private readonly DataLoader _dataLoader;

        public DataLoaderTests()
        {
            _dataLoader = new DataLoader();

        }
        [Fact]
        public void LoadingFlights_ShouldReturnAllFlights()
        {
            //Act
            var flights = _dataLoader.LoadFlights(_flightsFilePath);

            //Assert
            flights.Should().NotBeEmpty();
            flights.Should().HaveCount(12);
        }
        [Fact]
        public void LoadingHotels_ShouldReturnAllHotels()
        {
            //Act
            var hotels = _dataLoader.LoadHotels(_hotelsFilePath);

            //Assert
            hotels.Should().NotBeEmpty();
            hotels.Should().HaveCount(13);
        }
        [Fact]
        public void LoadingFlights_FlightWithId3_ShouldReturnCorrectData()
        {
            //Arrange
            var flights = _dataLoader.LoadFlights(_flightsFilePath);

            //Act
            var flight = flights.FirstOrDefault(flights => flights.Id == 3);

            //Assert
            flights.Should().NotBeEmpty();
            flight.Airline.Should().Be("Trans American Airlines");
            flight.From.Should().Be("MAN");
            flight.To.Should().Be("PMI");
            flight.Price.Should().Be(170);
            flight.DepartureDate.Should().Be(new DateTime(2023, 06, 15));
        }
        [Fact]
        public void LoadingHotels_HotelWithId5_ShouldReturnCorrectData()
        {
            //Arrange
            var hotels = _dataLoader.LoadHotels(_hotelsFilePath);
            //Act
            var hotel = hotels.FirstOrDefault(hotels => hotels.Id == 5);

            //Assert
            hotels.Should().NotBeEmpty();
            hotel.Name.Should().Be("Sol Katmandu Park & Resort");
            hotel.ArrivalDate.Should().Be(new DateTime(2023, 06, 15));
            hotel.PricePerNight.Should().Be(60);
            hotel.LocalAirports.Should().Contain("PMI");
            hotel.Nights.Should().Be(10);
        }
    }
}
