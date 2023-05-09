﻿using System.ComponentModel.DataAnnotations;

namespace METROAssignment.Contracts.Payment.Requests
{
    public class UpdatePaymentRequestDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int? Amount { get; set; }
    }
}
