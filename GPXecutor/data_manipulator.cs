using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPXecutor
{
    class data_manipulator
    {
        public double[] trendline_filter(double[] input_data, int iterations)
        {
            double[] output = new double[input_data.Length];
            //float[] output = new float[input_data.Length];
            input_data.CopyTo(output, 0);

            if (iterations > 0)
            {
                for (int j = 0; j < iterations; j++)
                {
                    for (int k = 1; k < output.Length - 2; k++)
                    {
                        double mid_h = (output[k - 1] + output[k + 1]) / 2;
                        output[k] = mid_h;
                    }
                }
            }
            else
            {

            }

            return output;
        }
    }
}
