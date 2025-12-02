#!/usr/bin/env bash

# bash "$(ProjectDir)dev\pre_build.sh" $(ProjectDir) $(SolutionName)

csFilePath="$1${2}Plugin.cs"
versionFile="${1}VERSION"

version="$(tr -d '\n' < "$versionFile")"

# Replace {VERSION} → actual version
cp "$csFilePath" "$csFilePath.bak"
sed "s/{VERSION}/$version/g" "$csFilePath" > "$csFilePath.tmp"
mv "$csFilePath.tmp" "$csFilePath"
