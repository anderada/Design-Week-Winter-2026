using UnityEngine;

public class Squishable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ParticleSystem squishParticles;

    private void OnTriggerEnter(Collider other)
    {
        Foot foot = other.gameObject.GetComponent<Foot>();
        if (foot != null)
        {
            Destroy(this.gameObject);
            squishParticles.Play();
        }
    }
}

