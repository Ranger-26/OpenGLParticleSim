using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;

namespace OpenGLParticleSim.Drawables;

public class SimpleTriangle : SimpleDrawingBase
{
    public override float[] GetVerticies()
    {
        return new float[]{
            -0.5f, -0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            0.0f,  0.5f, 0.0f
        };  
    }
}