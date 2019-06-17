using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Player
    {
        private string fToken;

        public Player(string aToken)
        {
            fToken = aToken;
        }

        //Getter for private field
        public string Token
        {
            get { return fToken; }
        }
    }
}
