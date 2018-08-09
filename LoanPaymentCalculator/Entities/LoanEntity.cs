using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanPaymentCalculator
{
    public class LoanEntity
    {
        public decimal LoanAmount { get; set; }
        public decimal Percent { get; set; }
        public decimal DownPaymentAmount { get; set; }
        public int TermInYears { get; set; }
    }
}
