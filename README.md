# RiderApp

This App was built for a coding challenge. Riders can be created, updated, deleted. There would be jobs associated with them. You can also view all the riders. 

## Getting Started

App URL: https://riderappprajith.azurewebsites.net/

The app is hosted on Azure using WebApps.

The SQL server is also configured on Azure, using Azure SQL server and db. There is a script of the tables that were created for this application in the RiderApp folder named RiderAppDB_script. 2 tables - Rider and Job

### Assumptions

* Simple App to showcase my full stack skills.
* You can only add, update, delete riders but cannot manipulate jobs. Jobs are added through the DB.
* StartDate for rider is the datetime the rider is added. Cannot update it.
* Simple validation against names, phonenumbers, emails. The add/udpate button will not be enabled unless there are valid entries on the addRider and updateRider form on the UI.
* Sufficient Unit tests
* Just 2 SQL tables - Rider, Job

### Improvements

* UI can be improved big time.
* Web API documentation using swagger
* Authentication/Authorization for the the API's
* Unit test to involve stub/mock interfaces to talk with dummy data instead of actual database.
* Azure Devops could be integrated with this repo.
* Docker container for the app.

### Prerequisites

There are no prerequisites for this app as everything is hosted on the cloud. 


## Running the tests

I have created a few unit tests which are found in the folder RiderAppTest. This could be run manually. Tests include the interface testing i.e. test the controllers. 

These tests will talk with the production database, unfortunately. I can create a dummy db and run the tests.


### Deisgn Style

3 Tier Architecture - Presentation layer, Business Layer, Data Access Layer

## Built With

* React.js, css, bootstrap - Front End 
* .NET MVC/Core C# - Back End
* Hosted on Azure WebApps
* Azure SQL Server - Database
* Docker Image
