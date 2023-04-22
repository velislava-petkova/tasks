using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColoredBalls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> balls = new Dictionary<string, int>();
            string input = "";

            int allBallsCount = 0;

            //we can control the input by converting to lovercase so we don't have mistakes with different typing of commands and colors
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] newColor = input.Split(':', (char)StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = newColor[0].Trim().ToLower();
                int count = int.Parse(newColor[1]);

                //if we try to add negative number of balls the input is invalid
                //if we add 0 balls we don't actually need to add anything to the box, so we can skip it
                if (count <= 0) continue;


                //My solution is designed this way so that we can add one color multiple times (first 4 yellow balls, then 3 more etc.)
                if (balls.ContainsKey(color))
                {
                    balls[color] += count;
                }
                else
                {
                    balls[color] = count;
                }

                allBallsCount += count; //We will calculate the total number of balls in the box
            }

            if (balls.Count == 1)
            {
                Console.WriteLine(0); //We don't need to remove any balls, we only have one color in the bag, so the answer is 0
                return;
            }

            Console.WriteLine(allBallsCount - 1);

            /*
            In any case where we have multiple colors we can only be 100% sure we have 1 color in the bag if we remove all but 1 ball.
            For example, if we have 10 red balls and 2 green ones in the best case scenario we can remove the 2 green balls first and then we will have
            the 10 red ones left, but we cannot be sure these are the ones we have removed. 
            
            In the worst case scenario we will remove 9 red balls and 1 green ball and in order to have only one color left we 
            will have to remove one of the two remaining balls, which means the removed count is allBallsCount-1;


            Other ideas
            If we are "sure" when we have at least 95% possibility (for example) of having only one color in the bag we will have a different approach.
            We can calculate the possibility of having only one color in the bag every time we remove a ball, and when we reach >=95% we will stop removing balls.           
            */

        }
    }
}
