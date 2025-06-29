using Boids.Graphics;

using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

var gws = GameWindowSettings.Default;
var nws = new NativeWindowSettings()
{
    ClientSize = new Vector2i(800, 600),
    Title = "Boid Simulation"
};

using var window = new BoidWindow(gws, nws);
window.Run();

