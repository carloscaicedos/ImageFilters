
namespace ImageFilters
{
    public abstract class ConvolutionFilterBase
    {
        public abstract string FilterName { get; set; }

        public abstract double Factor { get; }

        public abstract double Bias { get; }

        public abstract double[,] FilterMatrix { get; set; }
    }
}
