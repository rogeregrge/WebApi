## README: C#/.NET CRUD API (Authors & Books)

### Project Overview

This project is a **RESTful API** developed using **C# / ASP.NET Core Web API** that implements a **CRUD (Create, Read, Update, Delete)** system for managing **Authors** and **Books**. It includes a crucial **JWT (JSON Web Token) Authentication** module to secure all primary API endpoints.

---

### Technologies and Tools

| Category | Technology / Tool |
| :--- | :--- |
| **Platform** | C# / .NET [8.0] |
| **Framework** | ASP.NET Core Web API |
| **Database** | Entity Framework Core with **[SQL Server / InMemory Database]** |
| **Authentication** | ASP.NET Core Identity & JWT Bearer Token |
| **Documentation** | Swagger / OpenAPI |
| **Deployment** | Azure App Service (or Render/Railway) |

---

###Core Functionalities

#### 1. Authentication Module (JWT)

| Route | Method | Description |
| :--- | :--- | :--- |
| `/login` | `POST` | Authenticates the user and returns a valid **JWT Bearer Token**. |
| `/register` | `POST` | Creates a new user in the system. |

#### 2. Authors and Books CRUD

| Recurso | Método | Descrição | Requer Autenticação |
| :--- | :--- | :--- | :--- |
| `/api/authors` | `GET` | Lists all authors. | **Yes** |
| `/api/authors/{id}` | `POST` | Creates a new author. | **Yes** |
| `/api/books` | `PUT` | Updates an existing book. | **Yes** |
| `/api/books/{id}` | `DELETE` | Removes a book. | **Yes** |

---

### 🔗 How to Access and Test the API

The API is deployed and ready for testing directly via the Swagger UI interface.

1.  **Source Code:**
    * **GitHub Repository:** `[[INSERT YOUR GITHUB REPOSITORY LINK HERE]](https://github.com/rogeregrge/WebApi)`

2.  **Documentation and Testing (Swagger UI):**
    * **Deployed Link:** `[[INSERT YOUR AZURE/RENDER/RAILWAY SWAGGER LINK HERE]](https://webapiavanade-b9fedsegdmc5dnd6.canadaeast-01.azurewebsites.net/swagger/index.html)`

#### 📝 Recommended Test Sequence:

To successfully test the secured endpoints:

1.  **Register:** Use the `/register` route (via Swagger) to create a new user.
2.  **Login:** Use the `/login` route with the new credentials to obtain the **JWT Token**.
3.  **Authorize in Swagger:** Paste the retrieved token into the **"Authorize"** field in the Swagger UI.
4.  **Test CRUD:** Execute the protected endpoints (e.g., POST to create a new Author) to verify authorization.

---

### How to Run Locally

For who prefers to run the API locally:

1.  **Clone the Repository:**
    ```bash
    git clone [[YOUR REPOSITORY LINK]](https://github.com/rogeregrge/WebApi)
    cd WebApi
    ```
2.  **Restore Dependencies:**
    ```bash
    dotnet restore
    ```
3.  **Run the Application:**
    ```bash
    dotnet run
    ```
4.  Access Documentation: `http://localhost:[Port]/swagger/index.html` (The default port is usually 5000 or 7000).

---

### 🧠 Architectural Decisions and Notes

* **Data Persistence:** The core CRUD data utilizes **Entity Framework Core** with **SQL Server / InMemory Database]**.
* **Authorization Strategy:** Authorization rules are configured to load **in memory** (In-Memory Authorization) to maximize performance during the authentication check. For a production environment, this data would be migrated to the persistent **SQL Database** to allow for dynamic role management and persistence across server restarts, which is the industry standard. This current setup prioritizes technical speed and demonstration of authorization capability.

---
