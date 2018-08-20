using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LoanPaymentCalculator
{
    class PaymentEntity
    {
        [JsonProperty(PropertyName = "monthly payment")]
        public decimal MonthlyPayment { get; set; }

        [JsonProperty(PropertyName = "total interest")]
        public decimal TotalInterest { get; set; }

        [JsonProperty(PropertyName = "total payment")]
        public decimal TotalPayment { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public PaymentEntity RoundPaymentResultTo(int roundToNumber)
        {
            return new PaymentEntity
            {
                MonthlyPayment = Math.Round(MonthlyPayment, roundToNumber),
                TotalInterest = Math.Round(TotalInterest, roundToNumber),
                TotalPayment = Math.Round(TotalPayment, roundToNumber)
            };
        }
    }
}
