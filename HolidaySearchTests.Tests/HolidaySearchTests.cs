using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidaySearchLibrary;
using Xunit;

namespace HolidaySearchTests
{
    public class HolidaySearchTests
    {
        private readonly string _flightsFilePath = @"data/Flights.json";
        private readonly string _hotelsFilePath = @"data/Hotels.json";
        private readonly DataLoader _dataLoader;

        public HolidaySearchTests()
        {
            _dataLoader = new DataLoader();

        }
        [Fact]
        public void HolidaySearchForCustomer1ShouldReturnFlight2AndHotel9()
        {
            // Arrange
            var holidaySearch = new HolidaySearcher(_dataLoader, _flightsFilePath, _hotelsFilePath);

            //Act
            var results = holidaySearch.Search("MAN", "AGP", new DateTime(2023, 07, 01), 7);

            //Assert
            Assert.NotNull(results);
            Assert.Equal(2, results[0].Flight.Id);
            Assert.Equal(9, results[0].Hotel.Id);
        }
        [Fact]
        public void HolidaySearchForCustomer2ShouldReturnFlight6AndHotel5()
        {
            //Arrange

            //Act
            //var results = HolidaySearch.Results.First().Flight.Id;

            //Assert
            //Assert.NotNull(results);
            //Assert.Equal(6, flight.Id);
            //Assert.Equal(5, hotel.Id);
        }
        [Fact]
        public void HolidaySearchForCustomer3ShouldReturnFlight7AndHotel6()
        {
            //Arrange

            //Act
            //var results = HolidaySearch.Results.First().Flight.Id;

            //Assert
            //Assert.NotNull(results);
            //Assert.Equal(7, flight.Id);
            //Assert.Equal(6, hotel.Id);
        }
    }
}
