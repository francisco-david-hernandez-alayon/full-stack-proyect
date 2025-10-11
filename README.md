# Proyecto. Arquitectura Hexagonal
Autor: Francisco David Hernández Alayón


## Configuración backend


### crear carpeta backend y entrar
```
mkdir backend && cd backend
```

### crear solución
```
dotnet new sln -n CarApp
```

### crear proyectos
```
dotnet new classlib -n CarApp.Domain
dotnet new classlib -n CarApp.Application
dotnet new classlib -n CarApp.Infrastructure
dotnet new webapi -n CarApp.Api
```

### agregar referencias entre proyectos
```
dotnet add CarApp.Application reference CarApp.Domain
dotnet add CarApp.Infrastructure reference CarApp.Domain
dotnet add CarApp.Api reference CarApp.Application
dotnet add CarApp.Api reference CarApp.Infrastructure
```

### agregar proyectos a la solución
```
dotnet sln add CarApp.Domain CarApp.Application CarApp.Infrastructure CarApp.Api
```

# instalar paquete necesario
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


# crear base de datos
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
```
cd frontend/carapp-frontend
npm start
```
