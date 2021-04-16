#!/bin/bash

# Start appium server
echo "Starting appium server"
appium -a 127.0.0.1 -p 4723 &>/dev/null &
echo "Appium is running in the background."

echo "Running dotnet restore to generate project.assets.json file."
dotnet restore
echo "Done running dotnet restore."
echo "Searching for project.assets.json:"
find "$APPCENTER_SOURCE_DIRECTORY\SimpleApp\SimpleApp.iOS" -regex '.*project.assets.*\.json' -exec echo {} \;
echo