using System;
class VirtualPet
{
    public string Type { get; set; }
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int MentalHealth { get; set; }
    public int PhysicalHealth { get; set; }

    public VirtualPet(string type, string name)
    {
        Type = type;
        Name = name;
        Hunger = 5;
        MentalHealth = 5;
        PhysicalHealth = 5;
    }
    public void DisplayStatus()
    {
        Console.WriteLine($"{Name} ({Type}) - Hunger: {Hunger}/10, MentalHealth: {MentalHealth}/10, PhysicalHealth: {PhysicalHealth}/10");
    }
    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        PhysicalHealth = Math.Min(10, PhysicalHealth + 1);
        Console.WriteLine($"{Name} just ate. Hunger decreased, PhysicalHealth increased.");
    }
    public void Play()
    {
        MentalHealth = Math.Min(10, MentalHealth + 2);
        Hunger = Math.Min(10, Hunger + 1);
        Console.WriteLine($"{Name} is having great time while playing. MentalHealth increased, Hunger increased slightly.");

    }
    public void Rest()
    {
        PhysicalHealth = Math.Min(10, PhysicalHealth + 2);
        MentalHealth = Math.Max(0, MentalHealth - 1);
        Console.WriteLine($"{Name} is taking a nap. PhysicalHealth increased, MentalHealth decreased slightly.");
    }

    public void TimePasses()
    {
        Hunger = Math.Min(10, Hunger + 1);
        MentalHealth = Math.Max(0,  MentalHealth - 1);

        if (Hunger >= 8)
        {
            Console.WriteLine($"{Name} is getting hungry. Consider feeding!");
        }

        if (MentalHealth <= 2)
        {
            Console.WriteLine($"{Name} is feeling sad. Play with {Name} to increase MentalHealth!");
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
                pet.PhysicalHealth = Math.Min(10, pet.PhysicalHealth + 1);
                Console.WriteLine($"{pet.Name} is fed. Hunger decreased, PhysicaslHealth increased.");
            }
            else if (choice == "2")
            {
                pet.MentalHealth = Math.Min(10, pet.MentalHealth + 2);
                pet.Hunger = Math.Min(10, pet.Hunger + 1);
                Console.WriteLine($"{pet.Name} is playing. MentalHealth increased, Hunger increased slightly.");
            }
            else if (choice == "3")
            {
                pet.PhysicalHealth = Math.Min(10, pet.PhysicalHealth + 2);
                pet.MentalHealth = Math.Max(0, pet.MentalHealth - 1);
                Console.WriteLine($"{pet.Name} is resting. PhysicalHealth increased, happiness decreased slightly.");
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

            if (pet.Hunger >= 10 || pet.MentalHealth <= 0)
            {
                Console.WriteLine($"{pet.Name} has been neglected and is not doing well. Health is deteriorating!");
                pet.PhysicalHealth = Math.Max(0, pet.PhysicalHealth - 2);
            }

            if (pet.PhysicalHealth <= 0)
            {
                Console.WriteLine($"{pet.Name} has passed away due to neglect. Game over!");
                return;
            }
        }
    }
}