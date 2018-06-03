using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Models
{
    public class LoanRegistrationModel
    {
        //Stores the loan number.
        public string LoanNumber { get; set; }

        /// <summary>
        /// Stores the customer unique Identity.
        /// </summary>
        public string PersonNumber { get; set; }

        /// Stores the payment date of the loan to the customer.
        /// </summary>
        public DateTime PaymentDate { get; set; }
        /// <summary>
        /// Stores the Extra costs of the customer.
        /// </summary>
        public Decimal ExtraCosts { get; set; }
        /// <summary>
        /// Stores the id of the selected loan product.
        /// </summary>
        ///  
        public int LoanProductId { get; set; }

        /// <summary>
        /// Convert the current object to an instance of the Loan class object.
        /// </summary>
        /// <returns></returns>
        public Loan ToLoan()
        {
            return new Loan()
            {
                 LoanNumber=LoanNumber,
                 ExtraCosts=ExtraCosts,
                 PaymentDate=PaymentDate
            };
        }
    }
}
