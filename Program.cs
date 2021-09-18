using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace NumberTracker
{
  class Program
  {
    static void Main(string[] args)
    {
      // static void SaveStudents(List<Student> students){
      //   var writer = new StreamWriter("students.csv");  
      //   var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      //   csvWriter.WriterRecords(students);
      //   writer.Flush();
      // }

      Console.WriteLine("Welcome to Number Tracker");
      //create a list of numbers we will be tracking
      // var numbers = new List<int>(); replaced
      //create a stream reader to get information from our file
      var fileReader = new StreamReader("numbers.csv");  
      //tell the csv reader not to interpret the first row as a header, 
      //otherwise the first number will be skipped.
      var config = new CsvConfiguration(CultureInfo.InvariantCulture){
        //tell the reader not to interpret the first row as a header since 
        //it is just a first number.
        HasHeaderRecord = false,
      };
      //create a CSV reader to parse the stream into CSV format
      var csvReader = new CsvReader(fileReader, config);
      var numbers = csvReader.GetRecords<int>().ToList();
      fileReader.Close();
      //controls if we are still running our loop asking for more numbers
      var isRunning = true;
      //while we are running
      while(isRunning){
        //show the list of numbers
        Console.WriteLine("-------------------------");
        foreach (var number in numbers){
          Console.WriteLine(number);
        }
        Console.WriteLine($"Our list has: {numbers.Count()} entries.");
        Console.WriteLine("-------------------------");

        //Ask for a new number or the word quit to end
        Console.WriteLine("Enter a number to store, or 'quit' to end: ");
        var input = Console.ReadLine().ToLower();
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
      //create a stream writing information into a file
        var fileWriter = new StreamWriter("numbers.csv");
        //create a file that can write csv to the fileWriter
        var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
        //Ask our csvWrite to write out our list of numbers
        csvWriter.WriteRecords(numbers);
        //tell the file we are done
        fileWriter.Close();
        //creates a stream reader to get information from our file
        TextReader reader;

        //if the file exists
        if(File.Exists("numbers.csv")){
          //Assign a StreamReader to read from the file
          reader = new StreamReader("numbers.csv");
        }
        else
        {
          //Assign a StringReadera to read from an empty string
          reader = new StringReader("");
        }

    }//end Main
  }//end Program class
}//end namespace