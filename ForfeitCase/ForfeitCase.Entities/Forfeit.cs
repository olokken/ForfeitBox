namespace ForfeitBox.Entities
{
  public class Forfeit
  {
    public string? ForfeitId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Sum { get; set; }
    public string? BoxId { get; set; }
    public virtual Box? Box { get; set; }
  }
}

