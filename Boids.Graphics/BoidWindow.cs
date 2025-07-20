using Boids.Core;
using Boids.Math;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Boids.Graphics
{
    public class BoidWindow : GameWindow
    {
        private List<Boid> boids;
        private Random rng = new();

        private const int WindowWidth = 800;
        private const int WindowHeight = 600;

        public BoidWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            boids = new List<Boid>();
            for (int i = 0; i < 3; i++)
            {
                var position = new Vec2(rng.Next(WindowWidth), rng.Next(WindowHeight));
                var velocity = new Vec2(rng.NextDouble() * 2 - 1, rng.NextDouble() * 2 - 1);
                boids.Add(new Boid(position, velocity));
            }
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0f, 0f, 0f, 1f);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            foreach (var boid in boids)
            {
                var neighbors = boids.Where(b => b != boid);
                boid.Update(neighbors);
            }
        }
    }
}
