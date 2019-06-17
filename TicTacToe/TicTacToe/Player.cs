using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Player
    {
        private string fToken;
        private string fName;

        public Player(string aToken, string aName)
        {
            fToken = aToken;
            fName = aName;
        }

        //Getter for private fields
        public string Token
        {
            get { return fToken; }
        }
        public string Name
        {
            get { return fName;  }
        }
    }
}
