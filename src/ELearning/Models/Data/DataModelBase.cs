using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELearning.Data;

namespace ELearning.Models.Data
{
    public abstract class DataModelBase<Data> 
        where Data : class
    {
        public DataModelBase()
        {
        }
        public DataModelBase(Data data)
        {
        }


        public abstract Data ToData();


        public static List<Model> CreateFromArray<Model>(IEnumerable<Data> array) 
            where Model : DataModelBase<Data>
        {
            List<Model> result = new List<Model>();

            System.Reflection.ConstructorInfo ci = typeof(Model).GetConstructor(new[] { typeof(Data) });
            if (ci == null)
                throw new ApplicationException(String.Format("Contstructor of model class not found - {0}({1})", typeof(Model), typeof(Data)));

            IEnumerator<Data> e = array.GetEnumerator();
            while (e.MoveNext())
                result.Add(ci.Invoke(new object[] { e.Current }) as Model);

            return result;
        }

    }
}
