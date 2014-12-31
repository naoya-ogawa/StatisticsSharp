using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsSharp
{
    /// <summary>
    /// 確率関連ライブラリ
    /// </summary>
    public static class ProbabilityLib
    {
        /// <summary>
        /// 分散
        /// </summary>
        /// <param name="val">データ列</param>
        /// <returns>分散</returns>
        public static double Variance(this IReadOnlyList<double> x)
        {
            var avg = x.Average();

            var square = x.Select((i) => { return (i - avg) * (i - avg); });
            return square.Average();
        }

        /// <summary>
        /// 共分散
        /// </summary>
        /// <param name="x">データ列１</param>
        /// <param name="y">データ列２</param>
        /// <returns>共分散</returns>
        public static double Covariance(IReadOnlyList<double> x, IReadOnlyList<double> y)
        {
            var avgX = x.Average();
            var avgY = y.Average();

            var products = x.Zip(y, (i, j) => { return (i - avgX) * (j - avgY); });
            return products.Average();
        }

        /// <summary>
        /// 標準偏差
        /// </summary>
        /// <param name="x">データ列</param>
        /// <returns>標準偏差</returns>
        public static double StandardDeviation(this IReadOnlyList<double> x)
        {
            return Math.Sqrt(x.Variance());
        }

        /// <summary>
        /// 相関係数
        /// </summary>
        /// <param name="x">データ列１</param>
        /// <param name="y">データ列２</param>
        /// <returns>相関係数</returns>
        public static double CorrelationCoefficient(IReadOnlyList<double> x, IReadOnlyList<double> y)
        {
            return Covariance(x, y) / (x.StandardDeviation() * y.StandardDeviation());
        }

    }
}
