using System;
namespace ForfeitBox.Web.Dtos.Allocation
{
  public class CreateAllocationDto
  {
    public string? RecieverId { get; set; }
    public string? ForfeitId { get; set; }    
    public string? CaseId { get; set; }
  }
}

