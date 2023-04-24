using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


/*
 Example tests:

8
x--x--xx
xx-x-xx-
x--x-x-x
---xxx--
-x----xx
-x----x-
-xx--xx-
---x----


6
------
-xx-x-
--xxx-
---x-x
xx--xx
x---xx

5
xx---
-----
---xx
---xx
---xx

4
x--x
-x--
x--x
--x-

7
xx-----
-x---xx
-xx--x-
--xx-x-
---xxx-
---x---
---xx--
 
 */

namespace Rabbit_carrots
{
    internal class Program
    {

        public static char carrot = 'x';
        public static char empty = '-';

        public static void goLeft(int x, int y, char[,] matrix, int[,] visited, int dim)
        {
            //We want to go left from [x,y] but if we are in the first column of the
            //position on the left contains empty space or visited carrot we will stop here, we don't need to go left
            if (y == 0 || matrix[x, y - 1] == empty || visited[x, y - 1] == 1)
            {
                return;
            }

            //We will mark the left space as visited and we will start searching from there
            visited[x, y - 1] = 1;

            //Note, we have come here by going left so if we go right we will be going back to visited carrot so we can skip that 
            goLeft(x, y - 1, matrix, visited, dim);
            goUp(x, y - 1, matrix, visited, dim);
            goDown(x, y - 1, matrix, visited, dim);
        }

        public static void goRight(int x, int y, char[,] matrix, int[,] visited, int dim)
        {

            //If we are in the last column of the garden or the
            //position on the left contains empty space or visited carrot we will stop here, we don't need to go right
            if (y == dim - 1 || matrix[x, y + 1] == empty || visited[x, y + 1] == 1)
            {
                return;
            }

            //Same as before, we mark it as visited and go to the other directions
            visited[x, y + 1] = 1;
            goRight(x, y + 1, matrix, visited, dim);
            goUp(x, y + 1, matrix, visited, dim);
            goDown(x, y + 1, matrix, visited, dim);

        }

        public static void goUp(int x, int y, char[,] matrix, int[,] visited, int dim)
        {
            //If we are at the first row we can't go up
            if (x == 0 || matrix[x - 1, y] == empty || visited[x - 1, y] == 1)
            {
                return;
            }

            visited[x - 1, y] = 1;

            goLeft(x - 1, y, matrix, visited, dim);
            goRight(x - 1, y, matrix, visited, dim);
            goUp(x - 1, y, matrix, visited, dim);
        }

        public static void goDown(int x, int y, char[,] matrix, int[,] visited, int dim)
        {
            //If we are at the last row we can't go down
            if (x == dim - 1 || matrix[x + 1, y] == empty || visited[x + 1, y] == 1)
            {
                return;
            }

            visited[x + 1, y] = 1;
            goLeft(x + 1, y, matrix, visited, dim);
            goRight(x + 1, y, matrix, visited, dim);
            goDown(x + 1, y, matrix, visited, dim);
        }




        //This function is here for testing purposes only :)
        public static void print<T>(T[,] matrix, int dimension)
        {
            for (int i = 0; i < dimension; i++)
            {

                for (int k = 0; k < dimension; k++)
                {
                    Console.Write(matrix[i, k] + " ");
                }
                Console.WriteLine("");

            }

            Console.WriteLine("----------------------");

        }
        public static void findGroup(int x, int y, char[,] matrix, int[,] visited, int dim)
        {
            /*
            This is the first carrot of our new group so we mark it as visited and we will go and find all
            connected unvisited carrots going left, right, up and down          
            */
            visited[x, y] = 1;
            goLeft(x, y, matrix, visited, dim);
            goRight(x, y, matrix, visited, dim);
            goUp(x, y, matrix, visited, dim);
            goDown(x, y, matrix, visited, dim);

        }

        /*
         This function will iterate through the garden matrix and every time we find a carrot that hasn't been visited(eaten)
         it means that it is a part of a new group and we will go and eat all the carrots in the new group.
         */
        public static int countJumps(char[,] matrix, int[,] visited, int dimension)
        {
            int count = 0;
            for (int i = 0; i < dimension; i++)
            {
                for (int k = 0; k < dimension; k++)
                {
                    //If we find a carrot that has been visited it means it is part of a group we have already counted
                    if (matrix[i, k] == carrot && visited[i, k] == 0)
                    {
                        findGroup(i, k, matrix, visited, dimension);
                        count++;
                    }
                }
            }
            return count;
        }



        static void Main(string[] args)
        {

            Console.Write("Hi there! Please type the dimensions of the garden? : ");
            int dimension = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimension, dimension];
            int[,] visited = new int[dimension, dimension];

            Console.WriteLine("Great! Now log your garden sceme and note that 'x' is how we mark carrot and '-' is empty space");


            for (int i = 0; i < dimension; i++)
            {
                string row = Console.ReadLine();

                for (int k = 0; k < dimension; k++)
                {
                    matrix[i, k] = row[k];
                    visited[i, k] = 0;
                }
            }

            Console.WriteLine("The rabbit will need " + countJumps(matrix, visited, dimension) + " jumps :)");

        }
    }
}


