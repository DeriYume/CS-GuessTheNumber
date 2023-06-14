using System;

namespace GuessTheNumberGame
{
    class Program
    {
        static int maxTries = 10;
        static int currentTry = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Guess The Number!");
            Console.WriteLine("Pick a desired difficulty level: ");
            Console.WriteLine("-> 1: Numbers in range [ 1 , 10 ]");
            Console.WriteLine("-> 2: Numbers in range [ 1 , 100 ]");
            Console.WriteLine("-> 3: Numbers in range [ 1 , 1000 ]");

            int userChoice = ValidateUserChoice();
            int computerNumber = GenerateComputerNumber(userChoice);

            StartGame(computerNumber);
        }

        static int ValidateUserChoice()
        {
            Console.Write("Option: ");

            int result = 0;
            string input = Console.ReadLine();

            while (!(int.TryParse(input, out result) && (result >= 1 && result <= 3)))
            {
                Console.WriteLine("Option not found! Input a valid one!");
                input = Console.ReadLine();
            }

            return result;
        }

        static int GenerateComputerNumber(int level)
        {
            int number = 0;
            switch (level)
            {
                case 1:
                    number = GetRandomNumber(1, 10);
                    break;
                case 2:
                    number = GetRandomNumber(1, 100);
                    break;
                case 3:
                    number = GetRandomNumber(1, 1000);
                    break;
            }

            return number;
        }

        static int GetRandomNumber(int start, int end)
        {
            if (start > end)
            {
                return 0;
            }

            if (start == end)
                return start;

            Random rnd = new Random();
            return rnd.Next(start, end + 1);
        }

        static void StartGame(int computerNumber)
        {
            while (currentTry <= maxTries)
            {
                Console.Write("Pick a number: ");
                int userNumber = int.Parse(Console.ReadLine());

                if (userNumber == computerNumber)
                {
                    DeclareVictory();
                    return;
                }

                if (userNumber < computerNumber)
                {
                    Console.WriteLine("Try with a higher number!");
                    currentTry++;
                }
                else
                {
                    Console.WriteLine("Try with a lower number!");
                    currentTry++;
                }

            }


            Console.WriteLine("You lost! The number was: {0}", computerNumber);
            AskForRestart();
        }

        static void DeclareVictory()
        {
            Console.WriteLine("Congratulations, you won!");
            Console.WriteLine("You used {0} out of {1} guesses.", currentTry, maxTries);
            AskForRestart();
        }

        static void AskForRestart()
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                currentTry = 0;
                Console.Clear();
                Main(new string[1]);
            }

        }
    }
}
