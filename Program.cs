// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;

// Console.WriteLine("Hello, World!");

List<Plant> plants = new List<Plant>() // Plant is a custom class. plants is the variable holding this list of the Plant class.
// Below will be instances of the "Plant" class.
// The blue curly braces are the "collection initializer"
{
    new Plant() // each of these new Plant() is an "instance" of the Plant class
    // Below we "initialize" this Plant class with some data in the properties we defined when we created the Plant class. These curly braces are called the "object initializer".
    {
        Species = "Rose",
        LightNeeds = 1,
        AskingPrice = 26.00M,
        City = "Jacksonville",
        ZIP = 32256,
        AvailableUntil = new DateTime(2023, 8, 8), //recall that DateTime is a type just like int or string are types
        Sold = false
    },
    new Plant()
    {
        Species = "Hibiscus",
        LightNeeds = 5,
        AskingPrice = 18.00M,
        City = "Ponte Vedra",
        ZIP = 32082,
        AvailableUntil = new DateTime(2023, 10, 8),
        Sold = true,
    },
    new Plant()
    {
        Species = "Gardenia",
        LightNeeds = 3,
        AskingPrice = 36.00M,
        City = "Nocatee",
        ZIP = 32081,
        AvailableUntil = new DateTime(2024, 8, 8),
        Sold = false,
    },
    new Plant()
    {
        Species = "Queen Palm",
        LightNeeds = 2,
        AskingPrice = 130.00M,
        City = "Jax Beach",
        ZIP = 32255,
        AvailableUntil = new DateTime(2024, 6, 8),
        Sold = true
    },
    new Plant()
    {
        Species = "Begonia",
        LightNeeds = 4,
        AskingPrice = 22.00M,
        City = "South Ponte Vedra Beach" ,
        ZIP = 32083,
        AvailableUntil = new DateTime(2025, 4, 6),
        Sold = false
    }
};

Random random = new Random(); // this brings the type "Random" into this module/program so we can use it below in randomizing a plant selection

Console.WriteLine(plants[0]);

//^ Below is the first thing we see displayed...the greeting.
string greeting = @"Welcome to the world's most mediocre place to get your plants.  We're OK that you're here and really indifferent about choosing us for your plant needs.";
//^ Notice this is when the above greeting is displayed...when we writeline it.
Console.WriteLine(greeting);

//^ Note that we do NOT see this below menu options list displayed yet...we just defined a variable here...
string menuOptions = (@"Make a Selection:
                        1. View All Plants
                        2. Post a Plant for Adoption
                        3. Adopt a Plant
                        4. Delist a Plant
                        5. Random Plant
                        6. Search for a Plant
                        7. View App Statistics
                        8. Exit
                        ");

// Loop through your plants and display a numbered list of the plant names

//Create a menu of options. Use WriteLine to display thos options. Use ReadLine to give the user an input option (something they choose).
string choice = null;
// When "while (choice != "5")" I wondered and now I know: this while loop parameter is what actually gets you out of the program. ie - user clicks 5 and now the while loop condition is no longer met...so the while loop no longer runs. The condition is "while the choice is NOT 5 then run this loop...but if a user enters 5, don't run the loop anymore. Then the program looks for any other code below and runs it. If no other code, the program stops running.

//^ The program constinues to run when it meets the while loop because choice was null and still is null...
while (choice != "8") //while choice is not equal to 5....list/writeline this text...
// so when user selects 1, ListPlants runs, none of the other while conditions are met...but what makes it keep running?
//^ The program is running the while loop and will write/display the menuOptions for the user
{
    Console.WriteLine(menuOptions);
    //Now provide options to the user with ReadLine and if statements
    //^NOW THE PROGRAM STOPS AND WAITS FOR USER INPUT...ReadLine is an opening for the user to input data...
    choice = Console.ReadLine(); // store the user's input in the "choice" variable
    if (choice == "1") // if the user's choice was 1, list the plants
    {
        Console.Clear();
        ListPlants();
    }
    else if (choice == "2")
    {
        PostPlant();
    }
    else if (choice == "3")
    {
        AdoptPlant();
    }
    else if (choice == "4")
    {
        DelistPlant();
    }
    else if (choice == "5")
    {
        Console.Clear();
        RandomPlant();
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "6")
    {
        Console.Clear();
        SearchPlantByLight();
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "7")
    {
        Console.Clear();
        ViewStatistics();
        Console.ReadKey();
        Console.Clear();
    }
    else if (choice == "8")
    {
        Console.WriteLine("Goodbye and Happy Planting!");
    }
    else //...otherwise if the user enters any other characters...do this below
    {
        // Plant chosenPlant = null;

        // while (choice == null)
        // {
        // Console.WriteLine("Please enter a number between 1 and 5");
        try
        { //below piece of code says take the user's input stored in "choice", trim any spaces out, parse into an integer, and store it in the response variable.
            int response = int.Parse(choice.Trim());
            Plant chosenPlant = plants[response - 1]; // then subtract 1 from that response integer, give the plants list tha number as the index number, then store that (for example plants[2] would be the third plant on the list) as the chosenPlant variable.
        }
        catch (FormatException)
        {
            Console.WriteLine("Only numbers allowed. Enter a Number");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose between 1 and 5");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex); // show me the error (represented by "ex" variable here)
            Console.WriteLine("C'mon Man! Tray again...");
            // }
        }
    }
}

// Plant chosenPlant = null;

// while (chosenPlant == null)
// {
//     Console.WriteLine("Please enter a product number: ");
//     try
//     {
//         int response = int.Parse(Console.ReadLine().Trim());
//         chosenPlant = plants[response - 1];
//     }
//     catch (FormatException)
//     {
//         Console.WriteLine("Only numbers allowed. Enter a Number");
//     }
//     catch (ArgumentOutOfRangeException)
//     {
//         Console.WriteLine("Please choose between 1 and 5");
//     }
//     catch (Exception ex)
//     {
//         Console.WriteLine(ex); // show me the error (represente dby ex variable here)
//         Console.WriteLine("C'mon Man! Tray again...");
//     }
// }


void ListPlants() // this lists each plant by iterating over the Plant List with a "for loop"
{
    Console.WriteLine("Plants:"); //... and then display a Plants list by using below code which says...
                                  // Below: for every plant, look at the index, add one to it, then show the species of the plant being iterated over. 
                                  // plants.Count will determine how many iterations based on how many plants in our Plant List.
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? "was sold" : "is available")} for {plants[i].AskingPrice}");
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

//Post a Plant: When a user chooses this option, they should be able to input a plant species, light needs, asking price, city, and zip, and add it to the plant database. When a user posts a plant, it should be available (not sold) by default without the user having to input a value for Sold. Collect the user's answers, and create a new Plant object with those responses. Then, add that object to the plants List.
void PostPlant()
{
    // all of this through about line 233 displays to the user and promts the user for their input as they create a new plant to be posted...
    Console.WriteLine(
        @$"Please complete the form below:");

    Console.WriteLine("Species: ");
    string speciesResponse = Console.ReadLine().Trim();

    Console.WriteLine("Light Needs: (choose a number 1 - 5)");
    int lightNeedsResponse = int.Parse(Console.ReadLine().Trim());

    Console.WriteLine("Asking Price: ");
    int askingPriceResponse = int.Parse(Console.ReadLine().Trim());

    Console.WriteLine("City: ");
    string cityResponse = Console.ReadLine().Trim();

    Console.WriteLine("ZIP: ");
    int zipResponse = int.Parse(Console.ReadLine().Trim());


    //^BEGIN THE MADNESS OF TRYING TO CATCH THESE ERRORS
    //^DAY
    int dayResponse = 0;
    bool validDayInput = false;
    while (!validDayInput)
    {// while (!validInput)
        try
        {
            Console.WriteLine("How long should this post last? Let's start with the day of the month you want the post to expire (DD): ");
            dayResponse = int.Parse(Console.ReadLine());
            validDayInput = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
    }

    //^MONTH
    int monthResponse = 0; //had to declare outside the try block because i need monthResponse variable further down the code...so inside the try block i removed "int" before "monthResponse" since i already declared it an integer type...
    bool validMonthInput = false;
    while (!validMonthInput)
    {
        try //try taking the input from the user and see if it works...if not...refer to "catch" on how to handle
        {
            Console.WriteLine("Please enter a Month (MM): ");
            monthResponse = int.Parse(Console.ReadLine());
            validMonthInput = true;
        }
        catch (FormatException) //when the user types letters instead of numbers I want the below error to pop up and then for the user to be prompted again.
        {
            Console.WriteLine("Please type only integers between 1 - 12");
        }
    }

    //^YEAR
    int yearResponse = 0; //set initial value to zero
    bool validYearInput = false;
    while (!validYearInput)
    try
    {
        Console.WriteLine("Please enter a Year (YYYY): ");
        yearResponse = int.Parse(Console.ReadLine());
        validYearInput = true;
    }
    catch (FormatException)
    {
        Console.WriteLine("Please type only a 4-digit integer");
    }
    //^END THE MADNESS OF TRYING TO CATCH THESE ERRORS
    
    
    
    // need to combine the three date cariables into one maybe? but why?
    // because the format for DateTime has to be in a certain format with at least three 
    DateTime availableUntilDate = new DateTime(yearResponse, monthResponse, dayResponse);

    // this will store that user input into a new instance of the plants List
    Plant newPlant = new Plant
    {
        Species = speciesResponse,
        LightNeeds = lightNeedsResponse,
        AskingPrice = askingPriceResponse,
        City = cityResponse,
        ZIP = zipResponse,
        AvailableUntil = availableUntilDate,
        Sold = false
    };

    plants.Add(newPlant); //add this newPlant to the plants List
};


// present a list of plants not sold yet
// each item on the list should have a number for the user to select
// include a prompt (ReadLine) with the list so the user can enter a number
// catch anything outside of that number range (if implementing a catch)

// bool dateStillAvailable = 
// make this into a true or false, then use it in my if statement below as usersInput
// if the user-selected plant's AvailableUntil date is less than or equal to the DateTime.now, then it is still available, so show it on the list
//can't make function with boolean as a type though....
//use a foreach loop? No, we're already in a for loop on line 261...

DateTime now = DateTime.Now;
Console.WriteLine(now);

void AdoptPlant()
{
    Console.WriteLine("Please choose a numbered plant below to adopt:");
    for (int i = 0; i < plants.Count; i++) // iterate through all plants and do this next piece for each one...
    {
        if (!plants[i].Sold && (plants[i].AvailableUntil >= DateTime.Now)) //...if the plant's Sold value is NOT true...ie  if the plant is still available. AND the chosen plant's available date is less than or equal to today....
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species}"); //... then display the unsold plant here....
        }
    }
    int choiceIndex = int.Parse(Console.ReadLine()) - 1; //this reads user input and gives me back the INDEX integer from whatever integer the user gave me, then stores it in "choiceIndex" variable
    if (choiceIndex >= 0 && choiceIndex < plants.Count && !plants[choiceIndex].Sold) // if that chosen plant's index number is between 0 and however many plants are in the plants List...AND...if that plant is not sold.....then do this....
    {
        plants[choiceIndex].Sold = true; //...make the .Sold value "true"
        Console.WriteLine($"You adopted the {plants[choiceIndex].Species} plant!");
    }
    else
    {
        Console.WriteLine("Invalid choice or plant is already sold");
    }

};


// to delist a plant...well, a user will delist a plant.
// so for a user to delist a plant, the user must have options to choose from
// give the user a list of options
// the options should be ALL plants
// iterate over the plants List and display each with WriteLine
// iterate how? for loop or maybe a switch?
// give the user an opportunity to give us input
// use Console.ReadLine() 
void DelistPlant()
{
    Console.WriteLine("Please choose a numbered plant below to delist:");
    for (int i = 0; i < plants.Count; i++) // iterate over each plant
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

    int choiceIndex = int.Parse(Console.ReadLine()) - 1; // give user a place for input using ReadLine

    if (choiceIndex >= 0 && choiceIndex < plants.Count)
    {
        Console.WriteLine($"You delisted the {plants[choiceIndex].Species} plant.");

        // Remove the delisted plant from the list
        plants.RemoveAt(choiceIndex);
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
}


//How to approach getting a random plant...
//generate an index number first?
//or filter the list first?

//filter the list so only adoptable plants available
//then randomize from that list of plants

//iterate over the plants with for loop and give an if statement to filter

// something like this...
// for (int i = 0; i < plants.Count; i++)
// {
//         if (!plants[i].Sold) //...if the plant's Sold value is NOT true...ie  if the plant is still available...... then add it to a new list for the randomizer to go through?
//         {int randomPlant = random.Next(1, plants.Count); // then randomizer here

//         }
//     }
void RandomPlant() // 
{
    int suitablePlantIndex = 10; // Initialize to an invalid value. I asked why not null. CGPT said because memory expects an integer basically. Not a reference to an object.
    while (suitablePlantIndex == 10) // Keep looping until a suitable plant is found
    {
        int randomPlant = random.Next(0, plants.Count); // Generate a random index
        Console.WriteLine(randomPlant); //i want to see what tries were attempted
        if (!plants[randomPlant].Sold) // Check if the plant is available
        {
            suitablePlantIndex = randomPlant; // Store the index of the suitable plant
            break; // Exit the loop
        }
    }

    // Now you have the suitablePlantIndex, so you can use it to access the plant details
    Console.WriteLine(@$"Details on this random plant: 
    Species: {plants[suitablePlantIndex].Species}
    Location: {plants[suitablePlantIndex].City}, {plants[suitablePlantIndex].ZIP}
    Light Needs: {plants[suitablePlantIndex].LightNeeds}
    Price: {plants[suitablePlantIndex].AskingPrice}
    ");
}


// void RandomPlant() //another method learned from chatGPT. In testing it did well
// {    
//     int randomPlant; //declared a variable, but it is not initialized with a value... yet.
//     do // we want our program to do (randomize) while a certain condition is met....
//     {
//         randomPlant = random.Next(0, plants.Count); //this is the randomizer using the Next method on the Random type. randomPlant variable now holds a randomly chosen plant index number
//         Console.WriteLine(randomPlant); // this will show the indexes of the attempts (do)
//     } while (plants[randomPlant].Sold); //...and this is the filter...so the "do" will do its thing (randomize) while the chose plant index number is a sold plant...which is confusing at first. We want UNsold plants. So this will randomize as long as we run across sold plants...so if a sold plant is chosen, we will keep randomizing...then we grab an unsold plant and use that one....then a sold one and we randomize again... etc

//     Console.WriteLine(@$"Details on this random plant:
//     Species: {plants[randomPlant].Species}
//     Location: {plants[randomPlant].City}, {plants[randomPlant].ZIP}
//     Light Needs: {plants[randomPlant].LightNeeds}
//     Price: {plants[randomPlant].AskingPrice}
//     ");
// }

void SearchPlantByLight()
{
    //how do I search? I am searching through a list. So i have to get the list first
    //1. GET THE LIST
    // now i have to iterate through it. while iterating, i need to MATCH. to match though, i have to have received input from the user to match what they gave me...
    //2. I NEED A READLINE()
    //3. for loop? foreach? while?
    //4. if statement to say "if the plant STARTS WITH... then display it."
    //I need to display more than one, so don't just find the first plant that matches, find all matches and display them all...
    //5. store the findings of the matching plant search
    //6. display those matching plants (WriteLine)
    Console.WriteLine("Enter a Light Needs from 1 (low) to 5 (high):"); //give the user a prompt 
    string userInput = Console.ReadLine(); // take the user's input with ReadLine and store in variable

    List<Plant> userMatchedByLightNeeds = new List<Plant>(); // create a new plant instance to store the matching plants based on the user's input (a number 1-5)
    foreach (Plant plant in plants) // iterate over each plant in the plants List
    {
        if (plant.LightNeeds <= int.Parse(userInput)) // ...while looking at a specific plant...if that plant's LightNeeds value is <= user's input integer...
        //...remember the plant's LightNeeds value is an integer between 1 and 5 so we're comparing the user's number to this particular plant's LightNeeds number....
        {
            userMatchedByLightNeeds.Add(plant); //...then add that plant to the userMatchedByLightNeeds List
        }
    }

    Console.WriteLine("Choose from the matching plants below:"); // now display the list to the user.
    foreach (Plant plant in userMatchedByLightNeeds) //...how do we display? Loop over each plant in the new userMatchedByLightNeeds....
    {
        Console.WriteLine(plant.Species);//...and display it to the user with WriteLine. Notice here we are only showing the Species name...not all of the details. 
    }
}


void ViewStatistics()
{
    //^     Stats
    //^ Lowest price plant name 
    // loop through all plants prices and grab the price of one and store it...then on next iteration, it can store a new price if condition is met

    decimal lowestPrice = plants[0].AskingPrice; //this is the first plant in the index's price
    //by declaring decimal as the type, anything its variable equals MUST fall in line with the rules of that decimal type as defined by...
    string lowestPricePlantName = plants[0].Species; // create a variable that catches the first plant's price to have something to compare to in the foreach loop...

    foreach (Plant plant in plants)
    {
        //if the next price i come across is less than this one, replace it
        //remember, as we start the if statement we are now in the loop and asking the first plant in the list of plants...if your price is lower than this other one...
        if (plant.AskingPrice < lowestPrice)
        {
            lowestPrice = plant.AskingPrice;
            lowestPricePlantName = plant.Species;
        }
    }
    Console.WriteLine($"Lowest priced plant: {lowestPricePlantName} at {lowestPrice} dollars");

    //^ Number of Plants Available (not sold, and still available)
    //this is an integer that reps how many plants i have available. how do I get that number?
    //add up all the plants idiot. Yeah but how to do that in code?
    //Use .Count on the plants List moron
    //so, something like this...plants.Count
    //yes stupid. now put that in a variable so you can display it with Console.WriteLine();
    //actually i need to subtract total plants from sold plants and unavailable by date plants
    //which means I need to iterate through all plants and capture only non-sold plants and available plants.. and to captrue them i need a new List.....and then use .Count on that List of plants....and then subtract that from total plants...and then display that number as the total number of plants available.

    List<Plant> MatchingPlants = new List<Plant>();
    int totalPlants = plants.Count;
    int totalAvailablePlants = totalPlants - MatchingPlants.Count;

    for (int i = 0; i < plants.Count; i++) // iterate through all plants and do this next piece for each one...
    {
        if (!plants[i].Sold && (plants[i].AvailableUntil >= DateTime.Now)) //...if the plant is not sold AND it's available otherwise...
        {
            //add the plant to a list
            MatchingPlants.Add(plants[i]); // this line adds each plant being iterated over if it matches the criteria.
            //...then subtract totalPlants from the number of  MatchingPlants.Count
        }

    }
    Console.WriteLine($"Total Number of Available Plants: {totalAvailablePlants}");


    //^ Name of plant with highest light needs
    // loop through all plants and capture whichever plant has the highest (may not necessarily be 5)
    // how to loop? foreach
    // how to capture? int variableName can hold the value of the 0-indexed plant
    //designate index zero plant as the initializer...the comparable plant
    int highestLightNeedPlantIndex = 0;
    string highestLightNeedPlantName = "";

    foreach (Plant plant in plants)
    {
        if (plant.LightNeeds > highestLightNeedPlantIndex) //...if LightNeeds value is more than the previous plant's LightNeeds value....
        {
            highestLightNeedPlantIndex = plant.LightNeeds; //then update highestLightNeedPlantIndex value
            highestLightNeedPlantName = plant.Species;
        }
    };
    Console.WriteLine($"Plant With Highest Light Needs: {highestLightNeedPlantName}");

    //^ Average light needs
    // add up all the lightneeds integers, divide by plants.count, display with WriteLine
    int totalLightNeeds = 0;

    foreach (Plant plant in plants)
    {
        totalLightNeeds += plant.LightNeeds;
        // Console.WriteLine(totalLightNeeds);
    }
    int averageLightNeeds = totalLightNeeds / totalPlants;
    Console.WriteLine($"Average Light Needs: {averageLightNeeds}");


    //^ Percentage of plants adopted
    // total plants divided by adopted plants
    //already have a totalPlants variable holding that number
    //now I need a variable to hold adopted Plants
    //
    List<Plant> MatchingAdoptedPlants = new List<Plant>(); //create a new instance of a Plant-type plant so I can hold a list of plants as I filter through below
    foreach (Plant plant in plants)
    {
        if (plant.Sold)
        { //...if the value of Sold is true, then it is an adopted plant and the plant should be added to a list of plants which we can .Count on to get the total
            MatchingAdoptedPlants.Add(plant);
        };
    }
    int adoptedPlants = MatchingAdoptedPlants.Count; //adoptedPlants variable will hold the number of adopted plants from the MatchingAdoptedPlants list

    Console.WriteLine($"Adopted Plants {adoptedPlants}");

    // Floor division - "The result you will get when dividing integers that result in a non-whole number will be rounded down (which is why 1/2 will give you 0). This is called floor division."
    //* Think of floor division like an elevator: if the elevator gets stuck between floor 1 and 2, the elevator defaults to the lower floor because it CAN go down, but it cannot get up to floor 2. So Floor division is the same. It rounds down to nearest whole floor/number.

    decimal ratioAdopted = (decimal)adoptedPlants / totalPlants; //Since adopedPlants and totalPlants are both integer types....this would equate to an integer (and leave no decimal) if I didn't cast adoptedPlants as a decimal. ... or I could have cast totalPlants as a decimal?
    double ratioAsDouble = (double)ratioAdopted; //convert the variable TYPE of ratioAdopted from decimal to double. Literally read, it would say "This data type is a "double" which can give decimal numbers....the variable ratioAsDouble  will hold the value of another double-type piece of data called ratioAdopted.
    // now we have 0 stored in ratioAsDouble so we need to do math on it...
    //* Why use the double data type? ChatGPT "Without the use of double, you would lose precision and get inaccurate results." and "You use double when you need to work with numbers that require decimal points or fractions, such as measurements, scientific calculations, financial calculations, and more. It's suitable for situations where precision matters and integer types won't suffice."
    double half = ratioAsDouble / 2;
    Console.WriteLine($"Ratio {ratioAdopted}");
    decimal wholeNumberAdopted = ratioAdopted * 100;
    Console.WriteLine($"Percentage of Adopted Plants: {wholeNumberAdopted}%");
}


string PlantDetails(Plant plant) //declare the type of return for this metho here. We are getting a string in return after the method/function runs. So instead of declaring the PlantDetails method with "void" in front of it, we declare it as a string TYPE...
//* There is only one parameter for this method/function: plant. We show capital "Plant" in front of plant because we need to declare the Parameter type.
{
    string plantString = plant.Species; // plantString is a string type variable.
    
    return plantString; //we're returning a string, as explicitly stated when we declared the PlanDetails method above.

}