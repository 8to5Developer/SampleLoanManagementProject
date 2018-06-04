using LoanManagement.Core;
using LoanManagement.Models;
using System;

namespace SampleDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new TestRepository();
            var loanHandler = new LoanHandlingService(repository, new LoanCalculator())
            {
                InterestrateRetriever = new TestInterestRateService(),
                LogHandler = new ConsoleLogHandler()
            };

            //registering a new loan 
            LoanProduct loanProductSmall = repository.LoanProducts.Get(1);
            loanHandler.RegisterLoan(new LoanManagement.Models.LoanRegistrationModel()
            {
                LoanNumber="#1", ExtraCosts=0,
                LoanProductId= loanProductSmall.Id,
                PersonNumber="750312-1234",
                PaymentDate= new DateTime(2017,01,01)
            });

            Loan savedLoan = repository.Loans.FindByCustomReference("#1");
            if(savedLoan!=null)
            {
                Console.WriteLine("Found a new registered loan with loan Number = {0}" +
                    " {3} and loan product type = {1}" +
                    " {3} and person number = {2}",
                    savedLoan.LoanNumber, savedLoan.LoanProduct.ProductType, 
                    savedLoan.Customer.PersonNumber, Environment.NewLine);

                Console.WriteLine("Press Enter to Continue");
                Console.ReadLine();
            }

            Console.WriteLine("Registering the reypament of the previous loan");
            loanHandler.RegisterLoanRepayment(new LoanRepaymentRegistrationModel()
            {
                LoanNumber= "#1",
                PersonNumber= "750312-1234",
                RepaymentDate= new DateTime(2018,06,01)
            });

            savedLoan = repository.Loans.FindByCustomReference("#1");
            if (savedLoan != null)
            {
                Console.WriteLine("The amount to payback for the loan with number ={0} {3}" +
                    " and loan product type = {1} = {2} ",
                   savedLoan.LoanNumber, savedLoan.LoanProduct.ProductType, savedLoan.RepaymentAmount,
                   Environment.NewLine);

            }

            Console.ReadLine();

        }
    }
}