#!/bin/zsh

# Check if an argument was provided
if [ -z "$1" ]; then
  echo "Usage: ./create_day_folder.sh <day_number>"
  exit 1
fi

# Format the input as a two-digit number (e.g., 1 -> 01, 10 -> 10)
day_number=$(printf "%02d" $1)
day_folder="Day${day_number}"

# Paths
input_path="./input/2024/${day_folder}"
solution_path="./2024/${day_folder}"

# Create directories and files for input
mkdir -p "$input_path"
touch "$input_path/input" "$input_path/test"

# Create directory for solution and the C# file
mkdir -p "$solution_path"
solution_file="${solution_path}/Solution.cs"

# Write the base C# code to the file
cat > "$solution_file" << EOF
using System;
using System.IO;

namespace adventofcode.Year2024.Day${day_number}
{
    public class Solution : BaseSolution, ISolver
    {
        public void SolvePart1()
        {
            var inputFilePath = GetInputFilePath("test");
            // var inputFilePath = GetInputFilePath();

            string[] lines = File.ReadAllLines(inputFilePath);
            // Add your Part 1 solution logic here
        }

        public void SolvePart2()
        {
            Console.WriteLine("not implemented");
        }
    }
}
EOF

echo "Created folder structure and files for Day ${day_number}."
