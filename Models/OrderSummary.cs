namespace AuthQRChatAPI.Models
{
    public class OrderSummary
    {
        public int OrderId { get; set; }
        public int RequesterUserId { get; set; }
        public float OrderAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderCreationDate { get; set; }
        public int TotalParticipants { get; set; }
        public float TotalAmountPayed { get; set; }
        public List<ParticipantSummary> Participants { get; set; } = new List<ParticipantSummary>();
    }
}
