![LoupeLogo](Assets/LOUPE.png)
# Loupe Project
This project is a collaboration between Fontys ICT and Loupe PIT from ROC Tilburg. This is a project made to improve/support practical lessons with the use of Mixed Reality. At the time of writing this README the project mainly consists of a Portal. In this portal teachers can make lessons, groups with students, monitor what students do and give feedback to the actions that students did. In the Portal the teacher has a live view of the 3D object, the students are working on, this is done by implementing 3JS for rendering the 3D objects. All technologies chosen for this project were chosen by researching different available options. This project makes use of the microservice architecture, this architecture has been chosen by looking at the pro's- and cons of different architectures. For the main framework of this project .Net 6.0 is used. 
Every microservice has its own database. All of them except the Synchronization service make use of MsSQL databases. The Synchronization service makes use of MongoDB.
SignalR is used for messaging between the Synchronisation service and the Front-end React/Vite application.
GRPC is used for remote procedure calls betwen the Synchronisation- and Log Service.

## Table Of contents
* Loupe project
* Back-end 
* Installation of the project	
* How to use the project	
* Feedback Service	
* Grouping Service
* Logging Service
* Synchronisation Service
* User Service
* Object Service
* Front-end		
* Installation of the project
* Useful Sources	


# Back-end
## Installation of the project

## How to use the project
Because this project makes use of the microservice architecture the project is split into several components/services. 

### Feedback Service

### Grouping Service

### Logging Service

### Synchronisation Service

### User Service
The User Service is responsible for all user data and actions (CRUD).
### Object Service

# Front-end
## Installation of the project

## Useful Sources
[How to create a minimal api microservice](https://www.youtube.com/watch?v=Z4bINJudHX8&list=PL6tu16kXT9PrlCX-b1o0WdBc56rXHJXLy)

[Mega directory to all project related documents](https://mega.nz/fm/poAQnJhZ)

[See the Trello board for open issues](https://trello.com/b/RDldlSvD/loupe-back-end)
