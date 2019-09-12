using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cpk_test
{
    public static class Calculations
    {
        public static double Mean(this List<double> values)
        {
            return values.Count == 0 ? 0 : values.Mean(0, values.Count);
        }

        public static double Mean(this List<double> values, int start, int end)
        {
            double s = 0;

            for (int i = start; i < end; i++)
            {
                s += values[i];
            }

            return s / (end - start);
        }

        public static double Variance(this List<double> values)
        {
            return values.Variance(values.Mean(), 0, values.Count);
        }

        public static double Variance(this List<double> values, double mean)
        {
            return values.Variance(mean, 0, values.Count);
        }

        public static double Variance(this List<double> values, double mean, int start, int end)
        {
            double variance = 0;

            for (int i = start; i < end; i++)
            {
                variance += Math.Pow((values[i] - mean), 2);
            }

            int n = end - start;
            //if (start > 0) n -= 1;

            return variance / (n - 1);
        }

        public static double StandardDeviation(this List<double> values)
        {
            return values.Count == 0 ? 0 : values.StandardDeviation(0, values.Count);
        }

        public static double StandardDeviation(this List<double> values, int start, int end)
        {
            double mean = values.Mean(start, end);
            double variance = values.Variance(mean, start, end);

            return Math.Sqrt(variance);
        }

        public static double CpkPullTest(this List<double> values)
        {
            return values.Count == 0 ? 0 : values.CpkPullTest(0, values.Count);
        }

        public static double CpkPullTest(this List<double> values, int start, int end)
        {
            int minPullSpec = 250;
            double mean = values.Mean(start, end);
            double sd = values.StandardDeviation(start, end);

            return (mean - minPullSpec) / (3 * sd);

        }
    }
}
