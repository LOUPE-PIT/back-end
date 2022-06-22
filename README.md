# Loupe Project Backend
The Loupe Project Backend in collaboration with the Loupe Unity project is a project made to improve/support practical lessons with the use of Mixed Reality.
The Backend of this project is used and will be used as an API to deliver the essential data to the Unity Mixed Reality project (Logs, 3D Models, etc.). Eventually it will also be used as a way to save 3D Models via a web application.
The technologies used in this project were chosen by researching the available options. This project makes use of the microservice architecture, the main reason for this choice was the ability to scale the project to increase the performance. 
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
* API Gateway -> Authentication
* Useful Sources	

## Installation of the project
This project can be run locally in visual studio 2022. 
To setup the project in Visual Studio 2022:
1. Clone the repository to your device
2.	Start Visual Studio 2022
3.	Select open a project or solution
4.	Browse to the repository and select the .sln file in LOUPE_Backend
5.	– The project will be loaded in, before building the project be sure to run the test project first. This can be done by right clicking servicename.Microservice.Test.csproj and selecting run tests.
6.	Once all the tests have been completed and verified, select the projects you want to run by setting the startup projects in the solution and run the application

After this set-up the main part of the application is set-up, to fully use the application and its features messaging, service related databases and the ftp server need to be set up.

### Messaging RabbitMQ
RabbitMQ can be set up using the docker image from docker hub: 
```
docker run -d --hostname my-rabbit --name some rabbit-p -p 15672:15672 -p 5672:5672 rabbitmq:management
```
Management is a key component here!
The settings to connect to RabbitMQ in the application can be found in the RabbitMQSettings.cs file. Depending on if you're hosting RabbitMQ on a virtual machine or on e.g. docker desktop, the ip needs to be changed. Furthermore you can eventually choose to use different login credentials for security reasons (standard credentials are, pw: guest user:guest).
More on this image can be found [here](https://hub.docker.com/_/rabbitmq/).

### FTP Server
An FTP server can be set up using the docker image from docker hub:
```
docker run --rm -d --name ftpd_server -p 21:21 -p 30000-30009:30000-30009 stilliard/pure-ftpd bash /run.sh -c 30 -C 10 -l puredb:/etc/pure-ftpd/pureftpd.pdb -E -j -R -P localhost -p 30000:30059
```
More on this image can be found [here](https://hub.docker.com/r/stilliard/pure-ftpd).
### MsSQL Database
MsSQL can be set up using the docker image from docker hub:
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```
Using the Microsoft SQL Server Management Studio 18 or an equivalent management studio (Azure Data Studio), you can manage the created databases. For development the connectionstring is located in the appsettings.json file per microservice, as each microservice uses its own database as stated before.
More on this image can be found [here](https://hub.docker.com/_/microsoft-mssql-server).

As the database is an important part to make sure the application works as it should, during development the database is required to run at all times. To make sure the data is up-to-date and backed up make sure the migrations are automatically run when starting a microservice.

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
RabbitMQ (a message bus) is used to handle the exchange and queue. Messages/logs that run through the message bus will stay in the queue in the case of a loghandler service failure. When there is no failure the message/log will immediately be send to the Logconsumer.

#### Consumer
In this case the loghandler microservice is the consumer. In the project there is a separate LogModelConsumer.cs file which, as of now, displays the log in the console.

Both the Producer and Consumer make use of a SharedLibrary (which is needed because of the way the messaging is set up), when replacing the Producer to the unity project (external) this “Direct exchange” will have to be changed and the SharedLibrary will possibly become redundant.

### ObjectHandler Microservice (3DModel)
The ObjectHandler microservice is responsible for handling the 3DModels data and actions (upload, retrieve, delete, etc.). 3DModels are stored in a ftp server using .ZIP formatting.

### *Servicename*.Microservice.Test
For every service there is a test project. The tests, test the actions the api endpoints will need to be able to execute during runtime.

### API Gateway
This project makes use of an API gateway, this API is setup using ocelot. The api gateway can be used for authentication and other security purposes. This API is connected to the microservices and handles the routing of api calls to all the microservices

#### Authentication
As an addition to the API Gateway we started an implementation of the authentication in a seperate branch (Ocelot-Auth-Alpha). To complete the authentication implementation the **claim value** (which can be found in the jwt token) needs to be recognized by the API Gateway.

To elaborate:
Medium described 3 scenarios on how to implement authentication using ocelot, which can be found [here](https://medium.com/@niteshsinghal85/3-ways-to-do-authorization-in-ocelot-api-gateway-in-asp-net-core-7ef8301b2f65). There is also an official documentation by ocelot on authencication [here](https://ocelot.readthedocs.io/en/latest/features/authentication.html).

## Useful Sources
[How to create a minimal api microservice](https://www.youtube.com/watch?v=Z4bINJudHX8&list=PL6tu16kXT9PrlCX-b1o0WdBc56rXHJXLy)

[Mega directory to all project related documents](https://mega.nz/fm/poAQnJhZ)

[See the Trello board for open issues](https://trello.com/b/RDldlSvD/loupe-back-end)
