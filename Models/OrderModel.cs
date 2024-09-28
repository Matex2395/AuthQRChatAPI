using System.ComponentModel.DataAnnotations;

namespace payments.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public float OrderAmount { get; set; }
        public Boolean OrderEven { get; set; }
        public int OrderParticipants { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public DateTime OrderCreationDate {  get; set; }        
        public int RequesterUserId { get; set; }
        public int RequesterUserAccountId { get; set; }
        
    }

    public enum OrderStatusEnum
    {
        CREATED = 0,
        INPROCES = 1,
        COMPLETED = 2,
        FINISH = 3,
        CANCELED = 9
    }
}
