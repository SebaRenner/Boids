using Boids.Core;
using Boids.Math;

using Raylib_cs;

namespace Boids.Graphics;

public class BoidWindow
{
    private List<Boid> boids = new List<Boid>();
    private Random rng = new();

    private int WindowWidth;
    private int WindowHeight;

    private const float ProximityRadius = 100.0f;

    public BoidWindow(int windowWidth, int windowHeight, int birds, int fps = 15)
    {
        WindowWidth = windowWidth;
        WindowHeight = windowHeight;

        for (int i = 0; i < birds; i++)
        {
            var position = new Vec2(rng.Next(WindowWidth), rng.Next(WindowHeight));
            var velocity = new Vec2(rng.NextDouble() * 2 - 1, rng.NextDouble() * 2 - 1);
            boids.Add(new Boid(position, velocity));
        }

        Raylib.InitWindow(WindowWidth, WindowHeight, "Boids");

        Raylib.SetTargetFPS(fps);

        while (!Raylib.WindowShouldClose())
        {
            UpdateFrame();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            DrawBoids();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private void UpdateFrame()
    {
        foreach (var boid in boids)
        {
            var neighbors = boids
                .Where(b => b != boid && boid.Position.Distance(b.Position) < ProximityRadius);

            boid.Update(neighbors);
            WrapBoid(boid);
        }
    }

    private void DrawBoids()
    {
        foreach (var boid in boids)
        {
            Raylib.DrawCircle((int)boid.Position.X, (int)boid.Position.Y, 15, Color.Black);
        }
    }

    private void WrapBoid(Boid boid)
    {
        var pos = boid.Position;

        var x = pos.X;
        var y = pos.Y;

        if (x < 0) x += WindowWidth;
        if (x >= WindowWidth) x -= WindowWidth;
        if (y < 0) y += WindowHeight;
        if (y >= WindowHeight) y -= WindowHeight;

        boid.Position = new Vec2(x, y);
    }
}