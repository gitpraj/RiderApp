# RiderApp

This App was built for a coding challenge. Riders can be created, updated, deleted. There would be jobs associated with them. You can also view all the riders. 

## Getting Started

App URL: https://riderappprajith.azurewebsites.net/riders
The app is hosted on Azure using WebApps.

The SQL server is also configured on Azure, using Azure SQL server and db. There is a script of the tables that were created for this application. 2 tables - Rider and Job

I have also built a docker image out of the app and pushed it to the docker hub.

### Prerequisites

There are no prerequisites for this app as everything is hosted on the cloud. 

### Installing

If using the docker image.

Say what the step will be

```
Give the example
```

And repeat

```
until finished
```

End with an example of getting some data out of the system or using it for a little demo

## Running the tests

I have created a few unit tests which are found in the folder RiderAppTest. This could be run manually. Tests include the interface testing i.e. test the controllers. 

These tests will talk with the production database, unfortunately. I can create a dummy db and run the tests.


### And coding style tests

The functionalities are as modularized as possible.

```
Give an example
```

## Deployment

Run the docker image as mentioned previously. 

## Built With

* React.js, css, bootstrap - Front End 
* .NET MVC/Core C# - Back End
* Hosted on Azure WebApps
* Azure SQL Server - Database
* Docker Image
