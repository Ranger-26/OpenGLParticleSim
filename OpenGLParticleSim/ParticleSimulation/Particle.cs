using OpenTK.Mathematics;

namespace OpenGLParticleSim.ParticleSimulation;

public class Particle
{
    public ParticleData ParticleData;

    public Vector3 Velocity;

    public Vector3 NetForce;

    public Vector3 Position;

    public void OnUpdateFrame(float deltaTime)
    {
        
    }
}