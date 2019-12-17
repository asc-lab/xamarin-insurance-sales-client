using System;
using System.Collections.Generic;

namespace InsuranceSales.Models.Policy
{
    public class PolicyModel
    {
        public string Number { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public string PolicyHolder { get; set; }

        public decimal TotalPremium { get; set; }

        public string ProductCode { get; set; }

        public string AccountNumber { get; set; }

        public IEnumerable<string> Covers { get; set; }
    }
}
