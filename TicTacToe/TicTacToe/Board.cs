using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Board
    {
        private string[,] fGrid = new string[4, 4];
        
        public Board()
        {
            Init();
        }

        public void Init()
        {
            fGrid[1, 1] = ".";
            fGrid[1, 2] = ".";
            fGrid[1, 3] = ".";
            fGrid[2, 1] = ".";
            fGrid[2, 2] = ".";
            fGrid[2, 3] = ".";
            fGrid[3, 1] = ".";
            fGrid[3, 2] = ".";
            fGrid[3, 3] = ".";
        }

        // used to display
        public void PrintBoard()
        {
            for (int i = 1; i <=3; i++)
            {
                Console.WriteLine(fGrid[i, 1] + "\t" + fGrid[i, 2] + "\t" + fGrid[i, 3] + "\n");
            }
            
        }

        // changing tile to Player's token
        public void PlaceToken(int x, int y, Player aPlayer)
        {
            fGrid[x, y] = aPlayer.Token;
        }

        // checking boardstate for win conditions
        public bool CheckRows()
        {
            for (int i = 1; i <= 3; i++)
            {
                if ((Grid(i, 1) != ".") && (Grid(i, 1) == Grid(i, 2)) && (Grid(i, 2) == Grid(i, 3)))
                    return true;
            }
            return false;
        }

        public bool CheckCols()
        {
            for (int i = 1; i <= 3; i++)
            {
                if ((Grid(1, i) != ".") && (Grid(1, i) == Grid(2, i)) && (Grid(2, i) == Grid(3, i)))
                    return true;
            }
            return false;
        }

        public bool CheckDiags()
        {
            return ((Grid(1, 1) != ".") && ((Grid(1, 1) == Grid(2, 2)) && (Grid(2, 2) == Grid(3, 3))))
                || ((Grid(3, 1) != ".") && ((Grid(3, 1) == Grid(2, 2)) && (Grid(2, 2) == Grid(1, 3))));
        }

        //returns single tile 
        public string Grid(int x, int y)
        {
            return fGrid[x, y];
        }

        public bool isEmpty(int x, int y)
        {
            return (fGrid[x, y] == ".");
        }
    }
}
