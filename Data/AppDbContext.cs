using Microsoft.EntityFrameworkCore; // Giống import trong Java
using UserManagementAPI.Models; 

namespace UserManagementAPI.Data; // Giống package trong Java 

// Thay the Repository been Java
public class AppDbContext : DbContext
{
    // Constructor of AppDbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    // khai báo DbSet cho entity Product trong database
    // DbSet là một tập hợp các thực thể trong Entity Framework Core, đại diện cho một bảng trong cơ sở dữ liệu.
    // Mỗi DbSet cho phép bạn thực hiện các thao tác CRUD (Create, Read, Update, Delete) trên bảng tương ứng.
    public DbSet<Product> Products { get; set; }

    // phương thức này được sử dụng để cấu hình mô hình dữ liệu và thiết lập các ràng buộc, quan hệ giữa các thực thể.
    // Trong ví dụ này, nó được sử dụng để thêm dữ liệu mẫu (seed data) vào bảng Products khi cơ sở dữ liệu được tạo.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed initial data
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Sample Product 1", Price = 9.99M },
            new Product { Id = 2, Name = "Sample Product 2", Price = 19.99M }
        );
    }
}