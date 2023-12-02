
string folderPath = @"D:\UNI\DataVS\";
string heroesFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(folderPath + heroesFile);
string[] villains = File.ReadAllLines(Path.Combine (folderPath, villainFile)); //kasulikum edaspidi, kui pikad patheid v2i teine OS
//string[] heroes = { "Harry Potter", "Luke Skywalker", "Lara Croft", "Scooby-Doo" };
//string[] villains = { "Voledmort", "Darth Vader", "Dracula", "Joker", "Sauron" };
string[] weapons = { "Magic Wand", "Plastic fork", "Banana", "Wooden Sword", "Lego Brick" };



string hero = GetRandomValueFromaArray(heroes);
string heroWeapon = GetRandomValueFromaArray(weapons);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP; 
Console.WriteLine($"Today {hero} ({heroHP} HP) with a {heroWeapon} saves the day!");



string villain = GetRandomValueFromaArray(villains);
string villainWeapon = GetRandomValueFromaArray(weapons);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP; 
Console.WriteLine($"Today {villain} ({villainHP} HP) with a {villainWeapon} tries to take over the world!");


while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

if(heroHP > 0 )
{
    Console.WriteLine($"Hero {hero} saves the day with {heroHP}HP!");
    Console.WriteLine($"Villain {villain} HP: {villainHP}");

}
else if (villainHP > 0)
{
    Console.WriteLine($"Villain {villain} wins with {villainHP}HP!");
    Console.WriteLine($"Hero HP: {heroHP}");
}
else
{
    Console.WriteLine("Draw!");
}


static string GetRandomValueFromaArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random random = new Random();
    int strike = random.Next(0, characterHP);
    
    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");

    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}
//Random rnd = new Random();
//int randomIndex = rnd.Next(0, heroes.Length); 

//string hero = heroes[randomIndex];
//Console.WriteLine($"Today {hero} saves the day!");


//randomIndex = rnd.Next(0, villains.Length);

//string villain = villains[randomIndex];   
//Console.WriteLine($"Todays villain is {villain}");