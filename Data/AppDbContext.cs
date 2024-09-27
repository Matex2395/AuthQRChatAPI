using AuthQRChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthQRChatAPI.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<QR> QRCodes { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<UserPaymentStatus> UserPayments { get; set; }
    }
}
