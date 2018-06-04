using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Models.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// Stores the Identifier.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// A custom reference.
        /// </summary>
        string CustomReference { get; }
    }
}
