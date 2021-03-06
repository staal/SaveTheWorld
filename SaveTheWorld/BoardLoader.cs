﻿using System;
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
            XmlReaderSettings settings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };

            Board board = new Board();
            using (XmlReader reader = XmlReader.Create(fileName, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "cities")
                        {
                            LoadDiseases(reader.ReadSubtree(), board);
                        }
                        else if (reader.Name == "connections")
                        {
                            LoadConnections(reader.ReadSubtree(), board);
                        }
                        else if (reader.Name == "start")
                        {
                            board.Start = ReadText(reader);
                        }
                    }
                }
            }
            ValidateBoard(board);
            return board;
        }

        private void ValidateBoard(Board board)
        {
            if (board.Cities[board.Start] == null)
            {
                throw new XmlException("Starting city name does not match a city.");
            }
        }

        private string ReadText(XmlReader reader)
        {
            reader.Read();
            if (reader.NodeType == XmlNodeType.Text && reader.Value != String.Empty)
            {
                return reader.Value;
            }
            else
            {
                throw new XmlException("No text tag found where expected.");
            }
        }

        private void LoadConnections(XmlReader reader, Board board)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "city")
                {
                    string cityID = reader.GetAttribute("id");
                    if (cityID != null && board.Cities[cityID] != null)
                    {
                        LoadCityConnections(reader.ReadSubtree(), board.Cities[cityID], board);
                    }
                    else
                    {
                        throw new XmlException("Malformed city-connection tag found");
                    }
                }
            }
        }

        private void LoadCityConnections(XmlReader reader, City city, Board board)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "connection")
                {
                    string connectingCityID = reader.GetAttribute("id");
                    if (connectingCityID != null && board.Cities[connectingCityID] != null)
                    {
                        city.Connections[connectingCityID] = board.Cities[connectingCityID];
                    }
                    else
                    {
                        throw new XmlException("Malformed connection tag found");
                    }
                }
            }
        }

        private void LoadDiseases(XmlReader reader, Board board)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "disease")
                {
                    string diseaseColor = reader.GetAttribute("color");
                    if (diseaseColor != null)
                    {
                        board.Diseases.Add(diseaseColor);
                        LoadCities(reader.ReadSubtree(), diseaseColor, board);
                    }
                }
            }
        }

        private void LoadCities(XmlReader reader, string disease, Board board)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "city")
                {
                    string cityName = null;
                    string cityID = reader.GetAttribute("id");

                    // Read inner text node if present!
                    reader.Read();
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        cityName = reader.Value;
                    }

                    if (cityID != null && cityName != null)
                    {
                        City city = new City(disease, cityID, cityName);
                        board.Cities.Add(cityID, city);
                    }
                    else
                    {
                        throw new XmlException("Malformed city xml");
                    }
                }
            }
        }


    }
}
