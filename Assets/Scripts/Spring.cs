
[System.Serializable]

public class Spring
{
    public float dampening = 0.1f;
    public float tension = 0.05f;
    public float baseHeight; //get; private set;?
    public float velocity; // get; private set;?
    public float currentHeight; // get; private set;?

    public void ApplyAdditiveForce(float force)
    {
        velocity += force;
    }

    public void ApplyForceStartingAtPosition(float force, float position)
    {
        currentHeight = position;
        velocity = force;
    }

    public float Simulate()
    {
        float heightOffset = baseHeight - currentHeight;
        velocity += tension * heightOffset - velocity * dampening;
        currentHeight += velocity;

        return currentHeight;
    }
}