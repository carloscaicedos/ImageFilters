using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilters
{
    public class GenericFilter : ConvolutionFilterBase
    {
        private string filterName = "Generic Filter";
        public override string FilterName
        {
            get { return filterName; }
            set { filterName = value; }
        }

        private double factor = 1.0;
        public override double Factor
        {
            get { return factor; }
        }

        private double bias = 0.0;
        public override double Bias
        {
            get { return bias; }
        }

        private double[,] filterMatrix = new double[,] { { 0.0, 0.2, 0.0 }, 
                                                         { 0.2, 0.2, 0.2 },
                                                         { 0.0, 0.2, 0.2 }};

        public override double[,] FilterMatrix
        {
            get { return filterMatrix; }
            set { filterMatrix = value; }
        }
    }
}
