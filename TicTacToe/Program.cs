using System;

// This took me about 1.5 hours to make

namespace TicTacToe {
    class Program {
        private static string[,] choices = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

        static void PrintBoard() {
            Console.Clear();
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    Console.Write(choices[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
        }

        static void ResetChoices() {
            choices[0, 0] = "1";
            choices[0, 1] = "2";
            choices[0, 2] = "3";
            choices[1, 0] = "4";
            choices[1, 1] = "5";
            choices[1, 2] = "6";
            choices[2, 0] = "7";
            choices[2, 1] = "8";
            choices[2, 2] = "9";
        }

        public static string Checker(string[,] board) {
            // check horizontals
            for (int i = 0; i < 3; i++) {
                bool check = true;
                for (int j = 0; j < 3; j++) {
                    if (board[i, 0] != board[i, j]) {
                        check = false;
                    }
                    if (j == 2 && check) {
                        return board[i, 0];
                    }
                }
            }

            // check verticals
            for (int i = 0; i < 3; i++) {
                if (board[0, i] == board[1, i] && board[0, i] == board[2, i]) {
                    return board[0, i];
                }
            }

            //check diagonals
            if (board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) {
                return board[0, 0];
            } else if (board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2]) {
                return board[2, 0];
            }

            return null;
        }

        static int ChooseSpot(int playerNum) {
            int input = 0;
            string key = Console.ReadLine();
            bool check = int.TryParse(key, out input); // false means it's not a valid input
            bool check2 = CheckIfValid(key); // false means it's a taken spot

            while (!check || !(input > 0 && input < 10) || !check2) {
                Console.WriteLine("Invalid input! Choose another!");
                key = Console.ReadLine();
                check = int.TryParse(key, out input);
                check2 = CheckIfValid(key);
            }

            return UpdateChoice(input, playerNum);
        }

        static int UpdateChoice(int input, int playerNum) {
            int count = 1;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    if (count == input) {
                        if (playerNum == 1) {
                            choices[i, j] = "X";
                        } else {
                            choices[i, j] = "O";
                        }
                    }
                    count++;
                }
            }

            return (playerNum == 1) ? 2 : 1;
        }

        static bool CheckIfValid(string input) {
            foreach (string key in choices) {
                if (key == input) {
                    return true; // this means it is a free spot
                }
            }

            return false; // this means that it has lready been taken by a player
        }

        static void ShowChoices() {
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    Console.WriteLine("{0}, {1} is {2}", i, j, choices[i, j]);

                }
            }
        }

        static void StartGame() {
            string hasWon = null;
            int playersTurn = 1;
            ResetChoices();
            while (hasWon == null) {
                PrintBoard();
                Console.WriteLine();
                Console.WriteLine("Player {0}: Choose your field!", playersTurn);
                playersTurn = ChooseSpot(playersTurn);
                hasWon = Checker(choices);
            }

            if (hasWon == "X") {
                hasWon = "1";
            } else {
                hasWon = "2";
            }
            Console.WriteLine();
            Console.WriteLine("Player {0} has won!", hasWon);
        }

        static void Main(string[] args) {
            StartGame();
        }
    }
}
