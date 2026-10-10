#!/bin/bash

# prüfen ob Jahreszahl übergeben wurde
if [ -z "$1" ]; then
  echo "Usage: $0 <YEAR>"
  exit 1
fi

YEAR="$1"

# prüfen ob das Jahresverzeichnis existiert
if [ ! -d "$YEAR" ]; then
  echo "Directory $YEAR does not exist!"
  exit 1
fi

# durch alle DayXX Ordner iterieren
for daydir in "$YEAR"/Day*; do
  # nur wenn es ein Verzeichnis ist
  if [ -d "$daydir" ]; then
    dayname=$(basename "$daydir")
    src="$daydir/input.txt"
    dest="input/$YEAR/$dayname"

    if [ -f "$src" ]; then
      mkdir -p "$dest"
      mv "$src" "$dest/"
      echo "Moved $src -> $dest/"
    else
      echo "No input file in $daydir"
    fi
  fi
done

