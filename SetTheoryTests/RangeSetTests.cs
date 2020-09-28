using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetTheory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SetTheory.Tests
{
    [TestClass()]
    public class RangeSetTests
    {
        [TestMethod()]
        public void CompareToTestEquals()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, long.MaxValue);
            var rangeSet2 = new RangeSet(0, long.MaxValue);

            // Act
            var actual = rangeSet1.CompareTo(rangeSet2);

            // Assert
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareToTestPureSubset()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, 5_000_000);
            var rangeSet2 = new RangeSet(0, long.MaxValue);

            // Act
            var actual = rangeSet1.CompareTo(rangeSet2);

            // Assert
            var expected = -1;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void CompareToTestPureSuperset()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, 5_000_000);
            var rangeSet2 = new RangeSet(0, long.MaxValue);

            // Act
            var actual = rangeSet2.CompareTo(rangeSet1);

            // Assert
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareToTestNeitherSubset()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, 5_000_000);
            var rangeSet2 = new RangeSet(6_000_000, long.MaxValue);

            // Act
            var actual = rangeSet1.CompareTo(rangeSet2);

            // Assert
            var expected = -2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CompareToTestIndeterminable()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, 9_000_000_000);
            var values = new long[2_000_000];
            //for (var i = 0; i < values.Length; i++)
            //{
            //    values[i] = i;
            //}

            var hashedSet = new HashedSet(values);

            // Act
            var actual = rangeSet1.CompareTo(hashedSet);

            // Assert
            var expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void UnionTestTwoRangeSetsWithinRange()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, 5_000_000);
            var rangeSet2 = new RangeSet(200, 500);

            // Act
            var actual = rangeSet1.Union(rangeSet2);

            // Assert
            var expected = rangeSet1;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void UnionTestTwoRangeSetsOutOfRange()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, 5_000_000);
            var rangeSet2 = new RangeSet(-500, -1);

            // Act
            var actual = rangeSet1.Union(rangeSet2);

            // Assert
            var expected = new UnionSet(rangeSet1, rangeSet2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IntersectionTestTwoRangeSetsOutOfRange()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, 5_000_000);
            var rangeSet2 = new RangeSet(-500, -1);


            // Act
            var actual = rangeSet1.Intersection(rangeSet2);

            // Assert
            var expectedValues = new long[] { };
            var expected = new HashedSet(expectedValues);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IntersectionTestTwoRangeSetsInRange()
        {
            // Arrange
            var rangeSet1 = new RangeSet(0, 5_000_000);
            var rangeSet2 = new RangeSet(-500, 250);

            // Act
            var actual = rangeSet1.Intersection(rangeSet2);

            // Assert
            var expected = new RangeSet(0, 250);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IntersectionTestRangeSetAndSmallerHashedSet()
        {
            // Arrange
            var rangeSet = new RangeSet(0, 5_000_000);
            var values = new long[] { -1, 2, 4, 6, 8, 9, 10, 1_000_000_000 };
            var hs = new HashedSet(values);

            // Act
            var actual = rangeSet.Intersection(hs);

            // Assert
            var expectedValues = new long[] { 2, 4, 6, 8, 9, 10 };
            var expected = new HashedSet(expectedValues);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IntersectionTestRangeSetAndLargerHashedSet()
        {
            // Arrange
            var rangeSet = new RangeSet(0, 15);
            var values = new long[] { -1, 2, 4, 6, 8, 9, 10, 12, 14, 16, 17, 20, 24, 25, 26, 29, 30, 50, 1_000_000_000 };
            var hs = new HashedSet(values);

            // Act
            var actual = rangeSet.Intersection(hs);

            // Assert
            var expectedValues = new long[] { 2, 4, 6, 8, 9, 10, 12, 14 };
            var expected = new HashedSet(expectedValues);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void DifferenceTestRangeSets()
        {
            // Arrange
            var rangeSet1 = new RangeSet(-15, 20);
            var rangeSet2 = new RangeSet(0, 15);

            // Act
            var actual = rangeSet1.Difference(rangeSet2);

            // Assert
            var expectedRs1 = new RangeSet(-15, -1);
            var expectedRs2 = new RangeSet(16, 20);

            var expected = new UnionSet(expectedRs1, expectedRs2);

            Assert.AreEqual(expected, actual);
        }
    }
}