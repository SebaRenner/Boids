using Boids.Math;

namespace Boids.Core
{
    public class Boid
    {
        public Boid(Vec2 position, Vec2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

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
            var steering = new Vec2();

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
            var avgVelocity = sumVelocity / neighbors.Count();
            return avgVelocity - Velocity;
        }

        private Vec2 Cohesion(IEnumerable<Boid> neighbors)
        {
            var sumPosition = neighbors.Select(n => n.Position).Sum();
            var avgPosition = sumPosition / neighbors.Count();
            return avgPosition - Position;
        }
    }
}
