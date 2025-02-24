## 🚀 OnSite Management System  

### 🔹 About the Project  
This project demonstrates my **full-stack development skills** by integrating **Angular (Frontend), .NET Core (Backend), and MSSQL (Database)** to build a structured event management system. The system efficiently handles **quotes, events, sub-events, supervisors, laborers, and timesheets**.

I developed this project to reinforce my ability to **quickly architect and implement scalable solutions** using modern web technologies.

---

### 🛠️ Tech Stack  
- **Frontend:** Angular, TypeScript  
- **Backend:** .NET Core 7 (Web API), Entity Framework Core  
- **Database:** MSSQL (SQL Server)  
- **Version Control:** Git, GitHub  

---

### 🎯 Features  
✅ **Event & Sub-Event Management** (Sub-events are tied to events)  
✅ **Role-Based Assignments** (Supervisors & Laborers)  
✅ **Laborer Availability System** (Automatic availability update)  
✅ **Time Tracking** (TimeSheets for events & sub-events)  
✅ **RESTful API** (CRUD Operations via .NET Web API)  
✅ **SQL Database Integration** (EF Core with MSSQL)  
✅ **Modern UI** (Angular frontend with responsive design)  
✅ **Secure API Calls** (CORS enabled for frontend-backend communication)  

---

### 📌 How to Run  

#### 🔹 Prerequisites  
Ensure you have the following installed:  
- **Node.js** & **Angular CLI** (Frontend)  
- **.NET SDK** (Backend)  
- **MSSQL Server & Management Studio** (Database)  

#### 🔹 Setup Steps  

1️⃣ **Clone the Repository**  
```bash
git clone https://github.com/yourusername/OnSite-Management.git
cd OnSite-Management
```

2️⃣ **Setup Backend (.NET API)**  
```bash
cd Backend/OnSite.Backend
dotnet restore
dotnet ef database update  # Apply migrations
dotnet run  # Starts the API at https://localhost:7112
```

3️⃣ **Setup Frontend (Angular App)**  
```bash
cd Frontend
npm install  # Install dependencies
ng serve --open  # Runs the app on http://localhost:4200
```

---

### 📡 API Endpoints  

| Method | Endpoint | Description |
|--------|---------|-------------|
| **GET** | `/api/Event` | Get all events |
| **POST** | `/api/Event` | Create a new event |
| **GET** | `/api/SubEvent` | Get all sub-events |
| **POST** | `/api/SubEvent` | Create a sub-event |
| **GET** | `/api/Supervisor` | Get all supervisors |
| **POST** | `/api/Supervisor` | Add a supervisor |
| **GET** | `/api/Laborer` | Get all laborers |
| **POST** | `/api/Laborer` | Add a laborer |
| **GET** | `/api/Assignment` | Get assignments |
| **POST** | `/api/Assignment` | Assign supervisor/laborer to an event/sub-event |
| **GET** | `/api/TimeSheet` | Get time tracking records |
| **POST** | `/api/TimeSheet` | Add time tracking record |

✅ **Swagger UI Available:** Navigate to `https://localhost:7112/swagger` to test API endpoints interactively.  

---

### 📞 Contact 
**📧 Email:** rudram.vyas@gmail.com
**💼 LinkedIn:** linkedin.com/in/rudram-vyas/  
