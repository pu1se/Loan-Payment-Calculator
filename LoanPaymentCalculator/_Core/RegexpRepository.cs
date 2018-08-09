using System;
using System.Collections.Generic;
using System.Text;

namespace LoanPaymentCalculator
{
    static class RegexpRepository
    {
        public const string DecimalNumber = @"^\d\d*(.\d*)?$";
        public const string IntegerNumber = @"^\d\d*$";
        public const string Percent = @"^\d{1,2}(.\d*)%?$";
    }
}
