using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public abstract class DataModelBase<T> where T : class
    {
        public DataModelBase()
        {
        }
        public abstract DataModelBase(T data)
        {
        }


        
        public static IEnumerable<T> CreateFromArray<U>(IEnumerable<T> array) where U : DataModelBase<T>
        {
            List<U> result = new List<U>();

            IEnumerator<T> e = array.GetEnumerator();
            while(e.MoveNext())
            {
                System.Reflection.ConstructorInfo ci = typeof(U).GetConstructor(new [] { typeof(T) });
                result.Add(ci.Invoke(new object[] { e.Current }) as U);
            }

            return result;
            // TODO Write Unit test
        }
    }
}
