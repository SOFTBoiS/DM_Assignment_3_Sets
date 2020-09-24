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
            var a = new RangeSet(0, 100);
            var b = new RangeSet(50, 110);
           // var c = new RangeSet(long.MinValue, 0);
            
            // Compare b to a = -1
            Console.WriteLine(b.CompareTo(a));
            // Compare a to b = 1
            Console.WriteLine(a.CompareTo(b));

            var d = new RangeSet(80,105);
            var e = new RangeSet(0, 110);

            var ab = a.Union(b);
            //var abc = ab.Union(c);

            Console.WriteLine("Rangeset d is superset to unionset ab" + d.CompareTo(ab));
            Console.WriteLine("Unionset ab is subset to d" + ab.CompareTo(d));
            Console.WriteLine("ab equals e = " + ab.CompareTo(e));


            //var ab = a.Union(b);
            //var ab2 = new UnionSet(a, b);

            //ab.CompareTo(c);
        }
    }
}
