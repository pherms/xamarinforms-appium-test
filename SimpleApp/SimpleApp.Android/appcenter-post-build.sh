#!/bin/bash

echo "Found NUnit test projects:"
echo "Unittest dll file does not exist and needs to be build first"
echo "Found NUnit test projects:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*SimpleApp.Appium.UITestsUWP.*\.csproj' -exec echo {} \;
echo
echo "Building NUnit test projects:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*SimpleApp.Appium.UITestsUWP.*\.csproj' -exec dotnet restore {} \;
echo
echo "Building NUnit test projects:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*SimpleApp.Appium.UITestsUWP.*\.csproj' -exec msbuild {} \;
echo
echo "Compiled projects to run NUnit tests:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*SimpleApp.Appium.UITestsUWP.*\.dll' -exec echo {} \;
echo
echo "Running NUnit tests:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*SimpleApp.Appium.UITestsUWP.*\.dll' -exec nunit3-console {} +
echo
# find $APPCENTER_SOURCE_DIRECTORY -regex '.*SimpleApp.Appium.UITestsUWP.*\.csproj' -exec dotnet test --logger "nunit;logFileName=TestResults.xml" {} \;
