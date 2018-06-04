using LoanManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDemoApp
{
    public class TestInterestRateService : IInterestrateRetriever
    {
        public decimal GetCurrentInterestRate()
        {
            return 0.25M;
        }
    }
}
