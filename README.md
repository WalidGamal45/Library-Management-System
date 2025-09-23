
---

## 📊 Database Schema

The system supports books, members, borrowing transactions, and role-based access control.

![ERD](https://i.suar.me/npOlM/l)


### Key Entities
- **Books**: Metadata such as title, authors, publishers, categories, ISBN, edition, summary, cover image, and status (`In`/`Out`).
- **Members**: Borrowers who can check out books.
- **System Users**: Staff, librarians, and administrators with role-based permissions.
- **BorrowTransactions**: Tracks borrowing and returning of books.
- **ActivityLogs**: Captures all user actions for auditing.

---

## 🔑 Features

- **Book Management**
  - CRUD operations with support for multiple authors and categories.
  - Search by title, author, or category.
  - Filter by status (`In`, `Out`).

- **Member Management**
  - CRUD operations for library members.

- **System User Management**
  - Roles: **Administrator**, **Librarian**, **Staff**.
  - Secure authentication & authorization with JWT.
  - Role-based access control on API endpoints.

- **Borrowing System**
  - Borrow and return operations with due dates.
  - Track which staff processed the transaction.

- **Activity Logging**
  - Every action is logged for auditing purposes.

---

## 🚀 Technology Stack

- **.NET 7 / ASP.NET Core Web API**
- **Entity Framework Core** with SQL Server
- **JWT Authentication**
- **Clean Architecture**
- **Postman Collection** for API testing

---

## 📡 API Endpoints

### Authentication
- `POST /api/auth/login` – Login and get JWT token.
- `POST /api/auth/register` – Register a new system user (Admin only).

### Books
- `GET /api/books` – Get all books.
- `GET /api/books/{id}` – Get book details.
- `GET /api/books/search?name=...&author=...&category=...` – Search books.
- `GET /api/books/status/{status}` – Get books by status.
- `POST /api/books` – Add new book.
- `PUT /api/books/{id}` – Update book.
- `DELETE /api/books/{id}` – Delete book.

### Members
- `GET /api/members` – Get all members.
- `POST /api/members` – Add member.
- `PUT /api/members/{id}` – Update member.
- `DELETE /api/members/{id}` – Remove member.

### Borrowing
- `POST /api/borrow` – Borrow a book.
- `POST /api/return` – Return a book.

---

## 🧪 Testing

- ✅ Postman collection is included for easy API testing.
- ✅ SQL scripts with sample data are provided in `/docs/sql`.

---

## 📌 Notes

- Passwords are securely hashed before storage.
- Roles and permissions are enforced using ASP.NET Core Identity.
- Logs are stored in **ActivityLogs** for auditing.

---

## 🎯 Bonus Features Implemented
- API to **search books by name, author, or category**.
- API to **filter books by status**.
- Comprehensive **Postman collection** included.

---

## 👨‍💻 Author

**Walid** – Backend Developer  
