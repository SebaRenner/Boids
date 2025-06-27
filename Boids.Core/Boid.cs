using Boids.Math;

namespace Boids.Core
{
    public class Boid
    {
        public Vec2 Position { get; set; }

        public Vec2 Velocity { get; set; }

        public Vec2 Separation(IEnumerable<Boid> neighbors)
        {
            var steering = new Vec2(0, 0);

            foreach (var neighbor in neighbors)
            {
                var distance = Position.Distance(neighbor.Position);
                var diff = Position.Subtract(neighbor.Position);

                steering = new Vec2(
                    steering.X + diff.Divide(distance * distance).X,
                    steering.Y + diff.Divide(distance * distance).Y);
            }

            return steering;
        }
    }
}
