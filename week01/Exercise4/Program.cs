using System;

Console.WriteLine("Hello World! This is the Exercise4 Project.");

int number = -1;
List<int> numbers = new List<int>();
Console.WriteLine("What number do you want to add to your list?");
Console.WriteLine("Enter 0 when done.");

while (number != 0)
{
    Console.Write("Enter a number: ");
    string userInput = Console.ReadLine();
    number = int.Parse(userInput);

    if (number != 0)
    {
        numbers.Add(number);
    }
    else
    {
        int numberCount = numbers.Count;
        Console.WriteLine($"You entered {numberCount} numbers");
    }
}

int sum = 0;
int maximum = 0;

foreach (int num in numbers)
{
    sum = sum + num;

    if (num > maximum)
    {
        maximum = num;
    }
}

int numCount = numbers.Count;
float average = sum / numCount;

Console.WriteLine($"The sum is: {sum}");
Console.WriteLine($"The average is: {average}");
Console.WriteLine($"The largest number is: {maximum}");
