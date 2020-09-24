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

        public int CompareTo(ISet<long> other)
        {
            if (other is HashedSet hs)
            {
                // This HashedSet is shorter than the other
                if (Length < hs.Length)
                {
                    if (Length > Rules.MaxValueToLoop) return 2;
                    for (var i = 0; i < hs.Length; i++)
                    {
                        if (Values[i] != hs.Values[i]) return -2;
                    }
                    return -1;
                }

                // Other is longer than this HashedSet
                if (hs.Length > Rules.MaxValueToLoop) return 2;
                for (var i = 0; i < Length; i++)
                {
                    if (hs.Values[i] != Values[i]) return -2;
                }

                return Length == hs.Length ? 0 : 1;
            }

            if (other is RangeSet rs)
            {
                var first = Values[0];
                var last = Values[^1];

                // Equals
                if (Length == rs.Length && rs.Min == first && rs.Max == last) return 0;

                if (rs.Length <= Rules.MaxValueToLoop) return 2;

                // If HashedSet length is smaller
                if (Length < rs.Length)
                {

                    foreach (var x in Values)
                    {
                        if (!IsMember(x))
                        {
                            return -2;
                        }
                    }
                    // RangeSet is pure superset of HashedSet
                    return 1;
                }

                // Else if RangeSet length is smaller

                // Because we loop through the shortest set, we won't loop if the set 
                if (Length >= Rules.MaxValueToLoop) return 2;

                // Find the smallest common value in the Hashed Set
                var minCommonMemberIndex = IndexOf(rs.Min);

                // If smallest common value is not found
                if (minCommonMemberIndex == -1)
                {
                    return -2;
                }

                // The current value in the RangedSet which we are using in the loop below.
                var currentValue = rs.Min;

                // If we have a common value in the RangedSet and HashedSet
                // We iterate through the HashedSet to try and figure out if the RangedSet
                // Is a pure subset of the HashedSet
                for (var i = minCommonMemberIndex; i <= rs.Max; i++, currentValue++)
                {
                    //Check for indexOutOfRange and if values is not member of HashedSet
                    if (i >= Length || Values[i] != currentValue)
                    {
                        return -2;
                    }
                }
                // RangeSet is pure subset of HashedSet
                return -1;
            }

            if (other is UnionSet us)
            {
                var res = us.CompareTo(this);
                if (res == 2 || res == -2) return res;
                // Because we use the "other" set's compareTo method,
                // We have to reverse the result value.
                return res * -1;
            }

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
