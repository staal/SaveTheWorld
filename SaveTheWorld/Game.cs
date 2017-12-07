using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld
{
    class Game
    {
        private Board board;
        private Random rng;

        public Game(Board board, Int32 seed)
        {
            this.board = board;
            rng = new Random(seed);
        }

        public Game(Board board)
        {
            this.board = board;
            rng = new Random();
        }
    }
}
