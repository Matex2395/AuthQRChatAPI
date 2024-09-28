using AuthQRChatAPI.Data;
using AuthQRChatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payments.Models;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthQRChatAPI.Controllers
{
    [Route("friends/v1/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ChatRoomController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;

        }

        // POST friends/v1/<ChatRoomController>
        [HttpGet("Get")]
        public async Task<IActionResult> GetChatRoom([FromBody] ChatRoom chatRoom, int orderId, int accountId)
        {
            // Fetch the bank account number from the Account API
            var accountApiUrl = _configuration["AccountApiUrl"] + $"Account/getAccountById/{accountId}";
            var accountResponse = await _httpClient.GetAsync(accountApiUrl);

            if (!accountResponse.IsSuccessStatusCode)
            {
                return StatusCode((int)accountResponse.StatusCode, "Failed to fetch the bank account.");
            }

            var jsonAccountResponse = await accountResponse.Content.ReadAsStringAsync();
            var bankResponse = JsonSerializer.Deserialize<AccountModel>(jsonAccountResponse);

            if (bankResponse == null)
            {
                return BadRequest("Invalid data received from Payment API.");
            }

            string account = bankResponse.accountNumber;


            // Fetch the order summary from the Payments API
            var orderSummaryUrl = _configuration["AccountApiUrl"] + $"Order/orderSummary/{orderId}";
            var orderSummaryResponse = await _httpClient.GetAsync(orderSummaryUrl);

            if (orderSummaryResponse == null)
            {
                return BadRequest("Invalid data received from Payment API.");
            }

            var jsonSummaryResponse = await orderSummaryResponse.Content.ReadAsStringAsync();
            var summaryResponse = JsonSerializer.Deserialize<OrderSummary>(jsonSummaryResponse);

            if (summaryResponse == null)
            {
                return BadRequest("Invalid data received from Payment API.");
            }

            chatRoom.RoomId = Guid.NewGuid();
            chatRoom.BankAccount = account;
            chatRoom.TotalAmount = summaryResponse.OrderAmount;
            chatRoom.AmountRemaining = summaryResponse.OrderAmount;
            chatRoom.Participants = summaryResponse.Participants;

            return Ok(chatRoom);
        }

    }
}
