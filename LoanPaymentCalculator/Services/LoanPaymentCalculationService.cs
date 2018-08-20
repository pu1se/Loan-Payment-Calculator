using System;
using System.Collections.Generic;
using System.Text;

namespace LoanPaymentCalculator
{
    class LoanPaymentCalculationService
    {

        public PaymentEntity CalculatePayments(LoanEntity loanInfo)
        {
            var paymentInfo = new PaymentEntity();

            loanInfo.LoanAmount -= loanInfo.DownPaymentAmount;

            paymentInfo.MonthlyPayment = GetMonthlyPaymentByPmtFormula(loanInfo);

            paymentInfo.TotalPayment = loanInfo.TermInYears * 12 * paymentInfo.MonthlyPayment;

            paymentInfo.TotalInterest = paymentInfo.TotalPayment - loanInfo.LoanAmount;


            return paymentInfo.RoundPaymentResultTo(2);
        }

        private decimal GetMonthlyPaymentByPmtFormula(LoanEntity loanInfo)
        {
            var percentInDecimalFormat = loanInfo.Percent / 100 / 12;
            var numberOfPaymentPeriods = loanInfo.TermInYears * 12;
            var result = (percentInDecimalFormat * loanInfo.LoanAmount) / (1 - (decimal)Math.Pow((double) (1 + percentInDecimalFormat), numberOfPaymentPeriods*-1));

            return result;
        }

    }
}
