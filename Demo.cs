
using System;
using System.Collections.Generic;

namespace lateFall_21_cSharp
{
  class Demo
  {
    public bool Playing { get; private set; }
    public int Money { get; private set; }
    public int WholeNumber { get; private set; }
    public double TwoPlaceDecimal { get; private set; }
    public float GeneralJavaScriptNumber { get; private set; }
    public decimal GiantNumber { get; private set; }
    public string ItAString { get; private set; }
    public char JustOneLetter { get; private set; }
    public List<string> MyList { get; private set; }

    public Dictionary<string, Animal> Animals { get; private set; }


    public Demo()
    {
      Money = 1;
      MyList = new List<string>() { "Moo", "Boe", "Meow" };
      Animals = new Dictionary<string, Animal>();
      string str = Start();
      Console.WriteLine(str);
      Console.WriteLine(DoMath(5, 6));
      Console.WriteLine(DoMath(5.5, 6.25));
      Console.WriteLine(DoMath("5", "10"));
      Console.WriteLine(AddStrings("Thing ", "Other Thing"));
      Console.WriteLine(WhatDoesTheCowSay("Meuh"));
      Console.WriteLine(WhatDoesTheCowSay("hamba"));
      Console.WriteLine(WhatDoesTheCowSay("ungaa"));
      Console.WriteLine(AddToAnimals(new Animal("Tiger", 10, "Hobbes", true, "Tigeese")));
      Console.WriteLine(AddToAnimals(new Animal("Okapi", 10, "Forrest", false, "Giraffe")));
      Console.WriteLine(AddToAnimals(new Animal("Star Fish", 0, "Patrick", true, "South East, Bubble")));
      Console.Clear();
      Playing = true;
      while (Playing)
      {
        GetPlayerInput();
      }
    }
    public string Start()
    {
      return "Go";
    }

    private int DoMath(int num1, int num2)
    {
      return num1 + num2;
    }

    private double DoMath(double num1, double num2)
    {
      return num1 + num2;
    }

    private string AddStrings(string thing, string otherThing)
    {
      return thing + otherThing;
    }

    private int DoMath(string num1, string num2)
    {
      int converted1 = 0;
      int converted2 = 0;
      if (!Int32.TryParse(num1, out converted1))
      {
        return 0;
      }
      if (!Int32.TryParse(num2, out converted2))
      {
        return 0;
      }
      return converted1 + converted2;
    }

    public string WhatDoesTheCowSay(string phrase)
    {
      string template = "";
      MyList.Add(phrase);
      for (int i = 0; i < MyList.Count; i++)
      {
        template += MyList[i];
        template += ", ";
      }
      return template;
    }

    // ^^^^ Code examples of honestly not great code
    // \/\/\/\/\ Code for game

    private void GetPlayerInput()
    {
      Console.ForegroundColor = ConsoleColor.Gray;
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine();
      DoAction(input);
    }

    private void DoAction(string input)
    {
      string action = input.Split(" ")[0].ToLower();
      string target = input.Split(" ")[1];
      string value = input.Split(" ")[2];
      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.WriteLine("You " + action + " " + target);
      switch (action)
      {
        case "feed":
          Money--;
          Animals[target].FeedAnimal(value);
          SimulateAnimals();
          break;
        case "open":
          if (value != "please")
          {
            SimulateAnimals();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("you didn't say please");
          }
          // Money += Animals.Count;
          Random rand = new Random();
          int moneyMade = rand.Next(1, 5);
          Money += moneyMade;
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.WriteLine($"you opened the zoo, you made ${moneyMade} dollars, total is ${Money}");
          SimulateAnimals();
          break;
        default:
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.WriteLine("I do not understand");
          break;
      }
    }
    private string AddToAnimals(Animal animal)
    {
      string template = "";
      Animals.Add(animal.Name, animal);
      foreach (var elm in Animals)
      {
        Animal a = elm.Value;
        template += a.Name + ' ' + a.Type;
        template += "\n";
      }
      return template;
    }

    private void SimulateAnimals()
    {
      if (Animals.Count <= 0)
      {
        Playing = false;
        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"The game is over, they are all dead. I hope it was worth the ${Money}");
      }
      foreach (var item in Animals)
      {
        Animal a = item.Value;
        if (a.Hunger <= 0)
        {
          a.AnimalDie();
          Animals.Remove(item.Key);
        }
        a.Hunger--;
      }
    }

  }
}