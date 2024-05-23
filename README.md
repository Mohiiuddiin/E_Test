# E_Test

version : net6.0
ORM : Entity Framework Core
Programming/Tools : C# , HTML , Javascript

Back-End / API Development using .NET Core
  ==> To develop this project code first approch is used to create/update database informations.
  ==> Repository Pattern has been used here.
        --> For common featurs access there will be found IBaseRepository(Interface) and BaseRepository(Implementation).It handle all common feature for Adding,Getting List,Find,Update,Etc.There C# generics are used to handle this kind of common activity.
        --> And Others fetures implementation will be found on IPatientRepository/PatientRepository.
        --> In api folder (inside controller folder) all api base controllers will be found.Which contains only apis to communicate with frontend with general controllers.
        --> Dependency Injection has been used. Registrations will be found on Program.cs.    
        --> APIS (PatientApiController,AllergiesController,DiseaseController,NCDController)
        
Front-End / API intregation using .NET Core  
  --> Used HTTPCLIENT of system.net.http to handle web APIs in Controller.
  --> When need All developped APIS has been called on the controller to communicate between frontend and backend.
  --> Used HTML & Javascript with Razor view paged to communicate with controller.
  --> When need All developped APIS has been called on the controller to communicate between frontend and backend.
  --> Used HTTPCLIENT of system.net.http to handle web APIs.
  --> Used javascript to solve the add/delete of List box will contains the Allergies and NCD list
  --> Controller (PatientController)

