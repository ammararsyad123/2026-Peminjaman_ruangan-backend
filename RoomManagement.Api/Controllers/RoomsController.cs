using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomManagement.Api.Data;
using RoomManagement.Api.Models;
using RoomManagement.Api.DTOs;

namespace RoomManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomersController(AppDbContext context) => _context = context;

    // GET: api/customers (Melihat Semua Data - Poin 9)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
    {
        return await _context.Customers
            .Select(c => new CustomerDto(c.Id, c.Name, c.Email))
            .ToListAsync();
    }

    // POST: api/customers (Menambah Data Baru)
    [HttpPost]
    public async Task<ActionResult> Create(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Data berhasil disimpan ke database!" });
    }
}