namespace Excercise.Services
{
    public class Accumulator : IAccumulator
    {
        public double Add(double input, double change)
        {
            return input + change;
        }
    }
}
