install-dotnet-ef-tool:
	dotnet tool install --global dotnet-ef

install-packages:
	dotnet add package Microsoft.EntityFrameworkCore.SqlServer
	dotnet add package Microsoft.EntityFrameworkCore.Tools

create-migration:
	dotnet ef migrations add InitialCreate
update-migration:
	dotnet ef database update