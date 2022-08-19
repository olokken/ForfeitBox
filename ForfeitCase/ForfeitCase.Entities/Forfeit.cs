namespace ForfeitCase.Entities
{
  public class Forfeit
  {
    public string? ForfeitId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Sum { get; set; }
    public string? CaseId { get; set; }
    public virtual Case? @Case { get; set; }
  }
}

