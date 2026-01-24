# Sử dụng DB là PostgreSQL nên phải cài package để hỗ trợ
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0  Thư viện hỗ trợ công cụ Design-time (cần thiết để chạy Migration)
dotnet add package Microsoft.EntityFrameworkCore.Tools version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.AutoHistory --version 8.0.0
# Cài đặt bản 12.x cho tương thích .NET 8
dotnet add package MediatR --version 12.4.1
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.8
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.8
dotnet add package Microsoft.Extensions.Identity.Stores --version 8.0.8
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.8


# Lần build đầu setup code 
# Tạo BaseEntity để apply cho toàn bộ các entity khác(tái sử dụng) 
# ở đây tôi đã học được Generic là gì, Guid là gì 
Generic được dùng cho nhiều kiểu tham số khác nhau (int,long,Guid)
Guid là mã định danh không bao giờ trùng tên trên toàn cầu( được dùng làm primary key)












