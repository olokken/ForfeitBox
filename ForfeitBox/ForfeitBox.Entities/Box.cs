namespace ForfeitBox.Entities
{
  public class Box
  {
    public string? BoxId { get; set; }
    public string? Name { get; set; }
    public IEnumerable<Forfeit>? Forfeits { get; set; }
    public IEnumerable<User>? Admins { get; set; }
    public IEnumerable<User>? Members { get; set; }
    public IEnumerable<Payment>? Payments { get; set; }
    public IEnumerable<Allocation>? Allocations { get; set; }
  }
}

