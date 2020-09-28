using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetTheory;
using System;
using System.Collections.Generic;
using System.Text;
using static SetTheory.Rules;

namespace SetTheory.Tests
{
    [TestClass()]
    public class HashedSetTests
    {
        [TestMethod()]
        public void CompareToEqualsTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { 1, 2, 3, 4, 5, 6 });
            var hs2 = new HashedSet(new long[] { 1, 2, 3, 4, 5, 6 });

            // Act 
            var actual = hs1.CompareTo(hs2);

            // Assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void CompareToPureSubSetTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { 1, 2, 3, 4 });
            var hs2 = new HashedSet(new long[] { 1, 2, 3, 4, 5, 6 });

            // Act 
            var actual = hs1.CompareTo(hs2);

            // Assert
            var expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareToPureSuperSetTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { 1, 2, 3, 4, 5, 6, 7 });
            var hs2 = new HashedSet(new long[] { 1, 2, 3, 4, 5, 6 });

            // Act 
            var actual = hs1.CompareTo(hs2);
            
            // Assert
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareToNotSubOrSuperSetTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { 1, 2, 3, });
            var hs2 = new HashedSet(new long[] { 2, 3, 4, 5, 6 });

            // Act 
            var actual = hs1.CompareTo(hs2);

            // Assert
            var expected = -2;
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod()]
        //[ExpectedException(typeof(Exception),
        //"Set size too large to calculate")]
        //public void ComplementSetSizeTooLargeTest()
        //{
        //    // Assemble
        //    var a = new List<long>();
        //    for (long i = 0; i < MaxValueToLoop+2; i++)
        //    {
        //        a.Add(i);
        //    }
        //    HashedSet hs = new HashedSet(a.ToArray());

        //    // Act
        //    hs.Complement();
        //}

        [TestMethod()]
        public void ComplementTest()
        {
            // Assemble
            HashedSet hs = new HashedSet(new long[]{1,2,5,6,8,10});
            
            var lowerBound = new RangeSet(long.MinValue, 1);
            var middleSet = new HashedSet(new long[]{3,4,7,9});
            var upperBound = new RangeSet(10, long.MaxValue);

            // Act
            var actual = hs.Complement();

            // Assert
            var expected = new ComplementOrDifferenceSet(lowerBound, middleSet, upperBound);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DifferenceTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { 1, 2, 3, });
            var hs2 = new HashedSet(new long[] { 2, 3, 4, 5, 6 });

            // Act 
            var actual = hs1.CompareTo(hs2);

            // Assert
            var expected = -2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IntersectionTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { 1, 2, 3, 4,5,6,7});
            var hs2 = new HashedSet(new long[] { 2, 3, 4,5,6,7,8,9,10});
            var expected = new HashedSet(new long[] {2, 3, 4, 5, 6, 7});

            // Act 
            var actual = hs1.Intersection(hs2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsMemberTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] {1, 2, 3, 4, 5});

            // Act
            var actual1 = hs1.IsMember(1);
            var actual2 = hs1.IsMember(3);
            var actual3 = hs1.IsMember(5);
            var actual4 = hs1.IsMember(10);

            // Assert
            var expected1 = true;
            var expected2 = true;
            var expected3 = true;
            var expected4 = false;

            Assert.AreEqual(actual1, expected1);
            Assert.AreEqual(actual2, expected2);
            Assert.AreEqual(actual3, expected3);
            Assert.AreEqual(actual4, expected4);
        }

        [TestMethod()]
        public void UnionTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { 1, 2, 3, 4,5,6,7});
            var hs2 = new HashedSet(new long[] { 2, 3, 4,5,6,7,8,9,10});
            // Act 
            var actual = hs1.Union(hs2);

            // Assert
            var expected = new UnionSet(hs1, hs2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { 1, 2, 3, 4,5,6,7});
            
            // Act
            var actual = hs1.IndexOf(1);

            // Assert
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}