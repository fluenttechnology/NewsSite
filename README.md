# NewsSite
The project started out as a technical challenge sent to me by a prospective employer.  I used the opportunity to develop in a language I wasnt fluent in to try learn something new during the process!  The site is meant to be a shell news site that imports news articles through an external api and displays them with asp.net razor.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

## Prerequisites
1. Visual Studio: https://www.visualstudio.com/vs/community/

## Installing and Running
### 1. Visual Studio
1. Go to https://www.visualstudio.com/vs/community/ and download the executable
2. Run the executable when it has finished downloading onto your machine
3. On the Workloads section of the installation select ".NET Desktop Development" and "ASP.NET and web Development"
4. Follow the steps on the wizard and ensure you have a microsoft account set up (https://account.microsoft.com/account)
5. Run the development environment when installed

### 2. GitHub Repo
1. Navigate to https://github.com/IainCarlisle118/NewsSite
2. Click Clone or Download and then Download .zip file
3. Extract the zip file to your chosen repo destination on your drive
4. Navigate to and run the .sln file in the solution
5. Run the solution by Navigating to Debug->Start Debugging

The main website page should open!

## Unit tests
1. Open the visual studio project
2. Navigate to Test->Windows->Test Explorer on the top menu bar
3. On the top left of the test explorer window on the left, click "Run All", this will run the unit tests

## Deployment
The system is currently deployed to an azure App Service at http://newssite20180319085251.azurewebsites.net/.  To publish a new build you merely right click on your ASP.Net project and click publish.  This brings you to the publish page where you hit the publish button and it will upload the new build.

## Authors
* Iain Carlisle - Initial work

## Acknowledgments
* Hat tip to W3Schools and all the kind people of StackOverflow who helped me with this solution
* The fine people at https://newsapi.org/ for providing an excellent API
* The prospective employers who gave me this oppertunity to learn and improve myself over the course of the project
