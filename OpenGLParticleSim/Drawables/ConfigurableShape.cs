namespace OpenGLParticleSim.Drawables;

//why is this position clamped?
public class ConfigurableShape : SimpleDrawingBase
{
    private float[] _verticies;
    
    public ConfigurableShape(float[] verticies)
    {
        _verticies = verticies;
        if (_verticies == null)
        {
            throw new Exception("The verticies for this confugrabel shae are null!");
        }
    }
    
    public override float[] GetVerticies()
    {
        return _verticies;
    }
}