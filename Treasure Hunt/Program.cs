using System;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            Char[,] Island = new char[20, 20]; //generate Island
            Random R = new Random(); //random number generator
            int PosRow = R.Next(0, 20); //get treasure row
            int PosCol = R.Next(0, 20); //get treasure col
            Island[PosRow, PosCol] ='X'; //mark treasure on the map
            int RowLength = Island.GetLength(0);
            int colLength = Island.GetLength(1);
            
            Char[,] Island1 = new char[20, 20];

            
            for (int i = 0; i < colLength; i++)
            {
                for (int j = 0; j < RowLength; j++)
                {
                    Island1[j, i] = '~';
                   
                }
                

            }
            
            while (true)
            {
                Console.Clear();
                
                for (int i = 0; i < RowLength; i++)
                {
                    
                    for (int j = 0; j < colLength; j++)
                    {
                        
                        Console.Write(" {0}", Island1[j, i]);
                    }
                    Console.Write("\n");

                }


                Console.WriteLine(PosRow + " " + PosCol);
                Console.Write("\nEnter a guess for the row:");
                int rowGuess = 0;
                Input(ref rowGuess, 19);
                Console.Write("Enter a guess for the column:");
                int colGuess = 0;
                Input(ref colGuess, 19);

                if (Island[rowGuess, colGuess] == Island[PosRow, PosCol])
                {
                    Console.WriteLine("Well Done!");
                    break;
                }
                else if (Island1[rowGuess, colGuess] == 'M')
                {
                    Console.WriteLine("You have already guessed this spot.\nHit a Key.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("It is not in this spot.");
                    Island1[rowGuess, colGuess] = 'M';
                    double distance = Math.Sqrt(Math.Pow(PosRow - rowGuess, 2) + Math.Pow(PosCol - colGuess, 2));
                    distance = Math.Round(distance, 2);
                    if (distance > 10)
                    {
                        Console.WriteLine("You are more than 10 meters away.");
                    }
                    else
                    {
                        Console.WriteLine("You are {0} meters away", distance);
                    }
                    Console.WriteLine("Hit a key.");
                    Console.ReadKey();
                }


            }
            
            static void Input(ref int input, int max)
            {
                while(input == 0)
                {
                    try
                    {
                        input = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        input = 0;
                        Console.Write("Please re-enter a valid value: ");
                    }
                }
                if(input > max)
                {
                    Console.Write("Please enter a valid value between 0 and 19: ");
                    input = 0;
                    Input(ref input, max);
                }
            }






        }
    }
}
