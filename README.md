
# Playwright automation project using C#

This project has playwright automation test cases using NUnit classes. This supports running test cases in multiple browsers and to enable parallelising the tests.


##  Pre Requisites
- IDE: Visual Studio 2022
- .Net 8.0 or higher version
- Powershell 7.4.5 or higher version
- Windows 10+, Windows Server 2016+ or Windows Subsystem for Linux (WSL)

## Getting started
- Clone repository
```bash
  git clone https://github.com/SowmyaVMurthy/PlaywightAutomationAssignment.git
```
- Navigate to project directory
```bash
  cd PlaywrightTests
```
- Install dependencies
```bash
  dotnet add package Microsoft.Playwright.NUnit
```
- Install required browsers
```bash
  pwsh bin/Debug/net8.0/playwright.ps1 install
```
## Running Tests

- To run all tests, run the following command (runs in headless mode by default)

```bash
  dotnet test
```
- To run all the test in headed mode, run the following command
```bash
  dotnet test -- Playwright.LaunchOptions.Headless=false
```
- To run a specific test, provide the class name of the file and run the following command
```bash
  dotnet test --filter "ClassName"
```
- To run a set of tests, provide the class names of the file and run the following command
```bash
  dotnet test --filter "ClassName1|ClassName2"
```
- To run test in particular browser, run the following command
```bash
  dotnet test -- Playwright.BrowserName=firefox
```
- To run test in parallel, run the following command
```bash
  dotnet test -- NUnit.NumberOfTestWorkers=5
```
- Test can also be run from the Test Explorer window and the configuration changes for browser, parallel execution, headless mode, etc can be done in the .runsettigs file.


## Configuration
- Modify the Playwright.runsettings file for changing the browser for exceution as chromium, firefox or webkit
- Modify headless to true if want to execute the tests in headless mode and false to execute the tests in headed mode
## Note
- Run the tests in the sequence of 
    1. UserCreation
    2. EditUser
    3. DeleteUser
  The need to follow the sequence is as we are editing and deleting the existing user created in the user creation tests
- As the application doesn't allow duplicate username and email id, the same can be changed for execution if error is thrown.
