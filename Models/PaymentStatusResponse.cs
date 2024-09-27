namespace AuthQRChatAPI.Models
{
    internal class PaymentStatusResponse
    {
        public decimal TotalAmount { get; set; }
        public decimal AmountRemaining { get; set; }
        public int UsersPaid { get; set; }
        public int UsersNotPaid { get; set; }
        public List<UserPaymentStatus> UserPayments { get; set; }
    }
}