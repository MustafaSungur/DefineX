using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AjaxApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductApiController : ControllerBase
	{

        private readonly string _connectionString = "Server=localhost;Database=ajaxOrnek;Integrated Security=True;TrustServerCertificate=True;";


        // ürün arama
        [HttpGet("GetProducts")]
		public async Task<IActionResult> GetProducts(string qUrunAdi)
		{
			List<string> urunler = [];

            using (SqlConnection qcon = new(_connectionString))
            {
                await qcon.OpenAsync();

                using SqlCommand cmd = new("SELECT UrunAdi FROM productTable WHERE UrunAdi LIKE @UrunAdi", qcon);

                cmd.Parameters.AddWithValue("@UrunAdi", $"%{qUrunAdi}%");

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    urunler.Add(reader["UrunAdi"].ToString());
                }
            }
			
            

			if (urunler.Count == 0)
			{
				return NotFound("Kayıt bulunamadı.");
			}

            return Ok(urunler);
        }

        //ürün ekleme
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] string urunAdi)
        {
            if (string.IsNullOrEmpty(urunAdi))
                return BadRequest("Ürün adı boş olamaz!");

            using SqlConnection qcon = new(_connectionString);
            await qcon.OpenAsync();

            //  Table yoksa oluşturur
            string checkTableQuery = @"
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'productTable')
            BEGIN
                CREATE TABLE productTable (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    UrunAdi NVARCHAR(255) NOT NULL
                );
            END";

            using (SqlCommand tableCmd = new(checkTableQuery, qcon))
            {
                await tableCmd.ExecuteNonQueryAsync();
            }

            using SqlCommand cmd = new("INSERT INTO productTable (UrunAdi) VALUES (@UrunAdi)", qcon);
            cmd.Parameters.AddWithValue("@UrunAdi", urunAdi);

            int affectedRows = await cmd.ExecuteNonQueryAsync();
            if (affectedRows > 0)
                return Ok("Ürün başarıyla eklendi.");
            else
                return StatusCode(500, "Ürün eklenirken hata oluştu.");
        }

    }
}

