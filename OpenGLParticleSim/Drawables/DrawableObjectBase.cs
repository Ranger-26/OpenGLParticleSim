using OpenTK.Mathematics;

namespace OpenGLParticleSim.Drawables;

public abstract class DrawableObjectBase
{
    public static List<DrawableObjectBase> allObjects { get; private set; } = new();
    
    public Vector3 Position { get; protected set; }

    public Vector3 Rotation { get; protected set; }
    
    public Vector3 Scale { get; protected set; } = Vector3.One;

    public bool IsInitialized;
    
    protected DrawableObjectBase()
    {
        allObjects.Add(this);
    }
    
    /// <summary>
    /// Perform the draw call for this mesh.
    /// </summary>
    public abstract void DrawCall();
    
    /// <summary>
    /// Sets the position of the object.
    /// </summary>
    /// <param name="newPosition">The new position of the object.</param>
    public abstract void SetPosition(Vector3 newPosition);

    /// <summary>
    /// Sets the rotation of the object.
    /// </summary>
    /// <param name="newRotation">The new rotation of the object.</param>
    public abstract void SetRotation(Vector3 newRotation);

    /// <summary>
    /// Sets the scale of the object.
    /// </summary>
    /// <param name="newScale">The new scale of the object.</param>
    public abstract void SetScale(Vector3 newScale);

    /// <summary>
    /// Called once before the rendering starts.
    /// </summary>
    public virtual void Initialize()
    {
        if (IsInitialized) return;
        IsInitialized = true;
        Console.WriteLine("Initalizing....");   
    }

    public void Render()
    {
        if (!IsInitialized)
        {
            Initialize();
        }
        DrawCall();
    }
}