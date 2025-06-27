namespace Boids.Math
{
    public struct Vec2
    {
        public Vec2(double x, double y)
        {
            X = x; 
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public Vec2 Subtract(Vec2 other)
        {
            return new Vec2(X - other.X, Y - other.Y);
        }

        public Vec2 Divide(double scalar)
        {
            return new Vec2(X / scalar, Y / scalar);
        }

        public double Distance(Vec2 other) 
        { 
            var dx = X - other.X;
            var dy = Y - other.Y;

            return System.Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
