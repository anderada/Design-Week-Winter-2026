using UnityEngine;

public class Squishable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ParticleSystem squishParticles;
    public GameObject puddle;
    public GameObject thing;
    public Color color;

    bool squished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (squished) return;
        Foot foot = other.gameObject.GetComponent<Foot>();
        if (foot != null)
        {
            Destroy(thing);
            squishParticles.Play();
            puddle.GetComponent<puddleGrow>().StartTimer();
            puddle.GetComponent<puddleGrow>().setColor(color);
            foot.setSplatColor(color);
            squished = true;
        }
    }
}

