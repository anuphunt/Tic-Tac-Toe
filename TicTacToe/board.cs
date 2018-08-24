using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class board {
        public static void displayboard(int[,] matrix)
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("Welcome to play TicTacToe");

            Console.WriteLine("          |          |         ");
            Console.Write("    ");
            Console.Write(GetSymbol(matrix[0,0]));//0,0
            Console.Write("     |    ");
            Console.Write(GetSymbol(matrix[0, 1]));//0,1
            Console.Write("     |   ");
            Console.Write(GetSymbol(matrix[0, 2])); //0,2
            Console.WriteLine("      ");
            Console.WriteLine("__________|__________|_____________");
            Console.WriteLine("          |          |         ");
            Console.Write("    ");
            Console.Write(GetSymbol(matrix[1, 0]));//1,0
            Console.Write("     |    ");
            Console.Write(GetSymbol(matrix[1, 1]));//1,1
            Console.Write("     |   ");
            Console.Write(GetSymbol(matrix[1, 2])); //1,2
            Console.WriteLine("      ");
            Console.WriteLine("__________|__________|_____________");
            Console.WriteLine("          |          |         ");
            Console.Write("    ");
            Console.Write(GetSymbol(matrix[2, 0]));//2,0
            Console.Write("     |    ");
            Console.Write(GetSymbol(matrix[2, 1]));//2,1
            Console.Write("     |   ");
            Console.Write(GetSymbol(matrix[2, 2])); //2,2
            Console.WriteLine("      ");
            Console.WriteLine("          |          |");
        }

        //Symbol
        private static string GetSymbol(int value)
        {
            if (value == 0)
                return " ";
            else if (value == 1)
                return "O";
            else if (value == 2)
                return "X";
            else return " ";
        }

        //Update Matrix human = 2; AI = 1
        public static void UpdateBoard(int[,] matrix, Coordinates c, int player)
        {
            int x = c.x;
            int y = c.y;
            
            if(player == 1)
            {
                matrix[x, y] = 1;
            }
            else if (player == 2)
            {
                matrix[x, y] = 2;
            }
        }
    }
 }
