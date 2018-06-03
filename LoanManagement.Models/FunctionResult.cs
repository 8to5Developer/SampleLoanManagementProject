using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Models
{
   public class FunctionResult
    {
        /// <summary>
        /// Specifies if the function's operation has succeeded.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Stores a custom message.
        /// </summary>
        public string Message { get; set; }
    }
}
