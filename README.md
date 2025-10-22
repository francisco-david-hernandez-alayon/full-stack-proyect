# Proyecto. Arquitectura Hexagonal
Autor: Francisco David Hernández Alayón


## Configuración backend


### Crear carpeta backend y entrar
```
mkdir backend && cd backend
```

### Crear solución
```
dotnet new sln -n GameApp
```

### Crear proyectos
```
dotnet new classlib -n GameApp.Domain
dotnet new classlib -n GameApp.Application
dotnet new classlib -n GameApp.Infrastructure
dotnet new webapi -n GameApp.Api
```

### Agregar referencias entre proyectos
```
# Application -> Domain
dotnet add GameApp.Application/GameApp.Application.csproj reference GameApp.Domain/GameApp.Domain.csproj

# Infrastructure -> Domain
dotnet add GameApp.Adapter/GameApp.Infrastructure/GameApp.Infrastructure.csproj reference GameApp.Domain/GameApp.Domain.csproj
# Infrastructure -> Application
dotnet add GameApp.Adapter/GameApp.Infrastructure/GameApp.Infrastructure.csproj reference GameApp.Application/GameApp.Application.csproj

# Api -> Domain
dotnet add GameApp.Adapter/GameApp.Api/GameApp.Api.csproj reference GameApp.Domain/GameApp.Domain.csproj
# Api -> Application
dotnet add GameApp.Adapter/GameApp.Api/GameApp.Api.csproj reference GameApp.Application/GameApp.Application.csproj

# Host -> Api (para descubrir los controladores)
dotnet add GameApp.Host/GameApp.Host.csproj reference GameApp.Adapter/GameApp.Api/GameApp.Api.csproj

# Host -> Infrastructure (para DbContext y repositorios)
dotnet add GameApp.Host/GameApp.Host.csproj reference GameApp.Adapter/GameApp.Infrastructure/GameApp.Infrastructure.csproj

# Host -> Application (para servicios y casos de uso)
dotnet add GameApp.Host/GameApp.Host.csproj reference GameApp.Application/GameApp.Application.csproj



```

### Agregar proyectos a la solución
```
dotnet sln add GameApp.Domain GameApp.Application GameApp.Infrastructure GameApp.Api GameApp.Host
```

### Instalar paquete necesario
```
cd GameApp.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

cd GameApp.Api
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate -p ../GameApp.Infrastructure -s .
dotnet ef database update -p ../GameApp.Infrastructure -s .
```


### Crear base de datos
```
dotnet tool install --global dotnet-ef
cd GameApp.Api
dotnet ef migrations add InitialCreate -p ../GameApp.Infrastructure -s .
dotnet ef database update -p ../GameApp.Infrastructure -s .
```



## Configuración frontend
```
cd ../frontend
npx create-react-app gameapp-frontend
cd gameapp-frontend
npm install axios

```


## Ejecutar localmente

### Backend
```
cd backend/GameApp.Host
dotnet run --urls "URL API"
```

### Frontend
Crear un .env con REACT_APP_BACKEND_API_URL="URL DE LA API DEL BACKEND"
```
cd frontend/gameapp-frontend
npm start
```


# Comprobar base de datos SQL
```
sudo apt install sqlite3
```
cd backend/GameApp.Host

sqlite3 gameapp.db
```
SELECT * FROM Games;
.exit
```

