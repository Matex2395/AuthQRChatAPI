namespace AuthQRChatAPI.Models
{
    public class ParticipantSummary
    {
        public int CustomerUserId { get; set; }
        public int CustomerAccountId { get; set; }
        public float AmountPayed { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public bool OrderPayed { get; set; }
    }
}
