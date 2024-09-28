using System.ComponentModel.DataAnnotations;

namespace AuthQRChatAPI.Models
{
    public class ChatRoom
    {
        [Key]
        public Guid RoomId { get; set; }
        public string BankAccount { get; set; }
        public float TotalAmount { get; set; }
        public float AmountRemaining { get; set; }
        public List<ParticipantSummary> Participants { get; set; } = new List<ParticipantSummary>();
    }
}
