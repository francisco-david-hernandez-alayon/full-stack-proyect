# Proyecto. Arquitectura Hexagonal
Autor: Francisco David Hernández Alayón


## CONFIGURACIÓN BACKEND


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
mkdir GameApp.Adapter; cd GameApp.Adapter
dotnet new classlib -n GameApp.Adapter.Infrastructure
dotnet new webapi -n GameApp.Adapter.Api
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

# Host -> Api (para los controladores)
dotnet add GameApp.Host/GameApp.Host.csproj reference GameApp.Adapter/GameApp.Api/GameApp.Api.csproj
# Host -> Infrastructure (para DbContext y repositorios)
dotnet add GameApp.Host/GameApp.Host.csproj reference GameApp.Adapter/GameApp.Infrastructure/GameApp.Infrastructure.csproj
# Host -> Application (para servicios y casos de uso)
dotnet add GameApp.Host/GameApp.Host.csproj reference GameApp.Application/GameApp.Application.csproj
```

### Agregar proyectos a la solución
```
dotnet sln GameApp.sln add GameApp.Domain/GameApp.Domain.csproj
dotnet sln GameApp.sln add GameApp.Application/GameApp.Application.csproj
dotnet sln GameApp.sln add GameApp.Adapter/GameApp.Api/GameApp.Api.csproj
dotnet sln GameApp.sln add GameApp.Adapter/GameApp.Infrastructure/GameApp.Infrastructure.csproj
dotnet sln GameApp.sln add GameApp.Host/GameApp.Host.csproj
```

### Instalar paquetes necesarios
```
cd GameApp.Adapter.Infrastructure
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package MongoDB.Driver

cd GameApp.Adapter.Api
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Configurar base de datos mongodb
```
curl -fsSL https://pgp.mongodb.com/server-7.0.asc | sudo gpg -o /usr/share/keyrings/mongodb-server-7.0.gpg --dearmor
echo "deb [signed-by=/usr/share/keyrings/mongodb-server-7.0.gpg] https://repo.mongodb.org/apt/ubuntu jammy/mongodb-org/7.0 multiverse" | sudo tee /etc/apt/sources.list.d/mongodb-org-7.0.list
sudo apt update
sudo apt install -y mongodb-org
sudo systemctl start mongod
sudo systemctl enable mongod


```



## CONFIGURACIÓN FRONTEND
```
cd ../frontend
npx create-react-app gameapp-frontend
cd gameapp-frontend
npm install axios
```


## EJECUTAR LOCALMENTE

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


