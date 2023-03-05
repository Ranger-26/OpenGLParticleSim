using OpenGLParticleSim.Drawables;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenGLParticleSim;

public class MainGameWindow : GameWindow
{
    private DrawableObjectBase _triangle;
    
    public MainGameWindow(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
    {
        
    }

    protected override void OnLoad()
    {
        base.OnLoad();
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        _triangle = new Rectangle();
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit);

        for (int i = 0; i < DrawableObjectBase.allObjects.Count; i++)
        {
            DrawableObjectBase.allObjects[i].Render();
        }
        
        SwapBuffers();
    }
    
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        var input = KeyboardState;

        if (input.IsKeyPressed(Keys.Escape))
        {
            Close();
        }

        if (input.IsKeyDown(Keys.Up))
        {
            _triangle.SetPosition(new Vector3(_triangle.Position.X,(float) (_triangle.Position.Y+0.1f*e.Time),_triangle.Position.Z));
        }
        if (input.IsKeyDown(Keys.Down))
        {
            _triangle.SetPosition(new Vector3(_triangle.Position.X,(float) (_triangle.Position.Y-0.1f*e.Time),_triangle.Position.Z));
        }
        
        if (input.IsKeyDown(Keys.Left))
        {
            _triangle.SetPosition(new Vector3((float) (_triangle.Position.X-0.1f*e.Time), _triangle.Position.Y,_triangle.Position.Z));
        }
        if (input.IsKeyDown(Keys.Right))
        {
            _triangle.SetPosition(new Vector3((float) (_triangle.Position.X+0.1f*e.Time),(float) (_triangle.Position.Y-0.1f*e.Time),_triangle.Position.Z));
        }
        
        
        if (input.IsKeyPressed(Keys.Space))
        {
            _triangle.SetScale(_triangle.Scale * 2);
        }
        
        if (input.IsKeyPressed(Keys.M))
        {
            _triangle.SetScale(_triangle.Scale / 2);
        }

        if (input.IsKeyPressed(Keys.A))
        {
            Console.WriteLine($"{_triangle.Position}, {_triangle.Rotation}, {_triangle.Scale}");
        }
    }
    
    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);

        GL.Viewport(0, 0, Size.X, Size.Y);
    }
}