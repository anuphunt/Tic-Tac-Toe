using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class AI : IPlayer
    {
        /*
         * About to win = 10
         * About to lose = 7
         * One 1 and two 0= 5
         * One 2 and two 0 = 3
         * If center is 0 = 4
         * all 0 = 1
         * one 1, one 2 and one 0 = 0
         * 
         */


        public AIPriority AnalyseRows(int[,] matrix)
        {
            AIPriority backup = new AIPriority();
            Coordinates bc = new Coordinates();
            backup.Coordinates = bc;
            Coordinates c = new Coordinates();
            AIPriority p = new AIPriority();

            //For each rows Check for Win or Lose
            for (int i = 0; i < 3; i++)
            {
                List<int> l = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    l.Add(matrix[i, j]);
                }

                //Rows for Win or Lose
                if (l.Distinct().Count() == 2 && l.Count(n => n == 0) == 1)
                {
                    int zeropos = 0;
                    foreach (int num in l)
                    {
                        if (num != 0)
                            zeropos++;
                        else break;
                    }
                    c.x = i;
                    c.y = zeropos;
                    p.Coordinates = c;

                    //if about to win
                    if (l.First(a => a != 0) == 1)
                    {
                        p.Priority = 10;
                        return p;
                    }
                    //if about to lose
                    else
                        p.Priority = 7;
                    if (backup.Priority < p.Priority)
                    {
                        backup.Priority  = p.Priority;
                        bc.x = p.Coordinates.x;
                        bc.y = p.Coordinates.y;
                    }
                }

                //if one number and two zeroes
                else if (l.Count(n => n == 0) == 2)
                {
                    c.x = i;
                    if (matrix[i, 2] == 0)
                    {
                        c.y = 2;
                    }
                    else if (matrix[i, 0] == 0 && matrix [i,2] != 0)
                    {
                        c.y = 0;
                    }
                    else { c.y = 1; }
                    p.Coordinates = c;
                    //if one 1 and two zero
                    if (l.First(a => a != 0) == 1)
                    {
                        p.Priority = 5;
                    }

                    //if one 2 and two zeroes
                    else if(l.First(a => a!=0) ==2)
                        p.Priority = 3;

                    if (backup.Priority < p.Priority)
                    {
                        backup.Priority = p.Priority;
                        bc.x = p.Coordinates.x;
                        bc.y = p.Coordinates.y;
                    }
                }
                
                //if all zeroes
                else if (l.Count(n => n == 0) == 3)
                {
                    c.x = i;
                    c.y = 0;
                    p.Priority = 1;
                    p.Coordinates = c;
                    if (backup.Priority < p.Priority)
                    {
                        backup.Priority = p.Priority;
                        bc.x = p.Coordinates.x;
                        bc.y = p.Coordinates.y;
                    }

                }
                else
                {
                    for (int k = 0; k<3; k++)
                    {
                        if(matrix[i,k] == 0)
                        {
                            c.x = i;
                            c.y = k;
                            p.Coordinates = c;
                            p.Priority = 0;
                            break;
                        }
                    }
                    if(backup.Priority < p.Priority)
                    {
                        backup.Priority = p.Priority;
                        bc.x = p.Coordinates.x;
                        bc.y = p.Coordinates.y;
                    }
                }
            }

            return backup;
        }

        public AIPriority AnalyseColumns(int [,] matrix)
        {
            AIPriority backup = new AIPriority();
            Coordinates bc = new Coordinates();
            backup.Coordinates = bc;
            Coordinates c = new Coordinates();
            AIPriority p = new AIPriority();

            for (int i = 0; i<3; i++)
            {
                List<int> l = new List<int>();
                for (int j = 0; j<3; j++)
                {
                    l.Add(matrix[j, i]);
                }
              // Columns for Win or lose
              if(l.Distinct().Count() == 2 && l.Count(n => n == 0) == 1)
                {
                   int zeropos = 0;
                    foreach (int num in l)
                    {
                        if (num != 0)
                            zeropos++;
                        else break;
                    }
                    c.x = zeropos;
                    c.y = i;
                    p.Coordinates = c;

                    //if about to win
                    if (l.First(a => a != 0) == 1)
                    {
                        p.Priority = 10;
                        return p;
                    }
                    //if about to lose
                    else
                        p.Priority = 7;
                    if (backup.Priority < p.Priority)
                    {
                        backup.Priority = p.Priority;
                        bc.x = p.Coordinates.x;
                        bc.y = p.Coordinates.y;
                    }
                }
                //if one number and two zeroes <Columns>
                else if (l.Count(n => n == 0) == 2)
                {
                    c.y = i;
                    if (matrix[2, i] == 0)
                    {
                        c.x = 2;
                    }
                    else if (matrix[0, i] == 0 && matrix[2, i] != 0)
                    {
                        c.x = 0;
                    }
                    else { c.x = 1; }
                    p.Coordinates = c;
                    //if one 1 and two zero
                    if (l.First(a => a != 0) == 1)
                    {
                        p.Priority = 5;
                    }
                    else if (l.First(a => a != 0) == 2)
                        p.Priority = 3;

                    if (backup.Priority < p.Priority)
                    {
                        backup.Priority = p.Priority;
                        bc.x = p.Coordinates.x;
                        bc.y = p.Coordinates.y;
                    }
                }
                //if all zeroes
                else if (l.Count(n => n == 0) == 3)
                {
                    c.y = i;
                    c.x = 0;
                    p.Priority = 1;
                    p.Coordinates = c;
                    if (backup.Priority < p.Priority)
                    {
                        backup.Priority = p.Priority;
                        bc.x = p.Coordinates.x;
                        bc.y = p.Coordinates.y;
                    }

                }
                else
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (matrix[k, i] == 0)
                        {
                            c.x = k;
                            c.y = i;
                            p.Coordinates = c;
                            p.Priority = 0;
                            break;
                        }
                    }
                    if (backup.Priority < p.Priority)
                    {
                        backup.Priority = p.Priority;
                        bc.x = p.Coordinates.x;
                        bc.y = p.Coordinates.y;
                    }
                }
            }
            return backup;
        }

        public AIPriority AnalyseDiagonal(int [,] matrix)
        {
            AIPriority backup = new AIPriority();
            Coordinates bc = new Coordinates();
            backup.Coordinates = bc;
            AIPriority p = new AIPriority();
            Coordinates c = new Coordinates();

            List<int> l = new List<int>();
            for(int i = 0; i<3; i++)
            {
                l.Add(matrix[i, i]);
            }

            //Diagonal for win or lose
            if (l.Distinct().Count() == 2 && l.Count(n => n == 0) == 1)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (l[k] == 0)
                    {
                        c.x = k;
                        c.y = k;
                        break;
                    }
                }
                p.Coordinates = c;

                //if about to win
                if (l.First(a => a != 0) == 1)
                {
                    p.Priority = 10;
                    return p;
                }
                else
                    p.Priority = 7;
                if (backup.Priority < p.Priority)
                {
                    backup.Priority = p.Priority;
                    bc.x = p.Coordinates.x;
                    bc.y = p.Coordinates.y;
                }
            }

            //if one number and two zeroes 
            else if (l.Count(n => n == 0) == 2)
            {
                int k = 1;
                while (l[k] != 0)
                {
                    k++;
                }
                c.x = k;
                c.y = k;
                p.Coordinates = c;
                //if one 1 and two zero
                if (l.First(a => a != 0) == 1)
                {
                    p.Priority = 5;
                }
                else if (l.First(a => a != 0) == 2)
                    p.Priority = 3;

                if (backup.Priority < p.Priority)
                {
                    backup.Priority = p.Priority;
                    bc.x = p.Coordinates.x;
                    bc.y = p.Coordinates.y;
                }
            }
            
            if (matrix[1, 1] == 0)
            {
                c.x = 1;
                c.y = 1;
                p.Coordinates = c;
                p.Priority = 4;
                if (backup.Priority < p.Priority)
                {
                    backup.Priority = p.Priority;
                    bc.x = p.Coordinates.x;
                    bc.y = p.Coordinates.y;
                }
            }
            return backup;
        }

        public AIPriority AnalyseReverseDiagonal(int [,] matrix)
        {
            AIPriority backup = new AIPriority();
            Coordinates bc = new Coordinates();
            backup.Coordinates = bc;
            Coordinates c = new Coordinates();
            AIPriority p = new AIPriority();

            List<int> l = new List<int>();
            l.Add(matrix[0, 2]);
            l.Add(matrix[1, 1]);
            l.Add(matrix[2, 0]);

            //Analyse 2 numbers and 1 zero win or lose
            if (l.Distinct().Count() == 2 && l.Count(n => n == 0) == 1)
            {
                int zeropos = 0;
                for(int k = 0; k<3; k++)
                {
                    if (l[k] != 0)
                        zeropos++;
                    else break;
                }
                if(zeropos == 0)
                {
                    c.x = 0;
                    c.y = 2;
                }
                else if(zeropos == 1)
                {
                    c.x = 1;
                    c.y = 1;
                }
                else
                {
                    c.x = 2;
                    c.y = 0;
                }
                p.Coordinates = c;
                //if about to win
                if (l.First(a => a != 0) == 1)
                {
                    p.Priority = 10;
                    return p;
                }
                //if about to lose
                else
                    p.Priority = 7;
                if (backup.Priority < p.Priority)
                {
                    backup.Priority = p.Priority;
                    bc.x = p.Coordinates.x;
                    bc.y = p.Coordinates.y;
                }
            }
            //if one number and two zeroes 
            else if (l.Count(n => n == 0) == 2)
            {
               if(matrix[0,2] == 0)
                {
                    c.x = 0;
                    c.y = 2;
                }
               else
                {
                    c.x = 2;
                    c.y = 0;
                }
                p.Coordinates = c;
                //if one 1 and two zero
                if (l.First(a => a != 0) == 1)
                {
                    p.Priority = 5;
                }
                else if (l.First(a => a != 0) == 2)
                    p.Priority = 3;

                if (backup.Priority < p.Priority)
                {
                    backup.Priority = p.Priority;
                    bc.x = p.Coordinates.x;
                    bc.y = p.Coordinates.y;
                }
            }
            return backup;
        }
        public Coordinates play(int[,] matrix)
        {
            List<AIPriority> sort = new List<AIPriority>();
            AIPriority diagonal = AnalyseDiagonal(matrix);
            AIPriority reversediagonal = AnalyseReverseDiagonal(matrix);
            AIPriority row = AnalyseRows(matrix);
            AIPriority col = AnalyseColumns(matrix);

            sort.Add(diagonal);
            sort.Add(reversediagonal);
            sort.Add(row);
            sort.Add(col);

            return sort.FirstOrDefault(x => x.Priority == sort.Max(x1 => x1.Priority))?.Coordinates;
        }
        public int Symbol { get; set; }
    }
}
