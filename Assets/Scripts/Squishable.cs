using UnityEngine;

public class Squishable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ParticleSystem squishParticles;
    public GameObject puddle;
    public GameObject thing;
    public Color color;
    public GameObject spawn;
    bool squished = false;
    public bool gnome = false;

    private void Start()
    {
        color = new Color(color.r + Random.Range(-0.2f, 0.2f), color.g + Random.Range(-0.2f, 0.2f), color.b + Random.Range(-0.2f, 0.2f));
        var particleMaterial = squishParticles.main;
        particleMaterial.startColor = color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (squished) return;

        Foot foot = other.gameObject.GetComponent<Foot>();
        if (foot != null)
        {
            Destroy(thing);
            if (puddle != null)
            {
                squishParticles.Play();
                puddle.GetComponent<puddleGrow>().StartTimer();
                puddle.GetComponent<puddleGrow>().setColor(color);
                foot.setSplatColor(color);
            }
            if (spawn != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    GameObject child = Instantiate(spawn);
                    child.transform.position = transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                }
            }
            if (gnome)
            {
                GetComponentInParent<followPlayer>().stop = true;
                transform.parent.gameObject.transform.rotation = Quaternion.identity;
            }
            squished = true;
        }
    }
}

