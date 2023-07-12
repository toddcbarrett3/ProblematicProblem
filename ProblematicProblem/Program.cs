using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont = true;
            bool seeList = true;
            bool addToList = true;
            bool validUserAge = false;
            int userAge = 0;
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            //cont = bool.Parse(Console.ReadLine());
            var userResponse = Console.ReadLine();
            userResponse = userResponse.ToLower();
            Console.WriteLine(userResponse);
            if (userResponse == "yes") { cont = true; } else { cont = false; }
            if (!cont) { Console.WriteLine("\nThank you have a nice day!"); }
            else
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                while (!validUserAge)
                {
                    Console.Write("What is your age? ");
                    validUserAge = int.TryParse(Console.ReadLine(), out userAge);
                }
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: \n");
                var seeListView = Console.ReadLine();
                seeListView = seeListView.ToLower();
                if (seeListView == "sure") { seeList = true; } else if (seeListView == "yes") { seeList = true; } else { seeList = false; }

                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: \n");

                    var addToListView = Console.ReadLine();
                    addToListView = addToListView.ToLower();
                    if (addToListView == "yes") { addToList = true; } else { addToList = false; }
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? \n");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("\nWould you like to add more? yes/no: \n");
                        addToListView = Console.ReadLine();
                        addToListView = addToListView.ToLower();
                        if (addToListView == "yes") { addToList = true; } else { addToList = false; break; }
                        Console.WriteLine();
                    }
                }

                while (cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"\nOh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("\nPick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.WriteLine();
                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    var keepRedo = Console.ReadLine();
                    keepRedo = keepRedo.ToLower();
                    if (keepRedo == "redo") { cont = true; } else { cont = false; break; }
                }
            }
        }
    }
}