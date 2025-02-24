## 🚀 OnSite Management System  

### 🔹 About the Project  
This project demonstrates my **full-stack development skills** by integrating **Angular (Frontend), .NET Core (Backend), and MSSQL (Database)** to build a structured event management system. The system efficiently handles **events, sub-events, supervisors, laborers, and timesheets** while ensuring proper role-based assignments.

I developed this project within **two days** to reinforce my ability to **quickly architect and implement scalable solutions** using modern web technologies.

---

### 🛠️ Tech Stack  
- **Frontend:** Angular 16, TypeScript, Bootstrap  
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

### 🔥 Why This Project?  
After an **interview one week ago**, I wanted to **demonstrate my expertise** in **Angular, .NET, and MSSQL** with a complete **end-to-end** solution. This project is built **within 2 days** to showcase:  
- **Quick development & problem-solving skills**  
- **Strong understanding of full-stack architecture**  
- **Ability to deliver real-world projects under time constraints**  

---

### 📩 Final Follow-up  
This project reflects my **dedication, technical proficiency, and ability to execute efficiently**. Looking forward to the opportunity to discuss this further.  

**📌 GitHub Repository:** [Your Repository Link]  

---

### 📞 Contact  
**📧 Email:** your.email@example.com  
**💼 LinkedIn:** [Your LinkedIn Profile]  

🚀 **Built with passion & expertise in 48 hours!**  

---

This README will highlight your **technical skills, project execution speed, and ability to build real-world solutions**—perfect for impressing the interviewer in your **final follow-up email**. 🚀
