using LoanManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Models
{
    public class Loan:IEntity
    {
        /// <summary>
        /// Stores the unique Identity for the loan.
        /// </summary>
        public int Id { get; set; }

        //Stores the loan number.
        public string LoanNumber { get; set; }
        /// <summary>
        /// Stores the payment date of the loan to the customer.
        /// </summary>
        public DateTime PaymentDate { get; set; }
        /// <summary>
        /// Stores the Extra costs of the customer.
        /// </summary>
        public Decimal ExtraCosts { get; set; }      
        /// <summary>
        /// Stores the selected loan product.
        /// </summary>
        public LoanProduct LoanProduct{ get; set; }

        /// <summary>
        /// Stores the customer information.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Stores the date in which the customer pays back the loan.
        /// </summary>
        public DateTime RepaymentDate { get; set; }
        /// <summary>
        /// The amount to be payed back by the customer.
        /// </summary>
        public Decimal RepaymentAmount { get; set; }

        /// <summary>
        /// Defines the custom reference for the entity.
        /// </summary>
        public string CustomReference => LoanNumber;
    }
}
