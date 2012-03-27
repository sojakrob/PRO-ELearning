using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ELearning.Shared
{
    public class CollectionUtility
    {
        private static Random _random = new Random(Environment.TickCount);


        public static List<T> Shuffle<T>(ICollection<T> collection)
        {
            T[] result = new T[collection.Count];
            collection.CopyTo(result, 0);

            byte[] randomIndices = GetRandomArray(result.Length);

            Array.Sort(randomIndices, result);

            return new List<T>(result);
        }
        private static byte[] GetRandomArray(int length)
        {
            byte[] randomIndices = new byte[length];

            lock (_random)
            {
                _random.NextBytes(randomIndices);
            }

            return randomIndices;
        }
    }
}
