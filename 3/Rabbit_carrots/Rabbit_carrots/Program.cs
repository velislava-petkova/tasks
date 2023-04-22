using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit_carrots
{
    internal class Program
    {
        public enum Direction
        {
            up, down, left, right
        }


        public static void print(char[,] matrix, int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {

                for (int k = 0; k < dimension; k++)
                {
                    Console.Write(matrix[i, k]);
                }
                Console.WriteLine();

            }

        }


        public static int findGroup(int x, int y, Direction lastDir, char[,] matrix, int count)
        {
            if (lastDir != Direction.down)
            {
                Console.WriteLine("move up");

                if (x == 0 || matrix[x - 1, y] == '-')
                {
                    return count;
                }

                matrix[x - 1, y] = '-';
                count++;
                findGroup(x, y, Direction.up, matrix, count);
            }

            if (lastDir != Direction.up)
            {
                Console.WriteLine("move down");

                if (x == matrix.Length - 1 || matrix[x + 1, y] == '-')
                {
                    return count;
                }

                matrix[x + 1, y] = '-';
                count++;
                findGroup(x, y, Direction.down, matrix, count);
            }

            if (lastDir != Direction.right)
            {
                if (y == 0 || matrix[x, y - 1] == '-')
                {
                    return count;
                }

                matrix[x, y - 1] = '-';
                count++;
                findGroup(x, y, Direction.left, matrix, count);
            }


            if (lastDir != Direction.left)
            {
                if (y == matrix.Length - 1 || matrix[x, y + 1] == '-')
                {
                    return count;
                }

                matrix[x, y + 1] = '-';
                count++;
                findGroup(x, y, Direction.right, matrix, count);
            }

            return 1;
        }

        public static int countJumps(char[,] matrix)
        {
            int count = 0;
            int carrots = 0;
            while ((carrots = findGroup(0, 0, Direction.right, matrix, 0)) != 0)
            {
                Console.WriteLine("group");
            }
            return 0;
        }



        static void Main(string[] args)
        {
            int dimension = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                string row = Console.ReadLine();

                for (int k = 0; k < dimension; k++)
                {
                    matrix[i, k] = row[k];
                }
            }

            Console.WriteLine(countJumps(matrix));

            print(matrix, dimension);
        }
    }
}
