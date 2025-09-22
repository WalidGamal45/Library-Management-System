# 📚 Library Management System

A Library Management System built with **.NET 8 Web API** and **Entity Framework Core**.  
The project demonstrates database design, RESTful API implementation, and role-based access control for managing books, members, and borrowing transactions.  

---
📌 ERD Diagram:
![ERD Diagram](Docs/ERD.png)



## 🚀 Features

- **Books Management**
  - CRUD operations
  - Extended metadata: multiple authors, categories, publisher, ISBN, edition, summary, status (Available/In/Out)

- **Members Management**
  - CRUD for library members

- **System Users**
  - Roles: Administrator, Librarian, Staff
  - Authentication & Authorization using JWT
  - Secure password storage
  - Activity logging

- **Borrow & Return**
  - Borrow transactions with status updates

- **Search API**
  - Search books by **Title, Author, Category**
  - Filter books by **Status**

---

## 🏗️ Architecture & Design

- **Backend**: ASP.NET Core 8 (Web API)  
- **ORM**: Entity Framework Core  
- **Database**: SQL Server  
- **Authentication**: Identity + JWT  
- **Source Control**: Git / GitHub  

### Database Schema
- **Books** ←→ **BookAuthors** ←→ **Authors**  
- **Books** ←→ **BookCategories** ←→ **Categories**  
- **Books** ←→ **Publisher**  
- **BorrowTransactions** ←→ **Members**  
- **SystemUsers** with Roles  

📌 ERD available in `Docs/ERD.png`  

---

## ⚙️ Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/your-username/library-management-system.git
cd library-management-system
