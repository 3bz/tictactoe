using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        private int turnCount;
        private Board fBoard;
        private Player[] fPlayers = new Player[2];
        private Player currentPlayer;
        private Boolean winFlag;

        public Game(Board aBoard, Player p1, Player p2)
        {
            turnCount = 1;
            fBoard = aBoard;
            fPlayers[0] = p1; //X token
            fPlayers[1] = p2; //Y token
            winFlag = false;
        }
        
        // gameflow 
        public void Run()
        {
            Welcome();
            DisplayBoard();
            while (!winFlag)                            //count-down to Draw condition
            {
                TurnOrder();
                CheckWin();
            }
            if (turnCount == 10 && (!(CheckWin())))     //if player did not win on final turn
            {
                Console.WriteLine("We have a draw!\n");
                Console.ReadLine();
            }
        }
        
        //runs once on introduction
        public void Welcome()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!\n\n");
            Console.WriteLine("Here's the current board:\n\n");
        }

        public void DisplayBoard()
        {
            fBoard.PrintBoard();
        }

        //when player selects Q to quit game
        public void Quit()
        {
            Console.WriteLine("Press enter to End");
            Console.ReadLine();
            Environment.Exit(0);
        }

        //if turnCount is ODD, p1 turn. else p2 turn
        public void TurnOrder()
        {
            if (turnCount % 2 != 0)
                currentPlayer = fPlayers[0];
            else
                currentPlayer = fPlayers[1];
            
            Console.WriteLine(currentPlayer.Name + " enter a coord x,y to place your " + currentPlayer.Token + " or enter 'q' to give up: ");
            TakeTurn();
        }

        //reads user input and determines if move is valid, tile is open, then places player token
        public void TakeTurn()
        {
            string coords = Console.ReadLine();
            string[] coordsSplit = coords.Split(",");

            if (coordsSplit[0] == "q")              //player quits
            {
                Console.WriteLine("Oh no, player has quit the game!\n");
                Quit();
            }

            if (ValidMove(coordsSplit))             //move fits the desired format "x,y"
            {
                int x = int.Parse(coordsSplit[0]);
                int y = int.Parse(coordsSplit[1]);

                if (fBoard.isEmpty(x, y))           //tile is free (".")
                {
                    fBoard.PlaceToken(x, y, currentPlayer);
                    if (CheckWin())                 //win message displayed
                        WeHaveAWinner();
                    else
                    {
                        Console.WriteLine("Move accepted, here's the current board:\n");
                        DisplayBoard();
                    }
                    turnCount++;                    //increment Draw condition

                    if (turnCount == 10)
                        winFlag = true;             //break gameloop
                }
                else
                    Console.WriteLine("Oh no, a piece is already at this place! Try again...\n");
            }
            else
                Console.WriteLine("Oh no, invalid move!\n");
        }

        //move matches required format: "x,y"
        public bool ValidMove(string[] coords)
        {
            if (coords.Length == 2)
                return ((coords[0] == "1" || coords[0] == "2" || coords[0] == "3")
                    && (coords[1] == "1" || coords[1] == "2" || coords[1] == "3"));
            return false;
        }

        //win conditions
        public bool CheckWin()
        {
            if (fBoard.CheckCols() || fBoard.CheckRows() || fBoard.CheckDiags())
            {
                winFlag = true;
                return true;
            }
            return false;
        }

        //win message
        public void WeHaveAWinner()
        {
            Console.WriteLine("Move accepted, well done you've won the game!\n");
            DisplayBoard();
            Console.ReadLine();
        }
    }
}
