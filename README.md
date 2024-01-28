# DotnetAngularWebProject
A template of a web project using a .NET, Angular, and SQLite tech stack that is deployed to Azure App Services using Docker and CircleCI.

This is just an example project that contains the following:
- A frontend
- A backend
- A database
- A CI/CD pipeline

It is fully functional. The purpose is for anyone to have a starting point that can be used to get up and running quickly and save time when starting a new project.

## Technologies Used
### .NET
.NET is the free, open-source, cross-platform framework for building modern apps and powerful cloud services. Languages that are included in .NET are C#, Visual Basic, and F#. This template uses C# for the backend. More information about .NET can be found on [dotnet.microsoft.com](https://dotnet.microsoft.com/en-us/).

### Angular
A popular web development framework built on top of Node. Used for this template's frontend. For more information, please see [angular.io](https://angular.io/).

### SQLite
SQLite is a C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine. It is a very light-weight Database Management System (DBMS) that stores the entire DB in a single file, meaning it can run from anywhere that has a file system. More information can be found on [www.sqlite.org](https://www.sqlite.org/index.html).

SQLite is only meant to be used during development when a more "production-ready" DBMS is not yet available. It should be replaced in your project with another database solution of your choice before you publish your app to users.

### Microsoft Azure
Microsoft's cloud service provider that provides compute resources on-demand and uses a "pay-as-you-go" model where you only pay for the resources you use when you use them. There is no commitment and you are free to cancel at any time. There is a free trial and they offer a number of always free resources and services as long as your usage is low. More information can be found on [azure.microsoft.com](https://azure.microsoft.com/en-us/)

The Azure deploy target can be replaced if you are deploying your app to a different platform.

### Docker
Docker is a popular container engine. A container engine is a tool that allows you to build and install your app inside a container where it is completely isolated from all other apps on your machine. It is almost like a VM but without the OS. Containers themselves only have a limited file system from an OS (you can have Linux and Windows containers) but they run on top of the container engine.

Docker, and similar container engines, are used to create images that have your app already installed and configured. Those images can then be used to spin-up any number of identical containers that all run your app and are configured in the exact same way. Containerization is crucial to deploying your app to the cloud and allowing your app to automatically scale to meet demand.

For more information on Docker specifically, please see their website at [www.docker.com](https://www.docker.com/).

### CircleCI
CircleCI is a continuous integration and delivery platform that can be used to implement DevOps practices. CircleCI offers industry-leading speed, security, and flexibility for building anything fast. It is used to build the .NET Angular Docker image, run automated tests (for quality assurance), perform code scans (for security and best practices), and deploy it to Azure (or whatever platform you so choose). More information on CircleCI can be found on [circleci.com](https://circleci.com/).
