<!-- Librerias de EFCore -->
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql

<!-- Descargar imagen de mysql -->
docker pull mysql:8.0

<!-- Crear el el contenedor con la bd -->
docker run --name servicios_atemtia -e MYSQL_ROOT_PASSWORD=RubenyPlo2025 -p 3307:3306 -d mysql:8.0  