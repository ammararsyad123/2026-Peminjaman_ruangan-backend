using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomManagement.Api.Data;
using RoomManagement.Api.Models;

namespace RoomManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly AppDbContext _context;
    public ReservationsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
    {
        return await _context.Reservations.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Peminjaman berhasil dicatat!" });
    }
}