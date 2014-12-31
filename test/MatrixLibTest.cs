using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using StatisticsSharp;


namespace StatisticsTest
{
    [TestClass]
    public class MatrixLibTest
    {
        /// <summary>
        /// 逆行列（２×２）
        /// </summary>
        [TestMethod]
        public void InverseMatrix_2_Test()
        {
            var matrix = new double[,]{
                { 1, 2},
                { 3, 4}
            };
            var result = MatrixLib.InverseMatrix(matrix);

            // 変換後の結果表示
            Assert.AreEqual(-2, result[0, 0], 0.0001);
            Assert.AreEqual(1, result[0, 1], 0.0001);
            Assert.AreEqual((double)3/2, result[1, 0], 0.0001);
            Assert.AreEqual((double)-1/2, result[1, 1], 0.0001);

            // 変換前の値に影響がないこと
            Assert.AreEqual(1, matrix[0, 0], 0.0001);
            Assert.AreEqual(2, matrix[0, 1], 0.0001);
            Assert.AreEqual(3, matrix[1, 0], 0.0001);
            Assert.AreEqual(4, matrix[1, 1], 0.0001);
        }

        /// <summary>
        /// 逆行列（３×３）
        /// </summary>
        [TestMethod]
        public void InverseMatrix_3_Test()
        {
            var matrix = new double[,]{
                { 1, 2, 1},
                { 2, 1, 0},
                { 1, 1, 2}
            };
            var result = MatrixLib.InverseMatrix(matrix);

            // 変換後の結果表示
            Assert.AreEqual((double)-2 / 5, result[0, 0], 0.0001, "[0,0]");
            Assert.AreEqual((double)3 / 5, result[0, 1], 0.0001, "[0,1]");
            Assert.AreEqual((double)1 / 5, result[0, 2], 0.0001, "[0,2]");
            Assert.AreEqual((double)4 / 5, result[1, 0], 0.0001, "[1,0]");
            Assert.AreEqual((double)-1 / 5, result[1, 1], 0.0001, "[1,1]");
            Assert.AreEqual((double)-2 / 5, result[1, 2], 0.0001, "[1,2]");

            Assert.AreEqual((double)-1 / 5, result[2, 0], 0.0001, "[2,0]");
            Assert.AreEqual((double)-1 / 5, result[2, 1], 0.0001, "[2,1]");
            Assert.AreEqual((double)3 / 5, result[2, 2], 0.0001, "[2,2]");

        }

        /// <summary>
        /// 逆行列（４×４）
        /// </summary>
        [TestMethod]
        public void InverseMatrix_4_Test()
        {
            var matrix = new double[,]{
                { 3, 1, 1, 2},
                { 5, 1, 3, 4},
                { 2, 0, 1, 0},
                { 2, 3, 2, 1}
            };
            var result = MatrixLib.InverseMatrix(matrix);

            // 変換後の結果表示
            Assert.AreEqual((double)0.55, result[0, 0], 0.0001, "[0,0]");
            Assert.AreEqual((double)-0.25, result[0, 1], 0.0001, "[0,1]");
            Assert.AreEqual((double)0.4, result[0, 2], 0.0001, "[0,2]");
            Assert.AreEqual((double)-0.1, result[0, 3], 0.0001, "[0,3]");

            Assert.AreEqual((double)0.35, result[1, 0], 0.0001, "[1,0]");
            Assert.AreEqual((double)-0.25, result[1, 1], 0.0001, "[1,1]");
            Assert.AreEqual((double)-0.2, result[1, 2], 0.0001, "[1,2]");
            Assert.AreEqual((double)0.3, result[1, 3], 0.0001, "[1,3]");

            Assert.AreEqual((double)-1.1, result[2, 0], 0.0001, "[2,0]");
            Assert.AreEqual((double)0.5, result[2, 1], 0.0001, "[2,1]");
            Assert.AreEqual((double)0.2, result[2, 2], 0.0001, "[2,2]");
            Assert.AreEqual((double)0.2, result[2, 3], 0.0001, "[2,3]");

            Assert.AreEqual((double)0.05, result[3, 0], 0.0001, "[3,0]");
            Assert.AreEqual((double)0.25, result[3, 1], 0.0001, "[3,1]");
            Assert.AreEqual((double)-0.6, result[3, 2], 0.0001, "[3,2]");
            Assert.AreEqual((double)-0.1, result[3, 3], 0.0001, "[3,3]");
        }

        /// <summary>
        /// 連立方程式の解法（4連立方程式）
        /// </summary>
        [TestMethod]
        public void GaussElimination_4_Test()
        {
            var dimension = 4;
            var matrix = new double[,]{
                { 1.0, -2.0,  3.0, -4.0,  5.0},
                {-2.0,  5.0,  8.0, -3.0,  9.0},
                { 5.0,  4.0,  7.0,  1.0, -1.0},
                { 9.0,  7.0,  3.0,  5.0,  4.0}
            };
            var result = MatrixLib.GaussElimination(matrix, dimension);

            Assert.AreEqual(1, result[0], 0.01);
            Assert.AreEqual(3, result[1], 0.01);
            Assert.AreEqual(-2, result[2], 0.01);
            Assert.AreEqual(-4, result[3], 0.01);

        }

        /// <summary>
        /// 連立方程式の解法（2連立方程式）
        /// </summary>
        [TestMethod]
        public void GaussElimination_2_Test()
        {
            var dimension = 2;
            var matrix = new double[,]{
                { 1.0, 1.0,  5.0},
                { 2.0,  1.0,  7.0}
            };
            var result = MatrixLib.GaussElimination(matrix, dimension);

            Assert.AreEqual(2, result[0], 0.01);
            Assert.AreEqual(3, result[1], 0.01);

        }
    }
}
