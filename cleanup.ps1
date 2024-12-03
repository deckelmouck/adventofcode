# Clean the project
Write-Host "Cleaning the project..."
dotnet clean

# Remove bin and obj directories
Write-Host "Removing bin and obj directories..."
Remove-Item -Recurse -Force bin, obj

# Restore dependencies
Write-Host "Restoring dependencies..."
dotnet restore

# Build the project and show target log
Write-Host "Building the project..."
dotnet build /tl

