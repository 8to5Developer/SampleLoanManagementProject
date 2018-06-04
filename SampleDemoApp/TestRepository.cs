using LoanManagement.Data;
using System;
using System.Collections.Generic;
using System.Text;
using LoanManagement.Models;
using LoanManagement.Models.Entities;

namespace SampleDemoApp
{
    public class TestRepository : IRepository
    {
        private VolatileStorage<Customer> CutomerStorage = new VolatileStorage<Customer>();

        private VolatileStorage<Loan> LoanStorage = new VolatileStorage<Loan>();

        private VolatileStorage<LoanProduct> LoanProductStorage = new VolatileStorage<LoanProduct>();

        public TestRepository()
        {
            var loanProductSmall = new LoanProduct() { ProductType = LoanProductType.Small };
            LoanProductStorage.Add(ref loanProductSmall);
        }

        public IStorage<Customer> Customers
        {
            get { return CutomerStorage; }
        }

        public IStorage<LoanProduct> LoanProducts
        {
            get { return LoanProductStorage; }
        }

        public IStorage<Loan> Loans
        {
            get { return LoanStorage; }
        }
    }
}
