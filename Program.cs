using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberTracker
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Number Tracker");
      //create a list of numbers we will be tracking
      var numbers = new List<int>();
      //controls if we are still running our loop asking for more numbers
      var isRunning = true;
      //while we are running
      while(isRunning){
        //sow the list of numbers
        Console.WriteLine("-------------------------");
        foreach (var number in numbers){
          Console.WriteLine(number);
        }
        Console.WriteLine($"Our list has: {numbers.Count()} entries.");
        Console.WriteLine("-------------------------");
        //Ask for a new number or the word quit to end
        Console.WriteLine("Enter a number to store, or to 'quit' to end: ");
        var input = Console.ReadLine();
        if(input == "quit"){
          //if the input is quit, turn off the flag to keep looping
          isRunning = false;
        }
        else
        {
            //parse the number and add it to the list of numbers
            var number = int.Parse(input);
            numbers.Add(number);
        }
      }
    
    }
  }
}
