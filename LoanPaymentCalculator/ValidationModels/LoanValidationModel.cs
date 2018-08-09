using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace LoanPaymentCalculator
{
    class LoanValidationModel : BaseValidationModel<LoanEntity>
    {
        [Required]
        [Display(Name = "amount")]
        [StringLength(12)]
        [RegularExpression(RegexpRepository.DecimalNumber, ErrorMessage = "The field amount must contains only numbers and dot.")]
        public string LoanAmount { get; set; }

        [Required]
        [Display(Name = "interest")]
        [StringLength(8)]
        [RegularExpression(RegexpRepository.Percent, ErrorMessage = "The field interest must be a float number with % at the end. For example \"5.5%\".")]
        public string Percent { get; set; }

        [Required]
        [Display(Name = "downpayment")]
        [StringLength(12)]
        [RegularExpression(RegexpRepository.DecimalNumber, ErrorMessage = "The field downpayment must contains only numbers and dot.")]
        public string DownPaymentAmount { get; set; }

        [Required]
        [Display(Name = "term")]
        [StringLength(2, ErrorMessage = "Maximun term value is 99")]
        [RegularExpression(RegexpRepository.IntegerNumber, ErrorMessage = "The field term must be an integer number.")]
        public string TermInYears { get; set; }


        public override LoanEntity ToEntity()
        {
            Percent = Percent.Replace("%", string.Empty);

            var result = new LoanEntity();
            result.LoanAmount = decimal.Parse(LoanAmount, CultureInfo.InvariantCulture);
            result.Percent = decimal.Parse(Percent, CultureInfo.InvariantCulture);
            result.DownPaymentAmount = decimal.Parse(DownPaymentAmount, CultureInfo.InvariantCulture);
            result.TermInYears = int.Parse(TermInYears);

            return result;
        }
    }
}
