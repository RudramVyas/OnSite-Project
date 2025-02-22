using System;

namespace OnSite.Backend.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string QuoteDetails { get; set; }
    }
}
