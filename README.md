# hr

## :warning: Attention to project execution

This project was written in .NET 6.0, so we will need this version to execute.

#### GIT:

git clone <PROJECT_URL>

git submodule init

git submodule update

#### In the dotnet project: 

 1. In <i>Package Manager Console</i>, type: 
 
 ```
 Update-Database -ProjectName hr.Infra
 ```
 
 2. Click on the solution with the right mouse button.
 3. Select the Clean Solution option.
 4. Then click the right mouse button again.
 5. Select the Build option.
 6. Execute the project.

#### To execute angular project

 1. We need to install angular, please type in your command line:
  ```
    angular cli npm install - g @angular/cli.
  ```
 2. Inside the project you can search a file named as 'peoples.service.ts', open and set the urlPeopleAPI variable to your local url of the api.

 3. Then go to the folder "...\nutcache-challenge-HenriqueNMendes\src\hr-FrontEnd" and type:
  ```
    npm install
  ```
 4. After that, type:
  ```
    ng s
  ```