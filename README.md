# Game Shop API Documentation

## Table of Contents
1. [Project Overview](#project-overview)
2. [Technologies Used](#technologies-used)
3. [Database Schema](#database-schema)
4. [API Overview](#api-overview)
5. [Application Usage](#application-usage)
6. [Conclusions and Contributions](#conclusions-and-contributions)
7. [GitHub Link](#github-link)

## Project Overview
The project aims to develop a comprehensive system for managing an online video game store. It allows users to view available video games organized into categories and produced by various companies. The system also provides advanced functionalities for administrators, who can add, modify, and delete data about games, categories, companies, and users.

### Problems Solved:
1. **Centralization of Information:**
   - All data related to games, categories, and companies are stored in a centralized database, facilitating management and quick access to information.
2. **Game Classification:**
   - Games are organized into specific categories, helping users find games of interest more easily.
3. **Company Management:**
   - The system allows management of information about game-producing companies, facilitating the link between games and their producers.
4. **User and Role Management:**
   - Clear separation between normal users and administrators ensures that only users with appropriate rights can modify system data.
5. **User-Friendly Interface:**
   - Normal users can view all available games, along with details about categories and companies, in an easy-to-navigate interface.
6. **Advanced Control for Administrators:**
   - Administrators have complete control over adding, modifying, and deleting data, ensuring the accuracy and timeliness of information in the database.

## Technologies Used
1. ASP.NET Core
2. Entity Framework Core
3. SQL Server
4. Swagger/OpenAPI
5. Authentication and Authorization
6. Dependency Injection (DI)
7. Middleware

## Database Schema

![image](https://github.com/Gabi-Plosnita/GameShopAPI/assets/118562250/9717c300-646c-4f79-9a26-9d9f19941cfd)

### Tables and Relationships:
1. **Users Table:**
   - **Columns:**
     - UserId: Unique user ID (primary key)
     - Username: Username
     - Password: User's password
     - Email: User's email
     - RoleId: User's role ID (foreign key linked to Roles table)
   - **Relationships:**
     - RoleId is a foreign key linking to RoleId in the Roles table.

2. **Roles Table:**
   - **Columns:**
     - RoleId: Unique role ID (primary key)
     - Name: Role name
   - **Relationships:**
     - RoleId is referred by RoleId in the Users table.

3. **Games Table:**
   - **Columns:**
     - GameId: Unique game ID (primary key)
     - Name: Game name
     - Price: Game price
     - GameCompanyId: ID of the company that created the game (foreign key linked to GameCompanies table)
     - CategoryId: Game category ID (foreign key linked to Categories table)
   - **Relationships:**
     - GameCompanyId is a foreign key linking to GameCompanyId in the GameCompanies table.
     - CategoryId is a foreign key linking to CategoryId in the Categories table.

4. **GameCompanies Table:**
   - **Columns:**
     - GameCompanyId: Unique game company ID (primary key)
     - Name: Company name
     - Email: Company email
   - **Relationships:**
     - GameCompanyId is referred by GameCompanyId in the Games table.

5. **Categories Table:**
   - **Columns:**
     - CategoryId: Unique category ID (primary key)
     - Name: Category name
   - **Relationships:**
     - CategoryId is referred by CategoryId in the Games table.

### Table Relationships:
- **Users and Roles** are linked by RoleId, where a user can have a specific role defined in the Roles table.
- **Games** is linked to **GameCompanies** by GameCompanyId, indicating which company created each game.
- **Games** is linked to **Categories** by CategoryId, indicating the category each game belongs to.

## API Overview


![image](https://github.com/Gabi-Plosnita/GameShopAPI/assets/118562250/48b19310-9b42-4b4d-b386-afa34a65faab)

![image](https://github.com/Gabi-Plosnita/GameShopAPI/assets/118562250/f81560de-2766-40f3-a5f1-7cf43677a8ac)

![image](https://github.com/Gabi-Plosnita/GameShopAPI/assets/118562250/f0668215-70c9-4c9e-aef6-dbd07afd527d)


### CRUD Operations:
The API for managing the video game store contains several controllers, each having endpoints to perform CRUD (Create, Read, Update, Delete) operations on various resources. Here is a brief description of each:

#### CategoriesController
- **GET /api/Categories:** Returns all categories. Accessible by anyone.
- **GET /api/Categories/{id}:** Returns a category by ID. Admin only.
- **POST /api/Categories:** Creates a new category. Admin only.
- **PUT /api/Categories/{id}:** Updates a category by ID. Admin only.
- **DELETE /api/Categories/{id}:** Deletes a category by ID. Admin only.

#### GameCompaniesController
- **GET /api/GameCompanies:** Returns all game companies. Accessible by anyone.
- **GET /api/GameCompanies/{id}:** Returns a game company by ID. Admin only.
- **POST /api/GameCompanies:** Creates a new game company. Admin only.
- **PUT /api/GameCompanies/{id}:** Updates a game company by ID. Admin only.
- **DELETE /api/GameCompanies/{id}:** Deletes a game company by ID. Admin only.

#### GamesController
- **GET /api/Games:** Returns all games. Accessible by anyone.
- **GET /api/Games/{id}:** Returns a game by ID. Admin only.
- **POST /api/Games:** Creates a new game. Admin only.
- **PUT /api/Games/{id}:** Updates a game by ID. Admin only.
- **DELETE /api/Games/{id}:** Deletes a game by ID. Admin only.

#### RolesController
- **GET /api/Roles:** Returns all roles. Admin only.
- **GET /api/Roles/{id}:** Returns a role by ID. Admin only.
- **POST /api/Roles:** Creates a new role. Admin only.
- **PUT /api/Roles/{id}:** Updates a role by ID. Admin only.
- **DELETE /api/Roles/{id}:** Deletes a role by ID. Admin only.

#### UserController
- **POST /register:** Registers a new user. Accessible by anyone.
- **POST /login:** Logs in a user. Accessible by anyone.
- **GET /api/Users:** Returns all users. Admin only.
- **GET /api/Users/{id}:** Returns a user by ID. Admin only.
- **PUT /api/Users/{id}:** Updates a user by ID. Admin only.
- **DELETE /api/Users/{id}:** Deletes a user by ID. Admin only.

## Application Usage

### User Types
The GameShop application has two main user types:
1. **Admin:** Users with the Admin role have full access to all application functionalities.
2. **User:** Normal users (authenticated or unauthenticated) have limited access, mainly to public functionalities such as viewing lists of categories, game companies, and games.

### Authentication and Authorization
**Authentication:**
- Users can register and log in using the `/register` and `/login` endpoints.
- Upon authentication, users receive a JWT token to be used for authorization when accessing protected endpoints.

**Authorization:**
- Endpoints are protected by `[Authorize]` attributes, with access limited based on the user's role.
- Certain endpoints are accessible only to authenticated users with the Admin role, while others are accessible to all users, including unauthenticated ones.

### Role-Based Functionalities:

**User (Unauthenticated or Authenticated):**
- **View Categories:** 
  - **Endpoint:** GET /api/Categories
  - **Description:** Anyone can view the complete list of game categories.
- **View Game Companies:** 
  - **Endpoint:** GET /api/GameCompanies
  - **Description:** Anyone can view the complete list of game companies.
- **View Games:** 
  - **Endpoint:** GET /api/Games
  - **Description:** Anyone can view the complete list of games.
- **Register:** 
  - **Endpoint:** POST /register
  - **Description:** Allows users to register in the application.
- **Login:** 
  - **Endpoint:** POST /login
  - **Description:** Allows users to log in and receive a JWT token.

**Admin (Authenticated):**
- **Manage Categories:**
  - View specific category: GET /api/Categories/{id}
  - Create category: POST /api/Categories
  - Update category: PUT /api/Categories/{id}
  - Delete category: DELETE /api/Categories/{id}
- **Manage Game Companies:**
  - View specific company: GET /api/GameCompanies/{id}
  - Create company: POST /api/GameCompanies
  - Update company: PUT /api/GameCompanies/{id}
  - Delete company: DELETE /api/GameCompanies/{id}
- **Manage Games:**
  - View specific game: GET /api/Games/{id}
  - Create game: POST /api/Games
  - Update game: PUT /api/Games/{id}
  - Delete game: DELETE /api/Games/{id}
- **Manage Roles:**
  - View roles: GET /api/Roles
  - View specific role: GET /api/Roles/{id}
  - Create role: POST /api/Roles
  - Update role: PUT /api/Roles/{id}
  - Delete role: DELETE /api/Roles/{id}
- **Manage Users:**
  - View users: GET /api/Users
  - View specific user: GET /api/Users/{id}
  - Update user: PUT /api/Users/{id}
  - Delete user: DELETE /api/Users/{id}

## Conclusions and Contributions
The GameShop API was developed as part of a comprehensive system to manage an online video game store. The project emphasizes efficient information management, user-friendly interfaces, and robust control mechanisms for administrators. The main contributions of this project include:
- Streamlined game and company management.
- Enhanced user experience through categorized game listings.
- Secure authentication and role-based authorization.
- Comprehensive documentation for ease of use and further development.

## GitHub Link
The source code for the GameShop API is available on GitHub at the following link:
[GitHub Repository](https://github.com/your-repository-link)
