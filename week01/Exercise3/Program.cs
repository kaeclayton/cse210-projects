using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(100);

        string playGame = "yes";

        while (playGame == "yes")
        {
            int number = -1;
            int counter = 1;

            while (number != magicNumber)
            {
                Console.Write("Give me a guess for the magic number: ");
                string userInput = Console.ReadLine();
                number = int.Parse(userInput);

                if (number == magicNumber)
                {
                    Console.WriteLine("You guessed it!");
                }
                else if (number < magicNumber)
                {
                    Console.WriteLine("Too low, guess higher");
                }
                else
                {
                    Console.WriteLine("Too high, guess lower ");
                }

                counter += 1;

            }

            Console.WriteLine($"It took you {counter} times to guess the magic number");

            Console.Write("Do you want to play again? (yes/no) ");
            playGame = Console.ReadLine();

        }
    }
}