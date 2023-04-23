using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrots_v2
{
    internal class Program
    {
        /*
         This solution only works with square groups of carrots
         */
        public static int countJumps(char[,] garden)
        {
            int count = 0;
            int n = garden.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (garden[i, j] == 'c')
                    {
                        if ((i == 0 || garden[i - 1, j] != 'c') && (j == 0 || garden[i, j - 1] != 'c'))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Type dimension of garden: ");
            int dimension = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimension, dimension];

            Console.WriteLine("Log garden and type symbol 'c' for carrot:");

            for (int i = 0; i < dimension; i++)
            {
                string row = Console.ReadLine();

                for (int k = 0; k < dimension; k++)
                {
                    matrix[i, k] = row[k];
                }
            }

            Console.WriteLine(countJumps(matrix));
        }
    }
}
