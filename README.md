# Proyecto. Arquitectura Hexagonal
Autor: Francisco David Hernández Alayón


## Configuración backend


### Crear carpeta backend y entrar
```
mkdir backend && cd backend
```

### Crear solución
```
dotnet new sln -n CarApp
```

### Crear proyectos
```
dotnet new classlib -n CarApp.Domain
dotnet new classlib -n CarApp.Application
dotnet new classlib -n CarApp.Infrastructure
dotnet new webapi -n CarApp.Api
```

### Agregar referencias entre proyectos
```
dotnet add CarApp.Application reference CarApp.Domain
dotnet add CarApp.Infrastructure reference CarApp.Domain
dotnet add CarApp.Api reference CarApp.Application
dotnet add CarApp.Api reference CarApp.Infrastructure
```

### Agregar proyectos a la solución
```
dotnet sln add CarApp.Domain CarApp.Application CarApp.Infrastructure CarApp.Api
```

### Instalar paquete necesario
```
cd CarApp.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design

cd ../CarApp.Api
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate -p ../CarApp.Infrastructure -s .
dotnet ef database update -p ../CarApp.Infrastructure -s .
```


### Crear base de datos
```
dotnet tool install --global dotnet-ef
cd CarApp.Api
dotnet ef migrations add InitialCreate -p ../CarApp.Infrastructure -s .
dotnet ef database update -p ../CarApp.Infrastructure -s .
```



## Configuración frontend
```
cd ../frontend
npx create-react-app carapp-frontend
cd carapp-frontend
npm install axios

```


## Ejecutar localmente

### Backend
```
cd backend/CarApp.Api
dotnet run --urls "URL API"
```

### Frontend
Crear un .env con REACT_APP_BACKEND_API_URL="URL DE LA API DEL BACKEND"
```
cd frontend/carapp-frontend
npm start
```
