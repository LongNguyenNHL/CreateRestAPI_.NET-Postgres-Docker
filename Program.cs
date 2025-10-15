using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Data;

// var là từ khóa để khai báo biến mà không cần chỉ định kiểu dữ liệu cụ thể.
// WebApplication là một lớp trong ASP.NET Core được sử dụng để cấu hình và chạy ứng dụng web.
// CreateBuilder là một phương thức tĩnh của lớp WebApplication, được sử dụng để tạo một đối tượng WebApplicationBuilder.
// args là tham số truyền vào từ dòng lệnh khi chạy ứng dụng.
// tương đương với SpringApplication.run trong Java Spring Boot
var builder = WebApplication.CreateBuilder(args);

// Services cần thiết
// AddControllers: Đăng ký các dịch vụ cần thiết để sử dụng các controller trong ứng dụng ASP.NET Core. => tương đương @RestController trong Java Spring Boot
// AddDbContext: Đăng ký AppDbContext làm dịch vụ trong container Dependency Injection của ứng dụng. 
// UseNpgsql: Cấu hình AppDbContext để sử dụng PostgreSQL làm cơ sở dữ liệu.
// GetConnectionString: Lấy chuỗi kết nối từ tệp cấu hình (appsettings.json) dựa trên tên "DefaultConnection".
// Tất cả các dịch vụ này sẽ được sử dụng trong ứng dụng để xử lý các yêu cầu HTTP và tương tác với cơ sở dữ liệu.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// app là một biến đại diện cho ứng dụng web được xây dựng từ builder. 
var app = builder.Build();

// Middleware cần thiết
// UseHttpsRedirection: Chuyển hướng tất cả các yêu cầu HTTP đến HTTPS để đảm bảo an toàn. => tương đương với @EnableWebSecurity trong Java Spring Boot
// UseAuthorization: Thêm middleware xác thực và ủy quyền vào pipeline xử lý yêu cầu. => tương đương với @EnableWebSecurity trong Java Spring Boot
// MapControllers: Định tuyến các yêu cầu HTTP đến các controller tương ứng dựa trên các route đã định nghĩa. => tương đương @RequestMapping trong Java Spring Boot
// Run: Khởi động ứng dụng và bắt đầu lắng nghe các yêu cầu HTTP.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
