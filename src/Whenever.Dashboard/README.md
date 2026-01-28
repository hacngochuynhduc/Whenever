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

Ở đây khi tôi đã build xong các Entities(Table) việc cần làm là tôi phải tạo ApplicationDbContext để
EF core biết cách ánh xạ các entites vào Postgre SQL
Để ApplicationDbContext, trước tiên tôi phải tạo UserContext trước( mục đích để biết chính xác thông tin người dùng
khi đăng nhập, họ là ai, role là gì, để dễ phân quyền và filter data theo role trong ApplicationDbContext)

# HttpContext
Ở đây lần đầu tiên tôi biết HttpContext là gì( nó là toàn bộ thông tin của 1 request đang chạy, giống như
một cái hộp chứa toàn bộ thông tin bên trong) CLient call => MiddleWare => controller=> response=> hủy httpcontext

# HttpContextAccessor
HttpContextAccessor là cầu nối của HttpContext, mục đích là dùng ở Service, Repository, UserContext,DbContext,Middware
HttpContextAccessor giải quyết vấn đề đó( nó cho phép lấy HttpContext đang chạy)
HttpContext = thông tin request hiện tại
HttpContextAccessor = tay thò vào lấy HttpContext
IHttpContextAccessor cho phép Service / Helper / Context truy cập HttpContext của request hiện tại

Để làm vậy thì tôi phải đăng kí vào program.cs
Mà để làm cái đó thì tôi phải build cái Program này rồi=))
# Program.cs

Đầu tiên tôi cần phải add var builder = WebApplication.CreateBuilder(args);
Nếu failed phải add .web ở csproj program
# Cấu hình Database (PostgreSQL)
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.8 ở dashboard
dotnet add package EFCore.NamingConventions --version 8.0.3
okee Add GetConnectionString rồi đăng kí HttpContextAccessor

# Jwt Bearer 
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.8
Add authen Bearer cho program

# options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
Check authorize Header có token hay không( ưu tiên để kiểm tra xem thằng này là ai)
Nếu không có thì là anonymous
# options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
Chức năng: Quyết định sẽ làm gì khi một User chưa đăng nhập cố tình truy cập vào trang cấm (có attribute [Authorize])
Hành động: Với JWT, server sẽ trả về mã lỗi 401 Unauthorized.

dotnet add package Swashbuckle.AspNetCore --version 6.6.2

# Setup khi run program.cs hay
trước Build() thì đăng ký các nguyên liệu, service
Sau build thiết lập băng chuyền Middlware, lúc này app.Use để sắp xếp các thứ tự cần kiểm soát
Nếu để app.UseAuthorize trước app.Authenication thì lỗi logic ngay

# Cors
Tôi phải add Cors vì khi build project này Backedn ở port 6001 thì FE angular cbi build nó chạy 4200
Tôi cần đăng kí mở toang server để FE truy cập các API của port 6001


# appSetting.json
Chỉnh appSeting đăng kí connectionString, allowedHost, JwtToken: define Secret Key

# Chạy migration khởi tạo db đầu tiên
> dotnet ef migrations add InitialCreate --project ../Whenever.Infrastruture
dotnet ef database update 

# Static (tĩnh)
áp dụng static cho nó vì muốn set cứng nó luôn. Để không cần phải tạo object mới, gọi thẳng
Vì cần cái này để addService vào program

# tới đoạn căng setup IRepository Repository, IPagedList, PageList, IUnitOfWord, UnitOfWord

# IRepository & Repository (Cái "Kìm", cái "Búa")
# IRepository: Là bản thiết kế (interface). Nó định nghĩa:
"Tôi có các hàm Insert, Update, Delete, GetById, GetPagedList...".

# Repository: 
Là bản thực thi (class). Nó cầm DbContext và thực hiện các câu lệnh SQL thực tế
thông qua EF Core.
cần làm các thứ đó trước để hoàn thiện InfrastrutureDependencies

# IUnitOfWork & UnitOfWork (Cái "Hộp dụng cụ")
# IUnitOfWork: 
Là giao diện để bạn gọi trong Controller/Service.
# UnitOfWork:
Nó chứa hàm GetRepository<T>(): Để lấy ra cái "kìm", cái "búa" (Repository) bạn cần.

Nó chứa hàm SaveChangesAsync(): Đây là "nút chốt". Khi bạn làm 10 việc (thêm, sửa, xóa), 
chỉ khi bấm nút này thì toàn bộ 10 việc mới được lưu xuống DB. Nếu 1 việc lỗi, 
9 việc kia sẽ bị hủy (Rollback).

# PagedList Extensions (Bộ "Phù phép" phân trang)
## QueryablePagedListExtensions:
Dùng cho IQueryable (Dữ liệu đang nằm dưới Database).

Nó sẽ dùng .Skip() và .Take() để tạo ra câu lệnh SQL: "Chỉ lấy từ dòng 20 đến dòng 40 thôi nhé".

Hiệu năng: Cực cao, vì nó chỉ tải đúng số dữ liệu cần hiển thị lên RAM.

## EnumerablePagedListExtensions:
Dùng cho IEnumerable (Dữ liệu đã nằm trên RAM rồi).

Nó phân trang dựa trên danh sách đã lấy về.

Sử dụng: Thường dùng khi bạn đã lấy hết dữ liệu lên để xử lý logic phức tạp, 
sau đó mới phân trang để gửi về Client.

# ApplicationUser và ApplicationUserBase
Kiểu khi tôi vừa UnitOfwork.SaveChanges(); xong tôi muốn biết ai là người vừa sửa bản ghi này?
Để biết thì không thể nào đi hỏi từng controller được, cần 1 hàm để luôn luôn xác định nó là ai

# ApplicationUserBase (thằng cha)
Chứa các kỹ năng cơ bản về claims : Lấy thông tin từ token, check xem phải Admin không, xử lý việc đăng nhập
,đăng xuất
# ApplicationUser (Con)

Ép chuỗi sang Guid để lưu Db
..
# khi chạy thì đối với Dev nên chạy local trước
Build 1 Properties : bên trong là launchSettings.json: để config muốn chạy host nào
.NET nó sẽ ưu tiên












