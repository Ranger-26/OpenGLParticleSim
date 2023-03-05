using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace OpenGLParticleSim.Drawables;

public abstract class SimpleDrawingBase : DrawableObjectBase
{
    private Shader _shader;

    private int VBO, VAO;

    private float[] _vertices;
    

    private Matrix4 GetTranslationMatrix()
    {
        return Matrix4.CreateScale(Scale) * Matrix4.CreateTranslation(Position);
    }

    public override void Initialize()
    {
        base.Initialize();
        _vertices = GetVerticies();
        
        //create and bind vertex array
        VAO = GL.GenVertexArray();
        GL.BindVertexArray(VAO);
        
        //create a vertex buffer object and bind it
        VBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer,VBO);
        //buffer the vertex data
        GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
        //create the shader
        _shader = new Shader(
            @"C:\Users\siddh\Desktop\my stuff\My projects\C#\ConsoleApps\OpenGLParticleSim\OpenGLParticleSim\Shaders\Simple\SimpleShader.vert",
            @"C:\Users\siddh\Desktop\my stuff\My projects\C#\ConsoleApps\OpenGLParticleSim\OpenGLParticleSim\Shaders\Simple\SimpleShader.frag");
        _shader.Use();
        
        //link vertex attributes in shader to data
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);
    }

    public override void DrawCall()
    {
        _shader.Use();
        _shader.SetMatrix4("transform", GetTranslationMatrix());
        GL.BindVertexArray(VAO);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
    }

    public override void SetPosition(Vector3 newPosition)
    {
        Position = newPosition;
    }

    public override void SetRotation(Vector3 newRotation)
    {
        //Todo
        throw new NotImplementedException();
    }

    public override void SetScale(Vector3 newScale)
    {
        Scale = newScale;
    }

    public abstract float[] GetVerticies();
        
}