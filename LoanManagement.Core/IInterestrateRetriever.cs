using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Core
{
    /// <summary>
    /// Retreives the current daily interest rate.
    /// </summary>
    public interface IInterestrateRetriever
    {
        /// <summary>
        /// Returns the current interest rates.
        /// </summary>
        /// <returns></returns>
        Decimal GetCurrentInterestRate();
    }
}
