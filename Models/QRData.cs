using System.ComponentModel.DataAnnotations;

namespace AuthQRChatAPI.Models
{
    public class QRData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string[] Text;
    }
}
