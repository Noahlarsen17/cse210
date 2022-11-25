
using System;
using System.Collections.Generic;

namespace cse210_tic_tac_toe
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> board = GetNewBoard();
            string currentPlayer = "x";

            while (!IsGameOver(board))
            {
                DisplayBoard(board);

                int choice = GetMoveChoice(currentPlayer);
                MakeMove(board, choice, currentPlayer);

                currentPlayer = GetNextPlayer(currentPlayer);
            }

            DisplayBoard(board);
            Console.WriteLine("Good game. Thanks for playing!");
        }

        /// <returns>A list of 9 strings representing each square.</returns>
        static List<string> GetNewBoard()
        {
            List<string> board = new List<string>();

            for (int i = 1; i <= 9; i++)
            {
                board.Add(i.ToString());
            }

            return board;
        }

        /// <param name="board">The board</param>
        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        /// <param name="board">The current board.</param>
        /// <returns>True if the game is over</returns>
        static bool IsGameOver(List<string> board)
        {
            bool isGameOver = false;

            if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
            {
                isGameOver = true;
            }

            return isGameOver;
        }
        /// <param name="board">The current board</param>
        /// <param name="player">The player to check for a win</param>
        /// <returns></returns>
        static bool IsWinner(List<string> board, string player)
        {

            bool isWinner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                isWinner = true;
            }

            return isWinner; 
        }

        /// <param name="board">The current board.</param>
        /// <returns>True if the board is full.</returns>
        static bool IsTie(List<string> board)
        {
            // If there is a digit, there are still moves to be made.
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }

        /// <param name="currentPlayer">The current players sign (x or o)</param>
        /// <returns>The next players sign (x or o)</returns>
        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }

        /// <param name="currentPlayer">The sign (x or o) of the current player.</param>
        /// <returns>A 1-based spot number (not a 0-based index)</returns>
        static int GetMoveChoice(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
            string move_string = Console.ReadLine();

            int choice = int.Parse(move_string);
            return choice;
        }

        /// <param name="board">The current board</param>
        /// <param name="choice">The 1-based spot number (not a 0-based index).</param>
        /// <param name="currentPlayer">The current player's sign (x or o)</param>
        static void MakeMove(List<string> board, int choice, string currentPlayer)
        {

            int index = choice - 1;

            board[index] = currentPlayer;
        }
    }
}