using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StatisticsSharp;

namespace StatisticsTest
{
    /// <summary>
    /// Summary description for ProbabilityTest
    /// </summary>
    [TestClass]
    public class ProbabilityTest
    {
        /// <summary>
        /// 相関係数（1.0）
        /// </summary>
        [TestMethod]
        public void CorrelationCoefficient_10()
        {
            var x = new List<double>() { 1, 2, 3 };
            var y = new List<double>() { 1, 2, 3 };
            Assert.AreEqual(1, ProbabilityLib.CorrelationCoefficient(x, y), 0.01);
        }

        /// <summary>
        /// 相関係数（0.822）
        /// </summary>
        [TestMethod]
        public void CorrelationCoefficient_08()
        {
            var x = new List<double>() { 
                1.996, 2.765, 3.645 , 4.148, 4.984, 5.340, 5.535, 6.214, 6.621, 7.582, 7.607, 8.474, 9.383, 9.579, 9.812, 9.915
            };
            var y = new List<double>() { 
                2.672, 1.502, 1.226 , 3.267, 3.525, 1.835, 3.317, 4.528, 3.199, 2.853, 6.292, 7.319, 4.381, 6.707, 6.953, 7.068
            };
            Assert.AreEqual(0.822, ProbabilityLib.CorrelationCoefficient(x, y), 0.01);
        }


    }
}
