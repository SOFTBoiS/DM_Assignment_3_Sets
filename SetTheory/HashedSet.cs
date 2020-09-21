using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetTheory
{
    class HashedSet : ISet<long>
    {
        public long[] Set { get; private set; }
        public long Length => Set.Length;
        public HashedSet(long[] set)
        {
            Set = set.Distinct().ToArray();
            Array.Sort(Set);
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
    }
}
