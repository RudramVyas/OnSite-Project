# 🚀 OnSite Management System  

### 🔹 About the Project  
This project demonstrates my **full-stack development skills** by integrating **Angular (Frontend), .NET Core (Backend), and MSSQL (Database)** to build a structured event management system.  

The system efficiently handles **quotes, events, sub-events, supervisors, laborers, and timesheets** while enforcing role-based constraints.  

I developed this project to reinforce my ability to **quickly architect and implement scalable solutions** using modern web technologies.  

---

## 🛠️ Tech Stack  
- **Frontend:** Angular, TypeScript  
- **Backend:** .NET Core (Web API), Entity Framework Core  
- **Database:** MSSQL (SQL Server)  
- **Version Control:** Git, GitHub  

---

## 🎯 Features  
✅ **Event & Sub-Event Management** (Sub-events tied to events)  
✅ **Role-Based Assignments** (L1/L2 Supervisors & Laborers)  
✅ **Laborer Availability System** (Auto-updates availability)  
✅ **Time Tracking** (TimeSheets for supervisors & laborers)  
✅ **RESTful API** (Full CRUD Operations via .NET Web API)  
✅ **SQL Database Integration** (EF Core + MSSQL)  
✅ **Modern UI** (Angular frontend with responsive design)  
✅ **Secure API Calls** (CORS enabled for frontend-backend communication)  
✅ **Swagger API Documentation** (Test endpoints interactively)  

---

## 📌 How to Run  

### 🔹 Prerequisites  
Ensure you have the following installed:  
- **Node.js** & **Angular CLI** (Frontend)  
- **.NET SDK** (Backend)  
- **MSSQL Server & Management Studio** (Database)  

### 🔹 Setup Instructions  

#### **1️⃣ Clone the Repository**  
```bash
git clone https://github.com/RudramVyas/OnSite-Project.git
cd OnSite-Project
```

#### **2️⃣ Setup Backend (.NET API)**  
```bash
cd Backend/OnSite.Backend
dotnet restore
dotnet ef database update  # Apply migrations
dotnet run  # Starts the API at https://localhost:7112
```

#### **3️⃣ Setup Frontend (Angular App)**  
```bash
cd Frontend
npm install  # Install dependencies
ng serve --open  # Runs the app on http://localhost:4200
```

---

## 📡 API Endpoints  

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

## 🎯 What This Demonstrates  
This project was **built in just two days** to showcase my ability to:  
✅ Quickly architect & develop a **full-stack web application**  
✅ Implement **role-based workflows** for real-world event management  
✅ Handle **database design, API development, and frontend integration**  
✅ Debug and optimize using **AI-powered assistance** for efficiency  

I had planned to deploy the project live, but given the time constraints, I focused on delivering a **fully functional system** instead.  

---

## 📞 Contact  
📧 **Email:** rudram.vyas@gmail.com  
💼 **LinkedIn:** [linkedin.com/in/rudram-vyas](https://linkedin.com/in/rudram-vyas/)  
📂 **GitHub Repository:** [OnSite-Project](https://github.com/RudramVyas/OnSite-Project)  
