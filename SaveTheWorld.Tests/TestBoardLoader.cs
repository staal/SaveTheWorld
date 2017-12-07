using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SaveTheWorld;
using System.Reflection;
using System.IO;

namespace SaveTheWorld.Tests
{
    [TestFixture]
    class TestBoardLoader
    {
        private BoardLoader boardLoader;
        private string testBoardPath;

        [SetUp]
        public void Setup()
        {
            boardLoader = new BoardLoader();
            testBoardPath = AssemblyPath() + "testBoard.xml";
        }

        private string AssemblyPath()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var codebaseLocation = Path.GetDirectoryName(assembly.Location);
            return codebaseLocation + "/";
        }

        [Test]
        public void BoardLoadMustBeNonNull()
        {
            Assert.Throws<ArgumentNullException>(() => boardLoader.Load(null));
        }

        [Test]
        public void BoardLoadMustExist()
        {
            Assert.Throws<System.IO.FileNotFoundException>(() => boardLoader.Load("somewierdfile"));
        }

        [Test]
        public void BoardLoadReturnsBoard()
        {
            Assert.IsNotNull(boardLoader.Load(testBoardPath));
        }

        [Test]
        public void BoardLoadsCorrectly()
        {
            Board board = boardLoader.Load(testBoardPath);

            Assert.AreEqual(board.Cities.Count, 4);
            Assert.AreEqual(board.Diseases.Count, 2);
            Assert.AreEqual(board.Start, "atlanta");
        }

        [Test]
        public void BoardContainsCities()
        {
            Board board = boardLoader.Load(testBoardPath);

            Assert.NotNull(board.Cities["atlanta"]);
            Assert.NotNull(board.Cities["miami"]);
            Assert.NotNull(board.Cities["losangeles"]);
            Assert.NotNull(board.Cities["sanfrancisco"]);
        }

        [Test]
        public void CitiesHaveProperNames()
        {
            Board board = boardLoader.Load(testBoardPath);

            City city = board.Cities["sanfrancisco"];
            Assert.AreEqual(city.Name, "San Francisco");
        }

        [Test]
        public void CityIsConnected()
        {
            Board board = boardLoader.Load(testBoardPath);

            City city = board.Cities["atlanta"];
            Assert.AreEqual(city.Connections.Count, 1);
        }

        [Test]
        public void AtlantaIsConnectedToSanfran()
        {
            Board board = boardLoader.Load(testBoardPath);

            City city = board.Cities["atlanta"];
            Assert.IsTrue(city.Connections.ContainsKey("sanfrancisco"));
        }

        [Test]
        public void CityDiseaseIsOnBoard()
        {
            Board board = boardLoader.Load(testBoardPath);

            City city = board.Cities["atlanta"];
            Assert.IsTrue(board.Diseases.Contains(city.Disease));

        }
    }
}
