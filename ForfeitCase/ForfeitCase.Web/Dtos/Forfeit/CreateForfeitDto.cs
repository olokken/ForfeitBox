using System;
namespace ForfeitCase.Web.Dtos.Forfeit
{
  public class CreateForfeitDto
  {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Sum { get; set; }
    public string? CaseId { get; set; }
  }
}

