using Microsoft.AspNetCore.Mvc;
using TokoOnlineAPI.Models;

namespace TokoOnlineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokoOnlineController : ControllerBase
    {
        private static List<TokoOnlineModel> tokoonlineList = new List<TokoOnlineModel>
        {
            new TokoOnlineModel{Id="1",Customer_name="Burhan", Product_name="TV", Quantity="3", Total_price="30000000000", Order_date="123", Shipping_address="aaa", Status="pending"},
            new TokoOnlineModel{Id="2",Customer_name="Zhafira", Product_name="HP", Quantity="5", Total_price="30000000000", Order_date="12345", Shipping_address="aaa", Status="processed"}
        };

        [HttpGet]
        public ActionResult<IEnumerable<TokoOnlineModel>> GetAll()
        {
            return Ok(tokoonlineList);
        }

        [HttpGet("{id}")]
        public ActionResult<TokoOnlineModel> GetById(string id)
        {
            var tokoonline = tokoonlineList.Find(m => m.Id == id);
            if (tokoonline == null)
            {
                return NotFound(new { message = "Toko Online tidak ditemukan" });
            }
            return Ok(tokoonline);
        }

        [HttpPost]
        public ActionResult Add([FromBody] TokoOnlineModel newTokoOnline)
        {
            if (newTokoOnline == null)
            {
                return BadRequest(new { message = "Data Toko Online tidak valid." });
            }


            Console.WriteLine($"Customer_name: {newTokoOnline.Customer_name}, Product_name: {newTokoOnline.Product_name} , Quantity: {newTokoOnline.Quantity}, Total_price: {newTokoOnline.Total_price}, Order_date: {newTokoOnline.Order_date}, Shipping_address: {newTokoOnline.Shipping_address}, Status: {newTokoOnline.Status}");

            newTokoOnline.Id = (tokoonlineList.Count + 1).ToString(); 
            tokoonlineList.Add(newTokoOnline);
            return CreatedAtAction(nameof(GetById), new { id = newTokoOnline.Id }, newTokoOnline);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] TokoOnlineModel updatedTokoOnline)
        {
            var TokoOnline = tokoonlineList.Find(m => m.Id == id);
            if (TokoOnline == null)
            {
                return NotFound(new { message = "Toko Online tidak ditemukan" });
            }
            TokoOnline.Customer_name = updatedTokoOnline.Customer_name;
            TokoOnline.Product_name = updatedTokoOnline.Product_name;
            TokoOnline.Quantity = updatedTokoOnline.Quantity;
            TokoOnline.Total_price = updatedTokoOnline.Total_price;
            TokoOnline.Order_date = updatedTokoOnline.Order_date;
            TokoOnline.Shipping_address = updatedTokoOnline.Shipping_address;
            TokoOnline.Status = updatedTokoOnline.Status;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var mahasiswa = tokoonlineList.Find(m => m.Id == id);
            if (mahasiswa == null)
            {
                return NotFound(new { message = "Toko Online tidak ditemukan" });
            }
            tokoonlineList.Remove(mahasiswa);
            return NoContent();
        }
    };
}