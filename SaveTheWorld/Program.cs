using System;
using System.Xml;

namespace SaveTheWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardLoader loader = new BoardLoader();
            Board board = loader.Load("data.xml");
        }
    }
}
