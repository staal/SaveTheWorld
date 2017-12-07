using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    public class Board
    {
        public Board()
        {
            Cities = new List<City>();
            Diseases = new List<string>();
        }

        public List<City> Cities { get; set; }
        public List<string> Diseases { get; set; }
        public int Cubes { get; set; }
        public int Incidents { get; internal set; }
        public string Start { get; internal set; }
        public int ResarchStations { get; internal set; }
    }
}
