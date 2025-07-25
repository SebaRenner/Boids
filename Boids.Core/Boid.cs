using Boids.Math;

namespace Boids.Core;

public class Boid
{
    private const float MaxSpeed = 4.0f;
    private const float MaxForce = 0.5f;

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

        // consider wandering if acceleration is Vec(0,0) -> has no neighbors
        var acceleration = separation + alignment + cohesion;
        acceleration = Limit(acceleration, MaxForce);
       
        Velocity += acceleration;
        Velocity = Limit(Velocity, MaxSpeed);
        Position += Velocity;
    }

    private Vec2 Separation(IEnumerable<Boid> neighbors)
    {
        var steering = new Vec2();

        foreach (var neighbor in neighbors)
        {
            var distance = Position.Distance(neighbor.Position);

            if (distance == 0)
                continue;

            var diff = Position - neighbor.Position;

            steering += diff / (distance * distance);
        }

        return steering;
    }

    private Vec2 Alignment(IEnumerable<Boid> neighbors)
    {
        var count = neighbors.Count();
        if (count == 0) return new Vec2();

        var sumVelocity = neighbors.Select(n => n.Velocity).Sum();
        var avgVelocity = sumVelocity / count;

        return avgVelocity - Velocity;
    }

    private Vec2 Cohesion(IEnumerable<Boid> neighbors)
    {
        int count = neighbors.Count();
        if (count == 0) return new Vec2();

        var sumPosition = neighbors.Select(n => n.Position).Sum();
        var avgPosition = sumPosition / count;

        return avgPosition - Position;
    }

    private Vec2 Limit(Vec2 vector, float max)
    {
        // length is costly since sqrt, think about solution with lengthSquared
        if (vector.Length() > max)
        {
            return vector.Normalized() * max;
        }

        return vector;
    }
}
