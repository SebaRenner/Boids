namespace Boids.Math
{
    public static class Vec2Extensions
    {
        public static Vec2 Sum(this IEnumerable<Vec2> vectors)
        {
            var sum = new Vec2(0, 0);
            foreach (var v in vectors)
            {
                sum += v;
            }
            return sum;
        }
    }
}
