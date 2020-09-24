using System;

namespace SetTheory
{
    class RangeSet : ISet<long>
    {
        private readonly long min;
        private readonly long max;
        public long Length => max - min;

        public RangeSet(long min, long max)
        {
            this.min = min;
            this.max = max;
        }

        public bool IsMember(long member)
        {
            return min <= member && member < max;
        }

        public ISet<long> Union(ISet<long> other)
        {
            if (other is RangeSet rs)
            {
                if (min > rs.max || rs.min > max)
                {
                    return new UnionSet(this, other);
                }

                var minVal = Math.Min(this.min, rs.min);
                var maxVal = Math.Max(this.max, rs.max);
                return new RangeSet(minVal, maxVal);
            }
            
            // TODO: Do the same for HashedSet
            return new UnionSet(this, other);
        }

        public ISet<long> Intersection(ISet<long> set)
        {
            throw new NotImplementedException();
        }

        public ISet<long> Difference(ISet<long> set)
        {
            throw new NotImplementedException();
        }

        public ISet<long> Complement()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(ISet<long> other)
        {
            if (other is RangeSet rs)
            {
                if (max == rs.max && min == rs.min) return 0;
                if (min >= rs.min && max <= rs.max) return -1;
                if (min <= rs.min && max >= rs.max) return 1;
                return -2;

            }


            if (other is HashedSet hs)
            {
                var first = hs.Values[0];
                var last = hs.Values[^1];
                var isPureSubset = IsMember(first) && IsMember(last);
                bool isPureSuperset;


                // Equals
                if (Length == hs.Length && min == first && max == last) return 0;


                // TODO: Lav to loops, hvor vi kun kommer ind i loopet, alt efter, hvilken der er kortest (check på length)

                if (Length < hs.Length)
                {
                    if (Length >= Rules.MaxValueToLoop) return 2;

                    // Find the smallest common value in the Hashed Set
                    var minCommonMember = hs.IndexOf(min);

                    // If smallest common value is not found
                    if (minCommonMember == -1)
                    {
                        return -2;
                    }

                    // The current value in the RangedSet which we are using in the loop below.
                    var currentValue = min;

                    // If we have a common value in the RangedSet and HashedSet
                    // We iterate through the HashedSet to try and figure out if the RangedSet
                    // Is a pure subset of the HashedSet
                    for (var i = minCommonMember; i < max; i++, currentValue++)
                    {
                        //Check for indexOutOfRange and if values is not member of HashedSet
                        if (i >= hs.Values.Length || hs.Values[i] != currentValue)
                        {
                            return -2;
                        }
                    }
                    // RangeSet is pure subset of HashedSet
                    return -1;
                }

                // Else if HashSet length is smaller
                if (hs.Length <= Rules.MaxValueToLoop) return 2;

                foreach (var x in hs.Values)
                {
                    if (!IsMember(x))
                    {
                        return -2;
                    }
                }
                // RangeSet is pure superset of HashedSet
                return 1;


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
    }
}
