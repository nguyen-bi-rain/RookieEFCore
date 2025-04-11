# 📦 MyEFCoreApp

Ứng dụng này sử dụng **Entity Framework Core (EF Core)** với phương pháp **Code First** để tạo và quản lý cơ sở dữ liệu SQL Server.  
Làm theo hướng dẫn bên dưới để khởi chạy ứng dụng.

---

## 📋 Yêu cầu hệ thống

Trước khi chạy ứng dụng, hãy đảm bảo bạn đã cài đặt:

- [.NET SDK 6.0 hoặc mới hơn](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- Tuỳ chọn: [Visual Studio](https://visualstudio.microsoft.com/) hoặc [Visual Studio Code](https://code.visualstudio.com/)

---

## ⚙️ Hướng dẫn cài đặt & chạy

### 1. 📁 Clone repository

```bash
git clone https://github.com/nguyen-bi-rain/RookieEFCore.git
cd MyEFCoreApp
cd EFCore\ Assingment\ 1/
```
## 2. 📦 Khôi phục các gói NuGet
```bash
dotnet restore
```
--- 

3. ⚙️ Cấu hình chuỗi kết nối cơ sở dữ liệu
Mở file appsettings.json và thiết lập chuỗi kết nối của bạn:

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "yourconnectionstring"
  }
}
```
---

🔐 Lưu ý: Không nên để thông tin nhạy cảm trong mã nguồn. Hãy sử dụng User Secrets hoặc biến môi trường trong môi trường production.

## 🛠 Tạo cơ sở dữ liệu (Code First)
4. ✅ Cài đặt công cụ EF Core (nếu chưa có)
```bash

dotnet tool install --global dotnet-ef
```
---
5. 🏗 Tạo migration đầu tiên

```bash
dotnet ef migrations add InitialCreate
```
---

6. 🗃 Áp dụng migration để tạo cơ sở dữ liệu
```bash
dotnet ef database update
```

---

🚀 Chạy ứng dụng
```bash
dotnet run
```
Ứng dụng sẽ kết nối với cơ sở dữ liệu đã cấu hình và sử dụng DbContext để thực hiện các thao tác.


