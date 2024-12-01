#!/bin/bash

# Bereinigen des Projekts
echo "Cleaning the project..."
dotnet clean

# Entfernen von bin und obj Ordnern
echo "Removing bin and obj directories..."
rm -rf bin obj

# Wiederherstellen der Abhängigkeiten
echo "Restoring dependencies..."
dotnet restore

# Bauen des Projekts und Anzeigen von Zielzeit (tl = TargetLog)
echo "Building the project..."
dotnet build /tl

