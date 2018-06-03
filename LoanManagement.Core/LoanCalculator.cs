using System;
using LoanManagement.Models;
using LoanManagement.Models.Entities;

namespace LoanManagement.Core
{
    public class LoanCalculator : ILoanCalculator
    {
        // <summary>
        /// Calculates the load cost for the product loand "small"
        /// </summary>
        /// <param name="loanCostModel">The loan cost model data.</param>
        /// <returns></returns>
        public decimal CalculateBigLoanCost(LoanCostModel loanCostModel)
        {
            if (loanCostModel == null)
            {
                throw new ArgumentNullException("loanCostModel");
            }

            return 100 +(loanCostModel.NumerOfDaysSincReceivingTheLoan * loanCostModel.CurrentInterestRate);
        }

        // <summary>
        /// Calculates the load cost for the product loand "small"
        /// </summary>
        /// <param name="loanCostModel">The loan cost model data.</param>
        /// <returns></returns>
        public decimal CalculateFastLoanCost(LoanCostModel loanCostModel)
        {
            if (loanCostModel == null)
            {
                throw new ArgumentNullException("loanCostModel");
            }
            
            return 500 + (loanCostModel.NumerOfDaysSincReceivingTheLoan * loanCostModel.CurrentInterestRate);
        }

        // <summary>
        /// Calculates the load cost for the product loand "small"
        /// </summary>
        /// <param name="loanCostModel">The loan cost model data.</param>
        /// <returns></returns>
        public decimal CalculateSmallLoanCost(LoanCostModel loanCostModel)
        {
            if (loanCostModel == null)
            {
                throw new ArgumentNullException("loanCostModel");
            }
            
            return  (loanCostModel.NumerOfDaysSincReceivingTheLoan * loanCostModel.CurrentInterestRate);
        }

        /// <summary>
        /// Calculates the loan cost for different loan types.
        /// </summary>
        /// <param name="loanType">The loan type.</param>
        /// <param name="loanCostModel">the cost model</param>
        /// <returns></returns>
        public decimal CalculateLoanCost(LoanProductType loanType, LoanCostModel loanCostModel)
        {
            switch (loanType)
            {
                case LoanProductType.Big:
                    return CalculateBigLoanCost(loanCostModel);
                case LoanProductType.Small:
                    return CalculateSmallLoanCost(loanCostModel);
                case LoanProductType.Fast:
                    return CalculateFastLoanCost(loanCostModel);
                default:
                    throw new Exception(string.Format("Invalid loan type '{0}'", loanType));
            }
        }
    }
}
