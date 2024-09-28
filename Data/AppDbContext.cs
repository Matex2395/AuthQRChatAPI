using AuthQRChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthQRChatAPI.Data
{
    public class AppDbContext : DbContext
    {
        //protected readonly IConfiguration _configuration;

        //public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
        //: base(options)
        //{
        //    _configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        //    }
        //}

        //public DbSet<QR> QRCodes { get; set; }
        //public DbSet<ChatRoom> ChatRooms { get; set; }
        //public DbSet<UserPaymentStatus> UserPayments { get; set; }
    }
}
