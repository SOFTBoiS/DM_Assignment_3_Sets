using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheory
{
    class RangeSet : ISet<long>
    {
        private readonly long min;
        private readonly long max;
        
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
                var first = hs.Set[0];
                var last = hs.Set[^1];

                var isPureSubset = IsMember(first) && IsMember(last);
                bool isPureSuperset;

                var rangeSetLength = max - min;
                // Equals
                if (rangeSetLength == hs.Length && min == first && max == last) return 0;

                // TODO: Lav to loops, hvor vi kun kommer ind i loopet, alt efter, hvilken der er kortest (check på length)
                foreach (var x in hs.Set)
                {
                    if (!IsMember(x))
                    {
                        isPureSubset = false;
                        break;
                    }
                }
               // return 
            }
            throw new NotImplementedException();
        }
    }
}
