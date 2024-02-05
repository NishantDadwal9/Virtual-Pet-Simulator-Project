using System;

class VirtualPet
{
    public string Type { get; set; }
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Health { get; set; }

    public VirtualPet(string type, string name)
    {
        Type = type;
        Name = name;
        Hunger = 5;
        Happiness = 5;
        Health = 5;
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"{Name} ({Type}) - Hunger: {Hunger}/10, Happiness: {Happiness}/10, Health: {Health}/10");
    }

    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Health = Math.Min(10, Health + 1);
        Console.WriteLine($"{Name} just ate. Hunger decreased, health increased.");
    }

    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        Hunger = Math.Min(10, Hunger + 1);
        Console.WriteLine($"{Name} is having great time while playing. Happiness increased, hunger increased slightly.");
    }

    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(0, Happiness - 1);
        Console.WriteLine($"{Name} is taking a nap. Health increased, happiness decreased slightly.");
    }

    public void TimePasses()
    {
        Hunger = Math.Min(10, Hunger + 1);
        Happiness = Math.Max(0, Happiness - 1);

        if (Hunger >= 8)
        {
            Console.WriteLine($"{Name} is getting hungry. Consider feeding!");
        }

        if (Happiness <= 2)
        {
            Console.WriteLine($"{Name} is feeling sad. Play with {Name} to increase happiness!");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Virtual Pet Simulator!");
        Console.Write("Enter the type of pet (e.g., cat, dog, rabbit): ");
        string petType = Console.ReadLine();

        Console.Write("Enter the name of your pet: ");
        string petName = Console.ReadLine();

        VirtualPet pet = new VirtualPet(petType, petName);

        Console.WriteLine($"Welcome, {pet.Name} the {pet.Type}!");

        while (true)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Feed");
            Console.WriteLine("2. Play");
            Console.WriteLine("3. Rest");
            Console.WriteLine("4. Status Check");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                pet.Hunger = Math.Max(0, pet.Hunger - 2);
                pet.Health = Math.Min(10, pet.Health + 1);
                Console.WriteLine($"{pet.Name} is fed. Hunger decreased, health increased.");
            }
            else if (choice == "2")
            {
                pet.Happiness = Math.Min(10, pet.Happiness + 2);
                pet.Hunger = Math.Min(10, pet.Hunger + 1);
                Console.WriteLine($"{pet.Name} is playing. Happiness increased, hunger increased slightly.");
            }
            else if (choice == "3")
            {
                pet.Health = Math.Min(10, pet.Health + 2);
                pet.Happiness = Math.Max(0, pet.Happiness - 1);
                Console.WriteLine($"{pet.Name} is resting. Health increased, happiness decreased slightly.");
            }
            else if (choice == "4")
            {
                pet.DisplayStatus();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Exiting the Virtual Pet Simulator. Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                continue;
            }

            pet.TimePasses();

            if (pet.Hunger >= 10 || pet.Happiness <= 0)
            {
                Console.WriteLine($"{pet.Name} has been neglected and is not doing well. Health is deteriorating!");
                pet.Health = Math.Max(0, pet.Health - 2);
            }

            if (pet.Health <= 0)
            {
                Console.WriteLine($"{pet.Name} has passed away due to neglect. Game over!");
                return;
            }
        }
    }
}
