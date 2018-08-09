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
    }
}
