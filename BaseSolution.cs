using System;
using System.IO;

namespace adventofcode;

public abstract class BaseSolution
{
    public string GetNamespace() => this.GetType().Namespace;

    public string GetYear()
    {
        // Extract year from namespace
        string namespaceName = GetNamespace();
        return namespaceName?.Split('.')[1].Replace("Year", "") ?? "Unknown Year";
    }

    public string GetDay()
    {
        // Extract day from namespace
        string namespaceName = GetNamespace();
        return namespaceName?.Split('.')[2].Replace("Day", "") ?? "Unknown Day";
    }

    public string GetInputFilePath(string fileName = "input")
    {
        string path = Path.Combine(Environment.CurrentDirectory,"input", GetYear(), $"Day{GetDay()}", fileName);

        if(path.Contains("Tests/bin/Debug/net9.0/"))
        {
            path = path.Replace("Tests/bin/Debug/net9.0/", "");
        }
        return path;
    }
}
