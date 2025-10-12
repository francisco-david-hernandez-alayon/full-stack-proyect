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
dotnet add GameApp.Application reference GameApp.Domain
dotnet add GameApp.Infrastructure reference GameApp.Domain
dotnet add GameApp.Api reference GameApp.Application
dotnet add GameApp.Api reference GameApp.Infrastructure
```

### Agregar proyectos a la solución
```
dotnet sln add GameApp.Domain GameApp.Application GameApp.Infrastructure GameApp.Api
```

### Instalar paquete necesario
```
cd GameApp.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

cd ../GameApp.Api
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
cd backend/GameApp.Api
dotnet run --urls "URL API"
```

### Frontend
Crear un .env con REACT_APP_BACKEND_API_URL="URL DE LA API DEL BACKEND"
```
cd frontend/gameapp-frontend
npm start
```
