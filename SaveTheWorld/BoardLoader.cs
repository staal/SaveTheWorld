using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SaveTheWorld
{
    public class BoardLoader
    {
        public Board Load(string fileName)
        {
            XmlReaderSettings settings = new XmlReaderSettings();

            Board board = new Board();
            using (XmlReader reader = XmlReader.Create(fileName, settings))
            {
            }
            return board;
        }
    }
}
