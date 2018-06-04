using LoanManagement.Data;
using LoanManagement.Models;
using System;
using System.Collections.Generic;

using System.Text;
using LoanManagement.Models.Entities;
using System.Linq;

namespace SampleDemoApp
{
    /// <summary>
    /// Defines a sample volatile storage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VolatileStorage<T> : IStorage<T> where T:IEntity
    {
        private List<T> Storage = new List<T>();

        private int counter = 0;

        public bool Add(ref T record)
        {
             record.Id = ++counter;
            Storage.Add(record);
            return true;
        }

        T IStorage<T>.FindByCustomReference(string referenceNumber)
        {
            return Storage.Where(x => x.CustomReference == referenceNumber).FirstOrDefault();
        }

        public IEntity Get(int id)
        {
            return Storage.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Update(T record)
        {
            T element = Storage.Where(x => x.Id == record.Id).FirstOrDefault();
            if (record != null)
            {
                Storage.Remove(element);
                Storage.Add(record);
            }
        }        

        T IStorage<T>.Get(int id)
        {
            return Storage.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
