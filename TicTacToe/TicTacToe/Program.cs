using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // create use objects
            Player p1 = new Player("X", "Player 1");
            Player p2 = new Player("O", "Player 2");
            Board myBoard = new Board();
            Game myGame = new Game(myBoard, p1, p2);
            // run game logic
            myGame.Run();
        }
    }
}
