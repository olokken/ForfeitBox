using System;
namespace ForfeitCase.Entities
{
  public abstract class Action
  {
    public User? Executor { get; set; }
    public Case? Case { get; set; }
    public String? ExecutorId { get; set; }
    public String? CaseId { get; set; }
  }
}

