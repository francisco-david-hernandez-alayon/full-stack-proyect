# Proyecto. Arquitectura Hexagonal
Autor: Francisco David Hernández Alayón

El juego es una aventura por turnos basada en escenarios, donde el jugador debe avanzar a través de distintas escenas hasta llegar al final, manteniéndose con vida y gestionando correctamente sus recursos. Cada vez que se avanza a una nueva escena, el personaje pierde comida, por lo que es fundamental conseguir y usar objetos para alimentarse, curarse, combatir enemigos o comerciar con mercaderes.

A lo largo de la partida, el jugador explorará diferentes biomas, cada uno con escenas, enemigos y recompensas únicas que se generarán de forma aleatoria. Existen varios tipos de escenas, como combates, comercio, obtención de objetos o escenas donde no ocurre nada. El combate se basa en estadísticas de velocidad y daño, y cada personaje cuenta con una habilidad especial que se desbloquea al cumplir ciertas condiciones. La toma de decisiones, la gestión del inventario y la adaptación al entorno son clave para sobrevivir y completar el juego.


## CONFIGURACIÓN BACK-END: C# y mongoDb

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

<br>

## CONFIGURACIÓN FRONT-END: REACT, JS y Tailwind
### Crear proyecto con vite e instalar dependencias
```
cd ../frontend
npm create vite@latest
npm install uuid
npm install axios
npm install react-router-dom
npm install --save-dev @types/react-router-dom
```

### Añadir tailwind, daisyui y Lucide
1. Instalar Tailwind CSS
```
npm install -D @tailwindcss/vite tailwindcss
```
2. Intalar daisiui
```
npm install daisyui
```
3. Intalar Lucide
```
npm install lucide-react
```
4. Añadir Tailwind CSS al vite.config.js
5. Eliminar todo en index.css y añadir ```@import "tailwindcss"; y @plugin "daisyui";```



<br>

## EJECUCIÓN LOCAL

### Backend
```
cd backend/GameApp.Host
dotnet run --urls "URL API"
```

### Frontend
Crear un .env con VITE_BACKEND_API_URL="URL DE LA API DEL BACKEND"

```
cd frontend/gameapp-frontend
npm run dev
```

<br>

## Recursos
* [Instalar tailwind](https://tailwindcss.com/docs/installation/using-vite)

* [Daisiui](https://daisyui.com/)

* [Lucide](https://lucide.dev/)

* [Inicio rápido react](https://es.react.dev/learn)

* [Iconos FlatIcon](https://www.flaticon.es/)

 