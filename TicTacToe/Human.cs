using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Human : IPlayer
    {

        //Player types coordinates
        public static Coordinates GetPlayerInput(int[,] matrix)
        {
            Coordinates c = new Coordinates();
            int x = 0;
            int y = 0;

            List<int> pi = new List<int>();
            Console.WriteLine("YOUR TURN:");
            Console.WriteLine("Hint: Type the x and y coordinates separated with comma. (No Spaces)");
            string input = Console.ReadLine();

            if (input.Length != 3)
            {
                Console.WriteLine("Invalid Co-ordinates. Please Try again! (str length greater than 3)");
                c = GetPlayerInput(matrix);
            }

            string[] inputarr = input.Split(',');
            int.TryParse(inputarr[0].ToString(), out x);
            int.TryParse(inputarr[1].ToString(), out y);
            c.x = x;
            c.y = y;

            if (x >= 3 || y >= 3)
            {
                Console.WriteLine("Invalid Coordinates. Please Try again!");
                c = GetPlayerInput(matrix);
            }
            if (matrix[x,y] == 1|| matrix[x,y] == 2)
            {
                Console.WriteLine("Already filled. ");
                c = GetPlayerInput(matrix);
            }
            return c;
        }
        public Coordinates play(int[,] matrix)
        {
            Coordinates playerinput = GetPlayerInput(matrix);
            return playerinput;
        }
        public int Symbol { get; set; }

    }
}
