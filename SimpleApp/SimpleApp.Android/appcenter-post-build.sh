#!/bin/bash

echo "Found NUnit test projects:"
find $APPCENTER_SOURCE_DIRECTORY -regex '.*SimpleApp.Appium.UITestsUWP.*\.csproj' -exec dotnet test --logger "nunit;logFileName=TestResults.xml" {} \;
