using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HolidaySearchLibrary.Services;

namespace HolidaySearchTests
{
    public class HolidaySearchTests
    {
        private readonly string _flightsFilePath = @"data/Flights.json";
        private readonly string _hotelsFilePath = @"data/Hotels.json";
        private readonly DataLoader _dataLoader;
        private readonly HolidaySearch _holidaySearch;

        public HolidaySearchTests()
        {
            _dataLoader = new DataLoader();
            _holidaySearch = new HolidaySearch(_dataLoader, _flightsFilePath, _hotelsFilePath);

        }
        [Fact]
        public void HolidaySearch_ForCustomer1_ShouldReturnFlight2AndHotel9()
        {
            // Arrange
            var departingFrom = "MAN";
            var travellingTo = "AGP";
            var departureDate = new DateTime(2023, 07, 01);
            var duration = 7;

            //Act
            var results = _holidaySearch.Search(departingFrom, travellingTo, departureDate, duration);

            //Assert
            results.Should().NotBeEmpty();
            results.First().Flight.Id.Should().Be(2);
            results.First().Hotel.Id.Should().Be(9);
        }
        [Fact]
        public void HolidaySearch_ForCustomer2_ShouldReturnFlight6AndHotel5()
        {
            //Arrange
            var departingFrom = "Any Airport";
            var travellingTo = "PMI";
            var departureDate = new DateTime(2023, 06, 15);
            var duration = 10;

            //Act
            var results = _holidaySearch.Search(departingFrom, travellingTo, departureDate, duration);

            //Assert
            results.Should().NotBeEmpty();
            results.First().Flight.Id.Should().Be(6);
            results.First().Hotel.Id.Should().Be(5);
        }
        [Fact]
        public void HolidaySearch_ForCustomer3_ShouldReturnFlight7AndHotel6()
        {
            //Arrange
            var departingFrom = "Any Airport";
            var travellingTo = "LPA";
            var departureDate = new DateTime(2022, 11, 10);
            var duration = 14;

            //Act
            var results = _holidaySearch.Search(departingFrom, travellingTo, departureDate, duration);

            //Assert
            results.Should().NotBeEmpty();
            results.First().Flight.Id.Should().Be(7);
            results.First().Hotel.Id.Should().Be(6);
        }
        [Fact]
        public void HolidaySearch_ForCustomer4_ShouldReturnFlight5AndHotel5()
        {
            //Arrange
            var departingFrom = "MAN";
            var travellingTo = "PMI";
            var departureDate = new DateTime(2023, 06, 15);
            var duration = 10;

            //Act
            var results = _holidaySearch.Search(departingFrom, travellingTo, departureDate, duration);

            //Assert
            results.Should().NotBeEmpty();
            results.First().Flight.Id.Should().Be(5);
            results.First().Hotel.Id.Should().Be(5);
        }
        [Fact]
        public void HolidaySearch_ForCustomer5_ShouldReturnFlight11AndHotel12()
        {
            //Arrange
            var departingFrom = "Any Airport";
            var travellingTo = "AGP";
            var departureDate = new DateTime(2023, 07, 01);
            var duration = 14;

            //Act
            var results = _holidaySearch.Search(departingFrom, travellingTo, departureDate, duration);

            //Assert
            results.Should().NotBeEmpty();
            results.First().Flight.Id.Should().Be(11);
            results.First().Hotel.Id.Should().Be(12);
        }
    }
}
