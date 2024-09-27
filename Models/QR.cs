using System.ComponentModel.DataAnnotations;

namespace AuthQRChatAPI.Models
{
    public class QR
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string[] Text;
    }
}
