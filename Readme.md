# Products API

A RESTful API built with **ASP.NET Core 8**, **Entity Framework**, and **AutoMapper** for managing products. The project is containerized using **Docker** and **Docker Compose** to ensure a consistent development and production environment.

## Features

- ASP.NET Core 8 for the API backend  
- Entity Framework Core for database interactions with MySQL  
- AutoMapper for object-to-object mapping  
- Dockerized for easy setup and deployment with Docker Compose

## Prerequisites

- Docker  
- Docker Compose  
- Visual Studio or any preferred IDE  
- .NET 8 SDK (optional if you're building from source)

## Getting Started

### Clone the repository

```bash
git clone https://github.com/gabrielvgarcia/products-api.git
cd products-api
```

### Set up Docker and MySQL

```bash
docker compose up --build
```

This will:

- Build the API image  
- Create and start the MySQL container  
- Expose the API on port `5000` and MySQL on port `3306`

## Configuration

The connection string expected by the application:

```json
"ConnectionStrings": {
  "Default": "server=mysql-productsdb;port=3306;database=productsdb;user=root;password=root"
}
```

You can edit the `docker-compose.yml` or `appsettings.json` to change any values.

## Running the Application

Access the API at:

```
http://localhost:5000
```

Swagger UI is available at:

```
http://localhost:5000/swagger
```

## Database Migrations

To create or update the database schema using EF Core:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Ensure the connection string is correctly set in `appsettings.json`.

## Testing

Example requests:

- **Get all products**  
  `GET http://localhost:5000/api/products`

- **Create a new product**  
  `POST http://localhost:5000/api/products`

  Request body:
  ```json
  {
    "name": "New Product",
    "price": 19.99
  }
  ```

## Technologies Used

- ASP.NET Core 8  
- Entity Framework Core  
- AutoMapper  
- MySQL  
- Docker & Docker Compose

## Contributing

1. Fork the repository  
2. Create a new branch (`git checkout -b feature-name`)  
3. Commit your changes (`git commit -am 'Add new feature'`)  
4. Push to the branch (`git push origin feature-name`)  
5. Open a pull request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Docker  
- Microsoft (ASP.NET Core, EF Core)  
- MySQL  
- Swagger
