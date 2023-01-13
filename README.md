# Used Commands on project

## Used NugetPackages

- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.VisualStudio.Web.CodeGeneration.Design

## Used Commands to Create Project

- dotnet new solution
- dotnet new mvc -o ProjectName.Client
- dotnet new classlib -o ProjectName.Bussiness
- dotnet new classlib -o ProjectName.Common
- dotnet new classlib -o ProjectName.Data

### Add solutions to project

- dotnet sln add ProjectName.Client/ProjectName.Client.csproj
                 ProjectName.Bussiness/ProjectName.Bussiness.csproj
                 ProjectName.Common/ProjectName.Common.csproj
                 ProjectName.Data/ProjectName.Data.csproj

### Link classLib to projects

- dotnet add ProjectName.Client/ProjectName.Client.csproj reference
                 ProjectName.Bussiness/ProjectName.Bussiness.csproj
                 ProjectName.Common/ProjectName.Common.csproj
                 ProjectName.Data/ProjectName.Data.csproj

- dotnet add ProjectName.Bussiness/ProjectName.Bussiness.csproj
                 ProjectName.Common/ProjectName.Common.csproj
                 ProjectName.Data/ProjectName.Data.csproj

- dotnet add ProjectName.Data/ProjectName.Data.csproj
                 ProjectName.Common/ProjectName.Common.csproj

## Run Project

- dotnet watch run --project .\PersonalProject.Client\  

## Scaffold Database

- dotnet ef dbcontext scaffold "Data Source=BRAULIOJR\\SQLEXPRESS;Initial Catalog=medical;User Id=sa;Password=Pirata99*;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -o "Models" --force

## Git Commands

git init
dotnet new gitignore
git add .
git commit -m "First Commit"
git remote add origin <https://github.com/BaloJr99/PersonalProject.git>
git push -u origin main
git branch
git checkout -b newBranchName
git switch branchName
git branch --delete  branchName
git merge mergeBranch
