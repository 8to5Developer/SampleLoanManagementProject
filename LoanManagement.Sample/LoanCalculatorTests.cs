using LoanManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoandManagementX.Tests.LoanManagement.CoreTests
{
    public class LoanCalculatorTests
    {
        
        public void Test_CalculateBigLoanCost_Throws_ArgumentNullException()
        {
            var loanCalculator = new LoanCalculator();
            Assert.Throws<ArgumentNullException>("loanCostModel", ()=>loanCalculator.CalculateBigLoanCost(null));
        }
    }
}
