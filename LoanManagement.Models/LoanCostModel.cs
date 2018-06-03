using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Models
{
    public class LoanCostModel
    {
        /// <summary>
        /// Stores the date that the load was payed to the customer.
        /// </summary>
        public DateTime LoanPaymentDate { get; set; }
        /// <summary>
        /// Stores the date the customer pays back the loan.
        /// </summary>
        public DateTime LoanRepaymentDate { get; set; }

        /// <summary>
        /// Stores the current interest rate value.
        /// </summary>
        public Decimal CurrentInterestRate { get; set; }

        /// <summary>
        /// Stores the number of days since receiving the loan.
        /// </summary>
        public int NumerOfDaysSincReceivingTheLoan
        {
            get
            {
                return (LoanRepaymentDate - LoanPaymentDate).Days;
            }
        }
    }
}
