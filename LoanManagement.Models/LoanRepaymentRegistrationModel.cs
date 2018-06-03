using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Models
{
    public class LoanRepaymentRegistrationModel
    {
        /// <summary>
        /// Stores the loan number.
        /// </summary>
        public string LoanNumber { get; set; }
        /// <summary>
        /// Stores the customer person number.
        /// </summary>
        public string PersonNumber { get; set; }

        /// <summary>
        /// Stores the date in which the customer pays back the loan.
        /// </summary>
        public DateTime RepaymentDate { get; set; }



    }
}
