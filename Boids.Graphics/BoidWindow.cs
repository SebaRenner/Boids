using Boids.Core;
using Boids.Math;

namespace Boids.Graphics;

public class BoidWindow
{
    private List<Boid> boids;
    private Random rng = new();

    private const int WindowWidth = 800;
    private const int WindowHeight = 600;

    public BoidWindow()
    {
        boids = new List<Boid>();
        for (int i = 0; i < 3; i++)
        {
            var position = new Vec2(rng.Next(WindowWidth), rng.Next(WindowHeight));
            var velocity = new Vec2(rng.NextDouble() * 2 - 1, rng.NextDouble() * 2 - 1);
            boids.Add(new Boid(position, velocity));
        }
    }

    public void UpdateFrame()
    {
        foreach (var boid in boids)
        {
            var neighbors = boids.Where(b => b != boid);
            boid.Update(neighbors);
        }
    }
}