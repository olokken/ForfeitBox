using System;
namespace ForfeitCase.Entities
{
  public abstract class Action
  {
    //En action skal komme opp i feeden for en Case
    //En action kan være en allocation, en payment eller en paymentconfirmation.
    //I feeden kommer det også opp når folk blir lagt til/fjernet fra en case eller andre entiteter blir opprettet eller endret.
    //Disse actionene vil ikke bli lagret i DB som en action, ettersom man ikke trenger de i feeden over en lengre periode,
    //ettersom dataen er tilgjengelig, men ikke 
    public User? Executor { get; set; }
    public string? ExecutorId { get; set; }
    public Case? Case { get; set; }
    public string? CaseId { get; set; }
  }
}

