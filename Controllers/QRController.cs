using AuthQRChatAPI.Data;
using AuthQRChatAPI.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthQRChatAPI.Controllers
{
    [Route("friends/v1/[controller]")]
    [ApiController]
    public class QRController : ControllerBase
    {
        private readonly AppDbContext _db;

        public QRController(AppDbContext db)
        {
            _db = db;
        }

        //// GET: api/<QRController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<QRController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST friends/v1/<QRController>
        [HttpPost("{text}")]
        public async Task<String> Post([FromBody] string[] text)
        {
            string concatenatedText = string.Join(" ", text);
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(concatenatedText, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode bitmapByteCode = new BitmapByteQRCode(qrCodeData);
            var bitMap = bitmapByteCode.GetGraphic(20);
           
            using var ms = new MemoryStream();
            ms.Write(bitMap);
            byte[] byteImage = ms.ToArray();

            return Convert.ToBase64String(byteImage);
        }

        //// PUT api/<QRController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<QRController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
