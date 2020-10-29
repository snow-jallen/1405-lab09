using System;
using System.Runtime.CompilerServices;
using static System.Console;

/* This is the default implementation. */

namespace Lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_TURNS = 9;

            WriteLine("\n----------------------------------");
            WriteLine("Welcome to tic-tac-toe");
            WriteLine("----------------------------------");
            WriteLine("Players will take turns choosing an unoccupied cell.");
            WriteLine("The first player to get 3 in a row (or column or diagonal) wins!\n");

            char[] board = new char[9] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };

            // will hold the winning player when there is one
            int winner = 0;

            for (int turn = 0; turn < MAX_TURNS; turn++)
            {
                // player X on even turns, player O on odd turns
                char currentPlayer = turn % 2 == 0 ? 'X' : 'O';
                WriteLine($"currentPlayer={currentPlayer}; turn={turn}");
                WriteLine("Current Board: ");
                DisplayBoard(board);
                board = MakeMove(currentPlayer, board);
                if (HasWinner(board))
                {
                    winner = currentPlayer;
                    break;
                }
            }
            DisplayBoard(board);

            // print the game outcome
            if (winner == 'X')
            {
                WriteLine("\n/----------------\\");
                WriteLine($"|     X wins!    |");
                WriteLine("\\----------------/");                
            }
            else if(winner == 'O')
            {
                WriteLine("\n/----------------\\");
                WriteLine($"|     O wins!    |");
                WriteLine("\\----------------/");
            }
            else
            {
                WriteLine("Looks like a draw");                
            }
        }

        public static void DisplayBoard(char[] board)
        {
            WriteLine(" {0} | {1} | {2}", board[0], board[1], board[2]);
            WriteLine("---+---+---");
            WriteLine(" {0} | {1} | {2}", board[3], board[4], board[5]);
            WriteLine("---+---+---");
            WriteLine(" {0} | {1} | {2}", board[6], board[7], board[8]);
        }

        public static bool HasWinner(char[] board)
        {
            char[] row1 = new char[3] { board[0], board[1], board[2] };
            char[] row2 = new char[3] { board[3], board[4], board[5] };
            char[] row3 = new char[3] { board[6], board[7], board[8] };
            char[] col1 = new char[3] { board[0], board[3], board[6] };
            char[] col2 = new char[3] { board[1], board[4], board[7] };
            char[] col3 = new char[3] { board[2], board[5], board[8] };
            char[] diagonal1 = new char[3] { board[0], board[4], board[8] };
            char[] diagonal2 = new char[3] { board[2], board[4], board[6] };


            if (CellsAreTheSame(row1) || CellsAreTheSame(row2) || CellsAreTheSame(row3) || CellsAreTheSame(col1) || CellsAreTheSame(col2) || CellsAreTheSame(col3) || CellsAreTheSame(diagonal1) || CellsAreTheSame(diagonal2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CellsAreTheSame(char[] cells)
        {
            if(cells[0] == cells[1] && cells[0] == cells[2])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static char getChar(string prompt)
        {
            Write(prompt);
            char c = '\0';
            do 
            {
                var input = ReadLine();
                if(input.Length != 1)
                    continue;
                c = input[0];
            }while((c < 'a' || c > 'i'));
            return c;
        }

        public static int getIndex(char square)
        {
            switch (square)
            {
                //based on cell update board and assign newBoard the modified board.
                case 'a':
                    return 0;
                case 'b':
                    return 1;
                case 'c':
                    return 2;
                case 'd':
                    return 3;
                case 'e':
                    return 4;
                case 'f':
                    return 5;
                case 'g':
                    return 6;
                case 'h':
                    return 7;
                case 'i':
                    return 8;
                default: 
                    return -1;
            }
        }

        public static char[] MakeMove(char player, char[] board)
        {
            char[] newBoard = new char[9];
            board.CopyTo(newBoard, 0);
            char cell = 'n';

            do
            {
                cell = getChar("Please enter the cell you want to make your move (a-i): ");
            }
            while (!CanUpdateCell(newBoard, cell));
            newBoard[getIndex(cell)] = player;

            return newBoard;
        }

        private static bool CanUpdateCell(char[] board, char cell)
        {
            //check if cell is not X or O return true if so false if not
            return board[getIndex(cell)] != 'O' && board[getIndex(cell)] != 'X';      
        }

        // TODO: write the functions used in main (and any other helper functions you want to use)

        // DisplayBoard
        /**
         * displays the tic-tac-toe board
         * given the contents of the named cells
         *  a | b | c
         * ---+---+---
         *  d | e | f
         * ---+---+--
         *  g | h | i
         */

        //GetMove
        /* given a string to prompt the user for input, get a cell.
         * verify the cell is a valid cell defined in the board.  
         * numbers and words are not valid cells.
         * return the valid cell.
        */


        //HasWinner
        /**
         * given the board,
         * returns true if the board has a winner
         */
        // hint: just return true if you can find three-in-a-row
        // of any character; consider writing the function 'CellsAreTheSame'
        // described below

        //bool CellsAreTheSame(char a, char b, char c);
        /**
         *  returns true if a, b, and c are all the same
         */

        //MakeMove
        /**
         * Continues to ask the player with symbol 'currentPlayer'
         * for input until a valid (unused) cell is selected;
         * then the corresponding cell is updated appropriately
         */
        //hint: you'll want to pass in the board so that you can change it; 
        // also, you'll probably have a do-while loop in here in case the user selects a 
        // cell that another player already picked.  You'll need to ask again for them to
        // pick another cell.
        

    }
}
