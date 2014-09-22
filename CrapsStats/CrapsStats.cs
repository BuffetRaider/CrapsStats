using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsStats
{
    public class Craps
    {
        // create random number generator for use in method RollDice
        private static Random randomNumbers = new Random();

        // enumeration with constants that represent the game status
        public enum Status { CONTINUE = -1, WON, LOST }

        // plays one game of craps
        public static void Main(string[] args)
        {
            int SIZE = 21;
            int myPoint = 0;
            int RollCount = 0; 
            int[] WinningRoll = new int [SIZE];
            int[] LosingRoll = new int [SIZE];

            Status gameStatus;

            for (int i = 0; i < 1000; i++)
            {
                
                int sum = RollDice();
                RollCount = 0;
                switch (sum)
                {

                    case 7:
                    case 11:
                        gameStatus = Status.WON;
                        break;

                    case 2:
                    case 3:
                    case 12:
                        gameStatus = Status.LOST;
                        break;
                    default:
                        gameStatus = Status.CONTINUE;
                        myPoint = sum;
                        break;
                }

                while (gameStatus == Status.CONTINUE)
                {
                    RollCount++;
                    sum = RollDice();
                    if (sum == myPoint)
                    {
                        gameStatus = Status.WON;
                    }
                    else
                    {
                        if (sum == 7)
                        {
                            gameStatus = Status.LOST;
                        }
                    }
                }
                
                if (gameStatus == Status.WON)
                {
                    if (RollCount > SIZE)
                    {
                        WinningRoll[SIZE - 1]++;
                    }
                    else
                    {
                        WinningRoll[RollCount]++;
                    }
                 }
                
                else
                    {
                            if (RollCount > SIZE)
                            {
                                LosingRoll[SIZE - 1]++;
                            }
                            else
                            {
                                LosingRoll[RollCount]++;
                            }

                    }

               
            }

            //Console.WriteLine("RollCount = " + RollCount + Environment.NewLine);

            for (int i = 0; i < SIZE - 1; i++)
            {
                Console.WriteLine(WinningRoll[i] + " games won on roll " + (i + 1) + ".\n");
            }

            Console.WriteLine(WinningRoll[SIZE - 1] + " games won on or after roll " + SIZE + ".\n");
                    
            for (int i = 0; i < SIZE - 1; i++)
            {
                Console.WriteLine(LosingRoll[i] + " games lost on roll " + (i + 1) + ".\n");
            }

            Console.WriteLine(LosingRoll[SIZE - 1] + " games lost on or after roll " + SIZE + ".\n");
                    
            Console.ReadLine();
        }


        // roll dice, calculate sum and display results
        public static int RollDice()
        {
            // pick random die values
            int die1 = randomNumbers.Next(1, 7); // first die roll
            int die2 = randomNumbers.Next(1, 7); // second die roll

            int sum = die1 + die2; // sum of die values
            //Console.WriteLine("Rolled " + die1 + " + " + die2 + " = " + sum);
            return sum; // return sum of dice
        } // end method RollDice
    } // end class Craps
}
