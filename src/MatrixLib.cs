using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsSharp
{
    public class MatrixLib
    {
        /// <summary>
        /// 逆行列に変換
        /// </summary>
        /// <param name="input">入力</param>
        /// <returns>変換結果</returns>
        public static double[,] InverseMatrix(double[,] input)
        {
            var matrix = (double[,])input.Clone();

            var dimension = matrix.GetLength(0);
            var len = matrix.Length / dimension;
            var result = new double[dimension, len];
            for (var i = 0; i < dimension; i++)
            {
                result[i, i] = 1;
            }

            // 前進消去
            for (var k = 0; k < dimension; k++)
            {
                var tmp = matrix[k, k];
                for (var j = 0; j < dimension; j++)
                {
                    matrix[k, j] /= tmp;
                    result[k, j] /= tmp;
                }
                matrix[k, k] = 1;
                for (var i = k + 1; i < dimension; i++)
                {
                    var buf = matrix[i, k];
                    for (var j = 0; j < dimension; j++)
                    {
                        matrix[i, j] -= buf * matrix[k, j];
                        result[i, j] -= buf * result[k, j];
                    }
                    matrix[i, k] = 0;
                }
            }

            for (var k = dimension-1; 0 < k; k--)
            {
                for (var i = 0; i < dimension; i++)
                {
                    if (i == k) continue;
                    var buf = matrix[i, k];

                    for (var j = 0; j < dimension; j++)
                    {
                        matrix[i, j] -= buf * matrix[k, j];
                        result[i, j] -= buf * result[k, j];
                    }
                    matrix[i, k] = 0;
                }
            }
            
            return result;
        }

        /// <summary>
        /// ガウスの消去法（連立方程式の解法）
        /// </summary>
        /// <param name="input">係数（行列）</param>
        /// <param name="dimension">解の数</param>
        /// <returns>解</returns>
        public static List<Double> GaussElimination(Double[,] input, int dimension)
        {
            var matrix = (double[,])input.Clone();

            //// 並び替え
            //var matrix = SortDesc(input);

            // 前進消去
            for (var k = 0; k < dimension; k++)
            {
                var l_p = matrix[k, k];
                matrix[k, k] = 1;

                for (var j = k + 1; j < dimension + 1; j++)
                {
                    matrix[k, j] /= l_p;
                }

                for (var i = k + 1; i < dimension; i++)
                {
                    var l_q = matrix[i, k];

                    for (var j = k + 1; j < dimension + 1; j++)
                    {
                        matrix[i, j] -= l_q * matrix[k, j];
                    }

                    matrix[i, k] = 0;
                }
            }

            // 解の配列　初期化
            var result = Enumerable.Repeat((double)0, dimension).ToList();

            // 後退代入
            for (var i = dimension - 1; 0 <= i; i--)
            {
                result[i] = matrix[i, dimension];
                for (var j = dimension - 1; i < j; j--)
                {
                    result[i] -= matrix[i, j] * result[j];
                }
            }

            return result;
        }
    }
}
