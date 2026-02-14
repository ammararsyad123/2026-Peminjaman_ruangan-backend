namespace RoomManagement.Api.Models;
public class Reservation {
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int RoomId { get; set; }
    public DateTime StartTime { get; set; }
    public string Status { get; set; } = "Pending";
}