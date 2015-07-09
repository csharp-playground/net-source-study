using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSourceStudy
{
    public class ArraySpec
    {
        [Test]
        public void ShouldCreateNoneZeroBaseArray()
        {
            Array i2 = Array.CreateInstance(typeof(int), new int[] { 2 }, new int[] { 100 });
            i2.SetValue(1234, 100); // same as: i2[100] = 1234;
            int a = (int)i2.GetValue(100); // same as: int a = i2[100];

            Assert.AreEqual(1, i2.Rank);
        }
        [Test]
        public void ShoudCreateNonZero()
        {
            var dimension = new Int32[] { 2 };
            var lowerBound = new Int32[] { 2 };
            var array = Array.CreateInstance(typeof(String), dimension, lowerBound);

            Assert.AreEqual(1, array.Rank);

            array.SetValue("10", 2);
            array.SetValue("20", 3);

            var e1 = array.GetValue(2);
            Assert.AreEqual("10", e1);

            var e2 = array.GetValue(3);
            Assert.AreEqual("20", e2);

            var len = array.GetLength(0);
            Assert.AreEqual(2, len);

            var low = array.GetLowerBound(0);
            var high = array.GetLongLength(0);

            Assert.AreEqual(2, low);
            Assert.AreEqual(2, high);
        }
    }
}
