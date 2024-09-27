using System.ComponentModel.DataAnnotations;

namespace AuthQRChatAPI.Models
{
    public class ChatRoom
    {
        [Key]
        public Guid RoomId { get; set; }
        public string BankAccount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountRemaining { get; set; }
        public List<UserPaymentStatus> UserPayments { get; set; } = new List<UserPaymentStatus>();
    }
}
