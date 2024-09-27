using AuthQRChatAPI.Data;
using AuthQRChatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthQRChatAPI.Controllers
{
    [Route("friends/v1/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ChatRoomController(AppDbContext db)
        {
            _db = db;
        }

        // POST friends/v1/<ChatRoomController>
        [HttpPost("create")]
        public async Task<IActionResult> CreateChatRoom([FromBody] ChatRoom chatRoom)
        {
            chatRoom.RoomId = Guid.NewGuid();
            chatRoom.AmountRemaining = chatRoom.TotalAmount;

            _db.ChatRooms.Add(chatRoom);
            await _db.SaveChangesAsync();

            return Ok(chatRoom);
        }

        // GET: friends/v1/<ChatRoomController>
        [HttpGet("{roomId}/status")]
        public async Task<IActionResult> GetPaymentStatus(Guid roomId)
        {
            var chatRoom = await _db.ChatRooms.Include(cr => cr.UserPayments)
                .FirstOrDefaultAsync(cr => cr.RoomId == roomId);
            if (chatRoom == null)
            {
                return NotFound("Chat Room not found");
            }
            var usersPaid = chatRoom.UserPayments.Count(x => x.HasPaid);
            var usersNotPaid = chatRoom.UserPayments.Count(x => !x.HasPaid);

            var response = new PaymentStatusResponseModel
            {
                TotalAmount = chatRoom.TotalAmount,
                AmountRemaining = chatRoom.AmountRemaining,
                UsersPaid = usersPaid,
                UsersNotPaid = usersNotPaid,
                UserPayments = chatRoom.UserPayments
            };
            return Ok(response);
        }

        // PUT friends/v1/<ChatRoomController>/5
        [HttpPut("updatePaymentStatus")]
        public async Task<IActionResult> UpdatePaymentStatus([FromBody] UserPaymentStatus userPaymentStatus)
        {
            var existingUserPayment = await _db.UserPayments
                .FirstOrDefaultAsync(up => up.Id == userPaymentStatus.Id);

            if(existingUserPayment == null)
            {
                return NotFound("User not found in char room");
            }

            existingUserPayment.HasPaid = userPaymentStatus.HasPaid;
            existingUserPayment.AmountPaid = userPaymentStatus.AmountPaid;

            var chatRoom = await _db.ChatRooms.FindAsync(existingUserPayment.ChatRoomId);
            if(chatRoom == null)
            {
                chatRoom.AmountRemaining = chatRoom.TotalAmount - chatRoom.UserPayments
                    .Sum(x => x.AmountPaid);
            }
            _db.UserPayments.Update(existingUserPayment);
            await _db.SaveChangesAsync();
            return Ok(existingUserPayment);
        }
    }
}
