using LoanManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleDemoApp
{
    /// <summary>
    /// Defines a sample volatile storage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class VolatileStorage<IEntity> : IStorage<IEntity>
    {
        private List<IEntity> Storage = new List<IEntity>();

        public bool Add(ref IEntity record)
        {
            throw new NotImplementedException();
        }

        public IEntity FindByCustomReference(string referenceNumber)
        {
            throw new NotImplementedException();
        }

        public IEntity Get(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(IEntity record)
        {
            throw new NotImplementedException();
        }
    }
}
