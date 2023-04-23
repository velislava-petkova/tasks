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

        public static char carrot = 'x';
        public static char empty = '-';

        public static bool hasNoNeighbours(int x, int y, char[,] matrix, int dim)
        {
            if ((x == 0 || matrix[x - 1, y] == empty) && (x == dim - 1 || matrix[x + 1, y] == empty)
                && (y == 0 || matrix[x, y - 1] == empty) && (y == dim - 1 || matrix[x, y + 1] == empty))
            {
                Console.WriteLine("has no neighbours: " + x + ';' + y);
                return true;
            }

            return false;
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
        public static void goUp(int x, int y, char[,] matrix, int dim)
        {
            Console.WriteLine("up");

            if ((x == 0 || matrix[x - 1, y] == empty) && (x == dim - 1 || matrix[x + 1, y] == empty))
            {
                goLeft(x, y, matrix, dim);
                goRight(x, y, matrix, dim);
            }
            for (int i = x - 1; i >= 0; i--)
            {
                if (matrix[i, y] == carrot)
                {
                    matrix[i, y] = empty;
                    if (hasNoNeighbours(i, y, matrix, dim)) return;
                    goLeft(i, y, matrix, dim);
                    goRight(i, y, matrix, dim);


                }
                else
                {
                    print(matrix, dim);
                    Console.WriteLine("///////////");
                    return;
                }
            }

        }

        public static void goDown(int x, int y, char[,] matrix, int dim)
        {
            Console.WriteLine("down");


            if ((x == 0 || matrix[x - 1, y] == empty) && (x == dim - 1 || matrix[x + 1, y] == empty))
            {
                goLeft(x, y, matrix, dim);

                goRight(x, y, matrix, dim);
            }

            for (int i = x + 1; i < dim; i++)
            {
                if (matrix[i, y] == carrot)
                {
                    matrix[i, y] = empty;
                    if (hasNoNeighbours(i, y, matrix, dim)) return;
                    goLeft(i, y, matrix, dim);

                    goRight(i, y, matrix, dim);

                }
                else
                {
                    print(matrix, dim);
                    Console.WriteLine("///////////");
                    return;
                }
            }

        }

        public static void goLeft(int x, int y, char[,] matrix, int dim)
        {
            Console.WriteLine("left");

            if ((y == 0 || matrix[x, y - 1] == empty) && (y == dim - 1 || matrix[x, y + 1] == empty))
            {
                goUp(x, y, matrix, dim);
                goDown(x, y, matrix, dim);
            }

            for (int k = y - 1; k >= 0; k--)
            {
                if (matrix[x, k] == carrot)
                {
                    matrix[x, k] = empty;
                    if (hasNoNeighbours(x, k, matrix, dim)) return;
                    goUp(x, y, matrix, dim);
                    goDown(x, y, matrix, dim);

                }
                else
                {
                    print(matrix, dim);
                    Console.WriteLine("///////////");
                    return;
                }
            }


        }

        public static void goRight(int x, int y, char[,] matrix, int dim)
        {
            Console.WriteLine("right");

            if ((y == 0 || matrix[x, y - 1] == empty) && (y == dim - 1 || matrix[x, y + 1] == empty))
            {
                goUp(x, y, matrix, dim);
                goDown(x, y, matrix, dim);
            }

            for (int k = y + 1; k < dim; k++)
            {
                if (matrix[x, k] == carrot)
                {
                    matrix[x, k] = empty;
                    if (hasNoNeighbours(x, k, matrix, dim)) return;
                    goUp(x, y, matrix, dim);
                    goDown(x, y, matrix, dim);

                }
                else
                {
                    print(matrix, dim);
                    Console.WriteLine("///////////");
                    return;
                }

            }

        }
        public static void findGroup(int x, int y, char[,] matrix, int dim)
        {
            for (int i = x; i < dim; i++)
            {
                for (int k = y; k < dim; k++)
                {
                    goLeft(i, k, matrix, dim);
                    goRight(i, k, matrix, dim);

                }
            }
        }


        public static int countJumps(char[,] matrix, int dimension)
        {
            int count = 0;
            for (int i = 0; i < dimension; i++)
            {
                for (int k = 0; k < dimension; k++)
                {
                    if (matrix[i, k] == carrot)
                    {
                        findGroup(i, k, matrix, dimension);
                        print(matrix, dimension);
                        Console.WriteLine(" new group ");
                        count++;
                    }
                }
            }
            return count;
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

            Console.WriteLine(countJumps(matrix, dimension));

            print(matrix, dimension);
        }
    }
}

