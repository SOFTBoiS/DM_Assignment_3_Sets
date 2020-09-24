 using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheory
{
    class UnionSet : ISet<long>
    {
        private ISet<long> first;
        private ISet<long> second;

        public UnionSet(ISet<long> first, ISet<long> second)
        {
            this.first = first;
            this.second = second;
        }

        public int CompareTo(ISet<long> set)
        {
            var a = first.CompareTo(set);
            var b = second.CompareTo(set);

            // If either of the results are indeterminable, the whole equation is indeterminable
            if (a == 2 || b == 2) return 2;

            // C is a pure subset to either a or b, therefore c is a pure subset to to the whole unionset
            if (a == 1 || b == 1) return 1;

            // Now a and b can only equal -1 or 0. 
            // If a == -1 and b == 0.
            // Here a is a pure subset of c and c is equal to b, then a is a pure subset of b as well.
            // and c is equal to b.
            if (a == 0 || b == 0) return 0;

            // If a is not a subset of b, and b is not a subset of a.
            if (a == -2 || b == -2) return -2;

            // This can either return -1, 0 or 1, but is indeterminable which one it is (unless further logic is implementet)
            return 2;
            // TODO: implement feature to compress sets so we can figure out if we can return -1
        }

        public ISet<long> Complement()
        {
            throw new NotImplementedException();
        }

        public ISet<long> Difference(ISet<long> set)
        {
            throw new NotImplementedException();
        }

        public ISet<long> Intersection(ISet<long> set)
        {
            throw new NotImplementedException();
        }

        public bool IsMember(long set)
        {
            throw new NotImplementedException();
        }

        public ISet<long> Union(ISet<long> other)
        {

            return new UnionSet(this, other);
        }
    }

}
