using BloodBankWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BloodBankController : ControllerBase
{
    private static List<BloodBankEntry> BloodBankEntries = new List<BloodBankEntry>();
    private static int _idCounter = 1;

    // Add a new Blood Bank entry
    [HttpPost]
    public IActionResult Create([FromBody] BloodBankEntry newEntry)
    {
        if (newEntry == null)
            return BadRequest("Invalid entry data.");

        newEntry.Id = _idCounter++;
        BloodBankEntries.Add(newEntry);
        return CreatedAtAction(nameof(GetById), new { id = newEntry.Id }, newEntry);
    }

    // Get all Blood Bank entries
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(BloodBankEntries);
    }

    // Get a specific Blood Bank entry by Id
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var entry = BloodBankEntries.FirstOrDefault(e => e.Id == id);
        if (entry == null)
            return NotFound($"Entry with Id {id} not found.");

        return Ok(entry);
    }

    // Modify an existing Blood Bank entry
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] BloodBankEntry updatedEntry)
    {
        var entry = BloodBankEntries.FirstOrDefault(e => e.Id == id);
        if (entry == null)
            return NotFound($"Entry with Id {id} not found.");

        entry.DonorName = updatedEntry.DonorName;
        entry.Age = updatedEntry.Age;
        entry.BloodType = updatedEntry.BloodType;
        entry.ContactInfo = updatedEntry.ContactInfo;
        entry.Quantity = updatedEntry.Quantity;
        entry.CollectionDate = updatedEntry.CollectionDate;
        entry.ExpirationDate = updatedEntry.ExpirationDate;
        entry.Status = updatedEntry.Status;

        return NoContent();
    }

    // Remove a Blood Bank entry
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var entry = BloodBankEntries.FirstOrDefault(e => e.Id == id);
        if (entry == null)
            return NotFound($"Entry with Id {id} not found.");

        BloodBankEntries.Remove(entry);
        return NoContent();
    }

    // Pagination
    [HttpGet("paged")]
    public IActionResult GetPaged([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var pagedData = BloodBankEntries
            .Skip((page - 1) * size)
            .Take(size)
            .ToList();

        return Ok(pagedData);
    }

    // Search by blood type
    [HttpGet("search")]
    public IActionResult Search([FromQuery] string? bloodType, [FromQuery] string? status, [FromQuery] string? donorName)
    {
        var query = BloodBankEntries.AsQueryable();

        if (!string.IsNullOrEmpty(bloodType))
            query = query.Where(e => e.BloodType.Equals(bloodType, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(status))
            query = query.Where(e => e.Status.Equals(status, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(donorName))
            query = query.Where(e => e.DonorName.Contains(donorName, StringComparison.OrdinalIgnoreCase));

        return Ok(query.ToList());
    }

    // Sorting by parameter
    [HttpGet("sorted")]
    public IActionResult GetSorted([FromQuery] string sortBy = "BloodType")
    {
        var sortedData = sortBy.ToLower() switch
        {
            "collectiondate" => BloodBankEntries.OrderBy(e => e.CollectionDate).ToList(),
            _ => BloodBankEntries.OrderBy(e => e.BloodType).ToList()
        };

        return Ok(sortedData);
    }
}
