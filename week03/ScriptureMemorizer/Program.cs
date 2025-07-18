using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        List<Scripture> scriptures = library.GetScriptures();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("Choose a scripture to memorize: ");

            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetReferenceDisplay()}");
            }

            Console.Write("Enter number (or 0 to quit): ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    running = false;
                }
                else if (choice > 0 && choice <= scriptures.Count)
                {
                    Scripture selectedScripture = scriptures[choice - 1];
                    RunMemorizationSession(selectedScripture);
                }
                else
                {
                    Console.WriteLine("Invalid selection. Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }    

    static void RunMemorizationSession(Scripture scripture)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden.  Press any key to return to menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'menu' to return: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "menu")
            {
                return;
            }

            scripture.HideRandomWords(3);
            }
        }
}