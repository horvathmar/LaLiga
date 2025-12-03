using System;

namespace LaLiga
{
    public class Team
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Stadium { get; set; }
        public DateTime FoundationDate { get; set; }
        public int Titles { get; set; }
        public bool IsActive { get; set; }
        public bool HasTitles { get; set; }
    }
}