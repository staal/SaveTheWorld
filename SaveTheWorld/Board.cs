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
            Cities = new Dictionary<string,City>();
            Diseases = new List<string>();
        }

        public Dictionary<string,City> Cities { get; internal set; }
        public List<string> Diseases { get; internal set; }
        public string Start { get; internal set; }
    }
}
