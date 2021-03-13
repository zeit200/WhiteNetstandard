namespace TestStack.White.SystemExtensions
{
    public static class DoubleX
    {
        public static bool IsInvalid(this double @double)
        {
            return @double == double.PositiveInfinity || @double == double.NegativeInfinity || double.IsNaN(@double);
        }

        public static bool IsInvalid(this int @int)
        {
            return @int == int.MaxValue || @int == int.MinValue;
        }
    }
}