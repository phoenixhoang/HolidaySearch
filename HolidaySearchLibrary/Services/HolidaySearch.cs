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

            // Find matching flights
            var flightMatches = _flights.Where(f =>
            f.From == departingFrom &&
            f.To == travellingTo &&
            f.DepartureDate == departureDate
            );

            // Find matching hotels
            var hotelMatches = _hotels.Where(h =>
            h.ArrivalDate == departureDate &&
            h.LocalAirports.Contains(travellingTo) &&
            h.Nights == duration
            );

            // Create holiday package with the flight and hotel
            results = (from flight in flightMatches
                       from hotel in hotelMatches
                       select (Flight: flight, Hotel: hotel)).ToList();

            // Order the holiday package by price lowest to highest
            results = results.OrderBy(r => (r.Flight.Price + r.Hotel.PricePerNight) * r.Hotel.Nights).ToList();

            return results;
        }
    }
}