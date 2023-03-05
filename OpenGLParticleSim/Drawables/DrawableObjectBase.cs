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
    /// Called when the position of the object is set.
    /// </summary>
    /// <param name="newPosition">The new position of the object.</param>
    public virtual void OnSetPosition(Vector3 newPosition)
    {
        
    }

    /// <summary>
    /// Called when the rotation of the object is set..
    /// </summary>
    /// <param name="newRotation">The new rotation of the object.</param>
    public virtual void OnSetRotation(Vector3 newRotation)
    {
        
    }

    /// <summary>
    /// Called when the scale of the object is set.
    /// </summary>
    /// <param name="newScale">The new scale of the object.</param>
    public virtual void OnSetScale(Vector3 newScale)
    {
        
    }

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
    
    protected Matrix4 GetTranslationMatrix()
    {
        return Matrix4.CreateScale(Scale) * Matrix4.CreateTranslation(Position);
    }
    
    public void SetPosition(Vector3 newPosition)
    {
        Position = newPosition;
        OnSetPosition(newPosition);
    }

    public void SetRotation(Vector3 newRotation)
    {
        throw new NotImplementedException();
    }

    public  void SetScale(Vector3 newScale)
    {
        Scale = newScale;
        OnSetScale(newScale);
    }
}