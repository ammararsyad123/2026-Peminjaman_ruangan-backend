using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomManagement.Api.Data;
using RoomManagement.Api.Models;

namespace RoomManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;
    public RoomsController(AppDbContext context) => _context = context;

    // GET: api/Rooms (Melihat Semua Ruangan - Poin 2)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetAll()
    {
        return await _context.Rooms.ToListAsync();
    }

    // POST: api/Rooms (Menambah Ruangan Baru - Poin 2)
    [HttpPost]
    public async Task<ActionResult> Create(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Data ruangan berhasil disimpan ke database!" });
    }
}