using Microsoft.VisualStudio.TestTools.UnitTesting;
using SetTheory;

namespace SetTheoryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RangeSetCompareToEquals()
        {
            // Arrange
            var range1 = new RangeSet(0, long.MaxValue);
            var range2 = new RangeSet(0, long.MaxValue);

            // Act
            var res = range1.CompareTo(range2);
            // Assert
            var actual = 0;
            
        }
    }
}
