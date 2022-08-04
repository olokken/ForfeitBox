using System;
namespace ForfeitCase.Entities
{
  public class Case
  {
    public String? CaseId { get; set; }
    public String? Name { get; set; }
    public List<Forfeit>? Forfeits { get; set; }
    public List<User>? Admins { get; set; }
    public List<User>? Members { get; set; }
  }
}

