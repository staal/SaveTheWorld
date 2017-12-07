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
        [Test]
        public void BoardLoadMustBeNonNull()
        {
            BoardLoader board = new BoardLoader();

            Assert.Throws<ArgumentNullException>(() => board.Load(null));
        }

        [Test]
        public void BoardLoadMustExist()
        {
            BoardLoader board = new BoardLoader();

            Assert.Throws<System.IO.FileNotFoundException>(() => board.Load("somewierdfile"));
        }

        [Test]
        public void BoardLoadReturnsBoard()
        {
            BoardLoader boardLoader = new BoardLoader();
            string path = AssemblyPath() + "testBoard.xml";

            Assert.IsNotNull(boardLoader.Load(path));
        }

        [Test]
        public void BoardLoadsCorrectly()
        {
            BoardLoader boardLoader = new BoardLoader();
            string path = AssemblyPath() + "testBoard.xml";

            Board board = boardLoader.Load(path);

            Assert.AreEqual(board.Cities.Count, 4);
            Assert.AreEqual(board.Diseases.Count, 2);
            Assert.AreEqual(board.Cubes, 24);
            Assert.AreEqual(board.ResarchStations, 6);
            Assert.AreEqual(board.Incidents, 8);
            Assert.AreEqual(board.Start, "atlanta");
        }

        [Test]
        public void FileOpenSucceeds()
        {
            string path = AssemblyPath() + "testBoard.xml";

            Assert.DoesNotThrow(() => System.IO.File.Open(path, System.IO.FileMode.Open));
        }

        private string AssemblyPath()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var codebaseLocation = Path.GetDirectoryName(assembly.Location);
            return codebaseLocation + "/";
        }
    }
}
