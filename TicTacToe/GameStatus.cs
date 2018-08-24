using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameStatus
    {
        public static int CheckRow(int[,] matrix)
        {
            List<int> l = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    l.Add(matrix[i, j]);
                }

                if (l.Distinct().Count() == 1 && l[0] != 0)
                    return l[0];
                l.Clear();
            }
            return 234;
        }

        public static int CheckColumn(int[,] matrix)
        {
            List<int> l = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    l.Add(matrix[j, i]);
                }
                if (l.Distinct().Count() == 1 && l[0] != 0)
                    return l[0];
                l.Clear();
            }
            return 234;
        }

        public static int CheckDiagonal(int[,] matrix)
        {
            List<int> l = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                l.Add(matrix[i, i]);
            }

            if (l.Distinct().Count() == 1 && l[0] != 0)
            {
                return l[0];
            }
            l.Clear();
            return 234;
        }

        public static int CheckReverseDiagonal(int[,] matrix)
        {
            List<int> l = new List<int>();

            l.Add(matrix[0, 2]);
            l.Add(matrix[1, 1]);
            l.Add(matrix[2, 0]);

            if (l.Distinct().Count() == 1 && l[0] != 0)
            {
                return l[0];
            }
            l.Clear();
            return 234;
        }

        public static bool EmptyFields(int[,] matrix)
        {
            List<int> l = new List<int>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    l.Add(matrix[i, j]);
                }

                if (l.Contains(0))
                {
                    return true;
                }
                l.Clear();
            }
            return false;
        }

        //1 == AI Win
        //2 == Human win
        //3 = Draw
        //0 == Game not over
        public static int IsGameOver(int [,] matrix)
        {
            if (CheckRow(matrix) ==1 || CheckColumn(matrix) ==1 || CheckDiagonal(matrix)==1 || CheckReverseDiagonal(matrix)==1)
            {
                return 1;
            }

            if (CheckRow(matrix) == 2 || CheckColumn(matrix) == 2 || CheckDiagonal(matrix) == 2 || CheckReverseDiagonal(matrix) == 2)
            {
                return 2;
            }

            if (!EmptyFields(matrix))
            {
                return 3;
            }
            else { return 0; }
        }
    }
}
