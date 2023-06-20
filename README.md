![LoupeLogo](Assets/LOUPE.png)
# Loupe Project
This project is a collaboration between Fontys ICT and Loupe PIT from ROC Tilburg. This is a project made to improve/support practical lessons with the use of Mixed Reality. At the time of writing this README the project mainly consists of a Portal. In this portal teachers can make lessons, groups with students, monitor what students do and give feedback to the actions that students did. In the Portal the teacher has a live view of the 3D object, the students are working on, this is done by implementing 3JS for rendering the 3D objects. All technologies chosen for this project were chosen by researching different available options. This project makes use of the microservice architecture, this architecture has been chosen by looking at the pro's- and cons of different architectures. For the main framework of this project .Net 6.0 is used. 
Every microservice has its own database. All of them except the Synchronization service make use of MsSQL databases. The Synchronization service makes use of MongoDB.
SignalR is used for messaging between the Synchronisation service and the Front-end React/Vite application.
GRPC is used for remote procedure calls betwen the Synchronisation- and Log Service.

## Table Of contents
* Loupe project
* Evaluation and future
* Back-end 
* How to use the project	
* Feedback Service	
* Grouping Service
* Logging Service
* Synchronisation Service
* User Service
* Object Service
* Installation of the project	
* Front-end		
* Installation of the project
* Useful Sources
* Dependencies	

# Evaluation and future
At the moment of writing, the backend functions the way it was intended. There are some issues that could be addressed, these issues can be found in the [backlog](https://github.com/orgs/LOUPE-PIT/projects/1).
The frontend has some experimental work, like the use of Vite.js and Three.js. Because of that, there might be a lot of improvements possible frontend wise.

At the moment, this application is only used for the student/teacher portal. In the future it should be possible to use the application together with unity clients to actually work in a Mixed Reality space.

# Back-end

## How to use the project
Because this project makes use of the microservice architecture the project is split into several components/services.
These different microservices consist of 3 projects:
- The DAL, or data access layer is responsible for handling data persistence and database interactions. It provides an abstraction layer between the application and the underlying data storage system. The DAL project communicates with the database to perform CRUD (Create, Read, Update, Delete) operations and ensures data integrity and consistency.
- API.Core, this project serves as the core functionality and business logic layer of the microservice. It encapsulates the essential business rules and operations of the application. It defines the models, services and interfaces that represent the core functionalities of the microservice. The API.Core project does not directly handle the HTTP requests but provides a foundation for the API layer to build upon.
- API, the API project is responsible for exposing the microservice's functionalities to clients through HTTP-based APIs. It acts as a communication interface between the clients and the core logic of the microservice. This layer handles incoming HTTP requests, parses the request parameters and routes them to the appropriate API.Core service or method. 

### Feedback Service
The Feedback Service handles giving feedback to actions that users have performed. This is used by teachers in the portal to give feedback to specific actions that a student did.

### Grouping Service
The Grouping Service handles making groups of students. This is used by teachers in the portal, the teacher is able to add students to a group. After the students inside a group will be able to work on the same assignment.

### Logging Service
The Logging Service is responsible for logging all actions done to a object made by students. When the student makes a change to the object, which he/she is working on, it will be logged. Note that these logs are text, like: User A did X  

### Synchronisation Service
The Synchronisation Service 

### User Service
The User Service is responsible for all user data and actions (CRUD).

### Object Service
The Object Service is still a work in progress. Ultimately the Object Service should be used for uploading and managing the different 3D objects that will be used for lessons/assignments.

## Installation of the project
To fully use this project, all services need to be running.
To start working with this project:
- Clone the repository to your device
- Open the repository with your IDE of choice.
- Start by routing into the correct repository.
```console
cd .\Docker_compose\
```
- Proceed to launch the containers using the images on the LOUPE container registry
```console
docker-compose up -d
```
- Note that the -d is optional and will run the containers in detached mode. [More Info](https://docs.docker.com/language/golang/run-containers/#:~:text=Run%20in%20detached%20mode&text=Docker%20can%20run%20your%20container,you%20to%20the%20terminal%20prompt.)

# Front-end
## Installation of the project
To start working with this project:
- Install node version 18.16.0 (or LTS) [link](https://nodejs.org/en)
- Clone the repository to your device
- Open the repository with your IDE of choice.
- Run the application from the LOUPE_Frontend folder
- Start by installing necessary packages.
```console
npm install
```
```console
npm run dev
```

## Useful Sources
[What are microservices?](https://microservices.io/)

[Backlog with open issues](https://github.com/orgs/LOUPE-PIT/projects/1)

[Figma designs for the portal](https://www.figma.com/file/Zrbd25ObPN7vdwjT1SpIrd/LOUPE-Designs?type=design&node-id=0-1)

## Resources from older groups

[Mega directory to all project related documents](https://mega.nz/fm/poAQnJhZ)

[See the Trello board for open issues](https://trello.com/b/RDldlSvD/loupe-back-end)

## Dependencies
| Service              | Package                                           | Version                          |
|----------------------|---------------------------------------------------|----------------------------------|
| FeedbackService      | **API**                                           |                                  |
|                      | Microsoft.EntityFrameworkCore                      | 7.0.4                            |
|                      | Microsoft.EntityFrameworkCore.Design              | 7.0.4                            |
|                      | Swashbuckle.AspNetCore                            | 6.2.3                            |
|                      |                                                   |                                  |
|                      | **Core**                                          |                                  |
|                      | AutoMapper                                       | 12.0.1                           |
|                      | AutoMapper.Extensions.Microsoft.DependencyInjection | 12.0.1                           |
|                      |                                                   |                                  |
|                      | **DAL**                                           |                                  |
|                      | Microsoft.EntityFrameworkCore                      | 7.0.4                            |
|                      | Microsoft.EntityFrameworkCore.Design              | 7.0.4                            |
|                      | Microsoft.EntityFrameworkCore.SqlServer            | 7.0.4                            |
|                      | Microsoft.EntityFrameworkCore.Tools                | 7.0.4                            |
|                      | Microsoft.Extensions.Configuration                | 7.0.0                            |
|                      | Microsoft.Extensions.Configuration.Json           | 7.0.0                            |
|                      |                                                   |                                  |
|                      | **Test**                                          |                                  |
|                      | coverlet.collector                                | 3.1.0                            |
|                      | FluentAssertions                                 | 6.10.0                           |
|                      | Microsoft.NET.Test.Sdk                           | 16.11.0                          |
|                      | Moq                                              | 4.18.4                           |
|                      | NUnit                                            | 3.13.2                           |
|                      | NUnit3TestAdapter                                | 4.0.0                            |
| GroupingService      | **API**                                           |                                  |
|                      | EntityFramework                                  | 6.4.4                            |
|                      | Microsoft.EntityFrameworkCore                      | 6.0.4                            |
|                      | Microsoft.EntityFrameworkCore.Relational           | 6.0.4                            |
|                      | Microsoft.EntityFrameworkCore.SqlServer            | 6.0.4                            |
|                      | Swashbuckle.AspNetCore.Annotations                | 6.5.0                            |
|                      | Swashbuckle.AspNetCore.SwaggerUI                  | 6.5.0                            |
|                      |                                                   |                                  |
|                      | **Core**                                          |                                  |
|                      | Refit                                            | 6.3.2                            |
|                      |                                                   |                                  |
|                      | **DAL**                                           |                                  |
|                      | Microsoft.EntityFrameworkCore                      | 6.0.4                            |
|                      | Microsoft.EntityFrameworkCore.Design              | 6.0.4                            |
|                      | Microsoft.EntityFrameworkCore.SqlServer            | 6.0.4                            |
|                      | Microsoft.Extensions.Configuration                | 8.0.0-preview.2.23128.3         |
|                      | Microsoft.Extensions.Configuration.Abstracions    | 8.0.0-preview.2.23128.3         |
|                      | Microsoft.Extensions.Configuration.FileExtensions | 8.0.0-preview.2.23128.3         |
|                      | Microsoft.Extensions.Configuration.Json           | 8.0.0-preview.2.23128.3         |
|                      |                                                   |                                  |
|                      | **Test**                                          |                                  |
|                      | coverlet.collector                                | 3.1.2                            |
|                      | FluentAssertions                                 | 6.10.0                           |
|                      | Microsoft.NET.Test.Sdk                           | 17.1.0                           |
|                      | Moq                                              | 4.18.4                           |
|                      | NUnit                                            | 3.13.3                           |
|                      | NUnit.Analyzers                                  | 3.3.0                            |
|                      | NUnit3TestAdapter                                | 4.2.1                            |
| LogService           | **Api**                                           |                                  |
|                      | FluentAssertions                                 | 6.10.0                           |
|                      | Google.Protobuf                                  | 3.22.3                           |
|                      | Grpc.AspNetCore.Server.ClientFactory              | 2.52.0                           |
|                      | Grpc.Tools                                       | 2.54.0                           |
|                      |                                                   |                                  |
|                      | **Core**                                          |                                  |
|                      | FluentAssertions                                 | 6.10.0                           |
|                      | Swashbuckle.AspNetCore.Swaggergen                 | 6.5.0                            |
|                      | Swashbuckle.AspNetCore.SwaggerUI                  | 6.5.0                            |
|                      |                                                   |                                  |
|                      | **DAL**                                           |                                  |
|                      | FluentAssertions                                 | 6.10.0                           |
|                      | Microsoft.EntityFrameworkCore                      | 6.0.15                           |
|                      | Microsoft.EntityFrameworkCore.Design              | 6.0.4                            |
|                      | Microsoft.EntityFrameworkCore.SqlServer            | 6.0.15                           |
|                      | Microsoft.Extensions.Configuration.FileExtensions | 7.0.0                            |
|                      | Microsoft.Extensions.Configuration.Json           | 7.0.0                            |
|                      | Microsoft.NET.Test.Sdk                           | 17.6.0-preview-20230223-05      |
|                      |                                                   |                                  |
|                      | **Test**                                          |                                  |
|                      | coverlet.collector                                | 3.1.2                            |
|                      | FluentAssertions                                 | 6.10.0                           |
|                      | Microsoft.NET.Test.Sdk                           | 17.6.0-preview-20230223-05      |
|                      | Moq                                              | 4.18.4                           |
|                      | NUnit                                            | 3.13.3                           |
|                      | NUnit.Analyzers                                  | 3.3.0                            |
|                      | NUnit3TestAdapter                                | 4.2.1                            |
| ObjectHandler        | **Microservice**                                  |                                  |
|                      | FluentAssertions                                 | 6.10.0                           |
|                      | FluentFTP                                        | 37.0.2                           |
|                      | Microsoft.EntityFrameworkCore                      | 6.0.5                            |
|                      | Microsoft.EntityFrameworkCore.Design              | 6.0.5                            |
|                      | Microsoft.EntityFrameworkCore.SqlServer            | 6.0.5                            |
|                      | Microsoft.VisualStudio.Azure.Containers.Tools.Targets | 1.14.0                        |
|                      | Moq                                              | 4.18.4                           |
|                      | Swashbuckle.AspNetCore                            | 6.2.3                            |
|                      |                                                   |                                  |
|                      | **Test**                                          |                                  |
|                      | coverlet.collector                                | 3.1.2                            |
|                      | FluentAssertions                                 | 6.10.0                           |
|                      | Microsoft.AspNetCore.Mvc.Testing                  | 6.0.3                            |
|                      | Microsoft.EntityFrameworkCore.SqlServer            | 8.0.0-preview.2.23128.3         |
|                      | Microsoft.NET.Test.Sdk                           | 16.11.0                          |
|                      | Moq                                              | 4.18.4                           |
|                      | MSTest.TestAdapter                               | 2.2.7                            |
|                      | MSTest.TestFramework                             | 2.2.7                            |
|                      | xunit                                            | 2.4.1                            |
|                      | xunit.extensibility.core                         | 2.4.1                            |
|                      | xunit.runner.console                             | 2.4.1                            |
|                      | xunit.runner.visualstudio                         | 2.4.3                            |
| SynchronisationService | **API**                                          |                                  |
|                      | Google.Protobuf                                  | 3.22.3                           |
|                      | Grpc.AspNetCore.Server.ClientFactory              | 2.52.0                           |
|                      | Grpc.Tools                                       | 2.54.0                           |
|                      | Microsoft.VisualStudio.Azure.Containers.Tools.Targets | 1.17.2                        |
|                      | Swashbuckle.AspNetCore                            | 6.5.0                            |
|                      |                                                   |                                  |
|                      | **Core**                                          |                                  |
|                      | AutoMapper                                       | 12.0.1                           |
|                      | AutoMapper.Extensions.Microsoft.DependencyInjection | 12.0.1                           |
|                      |                                                   |                                  |
|                      | **DAL**                                           |                                  |
|                      | Microsoft.Extensions.Configuration.Json           | 7.0.0                            |
|                      | MongoDB.Driver                                   | 2.19.1                           |
| UserService          | **API**                                           |                                  |
|                      | Microsoft.EntityFrameworkCore                      | 7.0.4                            |
|                      | Microsoft.EntityFrameworkCore.Design              | 7.0.4                            |
|                      | Swashbuckle.AspNetCore                            | 6.2.3                            |
|                      |                                                   |                                  |
|                      | **Core**                                          |                                  |
|                      | NONE                                             |                                  |
|                      |                                                   |                                  |
|                      | **DAL**                                           |                                  |
|                      | Microsoft.AspNetCore.Mvc.Core                     | 2.2.5 (Deprecated)               |
|                      | Microsoft.EntityFrameworkCore                      | 7.0.4                            |
|                      | Microsoft.EntityFrameworkCore.Design              | 7.0.4                            |
|                      | Microsoft.EntityFrameworkCore.SqlServer            | 7.0.4                            |
|                      | Microsoft.EntityFrameworkCore.Tools                | 7.0.4                            |
|                      | Microsoft.Extensions.Configuration                | 7.0.0                            |
|                      | Microsoft.Extensions.Configuration.Json           | 7.0.0                            |
| API.Gateway          | FluentAssertions                                 | 6.10.0                           |
|                      | Microsoft.VisualStudio.Azure.Containers.Tools.Targets | 1.14.0                        |
|                      | MMLib.SwaggerForOcelot                           | 5.0.3                            |
|                      | Moq                                              | 4.18.4                           |
|                      | Ocelot                                           | 18.0.0                           |
|                      | Swashbuckle.AspNetCore                            | 6.3.1                            |
