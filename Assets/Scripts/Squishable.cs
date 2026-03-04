using UnityEngine;

public class Squishable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ParticleSystem squishParticles;
    public GameObject puddle;
    public GameObject thing;

    private void OnTriggerEnter(Collider other)
    {
        Foot foot = other.gameObject.GetComponent<Foot>();
        if (foot != null)
        {
            Destroy(thing);
            squishParticles.Play();
            puddle.GetComponent<puddleGrow>().StartTimer();
        }
    }
}

