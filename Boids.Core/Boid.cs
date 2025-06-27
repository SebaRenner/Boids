using Boids.Math;

namespace Boids.Core
{
    public class Boid
    {
        public Vec2 Position { get; set; }

        public Vec2 Velocity { get; set; }

        public void Update(IEnumerable<Boid> neighbors)
        {
            var separation = Separation(neighbors);
            var alignment = Alignment(neighbors);
            var cohesion = Cohesion(neighbors);

            var acceleration = separation + alignment + cohesion;

            Velocity += acceleration;
            Position += Velocity;
        }

        private Vec2 Separation(IEnumerable<Boid> neighbors)
        {
            var steering = new Vec2(0, 0);

            foreach (var neighbor in neighbors)
            {
                var distance = Position.Distance(neighbor.Position);
                var diff = Position - neighbor.Position;

                steering += diff / (distance * distance);
            }

            return steering;
        }

        private Vec2 Alignment(IEnumerable<Boid> neighbors)
        {
            var sumVelocity = neighbors.Select(n => n.Velocity).Sum();
            return sumVelocity / neighbors.Count() - Velocity;
        }

        private Vec2 Cohesion(IEnumerable<Boid> neighbors) => throw new NotImplementedException();
    }
}
