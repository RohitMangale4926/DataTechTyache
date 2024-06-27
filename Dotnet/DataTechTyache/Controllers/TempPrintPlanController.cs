using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using datatechtyache.Data;
using datatechtyache.Models;

namespace datatechtyache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempPrintPlanController : ControllerBase
    {
        private readonly DataContext _context;

        public TempPrintPlanController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("insert-records")]
        public async Task<IActionResult> InsertRecords([FromBody] List<List<string>> data)
        {
            try
            {
                Console.WriteLine("in insert records controller");
                // Clear existing data in Temp_PrintPlan table
                await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Tyache.Temp_PrintPlan");

                // Insert new data
                foreach (var row in data)
                {
                    if (row.Count >= 15) // Ensure row has at least 15 columns
                    {
                        var tempPrintPlan = new Temp_PrintPlan
                        {
                            ProductCode = row[0],
                            ProductName = row[1],
                            BatchNumber = row[2],
                            DLNumber = row[3],
                            GrossWeight = row[4],
                            TareWeight = row[5],
                            NetWeight = row[6],
                            MfgDate = row[7],
                            ExpDate = row[8],
                            UPCNo = row[9],
                            Storage = row[10],
                            ContainerNumber = row[11],
                            LabelCode = row[12],
                            CaseNo = row[13],
                            ErrorLog = row[14],
                            IsValid = true, // Set default values for additional columns
                            TransUserId = 1,
                            TransSessionID = 1,
                            TransTime = DateTime.Now
                        };

                        _context.Temp_PrintPlans.Add(tempPrintPlan);
                    }
                    else
                    {
                        // Handle case where row doesn't have enough columns
                        return BadRequest("Invalid data format: Each row must have at least 15 columns.");
                    }
                }

                await _context.SaveChangesAsync();

                return Ok("Records inserted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("get-records")]
        public async Task<ActionResult<IEnumerable<Temp_PrintPlan>>> GetRecords()
        {
            try
            {
                var records = await _context.Temp_PrintPlans.ToListAsync();
                return Ok(records);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
