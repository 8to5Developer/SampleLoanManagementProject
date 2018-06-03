using LoanManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Models
{
    public class Customer:IEntity
    {
        /// <summary>
        /// Stores a unique id for the customer.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Stores the customer unique Identity.
        /// </summary>
        public string PersonNumber { get; set; }

        /// <summary>
        /// Defines the custom reference for the entity
        /// </summary>
        public string CustomReference => PersonNumber ;
    }
}
