using System;
using System.Reflection;

namespace adventofcode;

public class Application
{
    public void Run(string[] args)
    {
        Console.WriteLine("Hello to adventofcode!");

        // Check if arguments were passed
        if (args.Length > 0)
        {
            Console.WriteLine("Command-line arguments received:");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
        else
        {
            Console.WriteLine("No command-line arguments received.");
        }

        PreparedArgs preparedArgs = CheckArgs(args);

        if(!preparedArgs.IsValid)
        {
            Console.WriteLine("Invalid arguments. Exiting...");
            return;
        }

        Solve(preparedArgs);
    }

    private PreparedArgs CheckArgs(string[] args)
    {
        int year = 0;
        int day = 0;
        int part = 1;
        try
        {
            if(args.Length > 3)
            {
                Console.WriteLine("Too many arguments. Please provide year, day, and part.");
                return new PreparedArgs { IsValid = false };
            }
            else if(args.Length == 3)
            {
                year = Convert.ToInt32(args[0]);
                day = Convert.ToInt32(args[1]);
                part = Convert.ToInt32(args[2]);
            }
            else if (args.Length == 2)
            {
                year = Convert.ToInt32(args[0]);
                day = Convert.ToInt32(args[1]);       
            }
            else 
            {
                var today = new DateTime();
                today = DateTime.Now;
                
                var start = new DateTime(2023, 12, 01);
                
                if(today.Month != 12 || today.Day > 25)
                {
                    today = start;
                    Console.WriteLine("It's not December or it's after the 25th. Setting today to December 1st, 2023.");
                }
                year = today.Year;
                day = today.Day;                   
            }

            Console.WriteLine("You selected year {0} day {1} part {2} to solve. Let's go and try it...", year.ToString(), day.ToString(), part.ToString());
            return new PreparedArgs { IsValid = true, Year = year, Day = day, Part = part };
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid format. Please ensure all arguments are positive integers.");
            return new PreparedArgs { IsValid = false };
        }
    }

    private void Solve(PreparedArgs preparedArgs)
    {
        try
        {
            if (preparedArgs.Year == 2024 || preparedArgs.Year == 2019)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var solution = $"adventofcode.Year{preparedArgs.Year}.Day{preparedArgs.Day.ToString("D2")}.Solution";
                Console.WriteLine(solution);

                Type type = assembly.GetType(solution);

                if (type == null)
                {
                    Console.WriteLine("The solution could not be found. Please try again.");
                    return;
                }
                
                object instance = Activator.CreateInstance(type);

                MethodInfo solve = type.GetMethod($"SolvePart{preparedArgs.Part}");
                solve.Invoke(instance, null);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while trying to solve the problem. Please try again.");
            Console.WriteLine(ex.Message);
        }
    }
}
