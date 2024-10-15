﻿// ourAnimals array will store the following:
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables tat support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data
string[,] ourAnimals = new string[maxPets, 6];

// create some iitial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = $"ID #: {animalID}";
    ourAnimals[i, 1] = $"Species: {animalSpecies}";
    ourAnimals[i, 2] = $"Age: {animalAge}";
    ourAnimals[i, 3] = $"Nickname: {animalNickname}";
    ourAnimals[i, 4] = $"Pysical description: {animalPhysicalDescription}";
    ourAnimals[i, 5] = $"Personality: {animalPersonalityDescription}";
}

// display the top-level menu options

do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFrieds app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal's age");
    Console.WriteLine(" 6. Edit an animal's personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(readResult))
    {
        Console.WriteLine("Choose an option...");
        Console.ReadLine();
        continue;
    }
    menuSelection = readResult.ToLower().Trim();
    Console.WriteLine($"You selected menu option {menuSelection}");
    Console.WriteLine($"Press the Enter key to continue");
    Console.ReadLine();
    Console.Clear();


    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ") continue;
                for (int j = 0; j < 6; j++)
                { Console.WriteLine(ourAnimals[i, j]); }
                Console.WriteLine();
            }
            Console.WriteLine("Press the Enter key to continue");
            Console.ReadLine();
            break;
        case "2":
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] == "ID #: ") continue;
                petCount++;
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue");
                Console.ReadLine();
                continue;
            }

            Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            Console.WriteLine("Do you want to enter info for another pet? (Y/N)");
            readResult = Console.ReadLine();

            if (string.IsNullOrEmpty(readResult) || readResult.ToLower() == "n")
            {
                Console.WriteLine("Another pet has not been added\nPress the Enter key to continue");
                Console.ReadLine();
                continue;
            }

            bool validEntry = false;

            // Get the specie
            do
            {
                Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                readResult = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(readResult)) continue;
                if ((readResult.ToLower() != "dog") && (readResult.ToLower() != "cat")) continue;
                animalSpecies = readResult.ToLower();
                validEntry = true;

            } while (!validEntry);

            // Get the age
            validEntry = false;
            do
            {
                int petAge;
                Console.WriteLine("Enter the pet's age or enter ? if unknown");
                readResult = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(readResult)) continue;
                if (readResult == "?")
                {
                    animalAge = readResult;
                    validEntry = true;
                    continue;
                }
                validEntry = int.TryParse(readResult, out petAge);
                animalAge = petAge.ToString();
            } while (!validEntry);

            // Get the physical description
            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
            readResult = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(readResult)) animalPhysicalDescription = readResult;

            // Get the personality
            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
            readResult = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(readResult)) animalPersonalityDescription = readResult;

            // Get the nickname
            do
            {
                Console.WriteLine("Enter a nickname for the pet"); ;
                readResult = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(readResult))
                {
                    Console.WriteLine("You need to enter the pet's nickname");
                    continue;
                }
                animalNickname = readResult;
            } while (animalNickname == "");

            animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

            // store the pet information
            ourAnimals[petCount, 0] = $"ID #: {animalID}";
            ourAnimals[petCount, 1] = $"Species: {animalSpecies}";
            ourAnimals[petCount, 2] = $"Age: {animalAge}";
            ourAnimals[petCount, 3] = $"Nickname: {animalNickname}";
            ourAnimals[petCount, 4] = $"Physical description: {animalPhysicalDescription}";
            ourAnimals[petCount, 5] = $"Personality: {animalPersonalityDescription}";

            Console.WriteLine($"{animalNickname} has been added");
            Console.WriteLine("Press the Enter key to continue");
            Console.ReadLine();
            break;
    }

} while (menuSelection != "exit");