using System;

namespace adventofcode;

public class Application
{
    private const int DefaultPart = 1;
    private const int MinDay = 1;
    private const int MaxDay = 25;
    private const int MinPart = 1;
    private const int MaxPart = 2;

    private readonly SolverResolver solverResolver = new();

    public int Run(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);

        var start = DateTime.Now;
        Console.WriteLine("Hello to adventofcode!");

        if (!TryPrepareArgs(args, out var preparedArgs))
        {
            Console.WriteLine("Invalid arguments. Expected usage:");
            Console.WriteLine("  adventofcode <year> <day> [part]");
            Console.WriteLine("Examples:");
            Console.WriteLine("  adventofcode 2024 1");
            Console.WriteLine("  adventofcode 2024 1 2");
            return 1;
        }

        var solvedSuccessfully = Solve(preparedArgs);

        var duration = DateTime.Now - start;
        Console.Write("Problem solved in ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{duration.TotalMilliseconds} ms");
        Console.ResetColor();
        Console.WriteLine();

        return solvedSuccessfully ? 0 : 1;
    }

    private static bool TryPrepareArgs(string[] args, out PreparedArgs preparedArgs)
    {
        if (args.Length > 3)
        {
            preparedArgs = new PreparedArgs { IsValid = false };
            return false;
        }

        if (args.Length == 0)
        {
            var today = GetDefaultDate();
            preparedArgs = new PreparedArgs
            {
                Year = today.Year,
                Day = today.Day,
                Part = DefaultPart,
                IsValid = true,
                BothParts = true,
            };

            Console.WriteLine($"No arguments provided. Using year {preparedArgs.Year}, day {preparedArgs.Day}, both parts.");
            return true;
        }

        if (!TryParsePositiveInt(args[0], "year", out var year)
            || !TryParsePositiveInt(args[1], "day", out var day))
        {
            preparedArgs = new PreparedArgs { IsValid = false };
            return false;
        }

        if (day < MinDay || day > MaxDay)
        {
            Console.WriteLine($"Day must be between {MinDay} and {MaxDay}.");
            preparedArgs = new PreparedArgs { IsValid = false };
            return false;
        }

        var bothParts = args.Length == 2;
        var part = DefaultPart;

        if (!bothParts)
        {
            if (!TryParsePositiveInt(args[2], "part", out part))
            {
                preparedArgs = new PreparedArgs { IsValid = false };
                return false;
            }

            if (part < MinPart || part > MaxPart)
            {
                Console.WriteLine($"Part must be either {MinPart} or {MaxPart}.");
                preparedArgs = new PreparedArgs { IsValid = false };
                return false;
            }
        }

        preparedArgs = new PreparedArgs
        {
            Year = year,
            Day = day,
            Part = part,
            IsValid = true,
            BothParts = bothParts,
        };

        Console.WriteLine($"You selected year {year} day {day} {(bothParts ? "both parts" : $"part {part}")}.");
        return true;
    }

    private bool Solve(PreparedArgs preparedArgs)
    {
        if (!preparedArgs.IsValid)
        {
            return false;
        }

        if (preparedArgs.BothParts)
        {
            var part1Solved = RunPart(preparedArgs.Year, preparedArgs.Day, 1);
            var part2Solved = RunPart(preparedArgs.Year, preparedArgs.Day, 2);
            return part1Solved && part2Solved;
        }

        return RunPart(preparedArgs.Year, preparedArgs.Day, preparedArgs.Part);
    }

    private bool RunPart(int year, int day, int part)
    {
        if (!solverResolver.TryResolvePart(year, day, part, out var solvePart, out var error))
        {
            Console.WriteLine(error);
            return false;
        }

        try
        {
            solvePart();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed while executing year {year}, day {day:D2}, part {part}: {ex.Message}");
            return false;
        }
    }

    private static bool TryParsePositiveInt(string value, string argumentName, out int result)
    {
        if (!int.TryParse(value, out result) || result <= 0)
        {
            Console.WriteLine($"Invalid {argumentName} '{value}'. It must be a positive integer.");
            return false;
        }

        return true;
    }

    private static DateTime GetDefaultDate()
    {
        var now = DateTime.Now;
        if (now.Month == 12 && now.Day <= MaxDay)
        {
            return now;
        }

        Console.WriteLine("It's not December or it's after day 25. Using December 1st, 2023.");
        return new DateTime(2023, 12, 1);
    }
}
