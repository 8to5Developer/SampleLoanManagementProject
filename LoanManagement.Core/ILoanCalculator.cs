using LoanManagement.Models;
using LoanManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Core
{
    public interface ILoanCalculator
    {
        /// <summary>
        /// Calculates the load cost for the product loand "small"
        /// </summary>
        /// <param name="loanCostModel">The loan cost model data.</param>
        /// <returns></returns>
        Decimal CalculateSmallLoanCost(LoanCostModel loanCostModel);
        /// <summary>
        /// Calculates the load cost for the product loand "Big"
        /// </summary>
        /// <param name="loanCostModel">The loan cost model data.</param>
        /// <returns></returns>
        Decimal CalculateBigLoanCost(LoanCostModel loanCostModel);

        /// <summary>
        /// Calculates the load cost for the product loand "Fast"
        /// </summary>
        /// <param name="loanCostModel">The loan cost model data.</param>
        /// <returns></returns>
        Decimal CalculateFastLoanCost(LoanCostModel loanCostModel);


        /// <summary>
        /// Calculates the loan cost for different loan types.
        /// </summary>
        /// <param name="loanType">The loan type.</param>
        /// <param name="loanCostModel">the cost model</param>
        /// <returns></returns>
        Decimal CalculateLoanCost(LoanProductType loanType, LoanCostModel loanCostModel);
        
    }
}
