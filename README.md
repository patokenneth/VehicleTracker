# VehicleTracker
A project to record, update and fetch the locations of vehicles.

## Description
In this project, I have built a web API to simulate a vehicle tracking platform. The web API receives the vehicle location coordinates, records the information and spits the location if required.

## Getting Started
This project is on my github repo and has one branch: main. Start by cloning the main branch of the repo. Afterwards, restore the NuGet packages 
and run migration (both the add-migration and update-database commands). As a way of seeding an admin user, I have a default user whose username is Seven and the password is Sev7T. The admin 
user is able to register other users and also fetch the vehicle location or location history. If you have followed the instructions above, the solution should start up on swagger when you run it.

##Test user
username : Seven
password : Sev7T

### Dependencies

To successfully run this project, you need to have the following environments ready:
* .NET 5 SDK or above (https://dotnet.microsoft.com/download/dotnet/5.0)
* Since "LocationName" property is fetched via google Geolocation api, you need internet access to get the whole properties. If there is no internet, the LocationName field will be empty. 

### Installing

This is a public repo and the project is licesed under GPL, hence, there is no permission needed to get the installation. 
Simply head over to the url: https://github.com/patokenneth/VehicleTracker. Or request for a zipped folder via my contact details below.

##Extensibility
As asked, if the user would like to add more properties like the fuel consumption, speed et cetera, all you have to do is include those nullable properties
in the "LocationHistory" model and run migrations to effect the changes in the db schema. Also, add those properties in the "RegisterPositionViewModel" and modify the "RecordPosition" method to use those 
new properties in saving a vehicle position.


## Issues

* As at the time of writing, this project has been successfully tested and no bug or recurring issue is detected. Kindly ensure that the requisite .NET core runtime/SDK is installed before running the application.

## Authors

Contributor(s) names and contact info

* Chiemezie Oloto (chiemezieoloto4@gmail.com)

## Version History
* 1.0.0

* 0.0.0
    * Initial Release

## Acknowledgments

Inspiration, code snippets, etc.
* https://docs.microsoft.com/en-us/aspnet/web-api/overview/

