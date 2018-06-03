using LoanManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Data
{
    public interface IRepository
    {
        /// <summary>
        /// Stores the list of customers.
        /// </summary>
        IStorage<Customer> Customers { get; set; }
        /// <summary>
        /// Stores the list of loan products.
        /// </summary>
        IStorage<LoanProduct> LoanProducts { get; set; }
        /// <summary>
        /// Stores the set of loans.
        /// </summary>
        IStorage<Loan> Loans { get; set; }
    }
}
