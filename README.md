# Loupe Project Bakckend
The Loupe Project Backend in collaboration with the Loupe Unity project is a project made to improve/support practical lessons with the use of Mixed Reality.
The Backend of this project is used and will be used as an API to deliver the essential data to the Unity Mixed Reality project (Logs, 3D Models, etc.). Eventually it will also be used as a way to save 3D Models via a web application.
The technology’s used in this project were chosen by researching the available options. This project makes use of the microservice architecture, the main reason for this choice was the ability to scale the project to increase the performance. 
For the main framework of this project .NET 6.0 is being used, this choice was made by comparing the framework to its competitors based on these nine different categories:
- Range of Applicability
-	Development Speed
-	Manageability & Flexibility
-	Load Support (Amount of requests, etc.)
-	Costs
-	Does it meet the NFR/FR
-	License constraints
-	Documentation/support
-	Maturity of the product
To make sure logs of user interactivity with 3D Models will be saved at all times Messaging is being used with RabbitMQ as the system. Messaging allows content to be handled by another part of the system that will process the message when it suits best. This feature is as of yet not fully implemented In both parts of the project.
To store data for most microservices MsSQL databases are being used, every microservice has its own database. To store the data of the 3DModel microservice a FTP server is being used.

## Table Of contents
* Loupe project Backend
* Installation of the project	
* How to use the project	
* UserHandler Microservice	
* LogHandler Microservice	
* ObjectHandler Microservice (3DModel)	
* *Servicename*.Microservice.Test	
* API Gateway	
* Useful Sources	

## Installation of the project
This project can be run locally in visual studio 2022. 
To setup the project in Visual Studio 2022:
* Clone the repository to your device
*	Start Visual Studio 2022
*	Select open a project or solution
*	Browse to the repository and select the .sln file in LOUPE_Backend
*	– The project will be loaded in, before building the project be sure to run the test project first. This can be done by right clicking servicename.Microservice.Test.csproj and selecting run tests.
*	Once all the tests have been completed and verified, select the projects you want to run by setting the startup projects in the solution and run the application.

After this set-up the main part of the application is set-up, to fully use the application and its features messaging, service related databases and the ftp server need to be set up.
MESSAGING
FTP SERVER
MSSQL DATABASE

## How to use the project
Because this project makes use of the microservice architecture the project is split into several components/services. 

### UserHandler Microservice
The UserHandler microservice is responsible for all user data and actions (create, login, configure, roles, etc.).
In this project we make use of Minimal APIs. This means no more Startup.cs, API Controllers, Extra dependencies, etc. In every microservice all API calls are mapped within the program.cs file, which also contains all startup code.

### LogHandler Microservice
The LogHandler microservice is responsible for all logs data and actions (saving, retrieving, etc.).
To make sure logs are saved (even if the microservice is down for a short period of time), as said earlier, messaging is implemented into the project with the use of RabbitMQ. 
To make messaging work you need a Producer (sender), Exchange & queue (RabbitMQ), and a consumer.

#### Producer
As of now our sender (to send the log) is located in this repository as LogHandler.WebApplicationSender. It contains a controller with a post endpoint, which posts a simple LogModel. 

#### Exchange & queue
RabbitMQ (a message bus) is used to handle the exchange and queue. Messages/logs that run trough the message bus will stay in the queue in the case of a loghandler service failure. When there is no failure the message/log will immediately be send to the Logconsumer.

#### Consumer
In this case the loghandler microservice is the consumer. In the project there is a separate LogModelConsumer.cs file which, as of now, displays the log in the console.

Both the Producer and Consumer make use of a SharedLibrary (which is needed because of the way the messaging is set up), when replacing the Producer to the unity project (external) this “Direct exchange” will have to be changed and the SharedLibrary will possibly become redundant.

### ObjectHandler Microservice (3DModel)
The ObjectHandler microservice is responsible for handling the 3DModels data and actions (upload, retrieve, delete, etc.). 3DModels are stored in a ftp server using .ZIP formatting.

### Servicename.Microservice.Test
For every service there is a test project. The tests, test the actions the api endpoints will need to be able to execute during runtime.

### API Gateway
This project makes use of an API gateway, this API is setup using ocelot. The api gateway can be used for authentication and other security purposes. This API is connected to the microservices and handles the routing of api calls to all the microservices

## Useful Sources
[How to create a minimal api microservice](https://www.youtube.com/watch?v=Z4bINJudHX8&list=PL6tu16kXT9PrlCX-b1o0WdBc56rXHJXLy)

[Sharepoint directory to all project related documents](https://stichtingfontys.sharepoint.com/:f:/r/sites/LOUPE/Gedeelde%20documenten/General/S6-Team?csf=1&web=1&e=NVtOaq)

