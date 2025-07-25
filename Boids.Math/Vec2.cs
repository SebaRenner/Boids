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

        public static Vec2 operator +(Vec2 a, Vec2 b) => new Vec2(a.X + b.X, a.Y + b.Y);

        public static Vec2 operator -(Vec2 a, Vec2 b) => new Vec2(a.X - b.X, a.Y - b.Y);

        public static Vec2 operator /(Vec2 v, double scalar) => new Vec2(v.X / scalar, v.Y / scalar);

        public static Vec2 operator *(Vec2 v, double scalar) => new Vec2(v.X * scalar, v.Y * scalar);

        public double Distance(Vec2 other) 
        { 
            var dx = X - other.X;
            var dy = Y - other.Y;

            return System.Math.Sqrt(dx * dx + dy * dy);
        }

        public double Length()
        {
            return System.Math.Sqrt(X * X + Y * Y);
        }

        public Vec2 Normalized()
        {
            double length = Length();
            if (length == 0)
                return new Vec2(0, 0);

            return this / length;
        }

    }
}
