﻿using System;
namespace ForfeitBox.Entities
{
  public class PaymentConfirmation : Action
  {
    public string? PaymentConfirmationId { get; set; }
    public Payment? Payment { get; set; }
    public string? PaymentId { get; set; }    
  }
}

