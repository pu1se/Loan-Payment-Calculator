using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LoanPaymentCalculator
{
    class Program
    {
        static readonly LoanPaymentCalculationService Service = new LoanPaymentCalculationService();

        static void Main(string[] args)
        {
            var model = ReadAndValidateLoanModel();

            var paymentEntity = Service.CalculatePayments(model.ToEntity());

            var json = paymentEntity.ToJson();
            json = json.Replace(",", ","+Environment.NewLine)
                       .Replace("{", "{"+Environment.NewLine)
                       .Replace("}", Environment.NewLine+"}");
            Console.WriteLine(json);
            Console.ReadLine();
        }



        #region Read and Validate Model

        static LoanValidationModel ReadAndValidateLoanModel()
        {
            LoanValidationModel model = null;

            do
            {

                if (model != null)
                {
                    ShowValidationError(model.GetValidationError());
                }

                Console.WriteLine("```");
                model = new LoanValidationModel
                {
                    LoanAmount = ReadValueFor<LoanValidationModel>(x=>x.LoanAmount),
                    Percent = ReadValueFor<LoanValidationModel>(x=>x.Percent),
                    DownPaymentAmount = ReadValueFor<LoanValidationModel>(x=>x.DownPaymentAmount),
                    TermInYears = ReadValueFor<LoanValidationModel>(x=>x.TermInYears),
                };
                Console.ReadLine();
                Console.WriteLine("```");

            } while (!model.IsValid());


            return model;
        }

        private static void ShowValidationError(string validationErrors)
        {
            Console.WriteLine("Validation error:");
            Console.WriteLine(validationErrors);
            Console.WriteLine("Please try again...");
            Console.WriteLine();
        }

        static string ReadValueFor<T>(Expression<Func<T, object>> expression)
        {
            var propertyDisplayName = AttributeHelper.GetPropertyDisplayName(expression);

            Console.Write(propertyDisplayName + ": ");
            var value = Console.ReadLine();
            return value;
        }

        #endregion Read and Validate Model
    }
}
