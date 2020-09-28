using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetTheory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheory.Tests
{
    [TestClass()]
    public class UnionSetTests
    {
        [TestMethod()]
        public void CompareToUnionSetIsPureSupersetToHashedSetTest()
        {

            // Assemble
            var hs1 = new HashedSet(new long[] { -1, 0, 1, 2, 3 });
            var hs2 = new HashedSet(new long[] { 4, 5, 6, 7, 8 });
            var hs3 = new HashedSet(new long[] { 1, 2, 3 });

            var us = new UnionSet(hs1, hs2);


            // Act
            var expected = 1;
            var actual = us.CompareTo(hs3);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        public void CompareToNoPureSubSetsTest()
        {

            // Assemble
            var hs1 = new HashedSet(new long[] { -1, 0, 1, 2, 3 });
            var hs2 = new HashedSet(new long[] { 4, 5, 6, 7, 8 });
            var hs3 = new HashedSet(new long[] { 10, 11, 12 });

            var us = new UnionSet(hs1, hs2);


            // Act
            var expected = 2;
            var actual = us.CompareTo(hs3);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void CompareToIndeterminableTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { -1, 0, 1, 2, 3 });
            var hs2 = new HashedSet(new long[] { 4, 5, 6, 7, 8 });
            var us = new UnionSet(hs1, hs2);

            var rs3 = new RangeSet(long.MinValue, long.MaxValue);

            // Act
            var expected = 2;
            var actual = us.CompareTo(rs3);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareToUnionSetIsPureSubsetToRangedSetTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { -1, 0, 1, 2, 3 });
            var hs2 = new HashedSet(new long[] { 4, 5, 6, 7, 8 });
            var us = new UnionSet(hs1, hs2);

            var rs3 = new RangeSet(-1, 3);

            // Act
            var expected = -1;
            var actual = us.CompareTo(rs3);

            //Assert
            Assert.AreEqual(expected, actual);


        }

        [TestMethod()]
        public void CompareToUnionSetIsEqualToRangedSetTest()
        {
            // Assemble
            var hs1 = new HashedSet(new long[] { -1, 0, 1, 2, 3 });
            var hs2 = new HashedSet(new long[] { -1, 0, 1, 2, 3, 4, 5});
            var us = new UnionSet(hs1, hs2);

            var rs3 = new RangeSet(-1, 5);

            // Act
            var expected = 0;
            var actual = us.CompareTo(rs3);

            //Assert
            Assert.AreEqual(expected, actual);


        }
    }
}