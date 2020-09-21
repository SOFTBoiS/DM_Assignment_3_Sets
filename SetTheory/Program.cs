using System;

namespace SetTheory
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            long[] arr1 = {1,1,2,3,4,6};
            long[] arr2 = {4,6,5,10,11};
            long[] arr3 = {4,6,5,10,11,12,13,14,15};
            var a = new HashedSet(arr1);
            var b = new HashedSet(arr2);
            var c = new HashedSet(arr3);
            //var ab = a.Union(b);
            //var ab2 = new UnionSet(a, b);

            //ab.CompareTo(c);
        }
    }
}
