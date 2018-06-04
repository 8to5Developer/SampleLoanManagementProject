using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Data
{
    public interface IStorage<IEntity>
    {   
        /// <summary>
        /// Stores the record in the storage.
        /// </summary>
        /// <param name="record"></param>
        bool Add(ref IEntity record);

        /// <summary>
        /// Updates the record in the storage.
        /// </summary>
        /// <param name="record"></param>
        void Update(IEntity record);

        /// <summary>
        /// Returns a record by searching for the Id.
        /// </summary>
        /// <param name="id">The unique Identifier for the record.</param>
        /// <returns></returns>
        IEntity Get(int id);

        /// <summary>
        /// Finds a record based on a specific provided reference.
        /// </summary>
        /// <param name="referenceNumber">The custom reference used to find to record.</param>
        /// <returns></returns>
        IEntity FindByCustomReference(string referenceNumber);
    }
}
