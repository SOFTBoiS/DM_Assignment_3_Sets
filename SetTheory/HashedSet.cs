using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetTheory
{
    class HashedSet : ISet<long>
    {
        public long[] Values { get; private set; }
        public long Length => Values.Length;
        public HashedSet(long[] set)
        {
            Values = set.Distinct().ToArray();
            Array.Sort(Values);
        }

        public int CompareTo(ISet<long> set)
        {
            throw new NotImplementedException();
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

        public int IndexOf(long value)
        {
            return Array.IndexOf(Values, value);
        }
    }
}
