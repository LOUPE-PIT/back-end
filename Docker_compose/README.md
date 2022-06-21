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
The *fullstack.yaml* file combines all the individual docker-compose files into one. This one can be used to deploy the entire project.