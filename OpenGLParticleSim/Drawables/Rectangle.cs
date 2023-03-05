using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace OpenGLParticleSim.Drawables;

public class Rectangle : DrawableObjectBase
{
    private int VAO;
    private int VBO;
    private int EBO;

    private Shader _shader;
    
    private readonly float[] _vertices =
    {
        0.5f,  0.5f, 0.0f, // top right
        0.5f, -0.5f, 0.0f, // bottom right
        -0.5f, -0.5f, 0.0f, // bottom left
        -0.5f,  0.5f, 0.0f, // top left
    };

    // Then, we create a new array: indices.
    // This array controls how the EBO will use those vertices to create triangles
    private readonly uint[] _indices =
    {
        // Note that indices start at 0!
        0, 1, 3, // The first triangle will be the top-right half of the triangle
        1, 2, 3  // Then the second will be the bottom-left half of the triangle
    };

    public override void Initialize()
    {
        base.Initialize();
        //create and bind vertex array
        VAO = GL.GenVertexArray();
        GL.BindVertexArray(VAO);
        
        //create a vertex buffer object and bind it
        VBO = GL.GenBuffer();
        
        //ebo stuff
        EBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, EBO);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
        
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
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}