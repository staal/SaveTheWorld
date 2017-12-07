using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    public class City
    {
        public City(string disease, string id, string name)
        {
            Disease = disease;
            Id = id;
            Name = name;
        }

        public string Disease { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }
    }
}
