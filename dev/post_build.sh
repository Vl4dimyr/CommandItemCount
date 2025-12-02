#!/usr/bin/env bash

# bash "$(ProjectDir)dev\post_build.sh" $(TargetDir) $(TargetFileName) $(ProjectDir) $(SolutionName)

dllFilePath="$1$2"
csFilePath="$3${4}Plugin.cs"
outFolder="${3}out/"
versionFile="${3}VERSION"

# Read version
version="$(tr -d '\n' < "$versionFile")"

# Target directory (replaces %APPDATA%)
targetDir="$HOME/.config/r2modmanPlus-local/RiskOfRain2/profiles/$4/BepInEx/plugins/"

mkdir -p "$targetDir"
cp "$dllFilePath" "$targetDir"

# Reset out folder
rm -rf "$outFolder"
mkdir -p "$outFolder"

# Copy base files
cp "$3/images/icon.png" "$outFolder"
cp "$3/README.md" "$outFolder"
cp "$3/manifest.json" "$outFolder"
cp "$dllFilePath" "$outFolder"

# Replace version in manifest.json
sed "s/{VERSION}/$version/g" "$outFolder/manifest.json" > "$outFolder/manifest.tmp"
mv "$outFolder/manifest.tmp" "$outFolder/manifest.json"

# Zip
zip -j "$outFolder/$4_$version.zip" "$outFolder"/*

# Replace version in Plugin.cs (reverse step)
mv "$csFilePath.bak" "$csFilePath"
