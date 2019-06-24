# Viajanet Evaluation Test

Evaluation test using C#, ASP.Net, RabbitMq, Angular, Sql Server and Couchbase.

## Screenshots

![Sign In Page](https://github.com/Katsshura/Viajanet_Teste_DEV/blob/master/Screenshots/signin.png)
![Sign In Page](https://github.com/Katsshura/Viajanet_Teste_DEV/blob/master/Screenshots/signup.png)
![Sign In Page](https://github.com/Katsshura/Viajanet_Teste_DEV/blob/master/Screenshots/leading.PNG)
![Sign In Page](https://github.com/Katsshura/Viajanet_Teste_DEV/blob/master/Screenshots/payment.PNG)
![Sign In Page](https://github.com/Katsshura/Viajanet_Teste_DEV/blob/master/Screenshots/checkout.PNG)

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

Visual Studio Community or another IDE that supports C# ASP.Net and dotnet 2
Npm installed

### Before anything:

Make sure you have Couchbase, Sql server and RabbitMq installed on your pc!

* [Couchbase](https://www.couchbase.com/downloads) - Download Couchbase, follow site guide to install.
* [RabbitMQ](https://www.rabbitmq.com/download.html) - Download RabbitMQ, follow site guide to install.
* [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) - Download Developer version, follow site guide to install.

- Observations:

 1. Create an user on couchbase called ("myuser") with password ("123456")
 2. Create a bucket named "ViajanetDB"

 Or you can change it inside the script for your preference.

### Preparing environment for dotnet API

Follow the instructions below to run the project on your machine

```
1. Open your visual studio

2. Go to files -> open -> ~~\Viajanet_Teste_DEV\WebApi.Client

3. Open Viajanet.sln inside WebApi.Client

4. Wait until Visual Studio install all dependencies
```
### Running API

```
1. Right click on Solution 'Viajanet' -> Properties (or Alt + Enter)

2. Expand the Common Properties node and choose Startup Project.

3. Choose the Multiple Startup Projects option.

4. Mark WebApi.Client.Api, WebApi.CouchbaseReader.Api and RabbitMq.Robot.Initializer as "Start".

5. Run the project -> Ctrl + F5 or F5

6. Wait Visual Studio to compile the project

7. Api is running. 
```
### Running Angular Project

```
1. Make sure all api's from dotnet core are running properly on your machine!.
Otherwise you may find problems to load landing page.

2. Open Web-Angular-Client folder on Visual Code, Webstorm or any other IDE.

3. Run 'npm install -g @angular/cli' to install angular on your machine

4. Run 'npm install' to get all project dependencies

5. Run 'ng serve --o'
```

If you find problems with ng command, try to add npm folder path to your profile 'PATH'
