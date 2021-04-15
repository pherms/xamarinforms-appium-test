#!/bin/bash

echo "Found NUnit test projects:"
find $testDir -regex '.*SimpleApp.Appium.UITestsUWP.*\.csproj' -exec dotnet test --logger "nunit;logFileName=TestResults.xml" {} \;
