using LoanManagement.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoandManagement.Tests
{
    public class LoanCalculatorTests
    {
        [Fact]
        [Trait("CoreTests","Calculator")]
        public void Test_CalculateBigLoanCost_Throws_ArgumentNullException()
        {
            var loanCalculator = new LoanCalculator();
            Assert.Throws<ArgumentNullException>("loanCostModel", ()=>loanCalculator.CalculateBigLoanCost(null));
        }

        [Fact]
        [Trait("CoreTests", "Calculator")]
        public void Test_CalculateBigLoanCost_Succeeds()
        {
            var loanCalculator = new LoanCalculator();

            decimal actual = loanCalculator.CalculateBigLoanCost(
                new LoanManagement.Models.LoanCostModel() {
                    CurrentInterestRate = 0.25M,
                    LoanPaymentDate = new DateTime(2016, 10, 1),
                    LoanRepaymentDate= new DateTime(2018,10,1)
                });

            Assert.Equal(282.5M, actual);
        }
        [Fact]
        [Trait("CoreTests", "Calculator")]
        public void Test_CalculateSmallLoanCost_Throws_ArgumentNullException()
        {
            var loanCalculator = new LoanCalculator();
            Assert.Throws<ArgumentNullException>("loanCostModel", () => loanCalculator.CalculateBigLoanCost(null));
        }

        [Fact]
        [Trait("CoreTests", "Calculator")]
        public void Test_CalculateSmallLoanCost_Succeeds()
        {
            var loanCalculator = new LoanCalculator();

            decimal actual = loanCalculator.CalculateSmallLoanCost(
                new LoanManagement.Models.LoanCostModel()
                {
                    CurrentInterestRate = 0.25M,
                    LoanPaymentDate = new DateTime(2016, 10, 1),
                    LoanRepaymentDate = new DateTime(2018, 10, 1)
                });

            Assert.Equal(182.5M, actual);
        }

        [Fact]
        [Trait("CoreTests", "Calculator")]
        public void Test_CalculateFastLoanCost_Throws_ArgumentNullException()
        {
            var loanCalculator = new LoanCalculator();
            Assert.Throws<ArgumentNullException>("loanCostModel", () => loanCalculator.CalculateFastLoanCost(null));
        }

        [Fact]
        [Trait("CoreTests", "Calculator")]
        public void Test_CalculateFastLoanCost_Succeeds()
        {
            var loanCalculator = new LoanCalculator();

            decimal actual = loanCalculator.CalculateFastLoanCost(
                new LoanManagement.Models.LoanCostModel()
                {
                    CurrentInterestRate = 0.25M,
                    LoanPaymentDate = new DateTime(2016, 10, 1),
                    LoanRepaymentDate = new DateTime(2018, 10, 1)
                });

            Assert.Equal(682.5M, actual);
        }
    }
}
