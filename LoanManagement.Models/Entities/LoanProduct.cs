using LoanManagement.Models.Entities;
using System;

namespace LoanManagement.Models
{
    public class LoanProduct:IEntity
    {
        /// <summary>
        /// Stores the unique identity for the product.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Stores the product type. 
        /// </summary>
        public LoanProductType ProductType { get; set; }

        /// <summary>
        /// Defines the custom reference for the entity.
        /// </summary>
        public string CustomReference => Id.ToString();
    }
}
