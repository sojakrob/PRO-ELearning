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


        public static List<Model> CreateFromArray<Model>(IEnumerable<Data> array, params object[] args) 
            where Model : DataModelBase<Data>
        {
            List<Model> result = new List<Model>();

            int argsLength = args == null ? 0 :args.Length;

            Type[] types = new Type[argsLength + 1];
            types[0] = typeof(Data);
            for (int i = 0; i < argsLength; i++)
                types[i + 1] = args[i].GetType();

            System.Reflection.ConstructorInfo ci = typeof(Model).GetConstructor(types);
            if (ci == null)
                throw new ApplicationException(String.Format("Contstructor of model class not found - {0}({1})", typeof(Model), typeof(Data)));

            IEnumerator<Data> e = array.GetEnumerator();
            while (e.MoveNext())
                result.Add(ci.Invoke(new object[] { e.Current }.Concat(args).ToArray()) as Model);

            return result;
        }
       

    }
}
