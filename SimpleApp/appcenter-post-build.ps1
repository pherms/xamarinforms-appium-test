# Running appium UI tests
write-output ---[post-build ROOT BEGIN]---------------------------------------------------------------
write-output "Running unit tests."

if (get-childitem -path .\SimpleApp\SimpleApp.Appium.UITestsUWP\bin -Recurse | Where-Object { $_.name -like "*UnitTests*.dll"}) {
    write-output "Unit test file found"
    write-output (get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP\bin -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*UnitTests*.dll" } | select-object -Expand fullname)
    # Running unit tests
    get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP\bin -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*UnitTests*.dll" } | foreach-object { 
        write-host "Running unit tests from file:" $_.fullname
        & .\packages\NUnit.ConsoleRunner.3.12.0\tools\nunit3-console.exe $_.fullname 
    }
}
else {
    write-output "No unit test file found. Searching for unit test project file"
    write-output (get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*Tests*.csproj" } | select-object -Expand fullname)
    write-output "Building NUnit test projects:"
    get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*Tests*.csproj" } | foreach-object {
        write-host "Building unit testfile from project:"  $_.fullname
        & "csc.exe /noconfig /nowarn:1701,1702 /fullpaths /nostdlib+ /errorreport:prompt /warn:4" $_.fullname
    }
    write-output "Running unit tests"
    get-childitem -Path .\SimpleApp\SimpleApp.Appium.UITestsUWP\bin -Recurse -ErrorAction SilentlyContinue | where-object { $_.name -like "*Tests*.dll" } | foreach-object { 
        write-host "Running unit tests from file:" $_.fullname
        & .\packages\NUnit.ConsoleRunner.3.12.0\tools\nunit3-console.exe $_.fullname 
    }
}

write-output ---[post-build ROOT BEGIN]---------------------------------------------------------------