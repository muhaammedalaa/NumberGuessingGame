namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool playAgain = true;
            Console.WriteLine("Welcome to the Number Guessing Game!");
            while (playAgain)
            {
                Console.WriteLine("\nSelect difficulty level: ");
                Console.WriteLine("1. Easy (10 chances)");
                Console.WriteLine("2. Medium (5 chances)");
                Console.WriteLine("3. Hard (3 chances)");
                Console.Write("Enter your choice (1-3): ");
                string choice = Console.ReadLine();
                int maxNumber = choice switch
                {
                    "1" => 10,
                    "2" => 5,
                    "3" => 3,
                    _ => 5
                };
                Console.WriteLine($"You have {maxNumber} attempts to guess the correct number.");

                int numberToGuess = random.Next(1, 101);
                int attempts = 0;
                bool hasGuessedCorrectly = false;
                while (attempts < maxNumber)
                {
                    Console.Write("Enter your guess (1-100): ");
                    if (!int.TryParse(Console.ReadLine(), out int userGuess))
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                        continue;
                    }
                    attempts++;
                    if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations! You've guessed the correct number {numberToGuess} in {attempts} attempts.");
                        hasGuessedCorrectly = true;
                        break;
                    }
                    if (attempts == maxNumber)
                    {
                        Console.WriteLine($"Sorry, you've used all your attempts. The correct number was {numberToGuess}.");
                    }
                    Console.Write("Do you want to play again? (y/n): ");
                    string playAgainInput = Console.ReadLine().ToLower();
                    playAgain = playAgainInput == "y" || playAgainInput == "yes";


                }
                Console.WriteLine("Thanks for playing!");


            }
        }
    }
}
