# Docker Compose

## Log handler
This docker-compose file has 3 services:
- loghandler
    - This is our API. Some things to note are:
        - We specify the container name and hostname so the service can later be found by the API gateway.
        - It is dependent on both the database and rabbit-mq, which means it will start AFTER those 2 services have started.
        - We add a couple of environmental values:

        | Environment  | Reason |
        | ---          | ---    |
        | ConnectionString | This is we can change it in the docker compose without having to rebuild the app.
        | rabbitmq:user | the username for rabbitmq 
        | rabbitmq:password | the password for rabbitmq
        | rabbitmq:ip-address | the ip-address for rabbitmq
        | rabbitmq:queue-name | the name of the rabbitmq queue
        | ASPNETCORE_URLS | Making it so its hosted on a different port than default.

    - We expose port 5000 for the microservice
- rabbit-mq
    - This is our rabbit-mq. We use this for messaging. Some things to note:
        - We specify the container name and hostname so the service can be found by our loghandler.
        - We add a couple of environmental values:

        | Environment  | Reason |
        | ---          | ---    |
        | RABBITMQ_DEFAULT_USER | This is the username for RabbitMQ.
        | RABBITMQ_DEFAULT_PASS | This is the password for RabbitMQ

        - Ports
            - We expose port 15672 for the web interface.
            - We expose port 5672 for the messaging.
- db
    - This is the service for our database. Some things to note:
        - We specify the container name and hostname so the service can later be found by the loghandler.
        - We add a couple of environmental values:

        | Environment  | Reason |
        | ---          | ---    |
        | ACCEPT_EULA | The EULA needs to be accepted before the database can be used.
        | SA_PASSWORD | This is the password for the database. The username is SA.
        - Ports
            - We expose port 1433 for database access.

## object handler
This docker-compose file has 3 services:
- objecthandler
    - This is our API. Some things to note are:
        - We specify the container name and hostname so the service can later be found by the API gateway.
        - It is dependent on both the database and the ftp service, which means it will start AFTER those 2 services have started.
        - We add a couple of environmental values:

        | Environment  | Reason |
        | ---          | ---    |
        | ConnectionString | This is we can change it in the docker compose without having to rebuild the app.
        | FTP:user | the username for ftp 
        | FTP:Password | the password for ftp
        | FTP:IpAddress | the ip-address for ftp
        | ASPNETCORE_URLS | Making it so its hosted on a different port than default.

    - We expose port 5001 for the microservice
- FTP
    - This is our ftp server. We use this for file storage. Some things to note:
        - We specify the container name and hostname so the service can be found by our loghandler.
        - We add a couple of environmental values:

        | Environment  | Reason |
        | ---          | ---    |
        | PUBLICHOST | Where the ftp server should be hosted
        | FTP_USER_NAME | This is the username for ftp
        | FTP_USER_PASS | This is the password for ftp
        | FTP_USER_NAME | The root folder for the user

        - Ports
            - We expose port 21 for ftp.
            - We expose ports 30000 to 30009 as excess ports
- db
    - This is the service for our database. Some things to note:
        - We specify the container name and hostname so the service can later be found by the loghandler.
        - We add a couple of environmental values:

        | Environment  | Reason |
        | ---          | ---    |
        | ACCEPT_EULA | The EULA needs to be accepted before the database can be used.
        | SA_PASSWORD | This is the password for the database. The username is SA.
        - Ports
            - We expose port 1433 for database access.

## user handler
This docker-compose file has 2 services:
- userhandler
    - This is our API. Some things to note are:
        - We specify the container name and hostname so the service can later be found by the API gateway.
        - It is dependent on the database, which means it will start AFTER that service has started.
        - We add a couple of environmental values:

        | Environment  | Reason |
        | ---          | ---    |
        | ConnectionString | This is we can change it in the docker compose without having to rebuild the app.
        | ASPNETCORE_URLS | Making it so its hosted on a different port than default.

    - We expose port 5002 for the microservice
- db
    - This is the service for our database. Some things to note:
        - We specify the container name and hostname so the service can later be found by the loghandler.
        - We add a couple of environmental values:

        | Environment  | Reason |
        | ---          | ---    |
        | ACCEPT_EULA | The EULA needs to be accepted before the database can be used.
        | SA_PASSWORD | This is the password for the database. The username is SA.
        - Ports
            - We expose port 1433 for database access. 

## API Gateway
This docker-compose file has 1 service:
- objecthandler
    - This is our API. Some things to note are:
        - We specify the container name and hostname so the service can later be found by the API gateway.
        - We expose port 8080 for the api-gateway


## Fullstack
The *fullstack.yaml* file combines all the individual docker-compose files into one. This one can be used to deploy the entire project. We expose multiple ports for this project which are listed belowed.
|App| Port|
| ---|---|
| API-GATEWAY | 8080
| LOGHANDLER | 5000
| OBJECTHANDLER | 5001
| USERHANDLER | 5002
| FTP | 21, 30000-30009
| RABBITMQ | 15672, 5672

For the documentation of each API we use swagger. This can be accessed by going to the address of the API and adding */swagger* at the end of the call (e.g. localhost:5000/swagger).
> As of writing this document, the API gateway is unable to show the swagger endpoints of the services attached to it. However, Tthe endpoint */swagger* does exist. The API gateway does support this, but isnt configured directly. Perhaps something to look into.

## How to use
The docker-compose file can be used in a variation of different ways. The easiest way is by using docker CLI

### Docker CLI
If you use the docker CLI, all you need is to have docker installed on your system. For Windows and IOS this can be done using Docker Desktop, and for Linux can be done using [this tutorial](https://www.digitalocean.com/community/tutorials/how-to-install-and-use-docker-on-ubuntu-20-04). Depending on your version of the Docker CLI, the command ```docker compose``` is avaiable or not. If it is not available, you need to install it seperately. See [this link](https://docs.docker.com/compose/install/) for more info.
When docker compose is installed, you can run the full app by using the following command:
```bash
(sudo) docker-compose up -f fullstack.yml
# OR
(sudo) docker compose up -f fullstack.yml
```
Docker should create the containers itself

### Portainer
Portainer is a webinterface for container management. It is very simple to install and can be very usefull. To install it, first install docker on your system. Once that is done, enter the following commands:
```bash
# Create a volume to save all the containers to
(sudo) docker volume create portainer_data

# Run the container
(sudo) docker run -d -p 9000:9000 -p 8000:8000 --name portainer --restart always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce:latest
```
Once it is running, it can be accessed using port *9000*. Make sure to select local as your enviroment and voila, portainer is running!
To run our app within portainer, you go into the local enviroment and click on the *Stacks* tab on the left hand side (see image).
![](https://cdn.discordapp.com/attachments/899947100899508254/989133024031543326/unknown.png)
Once you are here, you click the blue button *Add Stack*. Here you enter the stack name and the docker-compose file (fullstack.yml) and click the *deploy this stack* button at the bottom. Wait until it is started and you should see all the containers for the app be created.
