using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthQRChatAPI.Models
{
    public class UserPaymentStatus
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RoomId")]
        public Guid ChatRoomId { get; set; } // Foreign Key to ChatRoom
        public string UserId { get; set; }
        public string Username { get; set; }
        public bool HasPaid { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
