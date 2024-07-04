﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HolidaySearchLibrary.Models
{
    public class Hotel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("arrival_date")]
        public DateTime ArrivalDate { get; set; }
        [JsonProperty("price_per_night")]
        public decimal PricePerNight { get; set; }
        [JsonProperty("local_airports")]
        public List<string> LocalAirports { get; set; }
        [JsonProperty("nights")]
        public int Nights { get; set; }
    }
}
