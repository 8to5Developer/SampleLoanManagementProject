using LoanManagement.Core.Logging;
using LoanManagement.Data;
using LoanManagement.Models;
using LoanManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Core
{
    /// <summary>
    /// Handles different loan related services.
    /// </summary>
    public class LoanHandlingService
    {
        /// <summary>
        /// Stores an instance of the respository interface.
        /// </summary>
        private IRepository Repository { get; set; }

        /// <summary>
        /// Stores the loan calculator interface.
        /// </summary>
        private ILoanCalculator  LoanCalculator { get; set; }

        /// <summary>
        /// Stores the instance of the insterest rate retreiver.
        /// </summary>
        public IInterestrateRetriever InterestrateRetriever { get; set; }

        /// <summary>
        /// Stores an instance of the log handler unit.
        /// </summary>
        public ILog LogHandler { get; set; }


        #region Constructor

        /// <summary>
        /// The constructor for the class.
        /// </summary>
        /// <param name="repository">The instance of the repository interface.</param>
        /// <param name="loanCalculator">The instance of the loan calculator object,</param>
        public LoanHandlingService(IRepository repository,ILoanCalculator loanCalculator)
        {
            Repository = repository;
            LoanCalculator = loanCalculator;
        }

        #endregion

        /// <summary>
        /// Registers a new loan in the system.
        /// </summary>
        /// <param name="newLoanDetails">The new loan registration information.</param>
        public bool RegisterLoan(LoanRegistrationModel newLoanDetails)
        {
            var newCustomer = new Customer() { PersonNumber = newLoanDetails.PersonNumber };
            bool newCustomerAdded=Repository.Customers.Add(ref newCustomer);

            if(!newCustomerAdded)
            {
                LogHandler.Log(LogLevel.Error, "Failure while registering the new customer") ;
                return false;
            }

            LoanProduct selectedProduct = Repository.LoanProducts.Get(newLoanDetails.LoanProductId);
            if(selectedProduct==null)
            {
                LogHandler.Log(LogLevel.Error,"Can not find the selected loan product.");
                return false;
            }
        
            Loan loan = newLoanDetails.ToLoan();
            loan.Customer = newCustomer;
            loan.LoanProduct = selectedProduct;

            bool loanSaved= Repository.Loans.Add(ref loan);

            if(!loanSaved)
            {
                LogHandler.Log(LogLevel.Error,"Failure while saving the new loan.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Registers the repayment information for a loan.
        /// </summary>
        /// <param name="repaymentDetails">The repayment details.</param>
        /// <returns>if the operation has succeeded.</returns>
        public bool RegisterLoanRepayment(LoanRepaymentRegistrationModel repaymentDetails)
        {
            Loan existingLoan = Repository.Loans.FindByCustomReference(repaymentDetails.LoanNumber);

            if(existingLoan==null)
            {
               LogHandler.Log(LogLevel.Error,"can not find the select loan");
                return false;
            }

            LoanProductType loanType = existingLoan.LoanProduct.ProductType;
            Decimal amountToPay = LoanCalculator.CalculateLoanCost(loanType, new LoanCostModel()
            {
                LoanPaymentDate = existingLoan.PaymentDate,
                LoanRepaymentDate = repaymentDetails.RepaymentDate,
                CurrentInterestRate = InterestrateRetriever.GetCurrentInterestRate()
            });

            existingLoan.RepaymentAmount = amountToPay;
            existingLoan.RepaymentDate = repaymentDetails.RepaymentDate;
            Repository.Loans.Update(existingLoan);

            return true;
        }
    }
}
