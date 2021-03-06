# Running appium UI tests
write-output ---[post-build ROOT BEGIN]---------------------------------------------------------------
write-output "Running unit tests."

if (get-childitem -path .\SimpleApp\SimpleApp.Appium.UITestsUWP\bin -Recurse | Where-Object { $_.name -like "*UnitTests*.dll"}) {
    write-output "Unit test file found"
    write-output (get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP\bin -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*Appium*UITests*.dll" } | select-object -Expand fullname)
    # Running unit tests
    get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP\bin -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*Appium*UITests*.dll" } | foreach-object { 
        write-host "Running unit tests from file:" $_.fullname
        start-process '.\packages\NUnit.ConsoleRunner.3.12.0\tools\nunit3-console.exe' $_.fullname 
    }
}
else {
    write-output "No unit test file found. Searching for unit test project file"
    write-output (get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*Appium*UITests*.csproj" } | select-object -Expand fullname)
    write-output "Building NUnit test projects:"
    get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*Appium*UITests*.csproj" } | foreach-object {
        write-host "Building unit testfile from project:"  $_.fullname
        # start-process 'C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\Roslyn\csc.exe' -Argumentlist '/noconfig /nowarn:1701,1702 /fullpaths /nostdlib+ /errorreport:prompt /warn:4 $_.fullname'
        start-process 'C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\bin\msbuild.exe' -ArgumentList $_.FullName
    }
    write-output "Running unit tests"
    get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP\bin -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*Appium*UITests*.dll" } | foreach-object { 
        write-host "Running unit tests from file:" $_.fullname
        start-process '.\packages\NUnit.ConsoleRunner.3.12.0\tools\nunit3-console.exe' $_.fullname
    }
}

write-output ---[post-build ROOT BEGIN]---------------------------------------------------------------