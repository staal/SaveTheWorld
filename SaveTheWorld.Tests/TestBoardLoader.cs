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
            BoardLoader board = new BoardLoader();
            string path = AssemblyPath() + "testBoard.xml";

            Assert.IsNotNull(board.Load(path));
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
