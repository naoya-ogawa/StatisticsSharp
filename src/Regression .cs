using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsSharp
{
    /// <summary>
    /// 回帰分析
    /// </summary>
    public class Regression
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="y">目的変数</param>
        /// <param name="x">説明変数</param>
        public Regression(IReadOnlyList<double> y, params IReadOnlyList<double>[] x)
        {
            _y = y;
            _x = x.ToList();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="y">目的変数</param>
        /// <param name="x">説明変数</param>
        public Regression(IReadOnlyList<double> y, IReadOnlyList<IReadOnlyList<double>> x)
        {
            _y = y;
            _x = x;
        }

        /// <summary>
        /// 目的変数
        /// </summary>
        private readonly IReadOnlyList<double> _y;

        private IReadOnlyList<double> Y
        {
            get { return _y; }
        }

        /// <summary>
        /// 説明変数
        /// </summary>
        private readonly IReadOnlyList<IReadOnlyList<double>> _x;
        private IReadOnlyList<IReadOnlyList<double>> X { get { return _x; } }

        /// <summary>
        /// 係数
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<double> Coefficient()
        {
            var matrix = SimultaneousEquation_Matrix(Y, X);
            return MatrixLib.GaussElimination(matrix, _x.Count);
        }

        /// <summary>
        /// 切片
        /// </summary>
        /// <returns></returns>
        public double Intercept()
        {
            var avgY = Y.Average();
            var zip = Coefficient().Zip(X, (i, j) => { return i * j.Average(); });
            return avgY - zip.Sum();
        }

        /// <summary>
        /// 重相関係数
        /// </summary>
        /// <returns></returns>
        public double MultipleCorrelationCoefficient()
        {
            // 係数
            var coefficient = Coefficient();
            // 切片
            var intercept = Intercept();

            // 予測値を算出
            var expectancy = X[0].Select((rec, recordIndex) =>
            {
                return X.Select((x, index) => { return x[recordIndex] * coefficient[index]; })
                    .Sum() + intercept;
            }).ToList();

            // 実績値と予測値から相関係数を取得
            return ProbabilityLib.CorrelationCoefficient(Y, expectancy);
        } 

        /// <summary>
        /// 偏差積和
        /// </summary>
        /// <param name="x">データ列１</param>
        /// <param name="y">データ列２</param>
        /// <returns>偏差積和</returns>
        private static double SumProductsDeviation(
            IReadOnlyList<double> x, IReadOnlyList<double> y)
        {
            var avgX = x.Average();
            var avgY = y.Average();
            var zip = x.Zip(y, (i, j) => { return i * j; });

            return zip.Sum() - zip.Count() * avgX * avgY;
        }

        /// <summary>
        /// 連立方程式の行列を生成する
        /// 
        /// 参考：
        /// http://www.ritsumei.ac.jp/se/rv/dse/jukai/MRA.html
        /// 
        /// 最小二乗法より算出した連立方程式をガウスの消去法で解くための行列である
        /// </summary>
        /// <param name="y">目的変数</param>
        /// <param name="x">説明変数</param>
        /// <returns>係数行列</returns>
        private static double[,] SimultaneousEquation_Matrix(
            IReadOnlyList<double> y, IReadOnlyList<IReadOnlyList<double>> x)
        {
            var dimension = x.Count;
            var matrix = new double[dimension, dimension + 1];

            for (var k = 0; k < dimension; k++)
            {
                for (var i = 0; i < dimension; i++)
                {
                    matrix[k, i] = SumProductsDeviation(x[k], x[i]);
                }

                matrix[k, dimension] = SumProductsDeviation(x[k], y);
            }

            return matrix;
        }
    }
}
