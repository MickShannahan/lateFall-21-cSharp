using System;

namespace lateFall_21_cSharp
{
  public class Animal
  {
    public Animal(string type, int hunger, string name, bool carnivore, string language)
    {
      Type = type;
      Hunger = hunger;
      Name = name;
      Carnivore = carnivore;
      Language = language;
      IsAlive = true;
    }

    public string Type { get; private set; }
    public int Hunger { get; set; }
    public string Name { get; private set; }
    public bool Carnivore { get; private set; }
    public string Language { get; private set; }
    public bool IsAlive { get; private set; }

    public void AnimalDie()
    {
      IsAlive = false;
      Console.Beep(450, 100);
      Console.Beep(400, 100);
      Console.ForegroundColor = ConsoleColor.DarkRed;
      Console.WriteLine(@$"
      The Animal {Name} the {Type}, has perished,
      Why didn't you feed them. 
      you horrible keeper.
      ");
      Console.ForegroundColor = ConsoleColor.Gray;
    }

    public void FeedAnimal(string type)
    {
      if (type == "meat" && Carnivore)
      {
        Hunger += 2;
      }
      else if (type == "plant" && !Carnivore)
      {
        Hunger++;
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"!!!   {Name} does not eat {type}");
        Console.ForegroundColor = ConsoleColor.Gray;
      }
      Console.BackgroundColor = ConsoleColor.DarkGreen;
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine(@$"you fed {Name}, their hunger is now {Hunger}");
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.Gray;
    }

  }

}