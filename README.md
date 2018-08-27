# RV_assignment

RV_assignment project consists of 2 parts: documentation and solution.

Documentation includes RV_Test_Plan file and RV_Test_Cases file for testing landing page when navigate to https://internet.frontier.com/?lp=6108.
Solution includes FrontierTestingProjectForRV.sln -  automated tests suite created on C# with help of Selenium, NUnit, and .Net frameworks in Visual Studio 2017 IDE.

## How to review this assignment?

Please follow these steps to review the assignment:

1. Start with reviewing RV_Test_Plan that you can find in Documentation folder:

* It gives you brief overview of testing activities for the project. Since this assignment is for landing page testing only, some   sections are missed. Please note that test plan does not contain FrontierTestingProjectForRV.sln description. 

2. After Test Plan, please review RV_Test_Cases spreadsheet located in Documentation folder: 

* Test Summary tab provides information about Conditions/Assumptions, discovered issues, and automated test coverage (shows            corresponding automated tests for each test case from Functional Test Cases tab).
* Functional Test Cases tab contains actual test cases. Some columns are blank or marked as TBD/TBC: my goal is to show how testing efforts might be expanded if necessary.
* UI_UX Testing Checlist tab includes steps to perform for UI and usability testing. I tried to show a "light" version of test suite that might be used if project deadline is close.

3. Please review FrontierTestingProjectForRV.sln located in code folder:

* All the information provided below is for FrontierTestingProjectForRV.sln. 

### Description of FrontierTestingProjectForRV.sln

FrontierTestingProjectForRV.sln consists of 2 projects: Frontier Tests and Frontier Pages. 

Frontier Tests: 

* Test project has 9 tests based on created functional test cases.There are 2 regions: Initialize & Cleanup (driver initialization with different browsers consideration and driver tear down) and Tests.
Each test has [Description("...")] attribute which provides a brief description of what this test does. [Categoty("...")] attribute might be useful when executing tests for a specific functionality module.

Frontier Pages:

* Project is created based on Page Object pattern: each class contains page specific methods and locators for web elements. There are some empty classes that had to be created to show expandability.
BasePage.cs aggregates methods common for all pages.

### Prerequisites to run Frontier Tests


### Installing

## Authors

Kate Nasovich 

## Acknowledgments
