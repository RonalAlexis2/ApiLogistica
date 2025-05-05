# 🚚 Proyecto de Logística - Gestión de Clientes y Productos

Este proyecto es una solución completa para la gestión de logística terrestre y marítima. Incluye un backend desarrollado con ASP.NET Core y un frontend en React.

## 📁 Estructura del Proyecto

```
/logistica-app
├── backend/       --> API REST con ASP.NET Core
├── frontend/      --> Aplicación React
├── .gitignore
└── README.md
```

---

## ⚙️ Backend - ASP.NET Core (.NET 8)

### 📦 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### 🚀 Instrucciones

1. Navega al directorio del backend:

   ```bash
   cd backend/LogisticaApi
   ```

2. Restaura y compila el proyecto:

   ```bash
   dotnet restore
   dotnet build
   ```

3. Ejecuta las migraciones y actualiza la base de datos (si usas Entity Framework Core):

   ```bash
   dotnet ef database update
   ```

4. Corre la API:

   ```bash
   dotnet run
   ```

5. La API estará disponible en `https://localhost:7005`.

---

## 🌐 Frontend - React

### 📦 Requisitos

- [Node.js y npm](https://nodejs.org/)

### 🚀 Instrucciones

1. Navega al directorio del frontend:

   ```bash
   cd frontend
   ```

2. Instala las dependencias:

   ```bash
   npm install
   ```

3. Corre la aplicación:

   ```bash
   npm start
   ```

4. La app estará disponible en `http://localhost:3000`.

---

## 🔐 Autenticación

Este proyecto usa un token JWT de prueba para autorización. Por ahora, se almacena en `localStorage` de forma manual:

```js
localStorage.setItem("token", "mipersonalToken123");
```

> ⚠️ En producción se debe implementar un sistema de login seguro.

---

## 🧑‍💻 Autor

Desarrollado por Ronal Vargas.

---

## ✅ Estado del Proyecto

✅ Clientes  
✅ Productos  
🛠️ En desarrollo: Puertos, Bodegas, Envíos

---

## 📄 Licencia

MIT
