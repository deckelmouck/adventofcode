using System;
using System.Reflection;

namespace adventofcode;

internal sealed class SolverResolver
{
    private readonly Assembly assembly;

    public SolverResolver()
    {
        assembly = Assembly.GetExecutingAssembly();
    }

    public bool TryResolvePart(int year, int day, int part, out Action solvePart, out string error)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(part, 1);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(part, 2);

        return TryResolveConventionSolver(year, day, part, out solvePart, out error)
            || TryResolveAoc2022And2023Solver(year, day, part, out solvePart, out error)
            || TryResolveLegacy2020ConstructorSolver(year, day, part, out solvePart, out error)
            || TryResolveLegacy2019StaticSolver(year, day, part, out solvePart, out error);
    }

    private bool TryResolveConventionSolver(int year, int day, int part, out Action solvePart, out string error)
    {
        var typeName = $"adventofcode.Year{year}.Day{day:D2}.Solution";
        if (!TryFindType(typeName, out var type))
        {
            solvePart = default!;
            error = string.Empty;
            return false;
        }

        if (!TryCreateInstance(type, out var instance, out error))
        {
            solvePart = default!;
            return false;
        }

        if (!TryFindMethod(type, $"SolvePart{part}", out var method, out error))
        {
            solvePart = default!;
            return false;
        }

        solvePart = () => method.Invoke(instance, null);
        error = string.Empty;
        return true;
    }

    private bool TryResolveAoc2022And2023Solver(int year, int day, int part, out Action solvePart, out string error)
    {
        var typeName = $"aoc{year:D4}.solutionDay{day:D2}";
        if (!TryFindType(typeName, out var type))
        {
            solvePart = default!;
            error = string.Empty;
            return false;
        }

        if (!TryCreateInstance(type, out var instance, out error))
        {
            solvePart = default!;
            return false;
        }

        if (!TryFindMethod(type, $"SolvePart{part}", out var method, out error))
        {
            solvePart = default!;
            return false;
        }

        solvePart = () => method.Invoke(instance, null);
        error = string.Empty;
        return true;
    }

    private bool TryResolveLegacy2020ConstructorSolver(int year, int day, int part, out Action solvePart, out string error)
    {
        if (year != 2020)
        {
            solvePart = default!;
            error = string.Empty;
            return false;
        }

        var candidates = new[]
        {
            $"adventofcode.solutionday{day:D2}",
            $"adventofcode.solutionDay{day:D2}",
        };

        foreach (var candidateTypeName in candidates)
        {
            if (!TryFindType(candidateTypeName, out var type))
            {
                continue;
            }

            var constructor = type.GetConstructor(new[] { typeof(int) });
            if (constructor is null)
            {
                error = $"Type '{candidateTypeName}' was found but no constructor with signature (int part) exists.";
                solvePart = default!;
                return false;
            }

            solvePart = () => constructor.Invoke(new object[] { part });
            error = string.Empty;
            return true;
        }

        solvePart = default!;
        error = string.Empty;
        return false;
    }

    private bool TryResolveLegacy2019StaticSolver(int year, int day, int part, out Action solvePart, out string error)
    {
        if (year != 2019)
        {
            solvePart = default!;
            error = string.Empty;
            return false;
        }

        var typeName = $"adventofcode.year{year}day{day}";
        if (!TryFindType(typeName, out var type))
        {
            solvePart = default!;
            error = string.Empty;
            return false;
        }

        if (!TryFindMethod(type, $"part{part}", out var method, out error))
        {
            solvePart = default!;
            return false;
        }

        solvePart = () => method.Invoke(null, null);
        error = string.Empty;
        return true;
    }

    private bool TryFindType(string typeName, out Type type)
    {
        type = assembly.GetType(typeName, throwOnError: false, ignoreCase: false)!;
        return type is not null;
    }

    private static bool TryCreateInstance(Type type, out object instance, out string error)
    {
        try
        {
            var created = Activator.CreateInstance(type);
            if (created is null)
            {
                instance = default!;
                error = $"Could not create an instance of '{type.FullName}'.";
                return false;
            }

            instance = created;
            error = string.Empty;
            return true;
        }
        catch (MissingMethodException)
        {
            instance = default!;
            error = $"Type '{type.FullName}' does not have a parameterless constructor.";
            return false;
        }
    }

    private static bool TryFindMethod(Type type, string methodName, out MethodInfo method, out string error)
    {
        method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)!;
        if (method is null)
        {
            error = $"Method '{methodName}' was not found on type '{type.FullName}'.";
            return false;
        }

        if (method.GetParameters().Length != 0)
        {
            error = $"Method '{methodName}' on type '{type.FullName}' must not take parameters.";
            return false;
        }

        error = string.Empty;
        return true;
    }
}
