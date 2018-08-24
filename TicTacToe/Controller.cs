using System;

namespace TicTacToe
{
    class Controller
    {
        public static int [,] Reset()
        {
            int[,] matrix = new int[3, 3] 
            {
                {0,0,0},
                {0,0,0 },
                {0,0,0 }
            };
            return matrix;
        }

        static void Multiplayer()
        {
            var matrix = Reset();
            IPlayer Player1 = new Human();
            IPlayer Player2 = new Human();
            Coordinates c = new Coordinates();
            IPlayer CurrentPlayer = Player2;
            board.displayboard(matrix);

            do
            {
                c = CurrentPlayer.play(matrix);
                if (CurrentPlayer == Player2)
                {
                    board.UpdateBoard(matrix, c, 2);
                    board.displayboard(matrix);
                    CurrentPlayer = Player1;
                }
                else
                {
                    board.UpdateBoard(matrix, c, 1);
                    board.displayboard(matrix);
                    CurrentPlayer = Player2;
                }
            }
            //play the game
            while (GameStatus.IsGameOver(matrix) == 0);

            var ret = GameStatus.IsGameOver(matrix);
            if (ret == 1)
            {
                Console.WriteLine("Player 1 wins!!");
            }
            else if (ret == 2)
            {
                Console.Write("Player 2 wins!!");
            }

            else if (ret == 3)
            {
                Console.WriteLine("Draw");
            }

        }

        static void SinglePlayer()
        {
                var matrix =  Reset();
                IPlayer human = new Human() { Symbol = 2 };
                IPlayer ai = new AI() { Symbol = 1 };
                Coordinates c = new Coordinates();
                IPlayer CurrentPlayer = human;
                board.displayboard(matrix);
            

            do
            {

                c = CurrentPlayer.play(matrix);
                

                if (CurrentPlayer == human)
                {
                    board.UpdateBoard(matrix, c, 2);
                    board.displayboard(matrix);
                    CurrentPlayer = ai;
                }
                else
                {
                    board.UpdateBoard(matrix, c, 1);
                    board.displayboard(matrix);
                    CurrentPlayer = human;
                }
            }
            //play the game
            while (GameStatus.IsGameOver(matrix) == 0);


            var ret = GameStatus.IsGameOver(matrix);
            if (ret == 1)
            {
                Console.WriteLine(" :( You Lose!");
            }
            else if (ret == 2)
            {
                Console.Write("Congratulations!! You Win!! :D");
            }

            else if (ret == 3)
            {
                Console.WriteLine("Draw");
            }
        }
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Press S for Single Player, D for Double Player");
                char c = Console.ReadKey().KeyChar;
                if (c == 'S' || c == 's')
                {
                    SinglePlayer();
                }
                else
                {
                    Multiplayer();
                }

                Console.WriteLine("Press any key to play again. Q to quit.");
                var k = Console.ReadKey().KeyChar;
                if (k == 'q' || k == 'Q')
                {
                    break;
                }
            }

        }

    }
}
