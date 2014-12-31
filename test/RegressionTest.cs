using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StatisticsSharp;

namespace StatisticsTest
{
    [TestClass]
    public class RegressionTest
    {
        /// <summary>
        /// 単回帰分析
        /// </summary>
        [TestMethod]
        public void Regression_Single_Test()
        {
            var y = new List<double>() { 
                10, 5, 5, 4, 4, 6, 6, 2, 1, 2, 7, 7, 9, 8, 4 
            };
            var x = new List<double>(){
                10, 4, 2, 2, 8, 9, 7, 5, 1, 3, 4, 6, 8, 11, 6
            };

            var regression = new Regression(y,x);
            Assert.AreEqual(0.589, regression.Coefficient()[0], 0.01);
            Assert.AreEqual(1.954, regression.Intercept(), 0.01);
        }
    }
}
