using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
