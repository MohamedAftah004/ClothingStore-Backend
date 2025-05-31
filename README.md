# 👕 Clothing Store Backend API

A complete and functional **Backend REST API** for a clothing e-commerce platform built using **.NET 8**, following a clean 3-layer architecture. This project handles everything from product management to customer carts, orders, and reviews, with integration-ready endpoints.

---

## 🧠 Project Idea & Motivation

The goal of this project is to simulate the full backend infrastructure of a modern online clothing store, with the following business requirements:

- Customers can **browse products**, **filter by category/price**, and **search** by name.
- Users can **register/login** and manage their **shopping cart**.
- Customers can **place orders**, **cancel**, and **track order status**.
- Customers can leave **product reviews** and view others’ feedback.
- Admins can **manage products, categories, and users**.

The architecture encourages clean separation of concerns and scalability.

---

## 🧱 Architecture

```plaintext
📁 ClothingStore
├── 📂 ClothingStore.Api         → Main Web API project (entry point)
├── 📂 ClothingStore.Business    → Business logic services
├── 📂 ClothingStore.DataAccess  → Data access layer, DTOs
└── 📂 database                  → Complete SQL Server database script
└── 📂 assets
```

- **API Layer:** Handles HTTP requests, responses, and routing
- **Business Layer:** Contains application logic, validation, and orchestration
- **DataAccess Layer:** Direct communication with SQL Server using ADO.NET

---

## 🛠 Tech Stack

- **.NET 8** Web API
- **SQL Server 2014+** (Tables, Foreign Keys)
- **ADO.NET** (no EF)
- **Swagger / OpenAPI**
- **DTOs + 3-Tiered Architecture**

---

## 🧩 Database

The database includes:

- `Admins`, `Customers`, `Products`, `Categories`
- `Orders`, `OrderDetails`, `Carts`, `CartItems`
- `Reviews`

All tables are properly normalized and relational.

👉 Run the script: `FULLEcommerceScript.sql`

---

## 🚀 Getting Started

### 1. Clone the repository
```bash
git clone https://github.com/your-username/ClothingStore.git
cd ClothingStore
```

### 2. Setup the Database
- Open SQL Server Management Studio
- Execute `FULLEcommerceScript.sql`

### 3. Configure appsettings.json
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Ecommerce;Trusted_Connection=True;"
}
```

### 4. Run the API
```bash
dotnet run --project ClothingStore.Api
```

Access Swagger: `https://localhost:<port>/swagger`

---

## 📬 API Endpoints Summary

### 🔐 Authentication
| Method | Route                 | Description        |
|--------|-----------------------|--------------------|
| POST   | `/api/customer/login`| Customer login     |

### 👤 Customer
| GET/POST/PUT/DELETE | `/api/customer/{id}`      | Manage customer profile     |

### 👨‍💼 Admin
| GET/POST/PUT/DELETE | `/api/admins/{id}`        | Full CRUD for admins        |

### 📦 Product
| GET    | `/api/product`               | Get all products              |
| GET    | `/api/product/{id}`          | Get product by ID             |
| POST   | `/api/product`               | Add new product               |
| PUT    | `/api/product/{id}`          | Update product                |
| DELETE | `/api/product/{id}`          | Delete product                |
| GET    | `/api/product/search?name=`  | Search by name                |
| GET    | `/api/product/bycategory/{id}` | Filter by category          |
| GET    | `/api/product/byprice?min=&max=`| Filter by price           |
| GET    | `/api/product/latest?limit=` | Latest products               |
| GET    | `/api/product/instock`       | In-stock only                 |

### 🛒 Cart
| GET    | `/api/cart/customer/{id}`       | Get user cart                |
| POST   | `/api/cart/customer/{id}/create-if-not-exists` | Ensure cart exists |
| GET    | `/api/cart/customer/{id}/exists`| Check if cart exists        |
| PUT    | `/api/cart/{id}`               | Update cart                  |
| DELETE | `/api/cart/{id}`               | Delete cart                  |

### 🛍️ Cart Items
| GET    | `/api/cart-items`             | All cart items                |
| GET    | `/api/cart-items/cart/{id}`   | Items for specific cart       |
| POST   | `/api/cart-items`             | Add to cart                   |
| PUT    | `/api/cart-items/{id}`        | Update item                   |
| DELETE | `/api/cart-items/cart/{id}/clear` | Clear all items           |

### 📦 Orders
| POST   | `/api/order`                  | Place an order                |
| GET    | `/api/order`                  | All orders                    |
| GET    | `/api/order/{id}`             | Order by ID                   |
| GET    | `/api/order/customer/{id}`    | Orders by customer            |
| PUT    | `/api/order/{id}`             | Update order                  |
| DELETE | `/api/order/{id}`             | Delete order                  |
| PUT    | `/api/order/{id}/cancel`      | Cancel order                  |
| PUT    | `/api/order/{id}/payment-status` | Update payment status     |

### 📝 Reviews
| GET    | `/api/review`                 | All reviews                   |
| POST   | `/api/review`                 | Create review                 |
| GET    | `/api/review/product/{id}`    | Reviews for a product         |
| GET    | `/api/review/customer/{id}`   | Reviews by customer           |
| GET    | `/api/review/exists`          | Check if user reviewed product |
| DELETE | `/api/review/{id}`            | Delete review                 |

---

## 📷 API Demo (Swagger UI)
![Swagger](https://github.com/user-attachments/assets/067e923e-7f32-48f6-8a88-40f3ec84f882)
